using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Enemy : Character
    {
        //change the enemy spawn position to be random based on valid map positions/spawners
        //public int EnemyPosx = origx + 12 * Map.scale, EnemyPosy = origy + 4 * Map.scale;
        //public int OldEnemyPosx = origx + 12 * Map.scale, OldEnemyPosy = origy + 4 * Map.scale;        
        //public int GetPOSx = 0, GetPOSy = 0;
        //public static int enemyCount = 0;

        public Enemy(int x, int y) : base()
        {
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = "@";            
            corpse = "x";            
            dead = false;
        }
        public void SpawnMe()
        {                        
            EnemyDraw(posX, posY); //draws the enemy on the map
            Program.enemyCount++;
        }

        public void MoveMe()
        {
            Random random = new Random();
            int enemyMove = random.Next(1, 5); //a random number to represent the four cardinal directions
            
        switch (enemyMove)
            {
                case 1:
                posY--;
                EnemyUpdate();                
                Map.WallCheck(posX, posY);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    posY++;
                    EnemyUpdate();
                }
                    break;

                case 2:
                posX--;
                EnemyUpdate();
                Map.WallCheck(posX, posY);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    posX++;
                    EnemyUpdate();
                }
                    break;

                case 3:
                posY++;
                EnemyUpdate();
                Map.WallCheck(posX, posY);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    posY--;
                    EnemyUpdate();
                }
                    break;

                case 4:
                posX++;
                EnemyUpdate();
                Map.WallCheck(posX, posY);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    posX--;
                    EnemyUpdate();
                }
                    break;

                default:             
                    break;
            }
        }

        public void EnemyUpdate()
        {
            CursorController.InputAreaCursor();
            Console.WriteLine("Enemy position is: " + posX + " " + posY);
        }

        public void EnemyDraw(int posX, int posY)
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
        

        public void GetEnemyPOS()
        {
            oldPosX = posX;
            oldPosY = posY;
        }
    }

}
