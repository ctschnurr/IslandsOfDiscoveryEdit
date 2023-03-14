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
                    if (player.posX == enemy.posX && player.posY == enemy.posY)
                    {
                        return enemy;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                foreach (Enemy enemy in enemyList)
                {
                    if (character.posX == enemy.posX && character.posY == enemy.posY)
                    {
                        return enemy;
                    }
                    else
                    {
                        return null;
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
