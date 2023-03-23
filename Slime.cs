using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Slime : Enemy
    {
        public Slime(Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(map, itemManager, hud, cursorController, globals)
        {
            Name = Globals.slimeName;
            character = Globals.slimeCharacter;
            basehealth = globals.slimeBasehealth;
            basespeed = globals.slimeBasespeed;
            basestrength = globals.slimeBasestrength;
            Health = basehealth;            
            Strength = basestrength;
            xpValue = globals.slimeXPValue;            
            energyToMove = globals.slimeEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = Globals.slimeSpawnPoint;
            base.map = map;            
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController; 
            base.globals = globals;

            SpawnPoint(mySpawnTile);
            itemManager.CreateEnemyInv(Name, myID);
        }
    }
}
