using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class CombatManager
    {
        private static Character one, two;

        public Player player;
        public EnemyManager enemyManager;
        public CombatManager(Player player, EnemyManager enemyManager) 
        {
            one = null;
            two = null;
            this.player = player;
            this.enemyManager = enemyManager;
        }       
        public Character FightCheck(Character character)
        {
            List<Enemy> enemyList = enemyManager.GetEnemyList();

            foreach (Enemy enemy in enemyList)                                  // checks for fight between player and all enemies
            {
                one = character;
                two = enemy;
                if (one.posX == two.posX && one.posY == two.posY)
                {
                    return two;
                }
                else
                {
                    foreach (Enemy enemy2 in enemyList)
                    {
                        one = enemy2;
                        two = character;
                        if (one.posX == two.posX && one.posY == two.posY)
                        {
                            return two;
                        }
                    }
                }
                return null;
            }
            return null;
        }

        public void Battle(Character attacker, Character target)
        {
            target.HealthDecrease(attacker.strength);
        }
    }
}
