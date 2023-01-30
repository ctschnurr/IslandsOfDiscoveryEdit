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
        public int EnemyPosx = origx + 10 * Map.scale, EnemyPosy = origy + 4 * Map.scale;
        public int OldEnemyPosx = origx + 10 * Map.scale, OldEnemyPosy = origy + 4 * Map.scale;
        public string e = "E";
        public int GetPOSx = 0, GetPOSy = 0;

        public static int enemyCount = 0;
        public void SpawnMe()
        {                        
            EnemyDraw(e, EnemyPosx, EnemyPosy); //draws the enemy on the map
        }

        public void MoveMe()
        {
            Random random = new Random();
            int enemyMove = random.Next(1, 5); //a random number to represent the four cardinal directions
            
        switch (enemyMove)
            {
                case 1:
                EnemyPosy--; 
                Map.WallCheck(EnemyPosx, EnemyPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    EnemyPosy++;
                }
                    break;

                case 2:
                EnemyPosx--;                
                Map.WallCheck(EnemyPosx, EnemyPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    EnemyPosx++;
                }
                    break;

                case 3:
                EnemyPosy++;                
                Map.WallCheck(EnemyPosx, EnemyPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    EnemyPosy--;
                }
                    break;

                case 4:
                EnemyPosx++;                
                Map.WallCheck(EnemyPosx, EnemyPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    EnemyPosx--;
                }
                    break;

                default:             
                    break;
            }
        }

        public void EnemyDraw(string e, int EnemyPosx, int EnemyPosy)
        {
            Console.SetCursorPosition(origx + EnemyPosx, origy + EnemyPosy);
            Console.Write(e);
        }

        public void GetEnemyPOS()
        {
            GetPOSx = EnemyPosx;
            GetPOSy = EnemyPosy;
        }
    }

}
