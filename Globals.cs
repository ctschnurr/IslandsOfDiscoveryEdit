﻿using System;
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
        public const string playerName = "Player";
        public const string playerCharacter = "P";
        public const string playerCorpse = "X";
        public bool isPlayerDead = false;
        public int playerLevel = 1;
        public const int playerBasehealth = 25;        
        public const int playerBasestrength = 5;

        // All Enemy Information
        public int enemyID = 0;
        public const string enemyCorpse = "x";
        public const int maxEnemies = 41;             // this should equal the total amount of enemies to spawn in each enemy category
        
        // Enemy - Slime
        public const string slimeName = "Slime";
        public const string slimeCharacter = "s";
        public const char slimeSpawnPoint = '`';
        public const int slimeAmountToSpawn = 26;
        public const int slimeBasehealth = 2;        
        public const int slimeBasestrength = 1;
        public const int slimeXPValue = 2;
        public const int slimeEnergyToMove = 200;

        // Enemy - Wyvern
        public const string wyvernName = "Wyvern";
        public const string wyvernCharacter = "W";
        public const char wyvernSpawnPoint = '^';
        public const int wyvernAmountToSpawn = 5;
        public const int wyvernBasehealth = 12;        
        public const int wyvernBasestrength = 4;
        public const int wyvernXPValue = 5;
        public const int wyvernEnergyToMove = 100;

        // Enemy - Sea Serpent
        public const string seaserpentName = "SeaSerpent";
        public const string seaserpentCharacter = "S";
        public const char seaserpentSpawnPoint = '~';
        public const int seaserpentAmountToSpawn = 5;
        public const int seaserpentBasehealth = 22;        
        public const int seaserpentBasestrength = 8;
        public const int seaserpentXPValue = 12;
        public const int seaserpentEnergyToMove = 125;

        // Enemy - Dragon
        public const string dragonName = "Dragon";
        public const string dragonCharacter = "D";
        public const char dragonSpawnPoint = 'C';
        public const int dragonAmountToSpawn = 1; 
        public const int dragonBasehealth = 60;        
        public const int dragonBasestrength = 20;
        public const int dragonXPValue = 200;
        public const int dragonEnergyToMove = 100;

        // Enemy - Treasure Chest
        public const string treasureName = "Treasure";
        public const string treasureCharacter = "T";
        public const char treasureSpawnPoint = '*';
        public const int treasureChestAmountToSpawn = 3;
        public const int treasureBasehealth = 10;        
        public const int treasureBasestrength = 0;
        public const int treasureXPValue = 0;
        public const int treasureEnergyToMove = 10000;

        // Enemy - Trader
        public const string traderName = "Trader";
        public const string traderCharacter = "t";
        public const char traderSpawnPoint = '*';
        public const int traderAmountToSpawn = 1;
        public const int traderBasehealth = 10;
        public const int traderBasestrength = 0;
        public const int traderXPValue = 0;
        public const int traderEnergyToMove = 10000;
        public const int traderPotionCost = 25;

        // Maps Information
        public const string worldMap = "Maps_and_Overlays/OverworldMap_01.txt";
        public const string borders = "Maps_and_Overlays/HudBorders.txt";

        // Map Colours
        public const ConsoleColor mountainColor = ConsoleColor.Gray;
        public const ConsoleColor grassColor = ConsoleColor.Green;
        public const ConsoleColor waterColor = ConsoleColor.Blue;
        public const ConsoleColor forestColor = ConsoleColor.DarkGreen;
        public const ConsoleColor sandColor = ConsoleColor.Yellow;
        public const ConsoleColor dungeonEntrance = ConsoleColor.DarkGray;
        public const ConsoleColor castleEntrance = ConsoleColor.Magenta;
        public const ConsoleColor backgroundColor = ConsoleColor.Black;

        // Item Information
        public const int potionHealAmount = 10;
    }
    
}
