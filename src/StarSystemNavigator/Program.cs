using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemFileSystem;
using SalaryFinanceHomework.StarSystemNavigator.Worker;
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
            var simulationEngine = container.Resolve<ISpaceTimeFlightSimulation>();

            // Try to load file provided
            IEnumerable<ISpaceObject> spaceArray;
            try
            {
                var fileName = args[0];
                spaceArray = fileStore.LoadSpace(fileName);
            }
            catch(Exception ex)
            {
                throw new ArgumentException("File name is wrong or file can not be imported", ex);
            }

            // Find spaceship path to colonise it given space 
            var simResults = simulationEngine.Run(spaceArray);
            PrintOutResults(simResults);

            container.Dispose();
            return 0;
        }

        private static void PrintOutResults(SpaceTimeFlightSimulationResult simResult)
        {
            Console.WriteLine("Starship path");
            Console.WriteLine($"Home World {SpaceRules.HomeWorld}");
            foreach (var planet in simResult.VisitedPlanets)
            {
                if (((Planet)planet).Habitable)
                {
                    Console.WriteLine($"Colonised planet {((Planet)planet).SpaceCoordinate}");
                }
                else
                {
                    Console.WriteLine($"Visited planet {((Planet)planet).SpaceCoordinate}");
                }
            }

            Console.WriteLine($"Total colonised surface {simResult.ColonisedSurface} sq km");
        }

        private static WindsorContainer RegisterComponenets()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ISpaceStorage>().ImplementedBy<SpaceStorage>());
            container.Register(Component.For<IStarSystemFilter>().ImplementedBy<StarSystemFilter>());
            container.Register(Component.For<ISpaceTimeFlightSimulation>().ImplementedBy<SpaceTimeFlightSimulation>());
            container.Register(Component.For<ISpaceCalculator>().ImplementedBy<SpaceCalculator>());
            
            return container;
        }
    }
}
