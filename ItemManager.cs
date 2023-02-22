using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class ItemManager
    {        
        public List<string> PlayerInv { get; set; }             //getter/setter for the player inventory
        public List<string> TreasureInv { get; set; }           //getter/setter for the master treasure list

        public ItemManager()                                    //constructor for Item Manager
        { 
            TreasureInv = new List<string>();       
            PlayerInv = new List<string>();  
            InitTreasureInv();
        }        

        public void InitTreasureInv()                            //initializes the starting master treasure list
        {
            TreasureInv.Add("boat");
            TreasureInv.Add("sword");
            TreasureInv.Add("key");
        }

        public void Update()                                 //updates the inventory system
        {
                        
        }
        public bool BagCheck(string itemQuery)
        {
            if (PlayerInv.Count < 1)
            {
                return false;
            }
            else
            {
                foreach (string item in PlayerInv)
                {
                    if (item == itemQuery)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public void Reward()
        {
            if (PlayerInv.Contains("boat"))                     //if the player has already earned the boat, they will get the remaining treasure
            {
                int x = 1;
                foreach (string item in TreasureInv)
                {                    
                    CursorController.InputAreaCursor(x, 0);
                    Console.WriteLine("You've received a " + item + "!");
                    x++;
                }
                PlayerInv.AddRange(TreasureInv);
                TreasureInv.Clear();
            }
            else                                                //if the player has not earned the boat, they will get the boat
            {
                CursorController.InputAreaCursor(1, 0);                
                Console.WriteLine("You've received the " + TreasureInv.First() + "!");
                PlayerInv.Add(TreasureInv.First());
                TreasureInv.Remove(TreasureInv.First());
            }
        }
    }
}