using System;
using System.Collections.Generic;
using System.Dynamic;


namespace lab3_race
{
    class Program
    {
        static void Main(string[] args)
        {
            Race<LandTransport> landrace = new Race<LandTransport>(11111);
            landrace.AddMembers(new List<LandTransport> {
                new BactrianCamel(),
                new SpeedСamel(),
                new All_TerrainBoots(),
                new Centaur()
            });
            Console.WriteLine(landrace.WinRace());

            Race<AirTransport> airrace = new Race<AirTransport>(11111);
            airrace.AddMembers(new List<AirTransport> {
                new Broom(),
                new Stupa(),
                new MagicCarpet()
            });
            Console.WriteLine(airrace.WinRace());

            Race<ITransport> mixrace = new Race<ITransport>(11111);
            mixrace.AddMembers(new List<ITransport> {
                new BactrianCamel(),
                new SpeedСamel(),
                new All_TerrainBoots(),
                new Centaur(),
                new Broom(),
                new Stupa(),
                new MagicCarpet()
            });
            Console.WriteLine(mixrace.WinRace());
        }
    }
}
