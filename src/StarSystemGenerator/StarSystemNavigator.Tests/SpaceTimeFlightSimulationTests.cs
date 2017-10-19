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

            var simulator = new SpaceTimeFlightSimulation(new StarSystemFilter());
            var visitedPlanets = simulator.Run(spaceArray);

            // Need to come up with better assert criteria
            Assert.That(visitedPlanets, Is.Not.Empty);
        }

        [Test]
        public void CanCalculateSurfaceOfHabitablePlanetsInArray()
        {
            var numberOfSpaceObjects = 15000;
            var spacePopulator = new SpacePopulator(new CryptoRandomnessProvider());
            var spaceArray = spacePopulator.Run(numberOfSpaceObjects);

            var simulator = new SpaceTimeFlightSimulation(new StarSystemFilter());

            var planets = spaceArray.Where(o => o.SpaceObjectType == SpaceObjectType.Planet);
            var visitedPlanets = planets.Take(200);

            var testSumOfSurface = visitedPlanets.Select(p => ((Planet)p).Habitable ? ((Planet)p).SurfaceArea : 0).Sum();

            var surface = simulator.CalculateHabitablePlanetsSurface(visitedPlanets);

            Assert.That(surface, Is.EqualTo(testSumOfSurface));
        }
    }
}
