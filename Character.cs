using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Character
    {
        protected static int basehealth = 0;
        protected static int basespeed = 0;
        protected static int basestrength = 0;
        protected static int health, speed, strength;

        protected string character; //the alive version of the character
        protected string corpse;       //the dead version of the character
        public int posX, posY, oldPosX, oldPosY; //current and one step prior locations for characters (utilized for map redrawing)
        protected bool dead = false; //decides whether the character is dead or not, which determines what char is drawn for the character
        protected bool moveRollBack = false; //switch to flip if character is attempting to move into an illegal location

        //public int[,] POS = new int[Map.rows, Map.cols]; currently not implemented

        virtual protected void WallCheck(int x, int y) //checks to see if the character is allowed to move onto the map location
        {
            if (x > Map.cols || x < 0 + 1) //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else if (y > Map.rows || y < 0 + 1) //prevents character from moving outside bounds of border
            {
                moveRollBack = true;
            }
            else
            {
                switch (Map.map[y - 1, x - 1])
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
        virtual protected void GetMyPOS()
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
                dead = true;
            }
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
