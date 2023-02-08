using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Slime : Enemy
    {
        public Slime()
        {
            posX = 14;
            posY = 4;
            character = "s";
            basehealth = 2;
            basespeed = 2;
            basestrength = 1;
            health = basehealth;
            speed = basespeed;
            strength = basestrength;
        }
    }
}
