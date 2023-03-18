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

        private Character target;
        
        public Player(int x, int y, Map map, Player player, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals) : base(x, y, map, itemManager, hud, cursorController, globals)
        {
            Name = globals.playerName;
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = globals.playerCharacter;
            corpse = globals.playerCorpse;
            dead = globals.isPlayerDead;
            level = globals.playerLevel;
            basehealth = globals.playerBasehealth;
            basespeed = globals.playerBasespeed;
            basestrength = globals.playerBasestrength;
            Health = basehealth;            
            Strength = basestrength + level;
            xp = 0;

            base.map = map;
            base.player = player;
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController; 
            base.globals = globals;
        }

        public void Update(CombatManager combatManager)
        {
            StoreMyPOS();                                               // stores the player's current POS for reference
            PlayerInput();                                              // takes player input and adjusts x/y position
            HUD.ClearInputArea();                                       // clears the input/output area to make room for future output
            if (map.BorderCheck(posX, posY))
            {
                ResetMyPOS();
            }
            Walkable(posX, posY);                                       // checks for legal moves and undoes the move if illegal
            target = combatManager.FightCheck(this);                    // checks to see if there is an enemy to battle and returns that enemy
            if (target != null)
            {
                ResetMyPOS();                                           // prevents moving on top of the enemy
                combatManager.Battle(this, target);                     // applies damage to the enemy
            }
            itemManager.CheckForPotion(this);                           // checks the player's inventory for a potion and uses it if found
            map.Redraw(oldPosX, oldPosY);                               // redraws the player's sprite on the map
            EndOfTurnChecks();                                          // variety of state checks (level up, death, gameover)
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
                    globals.gameOver = true;
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
        override protected void Walkable(int x, int y)
        {
            if (map.TerrainCheck('^', x, y))
            {
                ResetMyPOS();
            }
            else if (map.TerrainCheck('~', x, y))
            {
                if (!itemManager.PlayerInv.Contains("boat"))
                {
                    ResetMyPOS();
                }                
            }            
        }
        private void GameOverCheck()
        {
            if (dead == true)
            {
                globals.gameOver = true;
                CursorController.InputAreaCursor(2, 1);
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
                Strength = basestrength + level;
                CursorController.InputAreaCursor(3, 1);
                Console.WriteLine(Name + " has gained a level!");
            }
        }
    }
}
