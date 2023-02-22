using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class HUD
    {      
        private bool firstRender = true;

        public void Draw()
        {   
            
        }
        public void Print()
        {
            string[] hudBorders = File.ReadAllLines(@"Maps_and_Overlays/HudBorders.txt");

            for (int y = 0; y < hudBorders.GetLength(0); y++)
            {
                Console.WriteLine(hudBorders[y]);
            }
        }

        public void Update(Player player, ItemManager itemManager)
        {
            if (firstRender)
            {
                Print();
                firstRender = false;
            }
            StatPlayer(player, itemManager);
        }

        private void StatPlayer(Player player, ItemManager itemManager)
        {
            for (int i = 0; i < 6; i++)
            {
                CursorController.PlayerStatsCursorInner(i);
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Player Stats");
                        break;
                    case 1:
                        Console.WriteLine("Level: " + player.level);
                        break;
                    case 2:
                        Console.WriteLine("XP: " + player.xp);
                        break;
                    case 3:
                        Console.WriteLine("Health: " + player.health);
                        break;
                    case 4:
                        Console.WriteLine("Strength: " + player.strength);
                        break;                    
                    case 5:
                        Console.WriteLine("Inventory: " + itemManager.PlayerInv.First());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
