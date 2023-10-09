using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_race
{
    class Broom : AirTransport
    {
        public Broom()
        {
            Name = "Broom";
            Speed = 20.0;
        }
        public override double DistanceReducer(double distance)
        {
            return distance / 100000;
        }
    }
}
