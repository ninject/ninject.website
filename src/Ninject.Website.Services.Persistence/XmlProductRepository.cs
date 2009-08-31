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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Ninject.Website.Data;
using Ninject.Website.Data.Collections;
#endregion

namespace Ninject.Website.Services.Persistence
{
	public class XmlProductRepository : IRepository<Product>
	{
		private const string Filename = "~/data/products.xml";
		private readonly ProductCollection _items;

		public XmlProductRepository(HttpContextBase httpContext, XmlLoader loader)
		{
			string path = httpContext.Server.MapPath(Filename);
			_items = loader.Load<ProductCollection>(path);
		}

		public IQueryable<Product> GetAll()
		{
			return _items.AsQueryable();
		}
	}
}