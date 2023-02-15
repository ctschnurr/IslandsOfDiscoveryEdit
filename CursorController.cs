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
        
        public CursorController() 
        {
            OuterLeft = 0;
            OuterTop = 0;
            InnerLeft = 1;
            InnerTop = 1;           
            inputAreaLeft = 1;
            inputAreaTop = 23;             
        }

        public static void CursorOuter()
        {            
            Console.SetCursorPosition(OuterLeft, OuterTop);
        }

        public static void CursorInner(int offsetY, int offsetX)
        {
            Console.SetCursorPosition(InnerLeft + offsetY, InnerTop + offsetX);
        }

        public static void CharacterPrintCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void InputAreaCursor(int offsetX, int offsetY)
        {
            Console.SetCursorPosition(inputAreaLeft + offsetY, inputAreaTop + offsetX);
        }

        public static void PlayerStatsCursorInner(int offsetX)
        {
            Console.SetCursorPosition(49, 1 + offsetX);
        }

        public static void EnemyStatsCursorInner(int offsetX)
        {
            Console.SetCursorPosition(49, 12 + offsetX);
        }
    }
}
