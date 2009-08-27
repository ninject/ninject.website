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
using System.Web.UI;
#endregion

namespace Ninject.Website
{
	public partial class _Default : Page
	{
		public void Page_Load(object sender, System.EventArgs e)
		{
			HttpContext.Current.RewritePath(Request.ApplicationPath);
			IHttpHandler httpHandler = new MvcHttpHandler();
			httpHandler.ProcessRequest(HttpContext.Current);
		}
	}
}