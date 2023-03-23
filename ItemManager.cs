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
        public List<Tuple<string, int>> EnemyInv;

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

        public List<Tuple<string, int>> CreateEnemyInv(string name)
        {
            int randNum;
            int listLength = MasterTreasureList.Count();

            switch (name)
            {
                case Globals.slimeName:
                    EnemyInv = new List<Tuple<string, int>>();
                    int slimeRandNum = globals.random.Next(1, globals.maxEnemies / 6);      // the amount of items the enemy will have
                    for (int x = 0; x < slimeRandNum; x++)
                    {
                        randNum = globals.random.Next(0, listLength);                       // random number no more than the length of the list
                        EnemyInv.Add(MasterTreasureList.ElementAt(randNum));                // adds to the enemy inventory the inventory item at the random location in the master list
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));   // removes the previous item from the master inventory list
                    }
                    return EnemyInv;                    
                case Globals.wyvernName:
                    EnemyInv = new List<Tuple<string, int>>();
                    int wyvernRandNum = globals.random.Next(1, globals.maxEnemies / 2);
                    for (int x = 0; x < wyvernRandNum; x++)
                    {
                        randNum = globals.random.Next(0, listLength);
                        EnemyInv.Add(MasterTreasureList.ElementAt(randNum));
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));
                    }
                    return EnemyInv;                    
                case Globals.seaserpentName:
                    EnemyInv = new List<Tuple<string, int>>();
                    int seaserpentRandNum = globals.random.Next(1, globals.maxEnemies);
                    for (int x = 0; x < seaserpentRandNum; x++)
                    {
                        randNum = globals.random.Next(0, listLength);
                        EnemyInv.Add(MasterTreasureList.ElementAt(randNum));
                        MasterTreasureList.Remove(MasterTreasureList.ElementAt(randNum));
                    }
                    return EnemyInv;                    
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
                int amount = victim.itemManager.EnemyInv.Count();
                for (int i = 0; i == amount; i++)
                {
                    PlayerInventory.Add(victim.itemManager.EnemyInv.ElementAt(i));
                }
                victim.itemManager.EnemyInv.Clear();
            }
            else
            {
                int amount = victim.itemManager.EnemyInv.Count();
                for (int i = 0; i == amount; i++)
                {
                    aggressor.itemManager.EnemyInv.Add(victim.itemManager.EnemyInv.ElementAt(i));
                }
                victim.itemManager.EnemyInv.Clear();
            }            
        }
    }
}