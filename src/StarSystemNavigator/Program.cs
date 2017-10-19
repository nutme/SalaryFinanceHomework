using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemFileSystem;
using System;
using System.Collections.Generic;


namespace SalaryFinanceHomework.StarSystemNavigator
{
    class Program
    {
        static int Main(string[] args)
        {
            var container = RegisterComponenets();
            var fileStore = container.Resolve<ISpaceStorage>();
            
            IEnumerable<ISpaceObject> spaceArray;

            // Try to load file provided
            try
            {
                var fileName = args[0];
                spaceArray = fileStore.LoadSpace(fileName);
            }
            catch(Exception ex)
            {
                throw new ArgumentException("File name is wrong or file can not be imported", ex);
            }

            container.Dispose();
            Console.ReadKey();
            return 0;
        }

        private static WindsorContainer RegisterComponenets()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ISpaceStorage>().ImplementedBy<SpaceStorage>());
            return container;
        }
    }
}
