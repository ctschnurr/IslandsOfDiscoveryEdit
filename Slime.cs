using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandsOfDiscoveryTxtRPG
{
    internal class Slime : Enemy
    {
        public Slime(int x, int y, Map map, Player player, ItemManager itemManager, HUD hud, CursorController cursorController) : base(x, y, map, player, itemManager, hud, cursorController)
        {
            name = "Slime";
            character = "s";
            basehealth = 2;
            basespeed = 2;
            basestrength = 1;
            health = basehealth;            
            strength = basestrength;
            xpValue = 2;
            moveEnergy = 0;
            energyToMove = 200;
            base.map = map;
            base.player = player;
            base.itemManager = itemManager;
            base.hud = hud;
            base.cursorController = cursorController;
        }
    }
}
