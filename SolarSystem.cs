using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace starwar_me
{
    public class SolarSystem
    {
        /*1. Find the ship with the greates power in the Solar System!
            2.List all the unprotected planets!
            3. Give the total shield of the ships guarding a given planet!*/
        public List<Planet> planets;
        public SolarSystem(string fname)
        {
            TextFileReader reader = new TextFileReader(fname);
            planets = new List<Planet>();
            while (reader.ReadString(out string name))
            {
                planets.Add(new Planet(name));
            }
        }
        public bool MaxPowerShip(out Starship bestship)
        {
            double max = 0;
            bool l = false;
            bestship = null;
            foreach(Planet planet in planets)
            {
                bool ll = planet.MaxPower(out double power, out Starship ship);
                if (ll && !l)
                {
                    l = true;
                    max = power;
                    bestship = ship;
                }
                else if( ll && l)
                {
                    if(max<power)
                    {
                        max = power;
                        bestship = ship;
                    }                 
                }
            }
            return l;
            
        }

       /* public bool MaxPowerShip(out Starship bestship)
        {
            bool l = false;
            double max = 0.0;
            bestship = null; ;
            foreach (Planet planet in planets)
            {
                bool ll = planet.MaxPower(out double power, out Starship ship);
                if (!ll) continue;
                if (!l) { l = true; max = power; bestship = ship; }
                else
                {
                    if (max < power) { max = power; bestship = ship; }
                }
            }
            return l;
        }*/



        public List<Planet> Unprotected()
        {
            List<Planet> unps = new List<Planet>();
            foreach (Planet p in planets)
            {
                if(p.shipount()==0)
                    unps.Add(p);
            }
            return unps;
        }

        public Planet SearchPlanetbyName(string name)
        {
            foreach (Planet planet in planets)
            {
                if (name==planet.getName()) 
                    return planet;
            }
            return null;
        }

       
    }
}
