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
using Elmah;
#endregion

namespace Ninject.Website.Framework.Filters
{
	public class HandleExceptionsAttribute : FilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext filterContext)
		{
			if (filterContext.Exception == null || filterContext.ExceptionHandled)
				return;
			
			var httpException = filterContext.Exception as HttpException;
			int statusCode = httpException == null ? 500 : httpException.GetHttpCode();

			var result = new ViewResult { ViewName = "error" + statusCode };
			result.ViewData["exception"] = filterContext.Exception;

			filterContext.Result = result;
			filterContext.ExceptionHandled = true;
			filterContext.HttpContext.Response.Clear();
			filterContext.HttpContext.Response.StatusCode = statusCode;

			if (statusCode >= 500)
				ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
		}
	}
}