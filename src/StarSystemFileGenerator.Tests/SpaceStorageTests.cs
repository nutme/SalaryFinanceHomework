using NUnit.Framework;
using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemFileSystem;
using SalaryFinanceHomework.StarSystemGenerator.Worker;
using System;
using System.Linq;

namespace StarSystemFileSystem.Tests
{
    // This test must have access to c:\temp\ to run
    [TestFixture]
    public class SpaceStorageTests
    {
        [Test]
        public void SaveAndLoadSpaceToFileSystem()
        {
            var numberOfSpaceObjects = 15000;
            var fileName = $"c:\\temp\\space{DateTime.Now.Ticks}.txt";

            var spacePopulator = new SpacePopulator(new CryptoRandomnessProvider());
            var spaceArray = spacePopulator.Run(numberOfSpaceObjects);

            var spaceStorage = new SpaceStorage();

            spaceStorage.SaveSpace(spaceArray, fileName);
            var restoredSpace = spaceStorage.LoadSpace(fileName).ToArray();

            var spaceArrayToCompare = spaceArray.ToArray();
            for (int index = 0; index < numberOfSpaceObjects; index++)
            {
                Assert.That(spaceArrayToCompare[index].SpaceCoordinate.X, Is.EqualTo(restoredSpace[index].SpaceCoordinate.X));
                Assert.That(spaceArrayToCompare[index].SpaceCoordinate.Y, Is.EqualTo(restoredSpace[index].SpaceCoordinate.Y));
                Assert.That(spaceArrayToCompare[index].SpaceCoordinate.Z, Is.EqualTo(restoredSpace[index].SpaceCoordinate.Z));
                Assert.That(spaceArrayToCompare[index].SpaceObjectType, Is.EqualTo(restoredSpace[index].SpaceObjectType));

                if (spaceArrayToCompare[index].SpaceObjectType == SpaceObjectType.Planet)
                {
                    Assert.That(((Planet)spaceArrayToCompare[index]).Habitable, Is.EqualTo(((Planet)restoredSpace[index]).Habitable));
                    Assert.That(((Planet)spaceArrayToCompare[index]).SurfaceArea, Is.EqualTo(((Planet)restoredSpace[index]).SurfaceArea));
                }

            }
        }
    }
}
