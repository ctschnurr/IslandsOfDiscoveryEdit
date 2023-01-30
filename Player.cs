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
        public static int PlayerPosx = origx + 8 * Map.scale, PlayerPosy = origy + 4 * Map.scale;
        public static int OldPlayerPosx = origx + 8 * Map.scale, OldPlayerPosy = origy + 4 * Map.scale;
        public static string p = "P";
        public static ConsoleKeyInfo key;
        public static int GetPOSx = 0, GetPOSy = 0;

        //basehealth = 30;

        public static void PlayerChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Press 'W' to move North, 'A' to move West, 'S' to move South, or 'D' to move East. Press 'ESC' to Quit.");

            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Program.gameOver = true;
            }
            else if (key.Key == ConsoleKey.W)
            {
                PlayerPosy--;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                Console.WriteLine("Player position is: " + PlayerPosx + " " + PlayerPosy);
                Map.WallCheck(PlayerPosx, PlayerPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    PlayerPosy++;
                }
            }
            else if (key.Key == ConsoleKey.A)
            {
                PlayerPosx--;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                Console.WriteLine("Player position is: " + PlayerPosx + " " + PlayerPosy);
                Map.WallCheck(PlayerPosx, PlayerPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    PlayerPosx++;
                }
            }
            else if (key.Key == ConsoleKey.S)
            {
                PlayerPosy++;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                Console.WriteLine("Player position is: " + PlayerPosx + " " + PlayerPosy);
                Map.WallCheck(PlayerPosx, PlayerPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    PlayerPosy--;
                }
            }
            else if (key.Key == ConsoleKey.D)
            {
                PlayerPosx++;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                Console.WriteLine("Player position is: " + PlayerPosx + " " + PlayerPosy);
                Map.WallCheck(PlayerPosx, PlayerPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    PlayerPosx--;
                }
            }
        }
        public static void PlayerDraw(string p, int PlayerPosx, int PlayerPosy)
        {
            Console.SetCursorPosition(origx + PlayerPosx, origy + PlayerPosy);
            Console.Write(p);
        }

        public static void GetPlayerPOS()
        {
            GetPOSx = PlayerPosx;
            GetPOSy = PlayerPosy;
        }
    }
}
