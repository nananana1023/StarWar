using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace starwar_me
{
    public class Planet
    {
        private string name;
        public string getName() { return name; }
        private List<Starship> ships=new List<Starship>();
        public Planet(string name)
        {
            this.name = name;
        }
        public int shipount() { return ships.Count; }
        public void ProtectedBy(Starship s) { ships.Add(s); }
        public void Leave(Starship s) { ships.Remove(s); }
        public double totalShield()
        {
            double shields = 0;
            foreach(Starship s in ships)
            {
                shields += s.getShield();
            }
            return shields;
        }

        public bool MaxPower(out double max, out Starship bestship)
        {
            bestship = null;
            bool l = false;
            max = 0;
            foreach (Starship s in ships)
            {
                if (s.Power() > max)
                {
                    max = s.Power();
                    bestship = s;
                    l = true;
                }
            }
            return l;
        }

    }
}
