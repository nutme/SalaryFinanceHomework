using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;
using System.Linq;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public class SpaceTimeFlightSimulation : ISpaceTimeFlightSimulation
    {
        private readonly IStarSystemFilter starSystemFilter;
        private SpaceCoordinate shipCoordinate;

        public SpaceTimeFlightSimulation(IStarSystemFilter starSystemFilter)
        {
            this.starSystemFilter = starSystemFilter;
            shipCoordinate = SpaceRules.HomeWorld;
        }
        
        /// <summary>
        /// Finds planets space ship will visit on it's mission and return a list of planets unhabitant and colonised on it's way
        /// </summary>
        public IEnumerable<ISpaceObject> Run(IEnumerable<ISpaceObject> spaceArray)
        {
            // filter only planets. Other space objects are of no interest for this simulation
            var planetsArray = starSystemFilter.FindTargetsForColonisation(spaceArray);
            return null;
        }

        /// <summary>
        /// Calculates surface of habitable planets
        /// </summary>
        public int CalculateHabitablePlanetsSurface(IEnumerable<ISpaceObject> planetsArray)
        {
            var habitablePlanetsSurface = planetsArray
                .Where(p => ((Planet)p).Habitable)
                .Select(p => ((Planet)p).SurfaceArea)
                .Sum();

            return habitablePlanetsSurface;
        }
    }
}
