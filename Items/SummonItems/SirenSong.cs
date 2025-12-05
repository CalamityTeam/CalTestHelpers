using CalamityMod.CalPlayer;
using CalamityMod.Events;
using CalamityMod.NPCs.Leviathan;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using CalamityMod;

namespace CalTestHelpers.Items.SummonItems
{
    public class SirenSong : ModItem, ILocalizedModType
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.MusicBoxDeerclops}";
        public new string LocalizationCategory => "Items.SummonItems";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 10;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Lime;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
            Item.color = Microsoft.Xna.Framework.Color.Cyan;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossItem;
        }

        public override bool CanUseItem(Player player)
        {
            CalamityPlayer modPlayer = player.Calamity();
            bool notOcean = player.position.Y < 800f || player.position.Y > Main.worldSurface * 16.0 || (player.position.X > 6400f && player.position.X < (Main.maxTilesX * 16 - 6400));
            return !notOcean && !modPlayer.ZoneSulphur && !NPC.AnyNPCs(ModContent.NPCType<Anahita>()) && !NPC.AnyNPCs(ModContent.NPCType<Leviathan>()) && !NPC.AnyNPCs(ModContent.NPCType<LeviathanStart>()) && !BossRushEvent.BossRushActive;
            // No clue why ??? has that name
        }

        public override bool? UseItem(Player player)
        {
            SoundEngine.PlaySound(SoundID.Roar, player.Center);
            if (Main.netMode != NetmodeID.MultiplayerClient)
                NPC.SpawnOnPlayer(player.whoAmI, Main.zenithWorld ? ModContent.NPCType<Leviathan>() : ModContent.NPCType<Anahita>()); 
            else
                NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, -1, -1, null, player.whoAmI, Main.zenithWorld ? ModContent.NPCType<Leviathan>() : ModContent.NPCType<Anahita>());

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.MusicBox, 1).
                AddIngredient(ItemID.Seashell, 10).
                AddTile(TileID.MythrilAnvil).
                Register();
        }
    }
}

