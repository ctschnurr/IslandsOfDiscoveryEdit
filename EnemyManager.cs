using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class EnemyManager
    {
        public Map map;        
        public ItemManager itemManager;
        public HUD hud;
        public CursorController cursorController;
        public Globals globals;
        
        public List<Enemy> enemiesList { get; set; }
        public List<Enemy> deadEnemiesList { get; set; }
        public EnemyManager (Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals)
        {   
            this.map = map;            
            this.hud = hud;
            this.cursorController = cursorController;            
            this.itemManager = itemManager;
            this.globals = globals;

            enemiesList = new List<Enemy>();
            deadEnemiesList = new List<Enemy>();
            InitEnemiesList(map, itemManager, hud, cursorController, globals);            
        }

        public void Update(CombatManager combatManager)
        {            
            foreach (Enemy enemy in enemiesList)
            {
                enemy.Update(combatManager);
                if (enemy.dead == true)
                {
                    DeadEnemy(enemy);                           // adds the dead enemy to the dead enemies list
                    enemy.Draw(enemy.posX, enemy.posY);         // draws the dead enemies corpse
                }
            }     
            ClearDeadEnemies();                                 // clear the list of dead enemies 
        }

        public void InitEnemiesList(Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals)
        {
            for (int i = 0; i <= globals.maxEnemies - 1; i++)
            {
                if (i < 2)
                {
                    enemiesList.Add(new TreasureChest(map, itemManager, hud, cursorController, globals));
                    globals.enemyID += 1;
                }
                else if (i >= 2 && i <= 30)
                {
                    enemiesList.Add(new Slime(map, itemManager, hud, cursorController, globals));
                    globals.enemyID += 1;
                }
                else if (i > 30 && i < 34)
                {
                    enemiesList.Add(new Wyvern(map, itemManager, hud, cursorController, globals));
                    globals.enemyID += 1;
                }
                else if (i >= 34 && i < globals.maxEnemies - 1)
                {
                    enemiesList.Add(new SeaSerpent(map, itemManager, hud, cursorController, globals));
                    globals.enemyID += 1;
                }
                else if (i ==  globals.maxEnemies - 1)
                {
                    enemiesList.Add(new Dragon(map, itemManager, hud, cursorController, globals));
                    globals.enemyID += 1;
                }
            }
        }

        public void Draw()
        {
            foreach (Enemy enemy in enemiesList)
            {
                enemy.Draw(enemy.posX, enemy.posY);
            }
        }

        public List<Enemy> GetEnemyList()
        {
            return enemiesList;
        }

        public void DeadEnemy(Enemy enemy)
        {
            deadEnemiesList.Add(enemy);
        }

        public void ClearDeadEnemies()
        {
            foreach (Enemy enemy in deadEnemiesList)
            {
                enemiesList.Remove(enemy);
            }
            deadEnemiesList.Clear();
        }
    }
}
