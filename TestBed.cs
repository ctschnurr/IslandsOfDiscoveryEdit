using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class TestBed
    {
        Random random = new Random();
        
        public char[,] overland;

        public TestBed(int width, int height)
        {
            overland = new char[width, height];
        }

        public void Generate()
        {
            bool loop;

            for (int i = 0; i < overland.GetLength(0); i++)
            {
                for (int j = 0; j < overland.GetLength(1); j++)
                {
                    overland[i, j] = '~';
                }
            }

            for (int i = 0; i < random.Next((int)(overland.GetLength(0) * overland.GetLength(1)) / 20, (int)(overland.GetLength(0) * overland.GetLength(1)) / 10); i++)
            {
                loop = true;
                while (loop == true)
                {
                    int k = random.Next(0, overland.GetLength(0));
                    int j = random.Next(0, overland.GetLength(1));

                    if (overland[k,j] == '~')
                    {
                        overland[k, j] = Lift();
                    }
                }
            }
        }

        private char Lift()
        {

        }

        private void SurroundCheck()
        {
            for (int i = 0; i < overland.GetLength(0); i++)
            {
                for (int j = 0; i < overland.GetLength(1); j++)
                {
                    switch (overland[i,j])
                    {
                        case i + 1 == '~':
                            break;
                    }
                        

                }
            } 
        }
    }
}
