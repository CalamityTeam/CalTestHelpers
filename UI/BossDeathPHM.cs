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
            new SpecialUIElement("Toggle King Slime's Death.", TextureAssets.NpcHeadBoss[7].Value, () => ToggleDeath(Boss.KingSlime), GetColor(GetDownedBool(Boss.KingSlime))),
            new SpecialUIElement("Toggle Desert Scourge's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/DesertScourge/DesertScourgeHead_Head_Boss").Value, () => ToggleDeath(Boss.DesertScourge), GetColor(GetDownedBool(Boss.DesertScourge))),
            new SpecialUIElement("Toggle Giant Clam's Death:", ModContent.Request<Texture2D>("CalamityMod/NPCs/SunkenSea/GiantClam_Head_Boss").Value, () => ToggleDeath(Boss.GiantClam), GetColor(GetDownedBool(Boss.GiantClam))),
            new SpecialUIElement("Toggle Eye of Cthulhu's Death.", TextureAssets.NpcHeadBoss[0].Value, () => ToggleDeath(Boss.EyeOfCthulhu), GetColor(GetDownedBool(Boss.EyeOfCthulhu))),
            new SpecialUIElement("Toggle Crabulon's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Crabulon/Crabulon_Head_Boss").Value, () => ToggleDeath(Boss.Crabulon), GetColor(GetDownedBool(Boss.Crabulon))),
            new SpecialUIElement("Toggle Eater of World's Death.", TextureAssets.NpcHeadBoss[2].Value, () => ToggleDeath(Boss.EaterOfWorlds), GetColor(GetDownedBool(Boss.EaterOfWorlds))),
            new SpecialUIElement("Toggle Brain of Cthulhu's Death.", TextureAssets.NpcHeadBoss[23].Value, () => ToggleDeath(Boss.BrainOfCthulhu), GetColor(GetDownedBool(Boss.BrainOfCthulhu))),
            new SpecialUIElement("Toggle Hive Mind's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/HiveMind/HiveMindP2_Head_Boss").Value, () => ToggleDeath(Boss.HiveMind), GetColor(GetDownedBool(Boss.HiveMind))),
            new SpecialUIElement("Toggle The Perforator's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Perforator/PerforatorHive_Head_Boss").Value, () => ToggleDeath(Boss.Perforators), GetColor(GetDownedBool(Boss.Perforators))),
            new SpecialUIElement("Toggle Queen Bee's Death.", TextureAssets.NpcHeadBoss[14].Value, () => ToggleDeath(Boss.QueenBee), GetColor(GetDownedBool(Boss.QueenBee))),
            new SpecialUIElement("Toggle Deerclops' Death.", TextureAssets.NpcHeadBoss[39].Value, () => ToggleDeath(Boss.Deerclops), GetColor(GetDownedBool(Boss.Deerclops))),
            new SpecialUIElement("Toggle Skeletron's Death.", TextureAssets.NpcHeadBoss[19].Value, () => ToggleDeath(Boss.Skeletron), GetColor(GetDownedBool(Boss.Skeletron))),
            new SpecialUIElement("Toggle The Slime God's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/SlimeGod/SlimeGodCore_Head_Boss").Value, () => ToggleDeath(Boss.SlimeGod), GetColor(GetDownedBool(Boss.SlimeGod))),
            new SpecialUIElement("Toggle Wall of Flesh's Death.", TextureAssets.NpcHeadBoss[22].Value, () => ToggleDeath(Boss.WallOfFlesh), GetColor(GetDownedBool(Boss.WallOfFlesh))),
            new SpecialUIElement("Toggle all Prehardmode boss Deaths.", ModContent.Request<Texture2D>("CalamityMod/Items/Weapons/Melee/FracturedArk").Value, () => ToggleDeath(Boss.AllPHM), GetColor(GetDownedBool(Boss.AllPHM)))
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
                    bossName = "Desert Scourge";
                    textColor = new Color(216, 151, 82);
                    bossDeathValue = ref DownedBossSystem._downedDesertScourge;
                    break;
                case Boss.GiantClam:
                    bossName = "Giant Clam";
                    textColor = new Color(66, 239, 245);
                    bossDeathValue = ref DownedBossSystem._downedCLAM;
                    break;
                case Boss.EyeOfCthulhu:
                    bossName = "Eye of Cthulhu";
                    textColor = new Color(216, 116, 114);
                    bossDeathValue = ref NPC.downedBoss1;
                    break;
                case Boss.Crabulon:
                    bossName = "Crabulon";
                    textColor = new Color(0, 184, 216);
                    bossDeathValue = ref DownedBossSystem._downedCrabulon;
                    break;
                case Boss.EaterOfWorlds:
                    bossName = "Eater of Worlds";
                    textColor = new Color(160, 131, 201);
                    bossDeathValue = ref NPC.downedBoss2;
                    break;
                case Boss.BrainOfCthulhu:
                    bossName = "Brain of Cthulhu";
                    textColor = new Color(214, 147, 182);
                    bossDeathValue = ref NPC.downedBoss2;
                    break;
                case Boss.HiveMind:
                    bossName = "Hive Mind";
                    textColor = new Color(160, 131, 201);
                    bossDeathValue = ref DownedBossSystem._downedHiveMind;
                    break;
                case Boss.Perforators:
                    bossName = "The Perforators";
                    textColor = new Color(214, 147, 182);
                    bossDeathValue = ref DownedBossSystem._downedPerforator;
                    break;
                case Boss.QueenBee:
                    bossName = "Queen Bee";
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
                    bossName = "Wall of Flesh";
                    textColor = new Color(192, 106, 122);
                    bossDeathValue = ref Main.hardMode;
                    break;
            }
            bossDeathValue = !bossDeathValue;
            NPC.downedMechBossAny = NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3;
            string bossReferenceText = bossName.Last() == 's' ? bossName + "'" : bossName + "'s";
            Main.NewText($"{bossReferenceText} death is now marked as: {bossDeathValue}", textColor);
        }

        public static void ToggleAllPHMBossDeaths()
        {
            bool killAll = NPC.downedSlimeKing;
            Main.NewText($"All Prehardmode bosses are now marked as {(killAll ? "alive" : "dead")}", Color.Red);

            NPC.downedSlimeKing = DownedBossSystem._downedDesertScourge = NPC.downedBoss1 = DownedBossSystem._downedCLAM = !killAll;
            DownedBossSystem._downedCrabulon = NPC.downedBoss2 = DownedBossSystem._downedHiveMind = DownedBossSystem._downedPerforator = !killAll;
            NPC.downedQueenBee = NPC.downedDeerclops = NPC.downedBoss3 = DownedBossSystem._downedSlimeGod = Main.hardMode = !killAll;
        }
    }
}