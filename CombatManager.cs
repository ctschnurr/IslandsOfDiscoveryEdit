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
            if (character == player)
            {
                foreach (Enemy enemy in enemyList)
                {
                    int row = character.posX;
                    int col = character.posY;

                    int row2 = enemy.posX;
                    int col2 = enemy.posY;

                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = col - 1; j <= col + 1; j++)
                        {
                            if (i >= 0 && i < row2 && j >= 0 && j < col2 && (i!= row || j!=col))
                            {
                                return enemy;
                            }
                        }
                    }
                }
            }
            

            //else
            //{
            //    foreach (Enemy enemy in enemyList)
            //    {
            //        if (character.posX == enemy.posX && character.posY == enemy.posY)
            //        {
            //            return enemy;
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //}
            return null;
        }

        public void Battle(Character attacker, Character target)
        {
            target.HealthDecrease(attacker.Strength);
        }
    }
}
