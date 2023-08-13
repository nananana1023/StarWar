using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starwar_me
{
    public class PLanetInShipException : Exception { };
    public abstract class Starship
    {
        protected string name;
        public string getName() { return name; }
        protected int armour { get; }
        protected int shield;
        public int getShield() { return shield; }
        protected int guards;
       protected Planet planet;
       public Starship(string name, int armour, int shield, int guards)
        {
            this.name = name;
            this.armour = armour;
            this.shield = shield;
            this.guards = guards;
        }
        public void Protect(Planet p)
        { 
            if (planet != null)
                throw new PLanetInShipException();
            planet = p;
            p.ProtectedBy(this);
        }
       public void Leave()
        {
            if (planet == null) throw new PLanetInShipException();
            planet.Leave(this);
            planet = null;
        }
        public abstract double Power();
    }

    public class Destroyer:Starship
    {
        public Destroyer(string n, int a, int s, int g) : base(n, a, s, g) { }
        public override double Power()
        {
            return shield / 2;
        }
    }
    public class Transport : Starship
    {
        public Transport(string n, int a, int s, int g) : base(n, a, s, g) { }
        public override double Power()
        {
            return guards;
        }
    }
    public class Ironclad : Starship
    {
        public Ironclad(string n, int a, int s, int g) : base(n, a, s, g) { }
        public override double Power()
        {
            return armour;
        }
    }
}
