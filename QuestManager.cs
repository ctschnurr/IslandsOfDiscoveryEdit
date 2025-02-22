﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG                                                          
{
    internal class QuestManager
    {
        ItemManager itemManager;
        EnemyManager enemyManager;
        Globals globals;
        Enemy questSubject;
        Quest activeQuest;
        bool continueQuests = true;

        int questCount = 0;
        int enemiesMax;
        int goldReward;
        
        Random rand = new Random();

        List<Enemy> enemiesList;

        public QuestManager(EnemyManager enemyManager, ItemManager itemManager, Globals globals)
        {
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
            this.globals = globals;
            enemiesList = enemyManager.EnemiesList;
            enemiesMax = enemiesList.Count;
            NewQuest(enemyManager);
        }

        public void NewQuest(EnemyManager enemyManager)
        {
            this.enemiesList = enemyManager.EnemiesList;

            if (enemiesList.Count > enemiesMax * Globals.questCreationMonsterThreshold && questCount <= Globals.questMaximum)   // if there are more than the threshold of enemies left and player hasn't completed the max number of quests, it'll generate a new quest
            {                                                                               
                questSubject = enemiesList[rand.Next(0, enemiesList.Count)];                
                List<string> excluded = globals.excludedFromQuests;

                while (excluded.Contains(questSubject.Name))                                
                {
                    questSubject = enemiesList[rand.Next(enemiesList.Count)];
                }

                int subjectCount = 0;

                foreach (Enemy countUs in enemiesList)                                      
                {
                    if (countUs.Name == questSubject.Name)
                    {
                        subjectCount++;
                    }
                }

                goldReward = rand.Next(Globals.questRewardMin, Globals.questRewardMax);
                goldReward *= subjectCount;

                activeQuest = new Quest(questSubject.Name, subjectCount, goldReward);       

            }
            else
            {
                activeQuest.questString = "Slay the Dragon!  ";
                continueQuests = false;
            }
        }

        public void Update(EnemyManager enemyManager)
        {
            if(continueQuests)
            {
                this.enemiesList = enemyManager.EnemiesList;

                int subjectCount = 0;

                foreach (Enemy countUs in enemiesList)
                {
                    if (countUs.Name == questSubject.Name)
                    {
                        subjectCount++;
                    }
                }

                if (subjectCount > 0)
                {
                    activeQuest.questEnemyAmount = subjectCount;
                    activeQuest.Update();
                }
                else QuestComplete();
            }
        }

        public void QuestComplete()
        {
            int goldReward = activeQuest.goldReward;
            CursorController.InputAreaCursor(4, 0);
            Console.WriteLine(" You completed a quest! Your reward is " + goldReward + " gold!");

            for (int i = 0; i <= activeQuest.goldReward; i++)
            {
                itemManager.PlayerInventory.Add("gold");
            }

            NewQuest(enemyManager);
        }
        public string GetQuest()
        {
            return activeQuest.questString;
        }
    }
}
