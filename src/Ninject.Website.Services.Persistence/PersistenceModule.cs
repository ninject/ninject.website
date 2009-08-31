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
using Ninject.Modules;
using Ninject.Website.Data;
#endregion

namespace Ninject.Website.Services.Persistence
{
	public class PersistenceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<XmlLoader>().ToSelf().InSingletonScope();
			Bind<IRepository<Extension>>().To<XmlExtensionRepository>().InSingletonScope();
			Bind<IRepository<Product>>().To<XmlProductRepository>().InSingletonScope();
		}
	}
}