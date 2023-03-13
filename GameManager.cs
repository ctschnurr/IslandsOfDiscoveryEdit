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
        static HUD hud = new HUD();
        static ItemManager itemManager = new ItemManager();
        static CursorController cursorController = new CursorController();
        static CombatManager combatManager = new CombatManager(player, enemyManager, hud, cursorController);
        static Player player = new Player(22, 14, map, player, itemManager, hud, cursorController, combatManager);
        static EnemyManager enemyManager = new EnemyManager(map, player, itemManager, hud, cursorController, combatManager); 

        //Game Loop
        public void RunGame()
        {            
            while (gameOver == false)
            {
                //updates
                itemManager.Update();                
                hud.Update(player, itemManager);
                map.Update();
                player.Update();
                enemyManager.Update();                               

                //draws 
                //hud.Draw();
                player.Draw(player.posX, player.posY);
                enemyManager.Draw();
                
            }           
        }
    }
}
