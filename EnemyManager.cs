using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class EnemyManager
    {        
        protected static List<Enemy> enemiesList = new List<Enemy>();
        protected static List<Enemy> deadEnemiesList = new List<Enemy>();

        //constructor

        public EnemyManager(Map map, Player player, ItemManager itemManager, HUD hud, CursorController cursorController, CombatManager combatManager)
        {
            for (int i = 0; i < enemiesList.Count; i++)
            {
                switch (i) //change to if statement to deal with larger quantities
                { 
                    case 0:
                        enemiesList[i] = new Slime(25, 14, map, player, itemManager, hud, cursorController, combatManager);
                            break;
                    case 1:
                        enemiesList[i] = new Wyvern(24, 15, map, player, itemManager, hud, cursorController, combatManager);
                            break;
                    case 2:
                        enemiesList[i] = new SeaSerpent(4, 4, map, player, itemManager, hud, cursorController, combatManager);
                            break;
                default:
                    break;                
                }
            }
        }

        public void Update()
        {
            for (int i = 0; i < enemiesList.Count; i++)
            {
                Enemy enemy = enemiesList[i];
                enemy.Update();
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

        public static List<Enemy> GetEnemyList()
        {
            return enemiesList;
        }

        public static void DeadEnemy(Enemy enemy)
        {
            deadEnemiesList.Add(enemy);
        }

        public static void ClearDeadEnemies()
        {
            foreach (Enemy enemy in deadEnemiesList)
            {
                enemiesList.Remove(enemy);
            }
            deadEnemiesList.Clear();
        }
    }
}
