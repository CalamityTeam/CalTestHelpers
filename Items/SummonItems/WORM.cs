using CalamityMod.CalPlayer;
using CalamityMod.Events;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using CalamityMod;
using CalamityMod.Items.Potions.Food;
using Microsoft.Xna.Framework;

namespace CalTestHelpers.Items.SummonItems
{
    public class WORM : ModItem, ILocalizedModType
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.TruffleWorm}";
        public new string LocalizationCategory => "Items.SummonItems";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 15;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Yellow;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
            Item.color = Color.LightBlue;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossItem;
        }

        public override bool CanUseItem(Player player)
        {
            CalamityPlayer modPlayer = player.Calamity();
            bool notOcean = player.position.Y < 800f || player.position.Y > Main.worldSurface * 16.0 || (player.position.X > 6400f && player.position.X < (Main.maxTilesX * 16 - 6400));
            return !modPlayer.ZoneSulphur && !notOcean && !NPC.AnyNPCs(NPCID.DukeFishron) && !BossRushEvent.BossRushActive;
        }

        public override bool? UseItem(Player player)
        {
            SoundEngine.PlaySound(SoundID.Zombie20, player.Center); //Terraria internal names suck
            if (Main.netMode != NetmodeID.MultiplayerClient)
                //the regular method fails so I have to do this instead
                NPC.SpawnBoss((int)player.Center.X+(player.position.X > 6400f ? 600 : -600), (int)player.Center.Y, NPCID.DukeFishron, player.whoAmI);
            else
                //may not work
                NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, -1, -1, null, player.whoAmI, NPCID.DukeFishron);

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.TruffleWorm, 1).
                AddIngredient(ModContent.ItemType<DeliciousMeat>(), 10).
                AddTile(TileID.MeatGrinder).
                Register();
        }
    }
}

