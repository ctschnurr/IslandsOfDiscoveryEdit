using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Trader : Enemy //  Trader is treated as an enemy, similar to the existing Treasure enemy
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

        public static void Transaction(ItemManager itemManager) // when the player interacts with the trader by running into them, this will take care of one potion purchase
        {
            int goldOnHand = itemManager.CountItems("gold");

            if (goldOnHand < Globals.traderSellCost)
            {
                CursorController.InputAreaCursor(4, 0);
                Console.WriteLine("Trader: \'" + Globals.traderSellItem + "s are " + Globals.traderSellCost + " " + Globals.traderSellCurrency + " each!\'");
            }
            else
            {
                itemManager.SpendItem(Globals.traderSellCost);
                itemManager.GiveItem(Globals.traderSellItem);

                CursorController.InputAreaCursor(4, 0);
                Console.WriteLine("You purchased a potion for " + Globals.traderSellCost + "!");
            }

        }
    }
}
