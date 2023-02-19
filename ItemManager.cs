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
        public ItemManager() { }                                //constructor for Item Manager?
        
        public string PlayerInv { get; set; }                   //getter/setter for the player inventory
        public string TreasureInv { get; set; }                 //getter/setter for the master treasure list

        public void InitTreasureInv()
        {
            
        }

        public void InvUpdate()
        {
            if (firstRun == true)
            {
                InitTreasureInv();
                firstRun = false;
            }
        }

        public void Reward()
        {

        }
    }
}