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
        public void PlayerUpdate(int enemyPosX, int enemyPosY)
        {
            GetMyPOS();
            PlayerChoice();
            Map.WallCheck(posX, posY);
            CombatManager.FightCheck(posX, posY, enemyPosX, enemyPosY);
            if (Map.moveRollBack == true || CombatManager.moveRollBack == true)
            {
                CombatManager.moveRollBack = false;
                Map.moveRollBack = false;
                ResetMyPOS();                
            }
            Map.Redraw(oldPosX, oldPosY);
            PlayerDraw(posX, posY);            
        }

        public void PlayerChoice()
        {
            CursorController.InputAreaCursor();

            Console.WriteLine("Press 'W' to move North, 'A' to move West, 'S' to move South, or 'D' to move East. Press 'ESC' to Quit.");

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Program.gameOver = true;
                    break;
                case ConsoleKey.W:
                    posY--;
                    break;
                case ConsoleKey.A:
                    posX--;                    
                    break;
                case ConsoleKey.S:
                    posY++;                    
                    break;
                case ConsoleKey.D:
                    posX++;                   
                    break;
                default:
                    break;
            }
        }

        public void PlayerDraw(int posX, int posY)
        {
            CursorController.CharacterPrintCursor(posX, posY); 
            if (dead == false)
            {
                Console.Write(character);
            }
            else if (dead == true)
            {
                Console.Write(corpse);
            }
        }

        public void GetMyPOS()
        {
            oldPosX = posX;
            oldPosY = posY;
        }
        public void ResetMyPOS()        //replace the old rollback system
        {
            posX = oldPosX;
            posY = oldPosY;
        }
    }
}
