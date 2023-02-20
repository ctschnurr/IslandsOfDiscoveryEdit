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
        
        List<string> _treasureInv = new List<string>();          //field list for master treasure list
        List<string> _playerInv = new List<string>();            //field list for player inventory list
        public ItemManager()                                    //constructor for Item Manager
        { 
            _treasureInv = new List<string>();
            _playerInv = new List<string>();
        }

        public string _PlayerInv { get; set; }                   //getter/setter for the player inventory
        public string _TreasureInv { get; set; }                 //getter/setter for the master treasure list

        public void InitTreasureInv()                           //initializes the starting master treasure list
        {
            _treasureInv.Add("boat");
            _treasureInv.Add("sword");
            _treasureInv.Add("key");
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
            if (_playerInv.Contains("boat"))                     //if the player has already earned the boat, they will get the remaining treasure
            {
                CursorController.InputAreaCursor(0, 0);
                foreach (string item in _treasureInv)
                {
                    Console.WriteLine("You've received a " + item + "!");
                }
                _playerInv.AddRange(_treasureInv);
                _treasureInv.Clear();
            }
            else                                                //if the player has not earned the boat, they will get the boat
            {
                CursorController.InputAreaCursor(0, 0);
                Console.WriteLine("You've received the " + _treasureInv.First() + "!");
                _playerInv.Add(_treasureInv.First());
                _treasureInv.Remove(_treasureInv.First());
            }
        }
    }
}