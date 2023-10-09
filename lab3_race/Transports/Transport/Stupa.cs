using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_race
{
    class Stupa : AirTransport
    {
        public Stupa()
        {
            Name = "Stupa";
            Speed = 8.0;
        }
        public override double DistanceReducer(double distance)
        {
            return 0.06;
        }
    }
}
