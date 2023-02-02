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
        public int EnemyPosx = origx + 12 * Map.scale, EnemyPosy = origy + 4 * Map.scale;
        public int OldEnemyPosx = origx + 12 * Map.scale, OldEnemyPosy = origy + 4 * Map.scale;
        public string e = "E";
        public int GetPOSx = 0, GetPOSy = 0;

        public int EnemyPos;
        //public static int enemyCount = 0;

        public Enemy(int x, int y) : base()
        {
            posX = x;
            posY = y;
            character = '@';
            EnemyPos = POS[posX, posY];
        }
        public void SpawnMe()
        {                        
            EnemyDraw(e, EnemyPosx, EnemyPosy); //draws the enemy on the map
            Program.enemyCount++;
        }

        public void MoveMe()
        {
            Random random = new Random();
            int enemyMove = random.Next(1, 5); //a random number to represent the four cardinal directions
            
        switch (enemyMove)
            {
                case 1:
                EnemyPosy--;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 3);
                Console.WriteLine("Enemy position is: " + EnemyPosx + " " + EnemyPosy);
                Map.WallCheck(EnemyPosx, EnemyPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    EnemyPosy++;
                }
                    break;

                case 2:
                EnemyPosx--;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 3);
                Console.WriteLine("Enemy position is: " + EnemyPosx + " " + EnemyPosy);
                Map.WallCheck(EnemyPosx, EnemyPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    EnemyPosx++;
                }
                    break;

                case 3:
                EnemyPosy++;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 3);
                Console.WriteLine("Enemy position is: " + EnemyPosx + " " + EnemyPosy);
                Map.WallCheck(EnemyPosx, EnemyPosy);
                if (Map.moveRollBack == true)
                {
                    Map.moveRollBack = false;
                    EnemyPosy--;
                }
                    break;

                case 4:
                EnemyPosx++;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 3);
                Console.WriteLine("Enemy position is: " + EnemyPosx + " " + EnemyPosy);
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
