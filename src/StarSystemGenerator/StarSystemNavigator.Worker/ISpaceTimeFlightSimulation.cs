using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public interface ISpaceTimeFlightSimulation
    {
        IEnumerable<ISpaceObject> Run(IEnumerable<ISpaceObject> spaceArray);
        int CalculateHabitablePlanetsSurface(IEnumerable<ISpaceObject> planetsArray);
    }
}
