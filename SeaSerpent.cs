using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class SeaSerpent : Enemy
    {
        public SeaSerpent(int x, int y, Map map, Player player, ItemManager itemManager) : base(x, y, map, player, itemManager)
        {
            character = "S";
            basehealth = 22;
            basespeed = 5;
            basestrength = 8;
            health = basehealth;            
            strength = basestrength;
            base.map = map;
            base.player = player;
            base.itemManager = itemManager;
        }

        override protected void WallCheck(int x, int y, ItemManager itemManager) //checks to see if the character is allowed to move onto the map location
        {
            if (x > map.cols || x < 0 + 1) //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else if (y > map.rows || y < 0 + 1) //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else
            {
                switch (map.map[y - 1, x - 1])
                {
                    case '^':
                        moveRollBack = true;
                        break;
                    case '`':
                        moveRollBack = true;
                        break;
                    case '#':
                        moveRollBack = true;
                        break;
                    case '*':
                        moveRollBack = true;
                        break;
                    default:
                        moveRollBack = false;
                        break;
                }
            }
        }  
    }
}
