#region License
// 
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 
#endregion
#region Using Directives
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Linq;
using Ninject.Website.Framework.Extensions;
#endregion

namespace Ninject.Website.Framework
{
	public class RouteParser
	{
		public HttpContextBase HttpContext { get; private set; }
		public RouteCollection Routes { get; private set; }

		public RouteParser(HttpContextBase httpContext, RouteCollection routes)
		{
			HttpContext = httpContext;
			Routes = routes;
		}

		public void ReadRouteFile()
		{
			string filename = HttpContext.Server.MapPath("~/routes.config");

			var document = XDocument.Load(filename);
			var routes = document.Element("routes");

			if (routes == null)
				throw new ConfigurationErrorsException("Missing required <routes> element");

			foreach (XElement area in routes.Elements())
			{
				foreach (XElement controller in area.Elements())
				{
					foreach (XElement route in controller.Elements("route"))
						RegisterRoute(area.Name.LocalName, controller.Name.LocalName, route);
				}
			}
		}

		private void RegisterRoute(string area, string controller, XElement route)
		{
			XAttribute action = route.RequiredAttribute("action");
			XAttribute pattern = route.RequiredAttribute("pattern");
			XAttribute verbs = route.Attribute("verbs");

			var defaults = new RouteValueDictionary();
			var constraints = new RouteValueDictionary();

			defaults["area"] = area;
			defaults["controller"] = controller;
			defaults["action"] = action.Value;

			if (verbs != null && !String.IsNullOrEmpty(verbs.Value) && !verbs.Value.Equals("*"))
			{
				string[] tokens = verbs.Value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				constraints["httpMethod"] = new HttpMethodConstraint(tokens.Select(m => m.ToUpperInvariant()).ToArray());
			}

			string routeName = controller + "." + action.Value;
			Routes.Add(routeName, new Route(pattern.Value, defaults, constraints, new MvcRouteHandler()));
		}
	}
}