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

        //public int[,] POS = new int[Map.rows, Map.cols]; currently not implemented
    }
}
