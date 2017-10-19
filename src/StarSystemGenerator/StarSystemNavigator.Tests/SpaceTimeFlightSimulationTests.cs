using NUnit.Framework;
using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemGenerator.Worker;
using SalaryFinanceHomework.StarSystemNavigator.Worker;
using System.Linq;

namespace SalaryFinanceHomework.StarSystemNavigator.Tests
{
    // TODO: refactor those test to use some sort of helper to create space objects
    // or load one test scenario from resource
    [TestFixture]
    public class SpaceTimeFlightSimulationTests
    {
        [Test]
        public void SimulationReturnShipsVisitedPlanets()
        {
            var numberOfSpaceObjects = 15000;
            var spacePopulator = new SpacePopulator(new CryptoRandomnessProvider());
            var spaceArray = spacePopulator.Run(numberOfSpaceObjects);

            var simulator = new SpaceTimeFlightSimulation(new StarSystemFilter(), new SpaceCalculator());
            var visitedPlanets = simulator.Run(spaceArray);

            // Need to come up with better assert criteria
            Assert.That(visitedPlanets.VisitedPlanets, Is.Not.Empty);
        }

        [Test]
        public void CanCalculateSurfaceOfHabitablePlanetsInArray()
        {
            var numberOfSpaceObjects = 15000;
            var spacePopulator = new SpacePopulator(new CryptoRandomnessProvider());
            var spaceArray = spacePopulator.Run(numberOfSpaceObjects);

            var simulator = new SpaceTimeFlightSimulation(new StarSystemFilter(), new SpaceCalculator());

            var simResult = simulator.Run(spaceArray);

            var testSumOfSurface = simResult.VisitedPlanets.Select(p => ((Planet)p).Habitable ? ((Planet)p).SurfaceArea : 0).Sum();
            Assert.That(simResult.ColonisedSurface, Is.EqualTo(testSumOfSurface));
        }
    }
}
