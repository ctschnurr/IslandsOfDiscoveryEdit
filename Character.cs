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
        public HUD hud;
        public CursorController cursorController;        

        protected Random random = new Random();

        public Character (int posX, int posY, Map map, ItemManager itemManager, HUD hud, CursorController cursorController)      //constructor, required to create string of data down inherited classes (ex. character -> enemy -> sea serpent)
        {
            this.posX = posX;
            this.posY = posY;
            this.map = map;
            this.player = player;
            this.itemManager = itemManager;
            this.hud = hud;
            this.cursorController = cursorController;            
        }

        virtual protected void Walkable(int x, int y)
        {
            if (map.TerrainCheck('^', x, y))
            {
                ResetMyPOS();
            }
            else if (map.TerrainCheck('~', x, y))
            {
                ResetMyPOS();
            }
            else 
            {
                 
            }
        }         
        virtual protected void StoreMyPOS() 
        {
            oldPosX = posX;
            oldPosY = posY;
        }
        virtual protected void ResetMyPOS() 
        {
            posX = oldPosX;
            posY = oldPosY;
        }        
        virtual protected void DeathCheck()
        {
            if (health <= 0)
            {
                health = 0;
                dead = true;
            }
        }
        virtual public void HealthDecrease(int amount)
        {
            CursorController.InputAreaCursor(4, 0);
            Console.WriteLine("The " + name + " has lost " + amount + " health!");
            health -= amount;
        }

        virtual public void HealthIncrease(int amount)
        {
            CursorController.InputAreaCursor(3, 0);
            Console.WriteLine("The " + name + " has healed for " + amount + " health!");
            health += amount;
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
