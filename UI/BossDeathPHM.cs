using CalamityMod;
using CalamityMod.World;
using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalTestHelpers.UI
{
    public class BossDeathPHM : BossDeathUIRenderer
    {
        public override List<SpecialUIElement> UIElements => new List<SpecialUIElement>()
        {
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.KingSlime)), TextureAssets.NpcHeadBoss[7].Value, () => ToggleDeath(Boss.KingSlime), GetColor(GetDownedBool(Boss.KingSlime))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.DesertScourge)), ModContent.Request<Texture2D>("CalamityMod/NPCs/DesertScourge/DesertScourgeHead_Head_Boss").Value, () => ToggleDeath(Boss.DesertScourge), GetColor(GetDownedBool(Boss.DesertScourge))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.GiantClam)), ModContent.Request<Texture2D>("CalamityMod/NPCs/SunkenSea/GiantClam_Head_Boss").Value, () => ToggleDeath(Boss.GiantClam), GetColor(GetDownedBool(Boss.GiantClam))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.EyeOfCthulhu)), TextureAssets.NpcHeadBoss[0].Value, () => ToggleDeath(Boss.EyeOfCthulhu), GetColor(GetDownedBool(Boss.EyeOfCthulhu))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.Crabulon)), ModContent.Request<Texture2D>("CalamityMod/NPCs/Crabulon/Crabulon_Head_Boss").Value, () => ToggleDeath(Boss.Crabulon), GetColor(GetDownedBool(Boss.Crabulon))),
            new SpecialUIElement(Language.GetTextValue(BossKeyEndsWithS, GetBossLocalizationKey(Boss.EaterOfWorlds)), TextureAssets.NpcHeadBoss[2].Value, () => ToggleDeath(Boss.EaterOfWorlds), GetColor(GetDownedBool(Boss.EaterOfWorlds))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.BrainOfCthulhu)), TextureAssets.NpcHeadBoss[23].Value, () => ToggleDeath(Boss.BrainOfCthulhu), GetColor(GetDownedBool(Boss.BrainOfCthulhu))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.HiveMind)), ModContent.Request<Texture2D>("CalamityMod/NPCs/HiveMind/HiveMindP2_Head_Boss").Value, () => ToggleDeath(Boss.HiveMind), GetColor(GetDownedBool(Boss.HiveMind))),
            new SpecialUIElement(Language.GetTextValue(BossKeyEndsWithS, GetBossLocalizationKey(Boss.Perforators)), ModContent.Request<Texture2D>("CalamityMod/NPCs/Perforator/PerforatorHive_Head_Boss").Value, () => ToggleDeath(Boss.Perforators), GetColor(GetDownedBool(Boss.Perforators))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.QueenBee)), TextureAssets.NpcHeadBoss[14].Value, () => ToggleDeath(Boss.QueenBee), GetColor(GetDownedBool(Boss.QueenBee))),
            new SpecialUIElement(Language.GetTextValue(BossKeyEndsWithS, GetBossLocalizationKey(Boss.Deerclops)), TextureAssets.NpcHeadBoss[39].Value, () => ToggleDeath(Boss.Deerclops), GetColor(GetDownedBool(Boss.Deerclops))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.Skeletron)), TextureAssets.NpcHeadBoss[19].Value, () => ToggleDeath(Boss.Skeletron), GetColor(GetDownedBool(Boss.Skeletron))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.SlimeGod)), ModContent.Request<Texture2D>("CalamityMod/NPCs/SlimeGod/SlimeGodCore_Head_Boss").Value, () => ToggleDeath(Boss.SlimeGod), GetColor(GetDownedBool(Boss.SlimeGod))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.WallOfFlesh)), TextureAssets.NpcHeadBoss[22].Value, () => ToggleDeath(Boss.WallOfFlesh), GetColor(GetDownedBool(Boss.WallOfFlesh))),
            new SpecialUIElement(Language.GetTextValue(GetBossLocalizationKey(Boss.AllPHM)), ModContent.Request<Texture2D>("CalamityMod/Items/Weapons/Melee/FracturedArk").Value, () => ToggleDeath(Boss.AllPHM), GetColor(GetDownedBool(Boss.AllPHM)))
        };


        public static void ToggleDeath(Boss bossDeathToToggle)
        {
            if (bossDeathToToggle == Boss.AllPHM)
            {
                ToggleAllPHMBossDeaths();
                return;
            }
            string bossName = GetBossLocalizationKey(bossDeathToToggle);
            Color textColor = Color.White;
            ref bool bossDeathValue = ref NPC.downedSlimeKing;
            switch (bossDeathToToggle)
            {
                case Boss.KingSlime:
                    textColor = new Color(96, 170, 255);
                    bossDeathValue = ref NPC.downedSlimeKing;
                    break;
                case Boss.DesertScourge:
                    textColor = new Color(216, 151, 82);
                    bossDeathValue = ref DownedBossSystem._downedDesertScourge;
                    break;
                case Boss.GiantClam:
                    textColor = new Color(66, 239, 245);
                    bossDeathValue = ref DownedBossSystem._downedCLAM;
                    break;
                case Boss.EyeOfCthulhu:
                    textColor = new Color(216, 116, 114);
                    bossDeathValue = ref NPC.downedBoss1;
                    break;
                case Boss.Crabulon:
                    textColor = new Color(0, 184, 216);
                    bossDeathValue = ref DownedBossSystem._downedCrabulon;
                    break;
                case Boss.EaterOfWorlds:
                    textColor = new Color(160, 131, 201);
                    bossDeathValue = ref NPC.downedBoss2;
                    break;
                case Boss.BrainOfCthulhu:
                    textColor = new Color(214, 147, 182);
                    bossDeathValue = ref NPC.downedBoss2;
                    break;
                case Boss.HiveMind:
                    textColor = new Color(160, 131, 201);
                    bossDeathValue = ref DownedBossSystem._downedHiveMind;
                    break;
                case Boss.Perforators:
                    textColor = new Color(214, 147, 182);
                    bossDeathValue = ref DownedBossSystem._downedPerforator;
                    break;
                case Boss.QueenBee:
                    textColor = new Color(216, 205, 2);
                    bossDeathValue = ref NPC.downedQueenBee;
                    break;
                case Boss.Deerclops:
                    textColor = new Color(190, 230, 253);
                    bossDeathValue = ref NPC.downedDeerclops;
                    break;
                case Boss.Skeletron:
                    textColor = new Color(183, 92, 214);
                    bossDeathValue = ref NPC.downedBoss3;
                    break;
                case Boss.SlimeGod:
                    textColor = new Color(182, 0, 164);
                    bossDeathValue = ref DownedBossSystem._downedSlimeGod;
                    break;
                case Boss.WallOfFlesh:
                    textColor = new Color(192, 106, 122);
                    bossDeathValue = ref Main.hardMode;
                    break;
            }
            bossDeathValue = !bossDeathValue;
            string DeadOrAlive = Language.GetTextValue(key + (bossDeathValue ? "Dead" : "Alive"));
            bool bossReferenceText = bossName.Last() == 's';
            Main.NewText(Language.GetTextValue(key+(bossReferenceText ? "ToggleEndsWithS" : "Toggle"), bossName, DeadOrAlive), textColor);
        }

        public static LocalizedText ToggleAllPreHM { get; private set; }
        public static void ToggleAllPHMBossDeaths()
        {
            bool killAll = NPC.downedSlimeKing;
            string DeadOrAlive = Language.GetTextValue(key + (killAll ? "Dead" : "Alive"));
            Main.NewText(Language.GetTextValue(key+ "ToggleAllPreHM", DeadOrAlive), Color.Red);

            NPC.downedSlimeKing = DownedBossSystem._downedDesertScourge = NPC.downedBoss1 = DownedBossSystem._downedCLAM = !killAll;
            DownedBossSystem._downedCrabulon = NPC.downedBoss2 = DownedBossSystem._downedHiveMind = DownedBossSystem._downedPerforator = !killAll;
            NPC.downedQueenBee = NPC.downedDeerclops = NPC.downedBoss3 = DownedBossSystem._downedSlimeGod = Main.hardMode = !killAll;
        }
    }
}