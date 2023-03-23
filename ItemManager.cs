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
        
        public List<string> MasterTreasureList;     // item name, amount
        public List<string> PlayerInventory;
        public List<string>[] EnemyInventory;

        public ItemManager(Globals globals)                                    // constructor for Item Manager
        {             
            this.globals = globals;
            MasterTreasureList = new List<string>();
            PlayerInventory = new List<string>();
            EnemyInventory = new List<string>[globals.maxEnemies];
                        
            InitTreasureInv();            
        }        

        public void InitTreasureInv()                           // initializes the starting master treasure list
        {
            MasterTreasureList.Add("boat");
            MasterTreasureList.Add("key");
            for (int i = 0; i < globals.maxEnemies * 2; i++)
            {
                MasterTreasureList.Add("potion");
            }
            for (int j = 0; j < globals.maxEnemies * 5; j++)
            {
                MasterTreasureList.Add("gold");
            }
        }        
                
        public void CreateEnemyInv(string name, int id)
        {
            int randNum; 

            switch (name)
            {
                case Globals.treasureName:
                    int treasureRandNum = globals.random.Next(1, 4);                        // the amount of items the enemy will have
                    EnemyInventory[id] = new List<string>();
                    for (int x = 0; x < treasureRandNum; x++)
                    {
                        randNum = globals.random.Next(0, MasterTreasureList.Count());       // random number no more than the length of the list
                        if (MasterTreasureList.Contains("key") || MasterTreasureList.Contains("boat"))  // assures that plot critical items are distributed to chests
                        {
                            for (int y = 0; y < MasterTreasureList.Count(); y++)
                            {
                                if (MasterTreasureList[y] == "key")
                                {
                                    EnemyInventory[id].Add(MasterTreasureList.ElementAt(y));
                                    MasterTreasureList.Remove(MasterTreasureList.ElementAt(y));
                                }
                                else if (MasterTreasureList[y] == "boat")
                                {
                                    EnemyInventory[id].Add(MasterTreasureList.ElementAt(y));
                                    MasterTreasureList.Remove(MasterTreasureList.ElementAt(y));
                                }
                            }
                        }
                        else
                        {
                            EnemyInventory[id].Add(MasterTreasureList.ElementAt(randNum));      // adds to the enemy inventory the inventory item at the random location in the master list
                            MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));   // removes the previous item from the master inventory list
                        }
                    }
                    break;
                case Globals.slimeName:                    
                    int slimeRandNum = globals.random.Next(1, globals.maxEnemies / 6);      // the amount of items the enemy will have
                    EnemyInventory[id] = new List<string>();
                    for (int x = 0; x < slimeRandNum; x++)
                    {
                        randNum = globals.random.Next(0, MasterTreasureList.Count());       // random number no more than the length of the list
                        EnemyInventory[id].Add(MasterTreasureList.ElementAt(randNum));      // adds to the enemy inventory the inventory item at the random location in the master list
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));   // removes the previous item from the master inventory list
                    } 
                    break;
                    
                case Globals.wyvernName:                    
                    int wyvernRandNum = globals.random.Next(1, globals.maxEnemies / 2);
                    EnemyInventory[id] = new List<string>();
                    for (int x = 0; x < wyvernRandNum; x++)
                    {
                        randNum = globals.random.Next(0, MasterTreasureList.Count());                        
                        EnemyInventory[id].Add(MasterTreasureList.ElementAt(randNum));
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));
                    }                    
                    break;
                case Globals.seaserpentName:                    
                    int seaserpentRandNum = globals.random.Next(1, globals.maxEnemies);
                    Debug.Assert(id < globals.maxEnemies);
                    EnemyInventory[id] = new List<string>();
                    for (int x = 0; x < seaserpentRandNum; x++)
                    {
                        randNum = globals.random.Next(0, MasterTreasureList.Count());                        
                        EnemyInventory[id].Add(MasterTreasureList.ElementAt(randNum));
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));
                    }                    
                    break;
                case Globals.dragonName:                    
                    Debug.Assert(id < globals.maxEnemies);
                    EnemyInventory[id] = new List<string>();
                    for (int x = 0; x < MasterTreasureList.Count; x++)
                    {                        
                        EnemyInventory[id].Add(MasterTreasureList.ElementAt(x));
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(x));
                    }
                    break;
                default:                    
                    break;
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
                if (amount != 0)
                {
                    Debug.WriteLine(amount);
                    for (int i = 0; i < amount; i++)
                    {
                        Debug.WriteLine(victim.itemManager.EnemyInventory[victim.myID].ElementAt(i));
                        PlayerInventory.Add(victim.itemManager.EnemyInventory[victim.myID].ElementAt(i));
                    }
                    victim.itemManager.EnemyInventory[victim.myID].Clear();
                }
            }
            else
            {
                int amount = victim.itemManager.EnemyInventory[victim.myID].Count();
                if (amount != 0)
                {
                    Debug.WriteLine(amount);
                    for (int i = 0; i < amount; i++)
                    {
                        Debug.WriteLine(victim.itemManager.EnemyInventory[victim.myID].ElementAt(i));
                        aggressor.itemManager.EnemyInventory[aggressor.myID].Add(victim.itemManager.EnemyInventory[victim.myID].ElementAt(i));
                    }
                    victim.itemManager.EnemyInventory[victim.myID].Clear();
                }
            }            
        }
    }
}