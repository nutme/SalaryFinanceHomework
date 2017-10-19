using System.Collections.Generic;
using SalaryFinanceHomework.StarSystemCore;

namespace SalaryFinanceHomework.StarSystemGenerator.Worker
{
    public class SpacePopulator
    {
        private readonly IRandomnessProvider randomnessProvider;

        public SpacePopulator(IRandomnessProvider randomnessProvider)
        {
            this.randomnessProvider = randomnessProvider;
        }

        public IEnumerable<ISpaceObject> Run(int capacity)
        {
            var spaceObjects = new List<ISpaceObject>();

            for (int index = 0; index < capacity; index++)
            {
                var newObject = RandomizeNewSpaceObject();
                spaceObjects.Add(newObject);
            }

            return spaceObjects;
        }

        private ISpaceObject RandomizeNewSpaceObject()
        {
            var coordinate = new SpaceCoordinate(
                randomnessProvider.GetRandomInt(SpaceRules.CoordinatesMinLimit, SpaceRules.CoordinatesMaxLimit),
                randomnessProvider.GetRandomInt(SpaceRules.CoordinatesMinLimit, SpaceRules.CoordinatesMaxLimit),
                randomnessProvider.GetRandomInt(SpaceRules.CoordinatesMinLimit, SpaceRules.CoordinatesMaxLimit));

            if (randomnessProvider.GetRandomBool())
            {
                return new Monster(coordinate);
            }

            return new Planet(
                coordinate,
                randomnessProvider.GetRandomBool(),
                randomnessProvider.GetRandomInt(SpaceRules.MinPlanetSurface, SpaceRules.MaxPlanetSurface));
        }
    }
}
