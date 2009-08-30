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
using Spark.Web.Mvc;
#endregion

namespace Ninject.Website.Framework
{
	public abstract class NinjectViewBase : SparkView
	{
		public string CurrentUrl
		{
			get { return Context.Request.Path; }
		}

		public string CurrentController
		{
			get { return ViewContext.RouteData.GetRequiredString("controller"); }
		}

		public string CurrentAction
		{
			get { return ViewContext.RouteData.GetRequiredString("action"); }
		}
	}
}