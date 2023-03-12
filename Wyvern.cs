using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Wyvern : Enemy
    {
        public Wyvern(int x, int y, Map map, Player player, ItemManager itemManager, HUD hud, CursorController cursorController) : base(x, y, map, player, itemManager, hud, cursorController)
        {
            name = "Wyvern";
            character = "W";
            basehealth = 12;
            basespeed = 12;
            basestrength = 4;
            health = basehealth;            
            strength = basestrength;
            xpValue = 5;
            moveEnergy = 0;
            energyToMove = 100;
            base.map = map;
            base.player = player;
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;
        }

        override protected void Walkable(int x, int y)
        {
            if (map.TerrainCheck('~', x, y))
            {
                ResetMyPOS();
            }
        }
    }
}
