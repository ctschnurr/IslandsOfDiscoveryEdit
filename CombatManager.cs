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
                    if (character.posX == enemy.posX && character.posY == enemy.posY)
                    {
                        return enemy;
                    }
                }  
                return null; // this is outside the if statement because it was preventing the foreach from going past the first enemy on the list
            }
            else
            {
                foreach (Enemy enemy in enemyList)
                {
                    if (character.posX == enemy.posX && character.posY == enemy.posY && character.myID != enemy.myID)
                    {
                        return enemy;
                    }
                    else if (character.posX == player.posX && character.posY == player.posY)
                    {
                        return player;
                    }                    
                }
                return null;                    
            }            
        }

        public void Battle(Character attacker, Character target)
        {
            target.HealthDecrease(attacker.Strength);
        }
    }
}
