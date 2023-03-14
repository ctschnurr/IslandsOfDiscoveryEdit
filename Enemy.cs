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
        public Enemy(int x, int y, Map map, ItemManager itemManager, HUD hud, CursorController cursorController) : base(x, y, map, itemManager, hud, cursorController)
        {
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = "@";            
            corpse = "x";
            dead = false;
            Health = basehealth;            
            Strength = basestrength;
            xpValue = 0;
            moveEnergy = 0;
            base.map = map;            
            this.itemManager = itemManager;
            this.hud = hud;
            this.cursorController = cursorController;            
        }
        public void Update(CombatManager combatManager, Player player)
        {
            SpawnMe();            
            DeathCheck(itemManager, player);
            if (dead == false)
            {
                StoreMyPOS();
                MoveMe();
                if (map.BorderCheck(posX, posY))
                {
                    ResetMyPOS();
                }
                Walkable(posX, posY);
                target = combatManager.FightCheck(this);                
                if (target != null)
                {
                    ResetMyPOS();
                    combatManager.Battle(this, target);
                    HUD.StatEnemy(this);
                }
                DeathCheck(itemManager, player);
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
        private void DeathCheck(ItemManager itemManager, Player player)
        {
            if (dead == true)
            {
                return;
            }
            else if (Health <= 0)
            {
                Health = 0;
                HUD.StatEnemy(this);
                dead = true;
                itemManager.Reward();
                player.xp += xpValue;                
            }
        }
    }
}
