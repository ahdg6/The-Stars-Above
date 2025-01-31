﻿using Terraria;
using Terraria.ModLoader;

namespace StarsAbove.Buffs.VirtuesEdge
{
    public class CelestialVoidBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Void");
            Description.SetDefault("You have torn a rift in spacetime!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
           
        }
    }
}
