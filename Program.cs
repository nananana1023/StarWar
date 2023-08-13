using TextFile;
using System;

namespace starwar_me
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*A starship has a name. It protects a planet, the planet is also known. It as 3
            properties: its armour (natural number), its shield (natural number), and the
            number of guardsmen on the ship. There are 3 types of ship: the destroyer, the
            transport, and the ironclad. The power of a ship depends on its type and its properties:
            The destroyer' power is given as the half of its shield.
            The transport's power means the number of guardsmen on it.
            The ironclad' power means its armour.
            1. Find the ship with the greates power in the Solar System!
            2.List all the unprotected planets!
            3. Give the total shield of the ships guarding a given planet!*/
            SolarSystem s = new SolarSystem("solarsystem.txt");
            try
            {
                TextFileReader r = new TextFileReader("input.txt");
                r.ReadInt(out int n);
                for(int i = 0; i < n; i++)
                {
                    r.ReadString(out string planetName);
                    Planet p=s.SearchPlanetbyName(planetName);

                    r.ReadInt(out int numShips);
                    for(int j=0; j < numShips; j++)
                    {
                        r.ReadString(out string name);
                        r.ReadString(out string type);
                        r.ReadInt(out int a);
                        r.ReadInt(out int sh);
                        r.ReadInt(out int g);
                        Starship ship=null;
                        switch(type)
                        {
                            case "Destroyer": ship = new Destroyer(name, a, sh, g);break;
                            case "Transport": ship = new Transport(name, a, sh, g); break;
                            case "Ironclad": ship = new Ironclad(name, a, sh, g); break;

                        }
                        ship.Protect(p);
                    }
                }
            }
            catch (System.IO.FileNotFoundException) { Console.WriteLine("file not found"); }

            if (s.MaxPowerShip(out Starship best))
                Console.WriteLine("MaxPowerShip: " + best.getName());
            else
                Console.WriteLine("no planet with a ship");

            Console.WriteLine("Unprotected planets: ");
            foreach(Planet p in s.Unprotected())
            {
                Console.WriteLine(p.getName());
            }

            Console.WriteLine("Total shield of Earth: "+s.SearchPlanetbyName("Earth").totalShield());
        }
    }
}