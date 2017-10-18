namespace SalaryFinanceHomework.StarSystemCore
{
    class Monster : ISpaceObject
    {
        public SpaceCoordinate SpaceCoordinate { get; private set; }
        public SpaceObjectType SpaceObjectType { get { return SpaceObjectType.Monster; } }
    }
}
