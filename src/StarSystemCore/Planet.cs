using System;

namespace SalaryFinanceHomework.StarSystemCore
{
    [Serializable]
    public class Planet : ISpaceObject, IPlanet
    {
        public SpaceCoordinate SpaceCoordinate { get; private set; }
        public SpaceObjectType SpaceObjectType { get { return SpaceObjectType.Planet; } }
        public bool Habitable { get; private set; }
        public int SurfaceArea { get; private set; }

        public Planet(SpaceCoordinate coordinate, bool habitable, int surfaceArea)
        {
            SpaceCoordinate = coordinate;
            Habitable = habitable;
            SurfaceArea = surfaceArea;
        }
    }
}