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

        public static void Transaction(ItemManager itemManager) // player can purchase any number of any item for any amount of another item, configurable in Globals
        {
            int itemCount = itemManager.CountItems(Globals.traderSellCurrency);

            if (itemCount < Globals.traderSellCost)
            {
                CursorController.InputAreaCursor(4, 0);
                Console.Write("Trader: \'I'll sell you " + Globals.traderSellQty + " " + Globals.traderSellItem);
                if (Globals.traderSellQty > 1) Console.Write("s");
                Console.WriteLine(" for " + Globals.traderSellCost + " " + Globals.traderSellCurrency + "!\'");
            }
            else
            {
                itemManager.SpendItem(Globals.traderSellCost);

                for (int i = 0; i < Globals.traderSellQty; i++)
                {
                    itemManager.GiveItem(Globals.traderSellItem);
                }

                CursorController.InputAreaCursor(4, 0);
                Console.Write("You purchased " + Globals.traderSellQty + " " + Globals.traderSellItem);
                if (Globals.traderSellQty > 1) Console.Write("s");
                Console.WriteLine(" for " + Globals.traderSellCost + " " + Globals.traderSellCurrency + "!");
            }

        }
    }
}
