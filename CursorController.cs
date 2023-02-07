using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class CursorController
    {
        protected static int OuterLeft, OuterTop;
        protected static int InnerLeft, InnerTop;        
        protected static int inputAreaLeft, inputAreaTop;
        protected static int playerStatsLeftInner, playerStatsTopInner, playerStatsLeftOuter, playerStatsTopOuter;
        protected static int enemyStatsLeft, enemyStatsTop, enemyStatsLeftOuter, enemyStatsTopOuter;        
        public CursorController() 
        {
            OuterLeft = 0;
            OuterTop = 0;
            InnerLeft = 1;
            InnerTop = 1;           
            inputAreaLeft = 1;
            inputAreaTop = Map.rows * Map.scale + 2;  
            playerStatsLeftInner = Map.rows * Map.scale + 3;
            playerStatsTopInner = 1;
            playerStatsLeftOuter = Map.rows * Map.scale + 2;
            playerStatsTopOuter = 0;
            enemyStatsLeft = Map.rows * Map.scale + 3;
            enemyStatsTop = HUD.statsRows * HUD.statsCols + 3;
            enemyStatsLeftOuter = Map.rows * Map.scale + 2;
            enemyStatsTopOuter = 0 + HUD.statsRows + 3;
        }

        public static void CursorOuter()
        {            
            Console.SetCursorPosition(OuterLeft, OuterTop);
        }

        public static void CursorInner()
        {
            Console.SetCursorPosition(InnerLeft, InnerTop);
        }

        public static void CharacterPrintCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void InputAreaCursor()
        {
            Console.SetCursorPosition(inputAreaLeft, inputAreaTop);
        }

        public static void PlayerStatsCursorInner()
        {
            Console.SetCursorPosition(playerStatsLeftInner, playerStatsTopInner);
        }

        public static void EnemyStatsCursorInner()
        {
            Console.SetCursorPosition(enemyStatsLeft, enemyStatsTop);
        }

        public static void PlayerStatsCursorOuter()
        {
            Console.SetCursorPosition(playerStatsLeftOuter, playerStatsTopOuter);
        }

        public static void EnemyStatsCursorOuter()
        {
            Console.SetCursorPosition(enemyStatsLeftOuter, enemyStatsTopOuter);
        }
    }
}
