using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_race
{ 
    class SpeedСamel : LandTransport
    {
        public SpeedСamel()
        {
            Name = "Speed Camel";
            Speed = 40.0;
            RestTime = 10.0;
        }
        public override double RestDuration(int i)
        {
            switch (i)
            {
                case 1:
                    return 5;
                case 2:
                    return 6.5;
                default:
                    return 8;
            }
        }
    }
}
