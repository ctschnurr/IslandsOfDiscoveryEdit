using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Slime : Enemy
    {
        public Slime(int x, int y, Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(x, y, map, itemManager, hud, cursorController, globals)
        {
            Name = "Slime";
            character = "s";
            basehealth = 2;
            basespeed = 2;
            basestrength = 1;
            Health = basehealth;            
            Strength = basestrength;
            xpValue = 2;
            moveEnergy = 0;
            energyToMove = 200;
            myID = globals.enemyID;
            base.map = map;            
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController; 
            base.globals = globals;
        }
    }
}
