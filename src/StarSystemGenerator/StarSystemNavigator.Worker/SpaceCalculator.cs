using SalaryFinanceHomework.StarSystemCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public class SpaceCalculator : ISpaceCalculator
    {
        /// <summary>
        /// FInds closest planet to the ship
        /// </summary>
        public Planet FindClosesPlanet(IEnumerable<ISpaceObject> planetsArray, SpaceCoordinate coordinates)
        {
            // This task can be solved in couple of diferent of ways
            // After reading this discussion:
            // https://stackoverflow.com/questions/2486093/millions-of-3d-points-how-to-find-the-10-of-them-closest-to-a-given-point
            // Decision was made to not overcomplecate and do brute force searc
            // As hi-end solution Unity could be used (redicilous overkill for homework):
            // https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
            // TODO: try other methods

            Planet closestPanel = null;
            double closestPanelDistance = 0;
            float[] sourcePoint = new float[3] { coordinates.X, coordinates.Y, coordinates.Z};

            foreach (var candidate in planetsArray)
            {
                // Calculate distnce to planet
                float[] targetPoint = new float[3] { candidate.SpaceCoordinate.X, candidate.SpaceCoordinate.Y, candidate.SpaceCoordinate.Z };
                var distanceToCandidate = Math.Sqrt(sourcePoint.Zip(targetPoint, (a, b) => (a - b) * (a - b)).Sum());

                // If it's closer that existing closes replace it with new closest
                if (distanceToCandidate > closestPanelDistance)
                {
                    closestPanelDistance = distanceToCandidate;
                    closestPanel = (Planet)candidate;
                }
            }

            return closestPanel;
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

        public int GetMinSurfaceNeededForColonisation(int surfaceArea)
        {
            // if surface is 1 sq km it's the absolute minimum to be habitated to colonize
            if (surfaceArea == 1)
            {
                return surfaceArea;
            }

            // otherwise get a bit more that half
            var fiftyPlusOne = surfaceArea / 2;
            if (fiftyPlusOne <= surfaceArea)
            {
                fiftyPlusOne += 1;
            }

            return fiftyPlusOne;
        }
    }
}
