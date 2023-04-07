using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class SeaSerpent : Enemy
    {
        public SeaSerpent(Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(map, itemManager, hud, cursorController, globals)
        {
            Name = Globals.seaserpentName;
            character = Globals.seaserpentCharacter;            
            Health = Globals.seaserpentBasehealth;            
            Strength = Globals.seaserpentBasestrength;
            XpValue = Globals.seaserpentXPValue;            
            energyToMove = Globals.seaserpentEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = Globals.seaserpentSpawnPoint;
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
            if (!map.CheckForTerrain('~', x, y))
            {
                ResetMyPOS();
            }            
        }
    }
}
