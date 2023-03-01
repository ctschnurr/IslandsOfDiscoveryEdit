using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Enemy : Character
    {      
        private int enemyCount = 0;
        protected int xpValue;
        protected int moveEnergy;
        protected int energyToMove;
        public Enemy(int x, int y, Map map, Player player, ItemManager itemManager, HUD hud, CursorController cursorController) : base(x, y, map, player, itemManager, hud, cursorController)
        {
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = "@";            
            corpse = "x";
            dead = false;
            health = basehealth;            
            strength = basestrength;
            xpValue = 0;
            moveEnergy = 0;
            base.map = map;
            this.player = player;
            this.itemManager = itemManager;
            this.hud = hud;
            this.cursorController = cursorController;
        }
        public void Update(Enemy enemy, Enemy enemy2, Enemy enemy3)
        {
            SpawnMe();            
            DeathCheck(itemManager);
            if (dead == false)
            {
                StoreMyPOS();
                MoveMe();
                ObstacleCheck(posX, posY, itemManager);
                UndoMoveCheck();
                CheckForFight(player, enemy, enemy2, enemy3);
                Fight();
                UndoMoveCheck();
                DeathCheck(itemManager);
                map.Redraw(oldPosX, oldPosY);
            }
        }

        private void Fight()
        {
            if (makeAttack == true)
            {
                makeAttack = false;
                ResetMyPOS();
                HUD.StatEnemy(this);
                player.HealthDecrease(strength);                
            }
        }
        public void SpawnMe()
        {                        
            Draw(posX, posY); //draws the enemy on the map            
        }

        //public void HealthDecrease(int amount)
        //{
        //    health -= amount;
        //}

        public void MoveMe()
        {
            moveEnergy += 100;
            if (moveEnergy >= energyToMove)
            {
                int enemyMove = random.Next(1, 5); //a random number to represent the four cardinal directions
            
                switch (enemyMove)
                {
                    case 1:
                    posY--;
                        break;

                    case 2:
                    posX--;
                        break;

                    case 3:
                    posY++;                
                        break;

                    case 4:
                    posX++;              
                        break;

                    default:             
                        break;
                }
                moveEnergy -= energyToMove;
            }
        }        
        private void DeathCheck(ItemManager itemManager)
        {
            if (dead == true)
            {
                return;
            }
            else if (health <= 0)
            {
                health = 0;
                HUD.StatEnemy(this);
                dead = true;
                itemManager.Reward();
                player.xp = player.xp + xpValue;
            }
        }
    }
}
