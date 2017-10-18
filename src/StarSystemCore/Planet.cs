namespace SalaryFinanceHomework.StarSystemCore
{
    class Planet : ISpaceObject, IPlanet
    {
        public SpaceCoordinate SpaceCoordinate { get; private set; }
        public SpaceObjectType SpaceObjectType { get { return SpaceObjectType.Planet; } }
        public bool Habitable { get; private set; }
        public int SurfaceArea { get; private set; }
    }
}