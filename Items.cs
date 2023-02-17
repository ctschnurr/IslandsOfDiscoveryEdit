using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Items
    {
        public bool hasBoat = false;
        public bool hasSword = false;
        public bool hasKey = false;

        list<string> inventory = new list<string>();
        inventory.Add("boat");
        inventory.Add("sword");
        inventory.Add("key");
    }
}