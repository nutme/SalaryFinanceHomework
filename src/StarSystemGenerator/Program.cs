using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemFileSystem;
using SalaryFinanceHomework.StarSystemGenerator.Worker;
using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SalaryFinanceHomework.StarSystemGenerator
{
    class Program
    {
        static int Main(string[] args)
        {
            var container = RegisterComponenets();
            var spacePopulator = container.Resolve<ISpacePopulator>();
            var fileStore = container.Resolve<ISpaceStorage>();

            // creating instance of random generator & space object generator
            Console.WriteLine("Generating planets from interspace void");

            // Generating all space objects in one go and writing to the file
            // is better than writing one by one as it gets generated.
            // Reason for it is that file system I/O operations are expensive 

            // run accuall space generation
            var randomSpace = spacePopulator.Run(SpaceRules.SpaceSystemCapacity);

            // write results to the file
            Console.WriteLine("Saving space to file store");
            var fileName = fileStore.SaveSpace(randomSpace);

            Console.WriteLine($"Saved space to file ${fileName}");

            container.Dispose();
            return 0;
        }

        private static WindsorContainer RegisterComponenets()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ISpaceStorage>().ImplementedBy<SpaceStorage>());
            container.Register(Component.For<IRandomnessProvider>().ImplementedBy<CryptoRandomnessProvider>());
            container.Register(Component.For<ISpacePopulator>().ImplementedBy<SpacePopulator>());
            return container;
        }
    }
}
