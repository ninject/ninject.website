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
using System.IO;
using System.Web.Mvc;
#endregion

namespace Ninject.Website.Framework.Extensions
{
	public static class ExtensionsForHtmlHelper
	{
		public static string Stylesheet(this HtmlHelper helper, string path)
		{
			return String.Format("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\"/>", GetCacheBustedPath(helper, path));
		}

		public static string Script(this HtmlHelper helper, string path)
		{
			return String.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", GetCacheBustedPath(helper, path));
		}

		private static string GetCacheBustedPath(HtmlHelper helper, string virtualPath)
		{
			var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
			string actualPath = urlHelper.RequestContext.HttpContext.Server.MapPath(virtualPath);

			if (!File.Exists(actualPath))
				throw new FileNotFoundException(String.Format("Couldn't find file: {0}", actualPath), actualPath);

			DateTime timestamp = File.GetLastWriteTimeUtc(actualPath);

			return urlHelper.Content(virtualPath) + "?t=" + timestamp.ToString("yyyyMMddhhmmss");
		}
	}
}