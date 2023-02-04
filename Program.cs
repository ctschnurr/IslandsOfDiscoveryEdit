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
            Player player = new Player(3,5);
            Enemy enemy = new Enemy(3,10);
            CursorController cursorController = new CursorController();

            while (gameOver == false)
            {
                if (Map.firstmaprender == true)
                {
                    Console.Clear();
                    Map.DisplayMap(Map.scale);
                    Map.firstmaprender = false;
                }
                player.PlayerDraw(player.posX, player.posY);    //draws the player on the map
                enemy.SpawnMe();
                Console.WriteLine();
                CursorController.InputAreaCursor();
                player.GetPlayerPOS();                          //stores the player position before they move
                enemy.GetEnemyPOS();                            //stores the enemy position before they move, this should eventually use an array for multiple enemies
                player.PlayerChoice(enemy.posX, enemy.posY);    //this is going to cause issues if there's more than one enemy; store enemy location in an array?                
                player.PlayerDraw(player.posX, player.posY);
                Map.Redraw(player.oldPosX, player.oldPosY);     //redraws the position the player left with the underlying map location
                enemy.MoveMe(player.posX, player.posY);
                Map.Redraw(enemy.oldPosX, enemy.oldPosY);       //redraws the position the enemy left with the underlying map location
                if (CombatManager.startFight == true)
                {
                    CombatManager.Combat();
                }

                //YOU CAN CREATE AN IF STATEMENT IN A METHOD CALL
                //no you can't dummy                
            }
        }
    }
}
