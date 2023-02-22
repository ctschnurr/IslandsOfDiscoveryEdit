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
        public int level { get; set; }
        public int xp { get; set; }
        
        public Player(int x, int y, Map map, Player player) : base(x, y, map, player)
        {
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = "P";
            corpse = "X";
            dead = false;
            level = 1;
            basehealth = 25;
            basespeed = 5;
            basestrength = 5;
            health = basehealth + level;            
            strength = basestrength + level;
            xp = 0;
            base.map = map;
            base.player = player;
        }

        public void Update(Enemy enemy, Enemy enemy2, Enemy enemy3, ItemManager itemManager)
        {
            GetMyPOS();
            PlayerChoice();
            WallCheck(posX, posY);
            CombatManager.FightCheck(posX, posY, enemy.posX, enemy.posY, enemy2.posX, enemy2.posY, enemy3.posX, enemy3.posY);
            if (moveRollBack == true || CombatManager.moveRollBack == true)
            {
                CombatManager.moveRollBack = false;
                moveRollBack = false;
                ResetMyPOS();
            }
            map.Redraw(oldPosX, oldPosY);
            //StatMe(itemManager);            
        }

        public void PlayerChoice()
        {
            CursorController.InputAreaCursor(0, 0);

            Console.WriteLine("Press 'W' to move North, 'A' to move West, 'S' to move South, or 'D' to move East. Press 'ESC' to Quit.");
           
            CursorController.InputAreaCursor(0, 0);

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    GameManager.gameOver = true;
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

        override protected void WallCheck(int x, int y)     //checks to see if the character is allowed to move onto the map location
        {
            if (x > map.cols || x < 0 + 1)                  //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else if (y > map.rows || y < 0 + 1)             //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else
            {
                switch (map.map[y - 1, x - 1])
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
