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
        private int maxEnemies = 26;
        
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

        public void Update(CombatManager combatManager, Player player)
        {            
            foreach (Enemy enemy in enemiesList)
            {
                enemy.Update(combatManager, player);
            }             
        }

        public void InitEnemiesList(Map map, ItemManager itemManager, HUD hud, CursorController cursorController, Globals globals)
        {
            for (int i = 0; i <= maxEnemies; i++)
            {
                if (i <= 24)
                {
                    enemiesList.Add(new Slime(25, 14, map, itemManager, hud, cursorController, globals));
                    globals.enemyID += 1;
                }
                else if (i == 25)
                {
                    enemiesList.Add(new Wyvern(24, 15, map, itemManager, hud, cursorController, globals));
                    globals.enemyID += 1;
                }
                else
                {
                    enemiesList.Add(new SeaSerpent(4, 4, map, itemManager, hud, cursorController, globals));
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
