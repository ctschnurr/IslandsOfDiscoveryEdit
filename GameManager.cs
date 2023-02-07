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
        Map map = new Map();
        CombatManager combatManager = new CombatManager();
        CursorController cursorController = new CursorController();
        HUD hud = new HUD();

        //Game Loop
        public void RunGame()
        {          
            while (gameOver == false)
            {   
                //updates
                map.Update();
                player.Update(enemy.posX, enemy.posY);
                enemy.Update(player.posX, player.posY);
                //combat manager update goes here.

                //draws
                player.Draw(player.posX, player.posY);
                enemy.Draw(enemy.posX, enemy.posY);
               
              
            }
        }
    }
}
