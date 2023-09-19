using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Trader : Enemy
    {
        public Trader(Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(map, itemManager, hud, cursorController, globals)
        {
            Name = Globals.traderName;
            character = Globals.traderCharacter;
            Health = Globals.traderBasehealth;
            Strength = Globals.traderBasestrength;
            XpValue = Globals.traderXPValue;
            energyToMove = Globals.traderEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = Globals.treasureSpawnPoint;
            base.map = map;
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;
            base.globals = globals;

            SpawnPoint(mySpawnTile);
            itemManager.CreateEnemyInv(Name, myID);
        }

        public static void Transaction(ItemManager itemManager)
        {
            int goldOnHand = itemManager.CountItems("gold");

            if (goldOnHand < Globals.traderPotionCost)
            {
                CursorController.InputAreaCursor(4, 0);
                Console.WriteLine("Trader: \'Potions are " + Globals.traderPotionCost + " \'gold each!\'");
            }
            else
            {
                itemManager.GivePotion();
                itemManager.SpendGold(Globals.traderPotionCost);

                CursorController.InputAreaCursor(4, 0);
                Console.WriteLine("You purchased a potion for " + Globals.traderPotionCost + "!");
            }

        }
    }
}
