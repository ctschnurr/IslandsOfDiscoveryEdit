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

        public Globals globals;
        private int returnedAmount;
        public HUD() 
        { 
            
        }
        public void Draw()
        {
            string[] hudBorders = File.ReadAllLines(Globals.borders);

            for (int y = 0; y < hudBorders.GetLength(0); y++)
            {
                Console.WriteLine(hudBorders[y]);
            }
        }

        public void Update(Player player, ItemManager itemManager, QuestManager questManager)
        {
            if (firstRender)
            {
                Draw();
                firstRender = false;
            }            
            ClearPlayer();
            StatPlayer(player, itemManager, questManager);
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

        private void StatPlayer(Player player, ItemManager itemManager, QuestManager questManager)
        {
            for (int i = 0; i < 11; i++)
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
                        Console.WriteLine("Health: " + player.Health);
                        break;
                    case 4:
                        Console.WriteLine("Strength: " + player.Strength);
                        break;                    
                    case 5:
                        returnedAmount = itemManager.CountItems("boat");
                        Console.WriteLine("Inv: Boat  x " + returnedAmount);
                        break;
                    case 6:
                        returnedAmount = itemManager.CountItems("key");
                        Console.WriteLine("Inv: Key  x " + returnedAmount);
                        break;
                    case 7:
                        returnedAmount = itemManager.CountItems("potion");
                        Console.WriteLine("Inv: Potion  x " + returnedAmount);
                        break;
                    case 8:
                        returnedAmount = itemManager.CountItems("gold");
                        Console.WriteLine("Inv: Gold  x " + returnedAmount);
                        break;
                    case 9:
                        string quest = questManager.GetQuest();
                        Console.WriteLine(quest);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void StatEnemy(Character character)
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
                        Console.WriteLine("Name: " + character.Name);
                        break;
                    case 2:
                        Console.WriteLine("Health: " + character.Health);
                        break;
                    case 3:
                        Console.WriteLine("Strength: " + character.Strength);
                        break;                    
                    default:
                        break;
                }
            }
        }
    }
}
