using CalamityMod.Rarities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalTestHelpers.Items
{
    public class Changelog : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.rare = ModContent.RarityType<CalamityRed>();
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.None;
        }
    }
}
