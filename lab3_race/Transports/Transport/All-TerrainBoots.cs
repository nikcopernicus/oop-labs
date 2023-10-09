using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_race
{
    class All_TerrainBoots : LandTransport
    {
        public All_TerrainBoots()
        {
            Name = "All-Terrain Boots";
            Speed = 6.0;
            RestTime = 60.0;
        }
        public override double RestDuration(int i)
        {
            switch (i)
            {
                case 1:
                    return 10;
                default:
                    return 5;
            }
        }
    }
}
