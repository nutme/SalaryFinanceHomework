using NUnit.Framework;
using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemGenerator.Worker;
using SalaryFinanceHomework.StarSystemNavigator.Worker;
using System.Linq;

namespace SalaryFinanceHomework.StarSystemNavigator.Tests
{
    [TestFixture]
    public class StarSystemFilterTests
    {
        [Test]
        public void FilterOutMostersFromSpaceArray()
        {
            var numberOfSpaceObjects = 15000;
            var spacePopulator = new SpacePopulator(new CryptoRandomnessProvider());
            var spaceArray = spacePopulator.Run(numberOfSpaceObjects);

            var filter = new StarSystemFilter();
            var planets = filter.FindTargetsForColonisation(spaceArray);

            Assert.That(planets.Any(p => p.SpaceObjectType == SpaceObjectType.Monster), Is.False);
        }
    }
}
