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
            basehealth = globals.seaserpentBasehealth;
            basespeed = globals.seaserpentBasespeed;
            basestrength = globals.seaserpentBasestrength;
            Health = basehealth;            
            Strength = basestrength;
            xpValue = globals.seaserpentXPValue;            
            energyToMove = globals.seaserpentEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = Globals.seaserpentSpawnPoint;
            base.map = map;            
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController; 
            base.globals = globals;

            SpawnPoint(mySpawnTile);
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
