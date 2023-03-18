using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Wyvern : Enemy
    {
        public Wyvern(int x, int y, Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(x, y, map, itemManager, hud, cursorController, globals)
        {
            Name = "Wyvern";
            character = "W";
            basehealth = 12;
            basespeed = 12;
            basestrength = 4;
            Health = basehealth;            
            Strength = basestrength;
            xpValue = 5;
            moveEnergy = 0;
            energyToMove = 100;
            myID = globals.enemyID;
            base.map = map;            
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;    
            base.globals = globals;
        }

        override protected void Walkable(int x, int y)
        {
            if (map.TerrainCheck('~', x, y))
            {
                ResetMyPOS();
            }
        }
    }
}
