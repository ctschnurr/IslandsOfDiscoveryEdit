using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Player : Character
    {                
        public ConsoleKeyInfo key;
        
        public Player(int x, int y)
        {
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = "P";
            corpse = "X";            
            dead = false;
        }

        public void PlayerChoice()
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
                    posY--;
                    PlayerUpdate();
                    Map.WallCheck(posX, posY);                    
                    if (Map.moveRollBack == true)
                    {
                        Map.moveRollBack = false;
                        posY++;
                        PlayerUpdate(); //checks to make sure the player location is accurate
                    }                    
                    break;
                case ConsoleKey.A:
                    posX--;
                    PlayerUpdate();
                    Map.WallCheck(posX, posY);                    
                    if (Map.moveRollBack == true)
                    {
                        Map.moveRollBack = false;
                        posX++;
                        PlayerUpdate(); //checks to make sure the player location is accurate
                    }
                    break;
                case ConsoleKey.S:
                    posY++;
                    PlayerUpdate();
                    Map.WallCheck(posX, posY);                    
                    if (Map.moveRollBack == true)
                    {
                        Map.moveRollBack = false;
                        posY--;
                        PlayerUpdate(); //checks to make sure the player location is accurate
                    }
                    break;
                case ConsoleKey.D:
                    posX++;
                    PlayerUpdate();
                    Map.WallCheck(posX, posY);                    
                    if (Map.moveRollBack == true)
                    {
                        Map.moveRollBack = false;
                        posX--;
                        PlayerUpdate(); //checks to make sure the player location is accurate
                    }
                    break;
                default:
                    break;
            }
        }

        public void PlayerUpdate()
        {
            CursorController.InputAreaCursor();
            Console.WriteLine("Player position is: " + posX + " " + posY);
        }
        public void PlayerDraw(string p, int posX, int posY)
        {
            CursorController.CharacterPrintCursor(posX, posY);            
            Console.Write(p);
        }

        public void GetPlayerPOS()
        {
            oldPosX = posX;
            oldPosY = posY;
        }
    }
}
