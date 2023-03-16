using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class CombatManager
    {
        public Player player;
        public EnemyManager enemyManager;
        public CombatManager(Player player, EnemyManager enemyManager) 
        {            
            this.player = player;
            this.enemyManager = enemyManager;
        }       
        public Character FightCheck(Character character)
        {
            List<Enemy> enemyList = enemyManager.GetEnemyList();
            if (character.Name == "Player")
            {
                foreach (Enemy enemy in enemyList)
                {
                    int row = character.posX;
                    int col = character.posY;

                    int row2 = enemy.posX;
                    int col2 = enemy.posY;

                    if (col > 0 && col - 1 != col2)
                    {
                        CursorController.InputAreaCursor(5, 1);
                        Console.WriteLine("nope1");
                        return null;
                    }
                    else if (col < col2 - 1 && col + 1 != col2)
                    {
                        return null;
                    }
                    else if (row > 0 && row - 1 != row2)
                    { 
                        return null; 
                    }
                    else if (row < row2 - 1 && row + 1 != row2)
                    {
                        return null;
                    }
                    else
                    {
                        return enemy;
                    }
                }  
            }
            return null;
        }

        public void Battle(Character attacker, Character target)
        {
            target.HealthDecrease(attacker.Strength);
        }
    }
}
