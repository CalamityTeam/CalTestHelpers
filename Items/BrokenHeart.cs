using CalamityMod;
using CalamityMod.Items.Materials;
using CalamityMod.Items.SummonItems;
using CalamityMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalTestHelpers.Items
{
    public class BrokenHeart : ModItem
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.LifeCrystal}";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 19; // Life Crystal
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
            Item.useTime = 30;
            Item.useAnimation = 30;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.Calamity().sStrawberry || player.Calamity().sTangerine || player.Calamity().tCloudberry || player.Calamity().mFruit)
                return false;
            else
                return true;
        }
        public override bool? UseItem(Player player)
        {
            if (player.statLifeMax > 100)
            {
                player.UseHealthMaxIncreasingItem(-20);
                if (player.ConsumedLifeFruit > 0)
                    player.ConsumedLifeFruit -= 4;
                else if (player.ConsumedLifeCrystals > 0)
                    player.ConsumedLifeCrystals -= 1;
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.LifeCrystal, 1).
                AddCondition(Condition.InGraveyard).
                Register();
        }
    }
}
