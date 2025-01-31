﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StarsAbove.Buffs
{
    public class HopesBrillianceBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hope's Brilliance");
            Description.SetDefault("");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            
            
        }
        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            tip = $"{Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().hopesBrilliance}/{Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().hopesBrillianceMax}";

            base.ModifyBuffTip(ref tip, ref rare);
        }
    }
}
