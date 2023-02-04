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
            Player player = new Player(3,5);
            Enemy enemy = new Enemy(7,7);
            CursorController cursorController = new CursorController();

            while (gameOver == false)
            {
                if (Map.firstmaprender == true)
                {
                    Console.Clear();
                    Map.DisplayMap(Map.scale);
                    Map.firstmaprender = false;
                }
                player.PlayerDraw(player.character, player.posX, player.posY); //draws the player on the map               
                Console.WriteLine();
                CursorController.InputAreaCursor();
                player.GetPlayerPOS(); //stores the player position before they move
                //enemy.GetEnemyPOS(); //stores the enemy position before they move
                player.PlayerChoice(); //this is going to cause issues if there's more than one enemy; store player and enemy location in an array?                
                player.PlayerDraw(player.character, player.posX, player.posY);
                Map.Redraw(player.oldPosX, player.oldPosY);

                //YOU CAN CREATE AN IF STATEMENT IN A METHOD CALL
                //no you can't dummy
                
            }
        }
    }
}
