using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Player : Character
    {
        //change the starting position to be random based on valid map positions
        public int PlayerPosx = origx + 8 * Map.scale, PlayerPosy = origy + 4 * Map.scale;
        public int OldPlayerPosx = origx + 8 * Map.scale, OldPlayerPosy = origy + 4 * Map.scale;
        public string p = "P";
        public ConsoleKeyInfo key;        
        public int GetPOSx = 0, GetPOSy = 0;        

        public void PlayerChoice(int playerx, int playery, int enemyx, int enemyy)
        {
            Console.WriteLine(); //leaving space for debug code
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press 'W' to move North, 'A' to move West, 'S' to move South, or 'D' to move East. Press 'ESC' to Quit.");

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Program.gameOver = true;
                    break;
                case ConsoleKey.W:
                    PlayerPosy--;
                    Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                    Console.WriteLine("Player position is: " + PlayerPosx + " " + PlayerPosy);
                    Map.WallCheck(PlayerPosx, PlayerPosy);
                    CombatManager.FightCheck(playerx, playery, enemyx, enemyy); //this will change when there's more than one enemy
                    if (Map.moveRollBack == true)
                    {
                        Map.moveRollBack = false;
                        PlayerPosy++;
                    }                    
                    break;
                case ConsoleKey.A:
                    PlayerPosx--;
                    Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                    Console.WriteLine("Player position is: " + PlayerPosx + " " + PlayerPosy);
                    Map.WallCheck(PlayerPosx, PlayerPosy);
                    CombatManager.FightCheck(playerx, playery, enemyx, enemyy); //this will change when there's more than one enemy
                    if (Map.moveRollBack == true)
                    {
                        Map.moveRollBack = false;
                        PlayerPosx++;
                    }
                    break;
                case ConsoleKey.S:
                    PlayerPosy++;
                    Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                    Console.WriteLine("Player position is: " + PlayerPosx + " " + PlayerPosy);
                    Map.WallCheck(PlayerPosx, PlayerPosy);
                    CombatManager.FightCheck(playerx, playery, enemyx, enemyy); //this will change when there's more than one enemy
                    if (Map.moveRollBack == true)
                    {
                        Map.moveRollBack = false;
                        PlayerPosy--;
                    }
                    break;
                case ConsoleKey.D:
                    PlayerPosx++;
                    Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                    Console.WriteLine("Player position is: " + PlayerPosx + " " + PlayerPosy);
                    Map.WallCheck(PlayerPosx, PlayerPosy);
                    CombatManager.FightCheck(playerx, playery, enemyx, enemyy); //this will change when there's more than one enemy
                    if (Map.moveRollBack == true)
                    {
                        Map.moveRollBack = false;
                        PlayerPosx--;
                    }
                    break;
                default:
                    break;
            }
        }
        public void PlayerDraw(string p, int PlayerPosx, int PlayerPosy)
        {
            Console.SetCursorPosition(origx + PlayerPosx, origy + PlayerPosy);
            Console.Write(p);
        }

        public void GetPlayerPOS()
        {
            GetPOSx = PlayerPosx;
            GetPOSy = PlayerPosy;
        }
    }
}
