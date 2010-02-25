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
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Spark.Web.Mvc;
#endregion

namespace Ninject.Website.Framework
{
	public class Bootstrapper
	{
		public HttpContextBase HttpContext { get; private set; }
		public RouteCollection Routes { get; private set; }
		public RouteParser RouteParser { get; private set; }
		public JavascriptRouteGenerator JsRouteGenerator { get; private set; }

		public Bootstrapper(HttpContextBase httpContext, RouteCollection routes, RouteParser routeParser,
			JavascriptRouteGenerator jsRouteGenerator)
		{
			HttpContext = httpContext;
			Routes = routes;
			RouteParser = routeParser;
			JsRouteGenerator = jsRouteGenerator;
		}

		public void RegisterRoutes()
		{
			Routes.RouteExistingFiles = false;

			Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			Routes.IgnoreRoute("errors/{*pathInfo}");

			RouteParser.ReadRouteFile();

			Routes.MapRoute("notfound", "{*url}", new { area = "public", controller = "error", action = "shownotfound" });
		}

		public void GenerateJavascriptForRouting()
		{
			string basePath = VirtualPathUtility.ToAbsolute("~/");
			string filename = HttpContext.Server.MapPath("~/content/js/routes.js");
			JsRouteGenerator.Write(basePath, filename);
		}

		public void SetUpViewEngine()
		{
			ViewEngines.Engines.Clear();
			SparkEngineStarter.RegisterViewEngine();
		}
	}
}