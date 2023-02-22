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
        public Enemy(int x, int y, Map map, Player player) : base(x, y, map, player)
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
        }
        public void Update(Enemy enemy, Enemy enemy2, Enemy enemy3)
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
            //StatMe();
        }
        public void SpawnMe()
        {                        
            Draw(posX, posY); //draws the enemy on the map            
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
        private void StatMe(Enemy enemy)
        {
            for (int i = 0; i < 3; i++)
            {
                CursorController.EnemyStatsCursorInner(i);
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Enemy Stats");
                        break;
                    case 1:
                        Console.WriteLine("Health: " + health);
                        break;
                    case 2:
                        Console.WriteLine("Strength: " + strength);
                        break;                    
                    default:
                        break;
                }
            }
        }
    }
}
