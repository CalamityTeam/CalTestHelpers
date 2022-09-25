using CalamityMod;
using CalamityMod.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalTestHelpers.UI
{
    public class BossDeathPHM : BossDeathUIRenderer
    {
        public override List<SpecialUIElement> UIElements => new List<SpecialUIElement>()
        {
            new SpecialUIElement("Toggle King Slime's Death.", TextureAssets.NpcHeadBoss[7].Value, () => ToggleDeath(Boss.KingSlime)),
            new SpecialUIElement("Toggle The Desert Scourge's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/DesertScourge/DesertScourgeHead_Head_Boss").Value, () => ToggleDeath(Boss.DesertScourge)),
            new SpecialUIElement("Toggle The Eye of Cthulhu's Death.", TextureAssets.NpcHeadBoss[0].Value, () => ToggleDeath(Boss.EyeOfCthulhu)),
            new SpecialUIElement("Toggle Crabulon's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Crabulon/Crabulon_Head_Boss").Value, () => ToggleDeath(Boss.Crabulon)),
            new SpecialUIElement("Toggle The Eater of World's Death.", TextureAssets.NpcHeadBoss[2].Value, () => ToggleDeath(Boss.EaterOfWorlds)),
            new SpecialUIElement("Toggle The Brain of Cthulhu's Death.", TextureAssets.NpcHeadBoss[23].Value, () => ToggleDeath(Boss.BrainOfCthulhu)),
            new SpecialUIElement("Toggle The Hive Mind's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/HiveMind/HiveMindP2_Head_Boss").Value, () => ToggleDeath(Boss.HiveMind)),
            new SpecialUIElement("Toggle The Perforator's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Perforator/PerforatorHive_Head_Boss").Value, () => ToggleDeath(Boss.Perforators)),
            new SpecialUIElement("Toggle The Queen Bee's Death.", TextureAssets.NpcHeadBoss[14].Value, () => ToggleDeath(Boss.QueenBee)),
            new SpecialUIElement("Toggle Deerclops' Death.", TextureAssets.NpcHeadBoss[39].Value, () => ToggleDeath(Boss.Deerclops)),
            new SpecialUIElement("Toggle Skeletron's Death.", TextureAssets.NpcHeadBoss[19].Value, () => ToggleDeath(Boss.Skeletron)),
            new SpecialUIElement("Toggle The Slime God's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/SlimeGod/SlimeGodCore_Head_Boss").Value, () => ToggleDeath(Boss.SlimeGod)),
            new SpecialUIElement("Toggle The Wall of Flesh's Death.", TextureAssets.NpcHeadBoss[22].Value, () => ToggleDeath(Boss.WallOfFlesh)),
            new SpecialUIElement("Toggle every Prehardmode boss' Death.", TextureAssets.Item[ItemID.EnchantedSword].Value, () => ToggleDeath(Boss.AllPHM))
        };

        public static void ToggleDeath(Boss bossDeathToToggle)
        {
            if (bossDeathToToggle == Boss.AllPHM)
            {
                ToggleAllPHMBossDeaths();
                return;
            }
            string bossName = string.Empty;
            Color textColor = Color.White;
            ref bool bossDeathValue = ref NPC.downedSlimeKing;
            switch (bossDeathToToggle)
            {
                case Boss.KingSlime:
                    bossName = "King Slime";
                    textColor = new Color(96, 170, 255);
                    bossDeathValue = ref NPC.downedSlimeKing;
                    break;
                case Boss.DesertScourge:
                    bossName = "The Desert Scourge";
                    textColor = new Color(216, 151, 82);
                    bossDeathValue = ref DownedBossSystem._downedDesertScourge;
                    break;
                case Boss.EyeOfCthulhu:
                    bossName = "The Eye of Cthulhu";
                    textColor = new Color(216, 116, 114);
                    bossDeathValue = ref NPC.downedBoss1;
                    break;
                case Boss.Crabulon:
                    bossName = "Crabulon";
                    textColor = new Color(0, 184, 216);
                    bossDeathValue = ref DownedBossSystem._downedCrabulon;
                    break;
                case Boss.EaterOfWorlds:
                    bossName = "The Eater of Worlds";
                    textColor = new Color(160, 131, 201);
                    bossDeathValue = ref NPC.downedBoss2;
                    break;
                case Boss.BrainOfCthulhu:
                    bossName = "The Brain of Cthulhu";
                    textColor = new Color(214, 147, 182);
                    bossDeathValue = ref NPC.downedBoss2;
                    break;
                case Boss.HiveMind:
                    bossName = "The Hive Mind";
                    textColor = new Color(160, 131, 201);
                    bossDeathValue = ref DownedBossSystem._downedHiveMind;
                    break;
                case Boss.Perforators:
                    bossName = "The Perforators";
                    textColor = new Color(214, 147, 182);
                    bossDeathValue = ref DownedBossSystem._downedPerforator;
                    break;
                case Boss.QueenBee:
                    bossName = "The Queen Bee";
                    textColor = new Color(216, 205, 2);
                    bossDeathValue = ref NPC.downedQueenBee;
                    break;
                case Boss.Deerclops:
                    bossName = "Deerclops";
                    textColor = new Color(190, 230, 253);
                    bossDeathValue = ref NPC.downedDeerclops;
                    break;
                case Boss.Skeletron:
                    bossName = "Skeletron";
                    textColor = new Color(183, 92, 214);
                    bossDeathValue = ref NPC.downedBoss3;
                    break;
                case Boss.SlimeGod:
                    bossName = "The Slime God";
                    textColor = new Color(182, 0, 164);
                    bossDeathValue = ref DownedBossSystem._downedSlimeGod;
                    break;
                case Boss.WallOfFlesh:
                    bossName = "The Wall of Flesh";
                    textColor = new Color(192, 106, 122);
                    bossDeathValue = ref Main.hardMode;
                    break;
            }
            bossDeathValue = !bossDeathValue;
            NPC.downedMechBossAny = NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3;
            string bossRefernceText = bossName.Last() == 's' ? bossName + "'" : bossName + "'s";
            Main.NewText($"{bossRefernceText} death is now marked as: {bossDeathValue}", textColor);
        }

        public static void ToggleAllPHMBossDeaths()
        {
            bool killAll = NPC.downedSlimeKing;
            Main.NewText($"All Prehardmode bosses are now marked as {(killAll ? "alive" : "dead")}", Color.Red);

            NPC.downedSlimeKing = DownedBossSystem._downedDesertScourge = NPC.downedBoss1 = !killAll;
            DownedBossSystem._downedCrabulon = NPC.downedBoss2 = DownedBossSystem._downedHiveMind = DownedBossSystem._downedPerforator = !killAll;
            NPC.downedQueenBee = NPC.downedDeerclops = NPC.downedBoss3 = DownedBossSystem._downedSlimeGod = Main.hardMode = !killAll;
        }
    }
}