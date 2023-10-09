using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_race
{
    class BactrianCamel : LandTransport
    {
        public BactrianCamel()
        {
            Name = "Bactrian Camel";
            Speed = 10.0;
            RestTime = 30.0;
        }
        public override double RestDuration(int i)
        {
            switch(i)
            {
                case 1:
                    return 5;
                default:
                    return 8;
            }
        }
    }
}