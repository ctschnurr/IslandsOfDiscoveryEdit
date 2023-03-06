using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class EnemyManager
    {
        Enemy[] enemies = new Enemy[25];

        //constructor

        public EnemyManager()
        {

        }

        public void Update()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Update();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Draw();
            }
        }
    }
}
