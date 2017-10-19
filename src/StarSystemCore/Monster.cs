using System;

namespace SalaryFinanceHomework.StarSystemCore
{
    [Serializable]
    public class Monster : ISpaceObject
    {
        public SpaceCoordinate SpaceCoordinate { get; private set; }
        public SpaceObjectType SpaceObjectType { get { return SpaceObjectType.Monster; } }

        public Monster(SpaceCoordinate coordinate)
        {
            SpaceCoordinate = coordinate;
        }
    }
}
