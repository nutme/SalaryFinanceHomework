using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public interface ISpaceCalculator
    {
        Planet FindClosesPlanet(IEnumerable<ISpaceObject> planetsArray, SpaceCoordinate coordinates);
        int CalculateHabitablePlanetsSurface(IEnumerable<ISpaceObject> planetsArray);
        int GetMinSurfaceNeededForColonisation(int surfaceArea);
    }
}
