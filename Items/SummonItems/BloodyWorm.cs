using CalamityMod.CalPlayer;
using CalamityMod.Events;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using CalamityMod;
using CalamityMod.Rarities;
using CalamityMod.Items.SummonItems;
using CalamityMod.NPCs.OldDuke;
using Microsoft.Xna.Framework;

namespace CalTestHelpers.Items.SummonItems
{
    public class BloodyWorm : ModItem, ILocalizedModType
    {
        public override string Texture => "CalamityMod/Items/SummonItems/BloodwormItem";
        public new string LocalizationCategory => "Items.SummonItems";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 19;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ModContent.RarityType<PureGreen>();
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
            Item.color = Color.Crimson;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossItem;
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 19; // Celestial Sigil
        }

        public override bool CanUseItem(Player player)
        {
            CalamityPlayer modPlayer = player.Calamity();
            bool notOcean = player.position.Y < 800f || player.position.Y > Main.worldSurface * 16.0 || (player.position.X > 6400f && player.position.X < (Main.maxTilesX * 16 - 6400));
            return modPlayer.ZoneSulphur && !notOcean && !NPC.AnyNPCs(ModContent.NPCType<OldDuke>()) && !BossRushEvent.BossRushActive;
        }

        public override bool? UseItem(Player player)
        {
            SoundEngine.PlaySound(CalamityMod.NPCs.OldDuke.OldDuke.RoarSound, player.Center);
            if (Main.netMode != NetmodeID.MultiplayerClient)
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<OldDuke>());
            else
                NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, -1, -1, null, player.whoAmI, ModContent.NPCType<OldDuke>());

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ModContent.ItemType<BloodwormItem>(), 1).
                AddIngredient(ItemID.ChumBucket, 10).
                AddTile(TileID.MeatGrinder).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}

