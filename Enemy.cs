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
        private int x = 12;
        private int y = 11;

        Map map;
        public Enemy()
        {
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = "@";            
            corpse = "x";            
            dead = false;
            basehealth = 10;
            basespeed = 3;
            basestrength = 3;
            health = basehealth;
            speed = basespeed;
            strength = basestrength;
        }
        public void Update(Player player, Enemy enemy, Enemy enemy2, Enemy enemy3)
        {
            if (enemyCount == 0)
            {
                SpawnMe();
            }
            GetMyPOS();
            MoveMe();
            WallCheck(posX, posY);
            CombatManager.FightCheck(player.posX, player.posY, enemy.posX, enemy.posY, enemy2.posX, enemy2.posY, enemy3.posX, enemy3.posY);
            if (moveRollBack == true || CombatManager.moveRollBack == true)
            {
                CombatManager.moveRollBack = false;
                moveRollBack = false;
                ResetMyPOS();                
            }
            map.Redraw(oldPosX, oldPosY);            
        }
        public void SpawnMe()
        {                        
            Draw(posX, posY); //draws the enemy on the map            
        }

        public void MoveMe()
        {
            Random random = new Random();
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
    }
}
