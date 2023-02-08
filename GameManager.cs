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
        Enemy enemy = new SeaSerpent();
        Enemy enemy2 = new Slime();
        Enemy enemy3 = new Slime();
        Map map = new Map();
        CombatManager combatManager = new CombatManager();
        CursorController cursorController = new CursorController();
        HUD hud = new HUD();
        //EnemyManager enemyManager = new EnemyManager();

        //Game Loop
        public void RunGame()
        {                      
            while (gameOver == false)
            {   
                //updates
                map.Update();
                player.Update(enemy, enemy2, enemy3);
                enemy.Update(player, enemy, enemy2, enemy3);
                enemy2.Update(player, enemy, enemy2, enemy3);
                enemy3.Update(player, enemy, enemy2, enemy3);
                //combat manager update goes here.

                //draws
                player.Draw(player.posX, player.posY);
                enemy.Draw(enemy.posX, enemy.posY);
                enemy2.Draw(enemy2.posX, enemy2.posY);
                enemy3.Draw(enemy3.posX, enemy3.posY);
            }
        }
    }
}
