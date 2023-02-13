using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Slime : Enemy
    {
        public Slime(int x, int y, Map map) : base(x, y, map)
        {            
            character = "s";
            basehealth = 2;
            basespeed = 2;
            basestrength = 1;
            health = basehealth;
            speed = basespeed;
            strength = basestrength;
            base.map = map;
        }
    }
}
