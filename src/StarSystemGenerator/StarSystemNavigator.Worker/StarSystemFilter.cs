using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;
using System.Linq;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    /// <summary>
    /// Filter array to contain only planets
    /// Monsters have no interest for spaceship
    /// 
    /// It wold make sence to filter out unhabitable planets as well
    /// But rules state that ship can fly only to closes planet
    /// So unhabitable planets would have to be visited unfortunatly
    /// </summary>
    public class StarSystemFilter : IStarSystemFilter
    {
        public IEnumerable<ISpaceObject> FindTargetsForColonisation(IEnumerable<ISpaceObject> spaceArray)
        {
            var targets = spaceArray
                .Where(o => o.SpaceObjectType == SpaceObjectType.Planet);
            return targets;
        }
    }
}
