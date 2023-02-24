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
            ClearPlayer();
            StatPlayer(player, itemManager);
        }
        private void ClearPlayer()
        {
            for (int i = 0; i < 10; i++)
            {
                CursorController.PlayerStatsCursorInner(i);
                Console.WriteLine("                 ");
            }
        }
        private static void ClearEnemy()
        {
            for (int i = 0; i < 10; i++)
            {
                CursorController.EnemyStatsCursorInner(i);
                Console.WriteLine("                 ");
            }
        }

        public static void ClearInputArea()
        {
            for (int i = 0; i < 5; i++)
            {
                CursorController.InputAreaCursor(i, 0);
                Console.WriteLine("                                                                 ");
            }
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
                        foreach (string item in itemManager.PlayerInv)
                        {
                            Console.WriteLine("Inventory: " + item);
                            i++;
                            CursorController.PlayerStatsCursorInner(i);
                        }                        
                        break;
                    default:
                        break;
                }
            }
        }

        public static void StatEnemy(Enemy enemy)
        {
            ClearEnemy();
            for (int i = 0; i < 4; i++)
            {
                CursorController.EnemyStatsCursorInner(i);
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Enemy Stats");
                        break;
                    case 1:
                        Console.WriteLine("Name: " + enemy.name);
                        break;
                    case 2:
                        Console.WriteLine("Health: " + enemy.health);
                        break;
                    case 3:
                        Console.WriteLine("Strength: " + enemy.strength);
                        break;                    
                    default:
                        break;
                }
            }
        }
    }
}
