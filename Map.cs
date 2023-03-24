using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Map
    {
        public Globals globals;

        public char[,] map;
        public List<Tuple<int, int>> spawnPoints;

        public static bool firstmaprender = true;

        public int rows;
        public int cols;        
        
        public void Update()
        {
            if (firstmaprender == true)
            {                
                firstmaprender = false;                
                Draw();
            }
        }

        public Map(Globals globals) //constructor
        {
            string[] mapString = File.ReadAllLines(globals.worldMap);
            map = new char[mapString.GetLength(0), mapString[0].Length];

            for (int x = 0; x < mapString.GetLength(0); x++)
            for (int y = 0; y < mapString[0].Length; y++)
                
            map[x, y] = mapString[x][y];                
            
            rows = map.GetLength(0);
            cols = map.GetLength(1);

            spawnPoints = new List<Tuple<int, int>>();

            this.globals = globals;
        }        
        public void Draw()
        {
            CursorController.CursorInner(0, 0);
            int posY = 1;                                           //accounts for offset of border
                for (int x = 0; x < rows; x++)
                {                    
                    for (int y = 0; y < cols; y++)
                    {                           
                        ColourCode(x, y);                        
                        Console.Write(map[x, y]);                           
                    }
                    Console.BackgroundColor = globals.backgroundColor;                        
                    Console.WriteLine();
                    CursorController.CursorInner(0, posY);          //adjusts the cursor to print each line on the correct line
                    posY++;
                }                
        }
        public void ColourCode(int x, int y)
        {
            switch (map[x, y]) //checks the characters in the array and assigns them colours
            {
                case '^': //mountain
                    Console.BackgroundColor = globals.mountainColor;
                    break;
                case '`': //grass
                    Console.BackgroundColor = globals.grassColor;
                    break;
                case '~': //water
                    Console.BackgroundColor = globals.waterColor;
                    break;
                case '*': //forest
                    Console.BackgroundColor = globals.forestColor;
                    break;
                case '∩': //dungeon entrance
                    Console.BackgroundColor = globals.dungeonEntrance;
                    break;
                case 'C': //castle entrance
                    Console.BackgroundColor = globals.castleEntrance;
                    break;
                case '#': //sand
                    Console.BackgroundColor = globals.sandColor;
                    break;
                default:
                    Console.BackgroundColor = globals.backgroundColor;
                    break;
            }
        }
        public void Redraw(int x, int y)
        {
            CursorController.CharacterPrintCursor(x, y);                            //sets the cursor position to the players previous location                  
            ColourCode(y - 1, x - 1);                                               //gets the appropriate colour for reprinting the previous position
            Console.Write(map[y - 1, x - 1]);                                       //writes the map array location at the player's previous location
            Console.BackgroundColor = globals.backgroundColor;                      //resets the console color for normal printing        
        }    
        
        public bool CheckForTerrain(char i, int x, int y)                              //takes in a char representing a terrain tile and an x/y location and returns true/false if it matches the location on the map
        {            
            if (map[y - 1, x - 1] == i)
            {
                return true;
            }
            return false;            
        }

        public bool CheckForBorder(int x, int y)
        {
            if (x < 1 || y < 1 || x > cols || y > rows)                             //checks to see if the move is outside the bounds of the map first
            {
                return true;
            }
            return false;
        }

        public List<Tuple<int, int>> SpawnPointsArray(char spawnPoint)              // takes in a char and returns a Tuple'd list of x/y positions that match that character
        {  
            for (int x = 0; x < rows; x++)
            {
                for (int  y = 0; y < cols; y++)
                {
                    if (map[x, y] == spawnPoint)
                    {
                        spawnPoints.Add(new Tuple<int, int>(x + 1, y + 1));         
                    }
                }
            }            
            return spawnPoints;
        }
    }
}
