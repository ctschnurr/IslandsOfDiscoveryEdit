using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class SeaSerpent : Enemy
    {
        public SeaSerpent()
        {
            character = "S";
            basehealth = 22;
            basespeed = 5;
            basestrength = 8;
            health = basehealth;
            speed = basespeed;
            strength = basestrength;
        }

    }
}
