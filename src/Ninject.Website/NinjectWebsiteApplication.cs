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
using CommonServiceLocator.NinjectAdapter;
using Microsoft.Practices.ServiceLocation;
using Ninject.Web.Mvc;
using Ninject.Website.Framework;
using Spark.Web.Mvc;
#endregion

namespace Ninject.Website
{
	public class NinjectWebsiteApplication : NinjectHttpApplication
	{
		protected override void OnApplicationStarted()
		{
			RegisterAllControllersIn("Ninject.Website");

			var serviceLocator = new NinjectServiceLocator(Kernel);
			ServiceLocator.SetLocatorProvider(() => serviceLocator);

			var bootstrapper = Kernel.Get<Bootstrapper>();

			bootstrapper.SetUpViewEngine();
			bootstrapper.RegisterRoutes();
			bootstrapper.GenerateJavascriptForRouting();
		}

		protected override IKernel CreateKernel()
		{
			var kernel = new StandardKernel();

			return kernel;
		}
	}
}