using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Enemy : Character
    {              
        protected int xpValue;
        protected int moveEnergy;
        protected int energyToMove;

        private Character target;
        public Enemy(int x, int y, Map map, Player player, ItemManager itemManager, HUD hud, CursorController cursorController, CombatManager combatManager) : base(x, y, map, player, itemManager, hud, cursorController, combatManager)
        {
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = "@";            
            corpse = "x";
            dead = false;
            health = basehealth;            
            strength = basestrength;
            xpValue = 0;
            moveEnergy = 0;
            base.map = map;
            this.player = player;
            this.itemManager = itemManager;
            this.hud = hud;
            this.cursorController = cursorController;
            this.combatManager = combatManager;
        }
        public void Update()
        {
            SpawnMe();            
            DeathCheck(itemManager);
            if (dead == false)
            {
                StoreMyPOS();
                MoveMe();                
                Walkable(posX, posY);
                target = combatManager.FightCheck(this);
                if (target != null)
                {
                    ResetMyPOS();
                    combatManager.Battle(this, target);
                    HUD.StatEnemy(this);
                }
                DeathCheck(itemManager);
                map.Redraw(oldPosX, oldPosY);
            }
        }
        
        public void SpawnMe()
        {                        
            Draw(posX, posY); //draws the enemy on the map            
        }

        public void MoveMe()
        {
            moveEnergy += 100;
            if (moveEnergy >= energyToMove)
            {
                int enemyMove = random.Next(1, 5); //a random number to represent the four cardinal directions
            
                switch (enemyMove)
                {
                    case 1:
                    posY--;
                        break;

                    case 2:
                    posX--;
                        break;

                    case 3:
                    posY++;                
                        break;

                    case 4:
                    posX++;              
                        break;

                    default:             
                        break;
                }
                moveEnergy -= energyToMove;
            }
        }        
        private void DeathCheck(ItemManager itemManager)
        {
            if (dead == true)
            {
                return;
            }
            else if (health <= 0)
            {
                health = 0;
                HUD.StatEnemy(this);
                dead = true;
                itemManager.Reward();
                player.xp += xpValue;
            }
        }
    }
}
