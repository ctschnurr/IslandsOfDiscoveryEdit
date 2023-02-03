using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class CursorController
    {
        protected int[,] topOuterLeft;
        protected int[,] topInnerLeft;
        protected int[,] playerPrint;
        protected int[,] enemyPrint;
        protected int[,] inputArea;
        public CursorController() 
        {
            topOuterLeft = new int[0, 0];
            topInnerLeft = new int[1, 1];
            

        
        }




    }
}
