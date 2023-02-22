using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal abstract class Character                       //abstract prevents you from constructing this class on the field
    {
        protected int basehealth, basespeed, basestrength;        
        public int health { get; set; }        
        public int strength { get; set; }
        public string name { get; set; }                    //name of character

        protected string character;                         //the alive version of the character
        protected string corpse;                            //the dead version of the character        
        public int posX, posY, oldPosX, oldPosY;            //current and one step prior locations for characters (utilized for map redrawing)
        protected bool dead = false;                        //decides whether the character is dead or not, which determines what char is drawn for the character
        protected bool moveRollBack = false;                //switch to flip if character is attempting to move into an illegal location        
        protected bool makeAttack = false;                  //switch to flip if character is able to make an attack

        public Map map;
        public Player player;
        public ItemManager itemManager;

        protected Random random = new Random();

        public Character (int posX, int posY, Map map, Player player, ItemManager itemManager)      //constructor, required to create string of data down inherited classes (ex. character -> enemy -> sea serpent)
        {
            this.posX = posX;
            this.posY = posY;
            this.map = map;
            this.player = player;
            this.itemManager = itemManager;
        }

        virtual protected void WallCheck(int x, int y, ItemManager itemManager)      //checks to see if the character is allowed to move onto the map location
        {
            if (x > map.cols || x < 0 + 1)                  //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else if (y > map.rows || y < 0 + 1)             //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else
            {
                switch (map.map[y - 1, x - 1])
                {
                    case '^':
                        moveRollBack = true;
                        break;
                    case '~':                        
                        moveRollBack = true;
                        break;
                    default:
                        moveRollBack = false;
                        break;
                }
            }
        }
        virtual protected void FightCheck(int playerx, int playery, int enemyx, int enemyy, int enemy2x, int enemy2y, int enemy3x, int enemy3y)
        {
            if (playerx == enemyx && playery == enemyy || playerx == enemy2x && playery == enemy2y || playerx == enemy3x && playery == enemy3y)  //compares player location to enemy locations
            {
                moveRollBack = true;
                makeAttack = true;                
            }
            else if (enemyx == playerx && enemyy == playery || enemy2x == playerx && enemy2y == playery || enemy3x == playerx && enemy3y == playery) //compares enemy locations to player location
            {
                moveRollBack = true;
                makeAttack = true;                
            }
            else if (enemyx == enemy2x && enemyy == enemy2y || enemyx == enemy3x && enemyx == enemy3y) //compares enemy 1 to other two enemies
            {
                moveRollBack = true;
            }
            else if (enemy2x == enemyx && enemy2y == enemyy || enemy2x == enemy3x && enemy2x == enemy3y) //compares enemy 2 to other two enemies
            {
                moveRollBack = true;
            }
            else if (enemy3x == enemyx && enemy3y == enemyy || enemy3x == enemy2x && enemy3y == enemy2y) //compares enemy 3 to other two enemies
            {
                moveRollBack = true;
            }
            return;
        }        
        virtual protected void GetMyPOS() //getter
        {
            oldPosX = posX;
            oldPosY = posY;
        }
        virtual protected void ResetMyPOS() //setter
        {
            posX = oldPosX;
            posY = oldPosY;
        }
        virtual protected void DeathCheck()
        {
            if (health <= 0)
            {
                dead = true;
            }
        }

        virtual protected void TakeDamage(int damage)
        {
            health = health - damage;
        }
        virtual public void Draw(int posX, int posY)
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
    }
}
