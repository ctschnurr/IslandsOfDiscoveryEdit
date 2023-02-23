﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Enemy : Character
    {      
        private int enemyCount = 0;        
        public Enemy(int x, int y, Map map, Player player, ItemManager itemManager) : base(x, y, map, player, itemManager)
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
            base.map = map;
            this.player = player;
            this.itemManager = itemManager;
        }
        public void Update(Enemy enemy, Enemy enemy2, Enemy enemy3)
        {
            if (enemyCount == 0)
            {
                SpawnMe();
            }
            DeathCheck(itemManager);
            if (dead == false)
            {
                GetMyPOS();
                MoveMe();
                WallCheck(posX, posY, itemManager);
                if (moveRollBack == true)
                {
                    moveRollBack = false;
                    ResetMyPOS();                
                }
                FightCheck(player, enemy, enemy2, enemy3);
                if (makeAttack == true)
                {
                    makeAttack = false;
                    ResetMyPOS();                    
                    HUD.StatEnemy(this);
                    player.TakeDamage(strength);
                    CursorController.InputAreaCursor(3, 0);
                    Console.WriteLine("Player takes " + strength + " damage!");
                }
                if (moveRollBack == true)
                {
                    moveRollBack = false;
                    ResetMyPOS();
                }
                DeathCheck(itemManager);
                map.Redraw(oldPosX, oldPosY);
            }
        }
        public void SpawnMe()
        {                        
            Draw(posX, posY); //draws the enemy on the map            
        }

        public void TakeDamage(int damage)
        {
            health = health - damage;
        }

        public void MoveMe()
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
            }
        }
    }
}
