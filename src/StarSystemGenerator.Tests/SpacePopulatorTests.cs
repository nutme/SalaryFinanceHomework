using NUnit.Framework;
using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemGenerator.Worker;
using System.Linq;

namespace SalaryFinanceHomework.StarSystemGenerator.Tests
{
    [TestFixture]
    public class SpacePopulatorTests
    {
        private readonly int numberOfObjects = 90000;
        private SpacePopulator spacePopulator;

        [SetUp]
        public void SetUp()
        {
            spacePopulator = new SpacePopulator(new CryptoRandomnessProvider());
        }

        [Test]
        public void Generate90000SpaceObjects()
        {
            var spaceArray = spacePopulator.Run(numberOfObjects);
            Assert.That(spaceArray.Count, Is.EqualTo(numberOfObjects));
        }

        [Test]
        public void SystemHasDiferentPlanetsAndMonsters()
        {
            var spaceArray = spacePopulator.Run(numberOfObjects);

            Assert.That(spaceArray.Any(o => o.SpaceObjectType == SpaceObjectType.Monster), Is.True);
            Assert.That(spaceArray.Any(o => o.SpaceObjectType == SpaceObjectType.Planet), Is.True);
            Assert.That(spaceArray.Any(o => o.SpaceObjectType == SpaceObjectType.Planet && ((Planet)o).Habitable), Is.True);
            Assert.That(spaceArray.Any(o => o.SpaceObjectType == SpaceObjectType.Planet && ((Planet)o).Habitable), Is.True);

            var uniqueSizeOfPlanets = spaceArray
                .Where(o => o.SpaceObjectType == SpaceObjectType.Planet)
                .GroupBy(p => ((Planet)p).SurfaceArea);

            Assert.That(uniqueSizeOfPlanets.Count() > 1, Is.True);
        }
    }
}
