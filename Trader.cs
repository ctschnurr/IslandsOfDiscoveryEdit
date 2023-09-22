using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Trader : Enemy //  Trader is treated as an enemy, similar to the existing Treasure enemy
    {
        ConsoleKeyInfo key;
        bool transactionOver = false;
        static Random rand = new Random();
        List<string> tradeItems = new List<string>();
        public Trader(Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(map, itemManager, hud, cursorController, globals)
        {
            Name = Globals.traderName;
            character = Globals.traderCharacter;
            Health = Globals.traderBasehealth;
            Strength = Globals.traderBasestrength;
            XpValue = Globals.traderXPValue;
            energyToMove = Globals.traderEnergyToMove;
            myID = globals.enemyID;
            mySpawnTile = Globals.traderSpawnPoint;

            List<string> itemsList;

            base.map = map;
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;
            base.globals = globals;

            SpawnPoint(mySpawnTile);
            itemManager.CreateEnemyInv(Name, myID);

            if (Globals.tradersRandom)
            {
                int numberOfItems = rand.Next(1, Globals.traderAllItems.Count);
                if (numberOfItems > 6) numberOfItems = 6;                               // limit to 6 items to sell, most that will nicely fit in game area
                itemsList = new List<string>(Globals.traderAllItems);
                tradeItems = new List<string>(numberOfItems);

                for (int i = 1; i <= numberOfItems; i++)
                {
                    int randomInt = rand.Next(0, itemsList.Count);
                    tradeItems.Add(itemsList[randomInt]);
                    itemsList.RemoveAt(randomInt);
                }
            }
            else
            {
                tradeItems = Globals.traderSetItems;

            }
        }



        public void Transaction(Player player, ItemManager itemManager, Map map, QuestManager questManager) // player can purchase any number of any item for any amount of another item, configurable in Globals
        {
            transactionOver = false;

            while (!transactionOver)
            {
                CursorController.CursorOuter();

                hud.Draw();
                hud.Update(player, itemManager, questManager);

                CursorController.CursorInner(1, 4);
                Console.WriteLine("What would you like to buy?");

                int line = 6;
                for (int i = 0; i < tradeItems.Count; i++)
                {
                    string purchase = tradeItems[i];
                    string[] components = purchase.Split(',');
                    string item = components[0];
                    int cost = Int32.Parse(components[1]);

                    CursorController.CursorInner(1, line);
                    Console.WriteLine("(" + (i +1 ) + ") One " + item + " for " + cost + " gold.");
                    line += 2;
                }

                CursorController.CursorInner(1, line);
                Console.WriteLine("(Q) Exit Trader");

                CursorController.InputAreaCursor(0, 1);

                Console.WriteLine("Choose: ");

                CursorController.InputAreaCursor(0, 9);

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Q:
                        transactionOver = true;
                        map.Draw();
                        break;
                    case ConsoleKey.D1:
                        RunPurchase(0, questManager, player);
                        break;
                    case ConsoleKey.D2:
                        if (tradeItems.Count > 1) RunPurchase(1, questManager, player);
                        break;
                    case ConsoleKey.D3:
                        if (tradeItems.Count > 2) RunPurchase(2, questManager, player);
                        break;
                    case ConsoleKey.D4:
                        if (tradeItems.Count > 3) RunPurchase(3, questManager, player);
                        break;
                    case ConsoleKey.D5:
                        if (tradeItems.Count > 4) RunPurchase(4, questManager, player);
                        break;
                    case ConsoleKey.D6:
                        if (tradeItems.Count > 5) RunPurchase(5, questManager, player);
                        break;
                    default:
                        break;
                }
            }
        }

        public void RunPurchase(int purchaseID, QuestManager questManager, Player player)
        {
            string purchase = tradeItems[purchaseID];
            string[] components = purchase.Split(',');
            string item = components[0];
            int cost = Int32.Parse(components[1]);

            int itemCount = itemManager.CountItems("gold");

            if (itemCount < cost)
            {
                CursorController.InputAreaCursor(0, 9);

                Console.Write("You don't have enough gold!");

            }
            else
            {

                itemManager.SpendGold(cost);
                itemManager.GiveItem(item);

                hud.Update(player, itemManager, questManager);

                CursorController.InputAreaCursor(0, 9);

                Console.Write("You purchased a " + item + " for " + cost + " gold!");
            }

            Console.ReadKey(true);
        }
    }
}
