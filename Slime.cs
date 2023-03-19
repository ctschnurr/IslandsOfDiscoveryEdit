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
            Name = globals.slimeName;
            character = globals.slimeCharacter;
            basehealth = globals.slimeBasehealth;
            basespeed = globals.slimeBasespeed;
            basestrength = globals.slimeBasestrength;
            Health = basehealth;            
            Strength = basestrength;
            xpValue = globals.slimeXPValue;            
            energyToMove = globals.slimeEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = globals.slimeSpawnPoint;
            base.map = map;            
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController; 
            base.globals = globals;

            SpawnPoint(mySpawnTile);
        }
    }
}
