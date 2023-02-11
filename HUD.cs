using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class HUD
    {      
        private bool firstRender = true;

        public void HudDraw()
        {   
            if (firstRender)
            {
                PrintHud();
                firstRender = false;
            }
        }
        public void PrintHud()
        {
            string[] hudBorders = File.ReadAllLines("D:\\GitHub\\Game Development\\Game-Development\\IslandsOfDiscoveryTxtRPG\\HudBorders.txt");

            for (int y = 0; y < hudBorders.GetLength(0); y++)
            {
                Console.WriteLine(hudBorders[y]);
            }
        }
    }
}
