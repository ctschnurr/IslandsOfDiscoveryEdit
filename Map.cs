using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Map
    {
        //change this to load maps from a file/procedurally generated
        public static char[,] map = new char[,] // dimensions defined by following data:
        {
            {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
            {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
            {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','C','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','~','~','`','`','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
            {'`','`','`','`','~','`','`','~','~','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','∩','^','^','^','^','`','`','`'},
            {'`','`','`','`','`','~','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        };

        public static int rows = map.GetLength(0);
        public static int cols = map.GetLength(1);
        public static int scale = 1;
        public static bool firstmaprender = true;
        public static bool moveRollBack = false;

        public void Update()
        {
            if (firstmaprender == true)
            {
                //Console.Clear();
                firstmaprender = false;
                
                DisplayMap(scale);
            }
        }
        public void DisplayMap(int scale)
        {     
                int bordersize = cols * scale;
                Console.BackgroundColor = ConsoleColor.Black;

                for (int g = 0; g < 1; g++)
                {
                    Console.Write("╔");
                    for (int r = 0; r < bordersize; r++)
                    {
                        Console.Write("═");
                    }
                    Console.Write("╗");
                }

                Console.WriteLine();

                for (int x = 0; x < rows; x++)
                {
                    for (int m = 0; m < scale; m++)
                    {
                        Console.Write("║");
                        for (int y = 0; y < cols; y++)
                        {
                            for (int z = 0; z < scale; z++)
                            {
                                ColourCode(x, y);
                                Console.Write(map[x, y]);
                            }
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("║");
                        Console.WriteLine();
                    }
                }
                for (int g = 0; g < 1; g++)
                {
                    Console.Write("╚");
                    for (int r = 0; r < bordersize; r++)
                    {
                        Console.Write("═");
                    }
                    Console.Write("╝");
                }
                Console.WriteLine();
        }
        public static void ColourCode(int x, int y)
        {
            switch (map[x, y]) //checks the characters in the array and assigns them colours
            {
                case '^':
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case '`':
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case '~':
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case '*':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case '∩':
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case 'C':
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
        }
        public static void Redraw(int x, int y)
        {
            CursorController.CharacterPrintCursor(x, y);                            //sets the cursor position to the players previous location                  
            ColourCode(y - 1, x - 1);                                               //gets the appropriate colour for reprinting the previous position
            Console.Write(map[y - 1, x - 1]);                                       //writes the map array location at the player's previous location
            Console.BackgroundColor = ConsoleColor.Black;                           //resets the console color for normal printing        
        }

        //PUT THIS IN THE CHARACTER CLASS SO PLAYER AND ENEMY CAN USE DIFFERENT CHECKS YOU DOLT
        public static void WallCheck(int x, int y) //checks to see if the character is allowed to move onto the map location
        {
            if (x > cols || x < 0 + 1) //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else if (y > rows || y < 0 + 1) //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else
            {
                switch (map[y - 1, x - 1])
                {
                    case '^':
                        moveRollBack = true;
                        break;
                    case '~':
                        moveRollBack = true;
                        break;
                    default:
                        moveRollBack = false;
                        break;
                }
            }
        }       
    }
}
