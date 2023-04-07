using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class GameManager
    {        
        static Globals globals = new Globals();
        static Map map = new Map();
        static HUD hud = new HUD();
        static ItemManager itemManager = new ItemManager(globals);
        //do not rearrange the order of these things - their constructors rely on timing of creation to function
        static CursorController cursorController = new CursorController();       
        static EnemyManager enemyManager = new EnemyManager(map, itemManager, hud, cursorController, globals);
        static Player player = new Player(22, 14, map, player, itemManager, hud, cursorController, globals);
        static CombatManager combatManager = new CombatManager(player, enemyManager, itemManager);

        //Game Loop
        public void RunGame()
        {            
            while (globals.gameOver == false)
            {
                //updates                
                hud.Update(player, itemManager);
                map.Update();
                player.Update(combatManager);
                enemyManager.Update(combatManager);

                //draws                  
                player.Draw(player.posX, player.posY);
                enemyManager.Draw();
            }           
        }
    }
}
