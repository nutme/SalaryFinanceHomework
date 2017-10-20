using SalaryFinanceHomework.StarSystemCore;
using System;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public class Starship
    {
        private readonly SpaceCoordinate coordinate;
        private TimeSpan lifeTime;
        private readonly TimeSpan flightSpeed;
        private readonly TimeSpan colonisationSpeed;
        private SpaceCoordinate shipCoordinate;

        public Starship(SpaceCoordinate coordinate, TimeSpan lifeTime, TimeSpan flightSpeed, TimeSpan colonisationSpeed)
        {
            this.coordinate = coordinate;
            this.lifeTime = lifeTime;
            this.flightSpeed = flightSpeed;
            this.colonisationSpeed = colonisationSpeed;
            shipCoordinate = SpaceRules.HomeWorld;
        }

        public void Flight(SpaceCoordinate coordinate)
        {
            lifeTime -= flightSpeed;
            shipCoordinate = coordinate;
        }

        public void Colonise(int sqKm)
        {
            // iteration of colonisation per sq km
            // potentially could calculate total milliseconds needed to colonise surface
            // and deduct from time span, but it would require new instances of timespan created
            for (int index = 0; index < sqKm; index++)
            {
                lifeTime -= colonisationSpeed;
            }
        }

        public bool HasFuel()
        {
            return lifeTime.TotalMilliseconds > 0;
        }

        public bool CanFly()
        {
            // since fuel of starship is calculated by time it can attemp to flight as long as it has filespan
            return lifeTime.TotalMilliseconds > flightSpeed.TotalMilliseconds;
        }

        public bool CanColonise(int sqKm)
        {
            // since fuel of starship is calculated by time it can attemp to colonise as long as it has filespan
            return lifeTime.TotalMilliseconds > colonisationSpeed.TotalMilliseconds * sqKm;
        }

        public SpaceCoordinate Location()
        {
            return coordinate;
        }

        public void Deactivate()
        {
            // way to stop ship completly is to set it's time resource to 0
            lifeTime = new TimeSpan(0);
        }
    }
}
