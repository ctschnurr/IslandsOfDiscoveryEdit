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
        private int maxEnemies = 3;
        
        public List<Enemy> enemiesList { get; set; }
        public List<Enemy> deadEnemiesList { get; set; }
        public EnemyManager (Map map, ItemManager itemManager, HUD hud, CursorController cursorController)
        {   
            this.map = map;            
            this.hud = hud;
            this.cursorController = cursorController;            
            this.itemManager = itemManager;

            enemiesList = new List<Enemy>();
            deadEnemiesList = new List<Enemy>();
            InitEnemiesList(map, itemManager, hud, cursorController);
            
        }

        public void Update(CombatManager combatManager, Player player)
        {            
            for (int i = 0; i < enemiesList.Count; i++)
            {
                Enemy enemy = enemiesList[i];
                enemy.Update(combatManager, player);
            }
        }

        public void InitEnemiesList(Map map, ItemManager itemManager, HUD hud, CursorController cursorController)
        {
            for (int i = 0; i < maxEnemies; i++)
            {
                switch (i) //change to if statement to deal with larger quantities
                {
                    case 0:
                        enemiesList.Add(new Slime(25, 14, map, itemManager, hud, cursorController));
                        break;
                    case 1:
                        enemiesList.Add(new Wyvern(24, 15, map, itemManager, hud, cursorController));
                        break;
                    case 2:
                        enemiesList.Add(new SeaSerpent(4, 4, map, itemManager, hud, cursorController));
                        break;
                    default:
                        break;
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < enemiesList.Count; i++)
            {
                Enemy enemy = enemiesList[i];
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
