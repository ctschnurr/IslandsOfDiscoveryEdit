using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Slime : Enemy
    {
        public Slime(int x, int y, Map map, Player player, ItemManager itemManager) : base(x, y, map, player, itemManager)
        {            
            character = "s";
            basehealth = 2;
            basespeed = 2;
            basestrength = 1;
            health = basehealth;            
            strength = basestrength;
            base.map = map;
            base.player = player;
            base.itemManager = itemManager;
        }
    }
}
