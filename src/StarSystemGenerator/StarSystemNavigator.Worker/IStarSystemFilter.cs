using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public interface IStarSystemFilter
    {
        IEnumerable<ISpaceObject> FindTargetsForColonisation(IEnumerable<ISpaceObject> spaceArray);
    }
}
