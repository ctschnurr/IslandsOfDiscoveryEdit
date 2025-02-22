﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Dragon : Enemy
    {
        public Dragon(Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(map, itemManager, hud, cursorController, globals)
        {
            Name = Globals.dragonName;
            character = Globals.dragonCharacter;            
            Health = Globals.dragonBasehealth;
            Strength = Globals.dragonBasestrength;
            XpValue = Globals.dragonXPValue;
            energyToMove = Globals.dragonEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = Globals.dragonSpawnPoint;
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
