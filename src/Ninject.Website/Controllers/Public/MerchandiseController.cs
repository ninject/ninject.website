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
using System.Linq;
using System.Web.Mvc;
using Ninject.Website.Data;
using Ninject.Website.Framework;
using Ninject.Website.Services.Persistence;
#endregion

namespace Ninject.Website.Controllers.Public
{
	public class MerchandiseController : NinjectControllerBase
	{
		public IRepository<Product> ProductRepository { get; private set; }

		public MerchandiseController(IRepository<Product> productRepository)
		{
			ProductRepository = productRepository;
		}

		public ViewResult Show()
		{
			ViewData["categories"] = ProductRepository.GetAll().OrderBy(product => product.Name).GroupBy(product => product.Category);
			return View();
		}
	}
}