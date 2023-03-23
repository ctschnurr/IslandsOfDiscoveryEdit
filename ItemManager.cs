using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class ItemManager
    {
        public Globals globals;
                
        private int potionHealAmount = 10;        
        
        public List<Tuple<string, int>> MasterTreasureList;     // item name, amount
        public List<Tuple<string, int>> PlayerInventory;
        public List<Tuple<string, int>>[] EnemyInventory;

        public ItemManager(Globals globals)                                    // constructor for Item Manager
        {             
            this.globals = globals;
            MasterTreasureList = new List<Tuple<string, int>>();
            PlayerInventory = new List<Tuple<string, int>>();
                        
            InitTreasureInv();            
        }        

        public void InitTreasureInv()                           // initializes the starting master treasure list
        {
            MasterTreasureList.Add(new Tuple<string, int>("boat", 1));
            MasterTreasureList.Add(new Tuple<string, int>("key", 1));
            MasterTreasureList.Add(new Tuple<string, int>("potion", globals.maxEnemies * 2));
            MasterTreasureList.Add(new Tuple<string, int>("gold", globals.maxEnemies * 5));
        }

        public List<Tuple<string, int>> CreateEnemyInv(string name, int id)
        {
            int randNum;
            int listLength = MasterTreasureList.Count();
            
            Debug.WriteLine("Creating " + name + " inventory."); // name and id are coming through null -> why?; also there's one extra list entry -> should be equal to max enemies

            switch (name)
            {
                case Globals.slimeName:                    
                    int slimeRandNum = globals.random.Next(1, globals.maxEnemies / 6);      // the amount of items the enemy will have
                    for (int x = 0; x < slimeRandNum; x++)
                    {
                        randNum = globals.random.Next(0, listLength);                       // random number no more than the length of the list
                        EnemyInventory[id].Add(MasterTreasureList.ElementAt(randNum));                // adds to the enemy inventory the inventory item at the random location in the master list
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));   // removes the previous item from the master inventory list
                    }

                    //int itemCount = EnemyInventory[id].Count;
                    //for (int i = 0; i < itemCount; i++)
                    //{
                    //    Debug.WriteLine(EnemyInventory[id].ElementAt(i));
                    //}
                    return EnemyInventory[id]; 
                    
                case Globals.wyvernName:                    
                    int wyvernRandNum = globals.random.Next(1, globals.maxEnemies / 2);
                    for (int x = 0; x < wyvernRandNum; x++)
                    {
                        randNum = globals.random.Next(0, listLength);
                        EnemyInventory[id].Add(MasterTreasureList.ElementAt(randNum));
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));
                    }
                    return EnemyInventory[id];                    
                case Globals.seaserpentName:                    
                    int seaserpentRandNum = globals.random.Next(1, globals.maxEnemies);
                    for (int x = 0; x < seaserpentRandNum; x++)
                    {
                        randNum = globals.random.Next(0, listLength);
                        EnemyInventory[id].Add(MasterTreasureList.ElementAt(randNum));
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));
                    }
                    return EnemyInventory[id];                    
                default:
                    return null;                    
            }            
        }

        public void Update()                                    // updates the inventory system
        {
            
        }
        public void CheckForPotion(Player player)
        {
            System.Collections.IList 
            list = PlayerInventory;

            for (int i = 0; i < list.Count; i++)
            {
                string item = (string)list[i];
                if (item == "potion")
                {                    
                    player.HealthIncrease(potionHealAmount);
                }               
            }         
        }

        public void Reward(Character aggressor, Character victim)
        {
            if (aggressor.Name == "Player")
            {
                int amount = victim.itemManager.EnemyInventory[victim.myID].Count();
                for (int i = 0; i == amount; i++)
                {
                    PlayerInventory.Add(victim.itemManager.EnemyInventory[victim.myID].ElementAt(i));
                }
                victim.itemManager.EnemyInventory[victim.myID].Clear();
            }
            else
            {
                int amount = victim.itemManager.EnemyInventory[victim.myID].Count();
                for (int i = 0; i == amount; i++)
                {
                    aggressor.itemManager.EnemyInventory[aggressor.myID].Add(victim.itemManager.EnemyInventory[victim.myID].ElementAt(i));
                }
                victim.itemManager.EnemyInventory[victim.myID].Clear();
            }            
        }
    }
}