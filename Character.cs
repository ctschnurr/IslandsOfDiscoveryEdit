using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Character
    {
        public static int origx = Console.CursorLeft, origy = Console.CursorTop;        
        public static int basehealth = 0;
        public static int basespeed = 0;
        public static int basestrength = 0;
        public static bool startFight = false;

        public char character;
        public int posX, posY;
        public bool dead = false;

        public int[,] POS = new int[Map.rows, Map.cols];
    }
}
