using SalaryFinanceHomework.StarSystemCore;
using System;

namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public class Starship
    {
        private readonly SpaceCoordinate coordinate;
        private readonly TimeSpan lifeTime;
        private readonly TimeSpan flightSpeed;
        private readonly TimeSpan colonisationSpeed;

        private ColonizationMeter meter;

        public Starship(SpaceCoordinate coordinate, TimeSpan lifeTime, TimeSpan flightSpeed, TimeSpan colonisationSpeed)
        {
            this.coordinate = coordinate;
            this.lifeTime = lifeTime;
            this.flightSpeed = flightSpeed;
            this.colonisationSpeed = colonisationSpeed;

            meter = new ColonizationMeter();
        }

        public void Flight()
        {
            // do the flying
        }
    }
}
