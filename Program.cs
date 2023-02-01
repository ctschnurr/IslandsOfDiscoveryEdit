using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Program
    {
        public static bool gameOver = false;
        public static int enemyCount = 0;

        static void Main(string[] args)
        {            
            Player player = new Player();
            Enemy enemy = new Enemy();

            while (gameOver == false)
            {
                if (Map.firstmaprender == true)
                {
                    Console.Clear();
                    Map.DisplayMap(Map.scale);
                    Map.firstmaprender = false;
                }
                player.PlayerDraw(player.p, player.PlayerPosx, player.PlayerPosy); //draws the player on the map
                if (enemyCount < 1)
                {
                    enemy.SpawnMe(); //spawns an enemy construct
                }
                Console.WriteLine();
                Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                player.GetPlayerPOS();
                enemy.GetEnemyPOS();
                player.PlayerChoice(player.GetPOSx, player.GetPOSy, enemy.GetPOSx, enemy.GetPOSy); //this is going to cause issues if there's more than one enemy; store player and enemy location in an array?
                if (CombatManager.startFight == true)
                {
                    CombatManager.Combat();
                }
                player.PlayerDraw(player.p, player.PlayerPosx, player.PlayerPosy);
                if (enemyCount > 0)
                {
                    enemy.MoveMe();
                    enemy.EnemyDraw(enemy.e, enemy.EnemyPosx, enemy.EnemyPosy);
                    Console.SetCursorPosition(player.GetPOSx, player.GetPOSy);
                    Map.ColourCode(player.GetPOSy - 1, player.GetPOSx - 1);
                    Console.Write(Map.map[player.GetPOSy - 1, player.GetPOSx - 1]);
                    Console.SetCursorPosition(enemy.GetPOSx, enemy.GetPOSy);
                    Map.ColourCode(enemy.GetPOSy - 1, enemy.GetPOSx - 1);
                    Console.Write(Map.map[enemy.GetPOSy - 1, enemy.GetPOSx - 1]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (enemyCount < 1)
                {
                    Console.SetCursorPosition(player.GetPOSx, player.GetPOSy);
                    Map.ColourCode(player.GetPOSy - 1, player.GetPOSx - 1);
                    Console.Write(Map.map[player.GetPOSy - 1, player.GetPOSx - 1]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}
