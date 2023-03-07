using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class EnemyManager
    {
        Enemy[] enemies = new Enemy[3];

        //constructor

        public EnemyManager(Map map, Player player, ItemManager itemManager, HUD hud, CursorController cursorController)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                switch (i) //change to if statement to deal with larger quantities
                { 
                    case 0:
                        enemies[i] = new Slime(25, 14, map, player, itemManager, hud, cursorController);
                            break;
                    case 1:
                        enemies[i] = new Wyvern(24, 15, map, player, itemManager, hud, cursorController);
                            break;
                    case 2:
                        enemies[i] = new SeaSerpent(4, 4, map, player, itemManager, hud, cursorController);
                        break;
                default:
                    break;                
                }
            }
        }

        public void Update()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Update();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Draw(enemy.posX, enemy.posY);
            }
        }
    }
}
