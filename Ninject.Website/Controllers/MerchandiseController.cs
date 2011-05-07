#region License
//
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2007-2010, Enkari, Ltd.
//
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
//
#endregion
#region Using Directives
using System.Web.Mvc;
#endregion

namespace Ninject.Website.Controllers
{
    using System.Linq;
    using Ninject.Website.Models;

    public class MerchandiseController : Controller
    {
        private readonly IRepository repository;
        public MerchandiseController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Show()
        {
            return View(repository.GetProducts().GroupBy(p => p.Category));
        }
    }
}