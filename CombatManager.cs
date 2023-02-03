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
        public static void FightCheck(int playerx, int playery, int enemyx, int enemyy)
        {
            if (playerx == enemyx && playery == enemyy)
            {
                Map.moveRollBack = true;
                startFight = true;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 4);
                Console.WriteLine("Let's Fight!");
                return;
            }
            else if (enemyx == playerx && enemyy == playery)
            {
                Map.moveRollBack = true;
                startFight = true;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 4);
                Console.WriteLine("Let's Fight!");
                return;
            }
        }
        public static void Combat()
        {
            Random random = new Random();
            int chance = random.Next(1,5);
            if (chance < 3)
            {
                Console.WriteLine("game over");

                //Program.gameOver = true;
            }
            else
            {
                Console.WriteLine("enemy dies");
                //Enemy.dead = true;
                Program.enemyCount--;
                Console.WriteLine("enemy count is" + Program.enemyCount);
            }
            startFight = false;
        }
    }

}
