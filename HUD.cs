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

        public void Draw()
        {   
            if (firstRender)
            {
                Print();
                firstRender = false;
            }
        }
        public void Print()
        {
            string[] hudBorders = File.ReadAllLines(@"Maps_and_Overlays/HudBorders.txt");

            for (int y = 0; y < hudBorders.GetLength(0); y++)
            {
                Console.WriteLine(hudBorders[y]);
            }
        }
    }
}
