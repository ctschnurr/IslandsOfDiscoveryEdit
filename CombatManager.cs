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
        public static void FightCheck(int playerx, int playery, int enemyx, int enemyy)
        {
            if (playerx == enemyx && playery == enemyy)
            {
                moveRollBack = true;
                startFight = true;                
            }
            else if (enemyx == playerx && enemyy == playery)
            {
                moveRollBack = true;
                startFight = true;
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
