using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Ninject.Website.Models;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Ninject.Website.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Ninject.Website.App_Start.NinjectMVC3), "Stop")]

namespace Ninject.Website.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;
    using Ninject.Website.Models;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepository>().To<Repository>();
            var extensions = LoadExtensions();
            kernel.Bind<IEnumerable<Extension>>().ToConstant( extensions );
        }

        private static IEnumerable<Extension> LoadExtensions()
        {
            var doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/extensions.xml"));
            var extensions = from extension in doc.Root.Elements("extension")
                             let authorNode = extension.Element("author")
                             select new Extension
                                    {
                                            Website = (string)extension.Element("website"),
                                            Description = (string)extension.Element("description"),
                                            Author = new Author()
                                                     {
                                                             Email = (string)authorNode.Element("email"),
                                                             Name = (string)authorNode.Element("name")

                                                     },
                                            Name = (string)extension.Element("name"),
                                    };
            return extensions;
        }
    }
}
