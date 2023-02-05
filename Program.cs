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
                if (Map.firstmaprender == true) //anything to be done on startup or first load should go here
                {
                    Console.Clear();
                    Map.DisplayMap(Map.scale);
                    Map.firstmaprender = false;
                    player.PlayerDraw(player.posX, player.posY);
                }      
                               
                player.PlayerUpdate(enemy.posX, enemy.posY);
                enemy.EnemyUpdate(player.posX, player.posY);
                
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
