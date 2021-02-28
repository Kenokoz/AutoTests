using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.Fundamentals
{
    public class DemeritPointCalculator
    {
        private const int speedLimit = 65;
        private const int maxSpeed = 300;

        public int CalculateDemeritPoints(int speed)
        {
            if (speed < 0 || speed > maxSpeed)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (speed <= speedLimit)
            {
                return 0;
            }

            const int kmPerDemeritPoint = 5;
            var demeritPoint = (speed - speedLimit) / kmPerDemeritPoint;

            return demeritPoint;
        }
    }
}
