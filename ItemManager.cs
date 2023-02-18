using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    private bool firstRun = true;
    internal class ItemManager
    {    
        public PlayerInv()                                  //constructor for the player inventory
        {
            List<string> PlayerInv = new List<string>();    //player inventory list
        }
        public TreasureInv()
        {
            List<string> TreasureInv = new List<string>();
        }
    }

    public string PlayerInv { get; set; }                   //getter/setter for the player inventory
    public string TreasureInv{ get; set; }                  //getter/setter for the master treasure list

    public void InitTreasureInv()
    {
        TreasureInv.Add("boat");
        TreasureInv.Add("sword");
        TreasureInv.Add("key");        
    }

    public void InvUpdate()
    {
        if (firstRun == true)
        {
            InitTreasureInv();
            firstRun = false;
        }
    }
}