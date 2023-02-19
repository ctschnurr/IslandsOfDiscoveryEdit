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

        static Map map = new Map();
        HUD hud = new HUD();
        Player player = new Player(22, 14, map);
        Enemy enemy = new SeaSerpent(4, 4, map);
        Enemy enemy2 = new Wyvern(24, 15, map);
        Enemy enemy3 = new Slime(25, 14, map);
        CombatManager combatManager = new CombatManager();
        CursorController cursorController = new CursorController();
        ItemManager itemManager = new ItemManager();

        //EnemyManager enemyManager = new EnemyManager();

        //Game Loop
        public void RunGame()
        {
            hud.Draw();
            while (gameOver == false)
            {
                //updates               
                map.Update();
                player.Update(enemy, enemy2, enemy3);
                enemy.Update(player, enemy, enemy2, enemy3);
                enemy2.Update(player, enemy, enemy2, enemy3);
                enemy3.Update(player, enemy, enemy2, enemy3);
                //combat manager update goes here.
                itemManager.Update();

                //draws  
                //map.Draw();                
                player.Draw(player.posX, player.posY);
                enemy.Draw(enemy.posX, enemy.posY);
                enemy2.Draw(enemy2.posX, enemy2.posY);
                enemy3.Draw(enemy3.posX, enemy3.posY);
            }
        }
    }
}
