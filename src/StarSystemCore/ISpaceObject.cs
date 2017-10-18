namespace SalaryFinanceHomework.StarSystemCore
{
    interface ISpaceObject
    {
        SpaceCoordinate SpaceCoordinate { get; }
        SpaceObjectType SpaceObjectType { get; }
    }
}
