using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class CombatManager
    {
        public static bool startFight = false;
        public static bool moveRollBack = false;        
        public static void FightCheck(int playerx, int playery, int enemyx, int enemyy, int enemy2x, int enemy2y, int enemy3x, int enemy3y)
        {
            if (playerx == enemyx && playery == enemyy || playerx == enemy2x && playery == enemy2y || playerx == enemy3x && playery == enemy3y)  //compares player location to enemy locations
            {
                moveRollBack = true;
                startFight = true;                
            }
            else if (enemyx == playerx && enemyy == playery || enemy2x == playerx && enemy2y == playery || enemy3x == playerx && enemy3y == playery) //compares enemy locations to player location
            {
                moveRollBack = true;
                startFight = true;
            }
            else if (enemyx == enemy2x && enemyy == enemy2y || enemyx == enemy3x && enemyx == enemy3y) //compares enemy 1 to other two enemies
            {
                moveRollBack = true;
            }
            else if (enemy2x == enemyx && enemy2y == enemyy || enemy2x == enemy3x && enemy2x == enemy3y) //compares enemy 2 to other two enemies
            {
                moveRollBack = true;
            }
            else if (enemy3x == enemyx && enemy3y == enemyy || enemy3x == enemy2x && enemy3y == enemy2y) //compares enemy 3 to other two enemies
            {
                moveRollBack = true;
            }
            return;
        }
        public static void Combat()
        {            
            Random random = new Random();
            int chance = random.Next(1,5);
            if (chance < 3)
            {
                CursorController.InputAreaCursor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("game over");
                startFight = false; 
            }
            else
            {
                CursorController.InputAreaCursor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("enemy dies");
                startFight = false;                                
            }            
        }
    }

}
