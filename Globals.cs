using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Globals
    {
        // Game Management
        public bool gameOver = false;

        // Player Information
        public string playerName = "Player";
        public string playerCharacter = "P";
        public string playerCorpse = "X";
        public bool isPlayerDead = false;
        public int playerLevel = 1;
        public int playerBasehealth = 25;
        public int playerBasespeed = 5;
        public int playerBasestrength = 5;

        // All Enemy Information
        public int enemyID = 0;
        public string enemyCorpse = "x";

        // Enemy - Slime
        public string slimeName = "Slime";
        public string slimeCharacter = "s";
        public string slimeSpawnPoint = "`";
        public int slimeBasehealth = 2;
        public int slimeBasespeed = 2;
        public int slimeBasestrength = 1;
        public int slimeXPValue = 2;
        public int slimeEnergyToMove = 200;

        // Enemy - Wyvern
        public string wyvernName = "Wyvern";
        public string wyvernCharacter = "W";
        public string wyvernSpawnPoint = "^";
        public int wyvernBasehealth = 12;
        public int wyvernBasespeed = 12;
        public int wyvernBasestrength = 4;
        public int wyvernXPValue = 5;
        public int wyvernEnergyToMove = 100;

        // Enemy - Sea Serpent
        public string seaserpentName = "SeaSerpent";
        public string seaserpentCharacter = "S";
        public string seaserpentSpawnPoint = "~";
        public int seaserpentBasehealth = 22;
        public int seaserpentBasespeed = 5;
        public int seaserpentBasestrength = 8;
        public int seaserpentXPValue = 12;
        public int seaserpentEnergyToMove = 125;

        // Enemy - Dragon

        // Maps Information
        public string worldMap = "Maps_and_Overlays/OverworldMap_01.txt";
        public string borders = "Maps_and_Overlays/HudBorders.txt";

        // Map Colours
        public ConsoleColor mountainColor = ConsoleColor.Gray;
        public ConsoleColor grassColor = ConsoleColor.Green;
        public ConsoleColor waterColor = ConsoleColor.Blue;
        public ConsoleColor forestColor = ConsoleColor.DarkGreen;
        public ConsoleColor sandColor = ConsoleColor.Yellow;
        public ConsoleColor dungeonEntrance = ConsoleColor.DarkGray;
        public ConsoleColor castleEntrance = ConsoleColor.Magenta;
        public ConsoleColor backgroundColor = ConsoleColor.Black;
    }
}
