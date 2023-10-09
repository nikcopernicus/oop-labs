using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_race
{
    class MagicCarpet : AirTransport
    {
        public MagicCarpet()
        {
            Name = "Magic Carpet";
            Speed = 10.0;
        }
        public override double DistanceReducer(double distance)
        {
            if (distance < 1000.0)
            {
                return 0;
            }
            else if (distance < 5000.0)
            {
                return 0.03;
            }
            else if (distance < 10000.0)
            {
                return 0.1;
            }
            else
            {
                return 0.05;
            }
        }
    }
}
