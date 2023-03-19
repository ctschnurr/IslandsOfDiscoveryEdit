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
            Name = globals.wyvernName;
            character = globals.wyvernCharacter;
            basehealth = globals.wyvernBasehealth;
            basespeed = globals.wyvernBasespeed;
            basestrength = globals.wyvernBasestrength;
            Health = basehealth;            
            Strength = basestrength;
            xpValue = globals.wyvernXPValue;            
            energyToMove = globals.wyvernEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = globals.wyvernSpawnPoint;

            base.map = map;            
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;    
            base.globals = globals;

            SpawnPoint(mySpawnTile);
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
