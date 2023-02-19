using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class ItemManager
    {

        private bool firstRun = true;
        
        List<string> treasureInv = new List<string>();          //field list for master treasure list
        List<string> playerInv = new List<string>();            //field list for player inventory list
        public ItemManager()                                    //constructor for Item Manager
        { 
            treasureInv = new List<string>();
            playerInv = new List<string>();
        }

        public string PlayerInv { get; set; }                   //getter/setter for the player inventory
        public string TreasureInv { get; set; }                 //getter/setter for the master treasure list

        public void InitTreasureInv()                           //initializes the starting master treasure list
        {
            treasureInv.Add("boat");
            treasureInv.Add("sword");
            treasureInv.Add("key");
        }

        public void Update()                                 //updates the inventory system
        {
            if (firstRun == true)
            {
                InitTreasureInv();
                firstRun = false;
            }
        }

        public void Reward()
        {
            if (playerInv.Contains("boat"))                     //if the player has already earned the boat, they will get the remaining treasure
            {
                CursorController.InputAreaCursor(0, 0);
                foreach (string item in treasureInv)
                {
                    Console.WriteLine("You've received " + item + "!");
                }
                playerInv.AddRange(treasureInv);
            }
            else                                                //if the player has not earned the boat, they will get the boat
            {
                CursorController.InputAreaCursor(0, 0);
                Console.WriteLine("You've received the " + treasureInv.First() + "!");
                playerInv.Add(treasureInv.First());
            }
        }
    }
}