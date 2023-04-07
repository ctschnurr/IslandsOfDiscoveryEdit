using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Wyvern : Enemy
    {
        public Wyvern(Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(map, itemManager, hud, cursorController, globals)
        {
            Name = Globals.wyvernName;
            character = Globals.wyvernCharacter;            
            Health = Globals.wyvernBasehealth;            
            Strength = Globals.wyvernBasestrength;
            XpValue = Globals.wyvernXPValue;            
            energyToMove = Globals.wyvernEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = Globals.wyvernSpawnPoint;

            base.map = map;            
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;    
            base.globals = globals;

            SpawnPoint(mySpawnTile);
            itemManager.CreateEnemyInv(Name, myID);
        }

        override protected void Walkable(int x, int y)
        {
            if (map.CheckForTerrain('~', x, y))
            {
                ResetMyPOS();
            }
        }
    }
}
