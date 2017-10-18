using System;

namespace SalaryFinanceHomework.StarSystemCore
{
    /// <summary>
    /// Represents all constans set for Space
    /// Making configuration of space and time continum easier
    /// </summary>
    public static class SpaceRules
    {
        public static readonly SpaceCoordinate HomeWorld = new SpaceCoordinate(123123991, 098098111, 456456999);
        public static readonly int CoordinatesMinLimit = 0;
        public static readonly int CoordinatesMaxLimit = 999999999;
        public static readonly int SpaceSystemCapacity = 15000;
        public static readonly int MinPlanetSurface = 1;
        public static readonly int MaxPlanetSurface = 100;
        public static readonly TimeSpan TravelTimteBetweenImmediateNeighbors = new TimeSpan(0, 10, 0); // 10 minutes
        public static readonly double MarkOfPlanetSurfacesNeededForColonizationInPercentage = 0.5;
        public static readonly TimeSpan SpeedOfColonizationOfOneSquareKm = new TimeSpan(0, 0, 0, 0, 43); // 43 milliseconds
        public static readonly TimeSpan SpaceShipLifetime = new TimeSpan(24, 0, 0); // 24 hours
    }
}
