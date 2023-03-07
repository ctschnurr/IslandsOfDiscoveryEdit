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

        private Enemy target;
        
        public Player(int x, int y, Map map, Player player, ItemManager itemManager, HUD hud, CursorController cursorController) : base(x, y, map, player, itemManager, hud, cursorController)
        {
            name = "Player";
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
            health = basehealth;            
            strength = basestrength + level;
            xp = 0;
            base.map = map;
            base.player = player;
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;
        }

        public void Update()
        {
            StoreMyPOS();                                               // stores the player's current POS for reference
            PlayerInput();                                              // takes player input and adjusts x/y position
            HUD.ClearInputArea();                                       // clears the input/output area to make room for future output
            ObstacleCheck(posX, posY, itemManager);                     // checks if the space the player wants to move to is traversible
            UndoMoveCheck();                                            // if the attempted move is illegal, moves the player back
            //target = CheckForFight(this, enemy, enemy2, enemy3);        // checks for a fight and returns the enemy that is being fought
            Fight();                                                    // if there is a fight, informs the target of how much damage it takes
            itemManager.CheckForPotion(this);                           // checks the player's inventory for a potion and uses it if found
            map.Redraw(oldPosX, oldPosY);                               // redraws the player's sprite on the map
            EndOfTurnChecks();                                          // variety of state checks (level up, death, gameover)
        }

        private void Fight()
        {
            if (makeAttack == true)
            {
                makeAttack = false;
                ResetMyPOS();
                target.HealthDecrease(strength);
            }
        }

        private void EndOfTurnChecks()
        {
            LevelIncrease();
            DeathCheck();
            GameOverCheck();
        }

        public void PlayerInput()
        {
            CursorController.InputAreaCursor(0, 0);

            Console.WriteLine("North(W), West(A), South(S), East(D). Press 'ESC' to Quit.");
           
            CursorController.InputAreaCursor(1, 0);

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

        override protected void ObstacleCheck(int x, int y, ItemManager itemManager)     //checks to see if the character is allowed to move onto the map location
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
                        if (itemManager.PlayerInv.Contains("boat"))
                        {
                            moveRollBack = false;
                        }
                        else
                        {
                            moveRollBack = true;
                        }                      
                        break;
                    default:
                        moveRollBack = false;
                        break;
                }
            }
        }
        private void GameOverCheck()
        {
            if (dead == true)
            {
                GameManager.gameOver = true;
                CursorController.InputAreaCursor(2, 0);
                Console.WriteLine("Game Over!");
                Console.ReadKey();
            }
        }

        private void LevelIncrease()
        {
            if (xp > level * 10)
            {
                xp -= level * 10;
                level++;
                strength = basestrength + level;
                CursorController.InputAreaCursor(3, 0);
                Console.WriteLine(name + " has gained a level!");
            }
        }
    }
}
