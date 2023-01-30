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
        static void Main(string[] args)
        {
            while (gameOver == false)
            {
                if (Map.firstmaprender == true)
                {
                    Console.Clear();
                    Map.DisplayMap(Map.scale);
                    Map.firstmaprender = false;
                }
                //GameLoop();
                Player.PlayerDraw(Player.p, Player.PlayerPosx, Player.PlayerPosy); //draws the player on the map
                Enemy.SpawnMe(); //spawns an enemy construct
                Console.WriteLine();
                Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
                Player.GetPlayerPOS();
                Enemy.GetEnemyPOS();
                Player.PlayerChoice();
                Player.PlayerDraw(Player.p, Player.PlayerPosx, Player.PlayerPosy);
                Enemy.MoveMe();
                Enemy.EnemyDraw(Enemy.e, Enemy.EnemyPosx, Enemy.EnemyPosy);
                Console.SetCursorPosition(Player.GetPOSx, Player.GetPOSy);
                Map.ColourCode(Player.GetPOSy - 1, Player.GetPOSx - 1);
                Console.Write(Map.map[Player.GetPOSy - 1, Player.GetPOSx - 1]);
                Console.SetCursorPosition(Enemy.GetPOSx, Enemy.GetPOSy);
                Map.ColourCode(Enemy.GetPOSy - 1, Enemy.GetPOSx - 1);
                Console.Write(Map.map[Enemy.GetPOSy - 1, Enemy.GetPOSx - 1]);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public static void GameLoop()
        {
            Player.PlayerDraw(Player.p, Player.PlayerPosx, Player.PlayerPosy); //draws the player on the map
            Enemy.SpawnMe(); //spawns an enemy construct
            Console.WriteLine();
            Console.SetCursorPosition(0, Map.rows * Map.scale + 2);
            Player.GetPlayerPOS();
            Enemy.GetEnemyPOS();
            Player.PlayerChoice();
            Player.PlayerDraw(Player.p, Player.PlayerPosx, Player.PlayerPosy);
            Enemy.MoveMe();
            Enemy.EnemyDraw(Enemy.e, Enemy.EnemyPosx, Enemy.EnemyPosy);
            Console.SetCursorPosition(Player.GetPOSx, Player.GetPOSy);
            Map.ColourCode(Player.GetPOSy - 1, Player.GetPOSx - 1);
            Console.Write(Map.map[Player.GetPOSy - 1, Player.GetPOSx - 1]);
            Console.SetCursorPosition(Enemy.GetPOSx, Enemy.GetPOSy);
            Map.ColourCode(Enemy.GetPOSy - 1, Enemy.GetPOSx - 1);
            Console.Write(Map.map[Enemy.GetPOSy - 1, Enemy.GetPOSx - 1]);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
