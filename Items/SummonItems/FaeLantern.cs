using CalamityMod.Events;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace CalTestHelpers.Items.SummonItems
{
    public class FaeLantern : ModItem, ILocalizedModType
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.FairyQueenMagicItem}";
        //Why is that its internal name?
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
            Item.color = Color.Pink;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossItem;
        }

        public override bool CanUseItem(Player player)
        {
            // No biome restriction since she doesn't enrage
            return !NPC.AnyNPCs(NPCID.EmpressButterfly) && !NPC.AnyNPCs(NPCID.HallowBoss) && !BossRushEvent.BossRushActive;
        }

        public override bool? UseItem(Player player)
        {
            SoundEngine.PlaySound(SoundID.Item161, player.Center); //Why is that the sound?
            if (Main.netMode != NetmodeID.MultiplayerClient)
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.HallowBoss); // No clue why it has that name
            else
                NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, -1, -1, null, player.whoAmI, NPCID.HallowBoss);

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.BrassLantern, 1).
                AddIngredient(ItemID.EmpressButterfly, 1).
                AddTile(TileID.MythrilAnvil).
                Register();
        }
    }
}

