using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Character
    {               
        public static int basehealth = 0;
        public static int basespeed = 0;
        public static int basestrength = 0;
        public static int health, speed, strength;

        public string character; //the alive version of the character
        public string corpse;       //the dead version of the character
        public int posX, posY, oldPosX, oldPosY; //current and one step prior locations for characters (utilized for map redrawing)
        public bool dead = false; //decides whether the character is dead or not, which determines what char is drawn for the character

        //public int[,] POS = new int[Map.rows, Map.cols]; currently not implemented
    }
}
