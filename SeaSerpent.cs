using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class SeaSerpent : Enemy
    {
        public SeaSerpent(int x, int y, Map map, ItemManager itemManager, HUD hud, CursorController cursorController) : base(x, y, map, itemManager, hud, cursorController)
        {
            name = "SeaSerpent";
            character = "S";
            basehealth = 22;
            basespeed = 5;
            basestrength = 8;
            health = basehealth;            
            strength = basestrength;
            xpValue = 12;
            moveEnergy = 0;
            energyToMove = 125;
            base.map = map;            
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;            
        }
        
        override protected void Walkable(int x, int y)
        {
            if (!map.TerrainCheck('~', x, y))
            {
                ResetMyPOS();
            }            
        }
    }
}
