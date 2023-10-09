using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_race
{
    class Centaur : LandTransport
    {
        public Centaur()
        {
            Name = "Centaur";
            Speed = 15.0;
            RestTime = 8.0;
        }
        public override double RestDuration(int i)
        {
            switch (i)
            {
                default:
                    return 2;
            }
        }
    }
}
