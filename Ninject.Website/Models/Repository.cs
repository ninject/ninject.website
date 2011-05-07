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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
#endregion

namespace Ninject.Website.Models
{
    public class Repository : IRepository
    {
        private readonly HttpContextBase context;
        private readonly Lazy<IEnumerable<Product>> products;

        public Repository(HttpContextBase context)
        {
            this.context = context;
            this.products = new Lazy<IEnumerable<Product>>(this.LoadProducts);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products.Value;
        }

        private IEnumerable<Product> LoadProducts()
        {
            var doc = XDocument.Load(context.Server.MapPath("~/App_Data/products.xml"));
            return from productElement in doc.Root.Elements("product")
                   select new Product
                   {
                       Category = (string)productElement.Element("category"),
                       Id = (string)productElement.Element("id"),
                       Image = (string)productElement.Element("image"),
                       Name = (string)productElement.Element("name"),
                   };
        }
    }
}