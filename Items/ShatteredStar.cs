using CalamityMod;
using CalamityMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalTestHelpers.Items
{
    public class ShatteredStar : ModItem
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.ManaCrystal}";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 21; // Mana Crystal
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.color = Color.DimGray;
            Item.UseSound = SoundID.Item4;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.Calamity().cShard || player.Calamity().eCore || player.Calamity().pHeart)
                return false;
            else
                return true;
        }
        public override bool? UseItem(Player player)
        {
            if (player.statManaMax > 20)
            {
                player.UseManaMaxIncreasingItem(-20);
                if (player.ConsumedManaCrystals > 0)
                    player.ConsumedManaCrystals -= 1;
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.ManaCrystal, 1).
                AddCondition(Condition.InGraveyard).
                Register();
        }
    }
}
