using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Enemy : Character
    {      
        private int enemyCount = 0;
        public Enemy(int x, int y)
        {
            posX = x;
            posY = y;
            oldPosX = x;
            oldPosY = y;
            character = "@";            
            corpse = "x";            
            dead = false;
        }
        public void EnemyUpdate(int playerPosX, int playerPosY)
        {
            if (enemyCount == 0)
            {
                SpawnMe();
            }
            GetMyPOS();
            MoveMe();
            Map.WallCheck(posX, posY);
            CombatManager.FightCheck(posX, posY, playerPosX, playerPosY);
            if (Map.moveRollBack == true || CombatManager.moveRollBack == true)
            {
                CombatManager.moveRollBack = false;
                Map.moveRollBack = false;
                ResetMyPOS();                
            }
            Map.Redraw(oldPosX, oldPosY);
            EnemyDraw(posX, posY);              //this has to follow the Map redraw to avoid weird disappearing enemy issues
        }
        public void SpawnMe()
        {                        
            EnemyDraw(posX, posY); //draws the enemy on the map            
        }

        public void MoveMe()
        {
            Random random = new Random();
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
        }

        public void EnemyDraw(int posX, int posY)
        {
            CursorController.CharacterPrintCursor(posX, posY);
            if (dead == false)
            {
                Console.Write(character);
            }
            else if (dead == true)
            {
                Console.Write(corpse);
            }
        }
        

        public void GetMyPOS()          //used to overwrite previous position on the map
        {
            oldPosX = posX;
            oldPosY = posY;
        }

        public void ResetMyPOS()        //replace the old rollback system
        {
            posX = oldPosX;
            posY = oldPosY;
        }
    }

}
