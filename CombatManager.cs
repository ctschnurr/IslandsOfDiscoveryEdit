using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class CombatManager
    {
        public Player player;
        public EnemyManager enemyManager;
        public ItemManager itemManager;

        private Character lootable;
        public CombatManager(Player player, EnemyManager enemyManager, ItemManager itemManager) 
        {            
            this.player = player;
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
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
                    if (character.posX == enemy.posX && character.posY == enemy.posY && character.myID != enemy.myID) // enemy.myID prevents enemies from attacking themselves
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

        public void Battle(Character aggressor, Character victim)
        {
            lootable = victim.HealthDecrease(aggressor.Strength);  // checks to see if the victim has died and become lootable

            if (lootable == null)
            {
                return;
            }
            else if (aggressor.Name != "Player")
            {
                itemManager.Reward(aggressor, victim);              // loots the victim
            }
            else
            {
                itemManager.Reward(aggressor, victim);
                player.XPIncrease(victim.XpValue);
                // Debug.WriteLine("xp value is " + victim.XpValue); // xpvalue seems to be zero even when it shouldn't be
            }
        }
    }
}
