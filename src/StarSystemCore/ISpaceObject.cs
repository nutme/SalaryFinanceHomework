namespace SalaryFinanceHomework.StarSystemCore
{
    public interface ISpaceObject
    {
        SpaceCoordinate SpaceCoordinate { get; }
        SpaceObjectType SpaceObjectType { get; }
    }
}
