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
                startFight = true;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 4);
                Console.WriteLine("Let's Fight!");
                return;
            }
            else if (enemyx == playerx && enemyy == playery)
            {
                startFight = true;
                Console.SetCursorPosition(0, Map.rows * Map.scale + 4);
                Console.WriteLine("Let's Fight!");
                return;
            }
        }
    }

}
