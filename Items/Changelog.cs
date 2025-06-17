using CalamityMod.Rarities;
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
