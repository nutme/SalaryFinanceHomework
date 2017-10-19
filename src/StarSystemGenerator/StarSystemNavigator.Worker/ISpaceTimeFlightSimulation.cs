using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public interface ISpaceTimeFlightSimulation
    {
        SpaceTimeFlightSimulationResult Run(IEnumerable<ISpaceObject> spaceArray);
    }
}
