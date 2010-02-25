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
using System.Net;
using System.Web;
#endregion

namespace Ninject.Website.Framework
{
	public static class HttpExceptionFactory
	{
		public static HttpException NotFound()
		{
			return new HttpException((int)HttpStatusCode.NotFound, "Resource not found");
		}

		public static HttpException BadRequest()
		{
			return new HttpException((int)HttpStatusCode.BadRequest, "Malformed request");
		}

		public static HttpException Forbidden()
		{
			return new HttpException((int)HttpStatusCode.Forbidden, "Forbidden");
		}

		public static HttpException Disabled()
		{
			return new HttpException((int)HttpStatusCode.PaymentRequired, "Disabled");
		}
	}
}