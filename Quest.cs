using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Quest
    {
        public string questEnemyType;
        public int questEnemyAmount;
        public int goldReward;

        public string questString;

        public Quest(string enemyTypeInput, int enemyAmountinput, int rewardInput)
        {
            questEnemyType = enemyTypeInput;
            questEnemyAmount = enemyAmountinput;
            goldReward = rewardInput;
        }

        public void Update()
        {
            questString = "Slay " + questEnemyAmount + " " + questEnemyType + "s";
        }

    }
}
