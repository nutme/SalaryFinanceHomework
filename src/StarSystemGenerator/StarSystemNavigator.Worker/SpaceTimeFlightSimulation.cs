using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;
using System.Linq;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public partial class SpaceTimeFlightSimulation : ISpaceTimeFlightSimulation
    {
        private readonly IStarSystemFilter starSystemFilter;
        private readonly ISpaceCalculator spaceCalculator;

        public SpaceTimeFlightSimulation(IStarSystemFilter starSystemFilter, ISpaceCalculator spaceCalculator)
        {
            this.starSystemFilter = starSystemFilter;
            this.spaceCalculator = spaceCalculator;
        }

        /// <summary>
        /// Finds planets space ship will visit on it's mission and return a list of planets unhabitant and colonised on it's way
        /// </summary>
        public SpaceTimeFlightSimulationResult Run(IEnumerable<ISpaceObject> spaceArray)
        {
            var visitedPlanets = new List<ISpaceObject>();

            // filter only planets. Other space objects are of no interest for this simulation
            var planetsArray = starSystemFilter.FindTargetsForColonisation(spaceArray).ToList();

            // TODO: ship could be created here or passed in to this function from outside
            var starship = new Starship(
                SpaceRules.HomeWorld,
                SpaceRules.SpaceShipLifetime,
                SpaceRules.TravelTimteBetweenImmediateNeighbors,
                SpaceRules.SpeedOfColonizationOfOneSquareKm);

            // every iteration simulation will look for closes not visited planet to spaceship
            // try to fly to it and colonise it if it's habitable
            // if attempt is a failure simulation will stop
            while (starship.HasFuel())
            {
                // find closest planet
                var closestPlanet = spaceCalculator.FindClosesPlanet(planetsArray, starship.Location());

                // try to fly to closestPlanet
                if (starship.CanFly())
                {
                    starship.Flight(closestPlanet.SpaceCoordinate);
                }
                else
                {
                    // if starship can't reach planet it's game over for that bucket
                    starship.Deactivate();
                    continue;
                }

                // once in new worl try to colonize it
                // if planet not habitable do nothing and fly away
                if (closestPlanet.Habitable)
                {
                    var minSurfaceNeededToColonize = spaceCalculator.GetMinSurfaceNeededForColonisation(closestPlanet.SurfaceArea);

                    if (starship.CanColonise(minSurfaceNeededToColonize))
                    {
                        // Colonise - Eureka!
                        starship.Colonise(minSurfaceNeededToColonize);
                    }
                    else
                    {
                        // if starship can't reach planet it's game over for that bucket
                        starship.Deactivate();
                        continue;
                    }
                }

                visitedPlanets.Add(closestPlanet);
                planetsArray.Remove(closestPlanet);
            }

            var colonisedSurface = spaceCalculator.CalculateHabitablePlanetsSurface(visitedPlanets);

            return new SpaceTimeFlightSimulationResult(colonisedSurface, visitedPlanets);
        }
    }
}
