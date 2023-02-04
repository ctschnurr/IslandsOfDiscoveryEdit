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
        //protected int[,] infoArea; placeholder for future hud expansion
        public CursorController() 
        {
            OuterLeft = 0;
            OuterTop = 0;
            InnerLeft = 1;
            InnerTop = 1;           
            inputAreaLeft = 0;
            inputAreaTop = Map.rows * Map.scale + 2;            
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



    }
}
