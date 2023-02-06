using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class GameManager
    {
        public static bool gameOver = false;

        Player player = new Player(3, 5);
        Enemy enemy = new Enemy(3, 10);
        CursorController cursorController = new CursorController();

        public void RunGame()
        {//Game Loop
            while (gameOver == false)
            {                
                if (Map.firstmaprender == true) //anything to be done on startup or first load should go here
                {
                    Console.Clear();
                    Map.DisplayMap(Map.scale);
                    Map.firstmaprender = false;
                    player.Draw(player.posX, player.posY);
                }

                //updates
                player.Update(enemy.posX, enemy.posY);
                enemy.Update(player.posX, player.posY);

                //draws
                player.Draw(player.posX, player.posY);
                enemy.Draw(enemy.posX, enemy.posY);
                
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
