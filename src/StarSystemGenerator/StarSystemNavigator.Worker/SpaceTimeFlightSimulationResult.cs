using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public class SpaceTimeFlightSimulationResult
    {
        public int ColonisedSurface { get; private set; }
        public List<ISpaceObject> VisitedPlanets { get; private set; }

        public SpaceTimeFlightSimulationResult(int colonisedSurface, List<ISpaceObject> visitedPlanets)
        {
            ColonisedSurface = colonisedSurface;
            VisitedPlanets = visitedPlanets;
        }
    }
}
