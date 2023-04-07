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
        public Random random = new Random();        

        // Player Information
        public string playerName = "Player";
        public string playerCharacter = "P";
        public string playerCorpse = "X";
        public bool isPlayerDead = false;
        public int playerLevel = 1;
        public int playerBasehealth = 25;        
        public int playerBasestrength = 5;

        // All Enemy Information
        public int enemyID = 0;
        public const string enemyCorpse = "x";
        public const int maxEnemies = 40;             // this should equal the total amount of enemies to spawn in each enemy category
        
        // Enemy - Slime
        public const string slimeName = "Slime";
        public const string slimeCharacter = "s";
        public const char slimeSpawnPoint = '`';
        public const int slimeAmountToSpawn = 26;
        public int slimeBasehealth = 2;        
        public int slimeBasestrength = 1;
        public int slimeXPValue = 2;
        public int slimeEnergyToMove = 200;

        // Enemy - Wyvern
        public const string wyvernName = "Wyvern";
        public const string wyvernCharacter = "W";
        public const char wyvernSpawnPoint = '^';
        public const int wyvernAmountToSpawn = 5;
        public int wyvernBasehealth = 12;        
        public int wyvernBasestrength = 4;
        public int wyvernXPValue = 5;
        public int wyvernEnergyToMove = 100;

        // Enemy - Sea Serpent
        public const string seaserpentName = "SeaSerpent";
        public const string seaserpentCharacter = "S";
        public const char seaserpentSpawnPoint = '~';
        public const int seaserpentAmountToSpawn = 5;
        public int seaserpentBasehealth = 22;        
        public int seaserpentBasestrength = 8;
        public int seaserpentXPValue = 12;
        public int seaserpentEnergyToMove = 125;

        // Enemy - Dragon
        public const string dragonName = "Dragon";
        public const string dragonCharacter = "D";
        public const char dragonSpawnPoint = 'C';
        public const int dragonAmountToSpawn = 1; 
        public int dragonBasehealth = 60;        
        public int dragonBasestrength = 20;
        public int dragonXPValue = 200;
        public int dragonEnergyToMove = 100;

        // Enemy - Treasure Chest
        public const string treasureName = "Treasure";
        public const string treasureCharacter = "T";
        public const char treasureSpawnPoint = '*';
        public const int treasureChestAmountToSpawn = 3;
        public int treasureBasehealth = 10;        
        public int treasureBasestrength = 0;
        public int treasureXPValue = 0;
        public int treasureEnergyToMove = 10000;

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

        // Item Information
        public const int potionHealAmount = 10;
    }
    
}
