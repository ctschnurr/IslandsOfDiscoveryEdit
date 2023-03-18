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
        static Map map = new Map(globals);
        static HUD hud = new HUD();
        static ItemManager itemManager = new ItemManager();
        static CursorController cursorController = new CursorController();       
        //do not rearrange the order of these things - their constructors rely on timing of creation to function
        static EnemyManager enemyManager = new EnemyManager(map, itemManager, hud, cursorController, globals);
        static Player player = new Player(22, 14, map, player, itemManager, hud, cursorController, globals);
        static CombatManager combatManager = new CombatManager(player, enemyManager);

        //Game Loop
        public void RunGame()
        {            
            while (globals.gameOver == false)
            {
                //updates
                itemManager.Update();
                hud.Update(player, itemManager);
                map.Update();
                player.Update(combatManager);
                enemyManager.Update(combatManager, player);

                //draws 
                //hud.Draw(); 
                player.Draw(player.posX, player.posY);
                enemyManager.Draw();

            }           
        }
    }
}
