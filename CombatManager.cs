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
            int y = 2;
            foreach (Enemy enemy in enemyList)
            {
                CursorController.InputAreaCursor(y, 1);
                Console.WriteLine(enemy.posX +" " + enemy.posY);
                y++;
            }
            CursorController.InputAreaCursor(y, 1);
            Console.WriteLine(player.posX + " " + player.posY);            
            if (character.Name == "Player")
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
