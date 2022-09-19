using CalamityMod;
using CalamityMod.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalTestHelpers.UI
{
    public class BossDeathUIRenderer : GrandUIRenderer
    {
        public enum Boss
        {
            KingSlime,
            DesertScourge,
            EyeOfCthulhu,
            Crabulon,
            EaterOfWorlds,
            BrainOfCthulhu,
            HiveMind,
            Perforators,
            QueenBee,
			Deerclops,
            Skeletron,
            SlimeGod,
            WallOfFlesh,
			QueenSlime,
            Cryogen,
            TheTwins,
            BrimstoneElemental,
            TheDestroyer,
            TheAquaticScourge,
            SkeletronPrime,
            Cloneamitas,
            Plantera,
            Leviathan,
            AstrumAureus,
            Golem,
            PlaguebringerGoliath,
			EmpressOfLight,
            DukeFishron,
            Ravager,
            LunaticCultist,
            AstrumDeus,
            MoonLord,
            ProfanedGuardians,
            Dragonfolly,
            Providence,
            CeaselessVoid,
            StormWeaver,
            Signus,
            Polterghast,
            OldDuke,
            DevourerOfGods,
            Yharon,
            Draedon,
            SupremeCalamitas,
            All
        }
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
            new SpecialUIElement("Toggle Queen Slime's Death.", TextureAssets.NpcHeadBoss[38].Value, () => ToggleDeath(Boss.QueenSlime)),
            new SpecialUIElement("Toggle Cryogen's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Cryogen/Cryogen_Phase1_Head_Boss").Value, () => ToggleDeath(Boss.Cryogen)),
            new SpecialUIElement("Toggle The Twins' Death.", TextureAssets.NpcHeadBoss[16].Value, () => ToggleDeath(Boss.TheTwins)),
            new SpecialUIElement("Toggle The Brimstone Elemental's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/BrimstoneElemental/BrimstoneElemental_Head_Boss").Value, () => ToggleDeath(Boss.BrimstoneElemental)),
            new SpecialUIElement("Toggle The Destroyer's Death.", TextureAssets.NpcHeadBoss[25].Value, () => ToggleDeath(Boss.TheDestroyer)),
            new SpecialUIElement("Toggle The Aquatic Scourge's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/AquaticScourge/AquaticScourgeHead_Head_Boss").Value, () => ToggleDeath(Boss.TheAquaticScourge)),
            new SpecialUIElement("Toggle Skeletron Prime's Death.", TextureAssets.NpcHeadBoss[18].Value, () => ToggleDeath(Boss.SkeletronPrime)),
            new SpecialUIElement("Toggle The Calamitas Clone's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Calamitas/CalamitasClone_Head_Boss").Value, () => ToggleDeath(Boss.Cloneamitas)),
            new SpecialUIElement("Toggle Plantera's Death.", TextureAssets.NpcHeadBoss[11].Value, () => ToggleDeath(Boss.Plantera)),
            new SpecialUIElement("Toggle The Leviathan's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Leviathan/Leviathan_Head_Boss").Value, () => ToggleDeath(Boss.Leviathan)),
            new SpecialUIElement("Toggle Astrum Aureus' Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/AstrumAureus/AstrumAureus_Head_Boss").Value, () => ToggleDeath(Boss.AstrumAureus)),
            new SpecialUIElement("Toggle Golem's Death.", TextureAssets.NpcHeadBoss[5].Value, () => ToggleDeath(Boss.Golem)),
            new SpecialUIElement("Toggle The Plaguebringer Goliath's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/PlaguebringerGoliath/PlaguebringerGoliath_Head_Boss").Value, () => ToggleDeath(Boss.PlaguebringerGoliath)),
            new SpecialUIElement("Toggle Empress of Light's Death.", TextureAssets.NpcHeadBoss[37].Value, () => ToggleDeath(Boss.EmpressOfLight)),
            new SpecialUIElement("Toggle Duke Fishron's Death.", TextureAssets.NpcHeadBoss[4].Value, () => ToggleDeath(Boss.DukeFishron)),
            new SpecialUIElement("Toggle The Ravager's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Ravager/RavagerBody_Head_Boss").Value, () => ToggleDeath(Boss.Ravager)),
            new SpecialUIElement("Toggle The Lunatic Cultist's Death.", TextureAssets.NpcHeadBoss[31].Value, () => ToggleDeath(Boss.LunaticCultist)),
            new SpecialUIElement("Toggle Astrum Deus' Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/AstrumDeus/AstrumDeusHead_Head_Boss").Value, () => ToggleDeath(Boss.AstrumDeus)),
            new SpecialUIElement("Toggle The Moon Lord's Death.", TextureAssets.NpcHeadBoss[8].Value, () => ToggleDeath(Boss.MoonLord)),
            new SpecialUIElement("Toggle The Profaned Guardian's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/ProfanedGuardians/ProfanedGuardianCommander_Head_Boss").Value, () => ToggleDeath(Boss.ProfanedGuardians)),
            new SpecialUIElement("Toggle The Dragonfolly's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Bumblebirb/Birb_Head_Boss").Value, () => ToggleDeath(Boss.Dragonfolly)),
            new SpecialUIElement("Toggle Providence's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Providence/Providence_Head_Boss").Value, () => ToggleDeath(Boss.Providence)),
            new SpecialUIElement("Toggle The Ceasless Void's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/CeaselessVoid/CeaselessVoid_Head_Boss").Value, () => ToggleDeath(Boss.CeaselessVoid)),
            new SpecialUIElement("Toggle The Storm Weaver's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/StormWeaver/StormWeaverHeadNaked_Head_Boss").Value, () => ToggleDeath(Boss.StormWeaver)),
            new SpecialUIElement("Toggle Signus' Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Signus/Signus_Head_Boss").Value, () => ToggleDeath(Boss.Signus)),
            new SpecialUIElement("Toggle The Polterghast's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Polterghast/Polterghast_Head_Boss").Value, () => ToggleDeath(Boss.Polterghast)),
            new SpecialUIElement("Toggle The Old Duke's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/OldDuke/OldDuke_Head_Boss").Value, () => ToggleDeath(Boss.OldDuke)),
            new SpecialUIElement("Toggle The Devourer of Gods' Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/DevourerofGods/DevourerofGodsHeadS_Head_Boss").Value, () => ToggleDeath(Boss.DevourerOfGods)),
            new SpecialUIElement("Toggle Yharon's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Yharon/Yharon_Head_Boss").Value, () => ToggleDeath(Boss.Yharon)),
            new SpecialUIElement("Toggle The Exo Mechs' Death.", ModContent.Request<Texture2D>("CalTestHelpers/UI/TemporaryDraedonIcon").Value, () => ToggleDeath(Boss.Draedon)),
            new SpecialUIElement("Toggle Supreme Calamitas' Death.", ModContent.Request<Texture2D>("CalamityMod/Items/Pets/BrimstoneJewel").Value, () => ToggleDeath(Boss.SupremeCalamitas)),
            new SpecialUIElement("Toggle every boss' Death.", ModContent.Request<Texture2D>("CalamityMod/Items/SummonItems/Terminus").Value, () => ToggleDeath(Boss.All)),
        };
        public override float UIScale => 0.65f * ResolutionRatio;

        public override Vector2 TopLeftLocation => new Vector2(Main.screenWidth - 660 - 270 * ResolutionRatio, 5);

        public static void ToggleDeath(Boss bossDeathToToggle)
        {
            if (bossDeathToToggle == Boss.All)
            {
                ToggleAllBossDeaths();
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
                case Boss.QueenSlime:
                    bossName = "Queen Slime";
                    textColor = new Color(255, 129, 255);
                    bossDeathValue = ref NPC.downedQueenSlime;
                    break;
                case Boss.Cryogen:
                    bossName = "Cryogen";
                    textColor = new Color(174, 229, 239);
                    bossDeathValue = ref DownedBossSystem._downedCryogen;
                    break;
                case Boss.TheTwins:
                    bossName = "The Twins";
                    textColor = new Color(147, 189, 198);
                    bossDeathValue = ref NPC.downedMechBoss2;
                    break;
                case Boss.BrimstoneElemental:
                    bossName = "The Brimstone Elemental";
                    textColor = new Color(196, 7, 102);
                    bossDeathValue = ref DownedBossSystem._downedBrimstoneElemental;
                    break;
                case Boss.TheDestroyer:
                    bossName = "The Destroyer";
                    textColor = new Color(147, 189, 198);
                    bossDeathValue = ref NPC.downedMechBoss1;
                    break;
                case Boss.TheAquaticScourge:
                    bossName = "The Aquatic Scourge";
                    textColor = new Color(54, 156, 196);
                    bossDeathValue = ref DownedBossSystem._downedAquaticScourge;
                    break;
                case Boss.SkeletronPrime:
                    bossName = "Skeletron Prime";
                    textColor = new Color(147, 189, 198);
                    bossDeathValue = ref NPC.downedMechBoss3;
                    break;
                case Boss.Cloneamitas:
                    bossName = "The Calamitas Clone";
                    textColor = new Color(204, 3, 0);
                    bossDeathValue = ref DownedBossSystem._downedCalamitas;
                    break;
                case Boss.Plantera:
                    bossName = "Plantera";
                    textColor = new Color(204, 89, 209);
                    bossDeathValue = ref NPC.downedPlantBoss;
                    break;
                case Boss.Leviathan:
                    bossName = "Anahita and the Leviathan";
                    textColor = new Color(0, 199, 206);
                    bossDeathValue = ref DownedBossSystem._downedLeviathan;
                    break;
                case Boss.AstrumAureus:
                    bossName = "Astrum Aureus";
                    textColor = new Color(237, 93, 83);
                    bossDeathValue = ref DownedBossSystem._downedAstrumAureus;
                    break;
                case Boss.Golem:
                    bossName = "Golem";
                    textColor = new Color(188, 62, 0);
                    bossDeathValue = ref NPC.downedGolemBoss;
                    break;
                case Boss.PlaguebringerGoliath:
                    bossName = "The Plaguebringer Goliath";
                    textColor = new Color(73, 130, 57);
                    bossDeathValue = ref DownedBossSystem._downedPlaguebringer;
                    break;
                case Boss.EmpressOfLight:
                    bossName = "Duke Fishron";
                    textColor = new Color(248, 255, 129);
                    bossDeathValue = ref NPC.downedEmpressOfLight;
                    break;
                case Boss.DukeFishron:
                    bossName = "Duke Fishron";
                    textColor = new Color(89, 204, 183);
                    bossDeathValue = ref NPC.downedFishron;
                    break;
                case Boss.Ravager:
                    bossName = "The Ravager";
                    textColor = new Color(88, 97, 189);
                    bossDeathValue = ref DownedBossSystem._downedRavager;
                    break;
                case Boss.LunaticCultist:
                    bossName = "The Lunatic Cultist";
                    textColor = new Color(112, 132, 211);
                    bossDeathValue = ref NPC.downedAncientCultist;
                    break;
                case Boss.AstrumDeus:
                    bossName = "Astrum Deus";
                    textColor = new Color(66, 189, 181);
                    bossDeathValue = ref DownedBossSystem._downedAstrumDeus;
                    break;
                case Boss.MoonLord:
                    bossName = "The Moon Lord";
                    textColor = new Color(0, 215, 155);
                    bossDeathValue = ref NPC.downedMoonlord;
                    break;
                case Boss.ProfanedGuardians:
                    bossName = "The Profaned Guardians";
                    textColor = new Color(255, 159, 0);
                    bossDeathValue = ref DownedBossSystem._downedGuardians;
                    break;
                case Boss.Dragonfolly:
                    bossName = "The Dragonfolly";
                    textColor = new Color(255, 20, 20);
                    bossDeathValue = ref DownedBossSystem._downedDragonfolly;
                    break;
                case Boss.Providence:
                    bossName = "Providence";
                    textColor = new Color(255, 159, 0);
                    bossDeathValue = ref DownedBossSystem._downedProvidence;
                    break;
                case Boss.CeaselessVoid:
                    bossName = "The Ceaseless Void";
                    textColor = new Color(125, 100, 153);
                    bossDeathValue = ref DownedBossSystem._downedCeaselessVoid;
                    break;
                case Boss.StormWeaver:
                    bossName = "The Storm Weaver";
                    textColor = new Color(235, 100, 153);
                    bossDeathValue = ref DownedBossSystem._downedStormWeaver;
                    break;
                case Boss.Signus:
                    bossName = "Signus";
                    textColor = new Color(143, 101, 228);
                    bossDeathValue = ref DownedBossSystem._downedSignus;
                    break;
                case Boss.Polterghast:
                    bossName = "Polterghast";
                    textColor = new Color(35, 200, 254);
                    bossDeathValue = ref DownedBossSystem._downedPolterghast;
                    break;
                case Boss.OldDuke:
                    bossName = "The Old Duke";
                    textColor = new Color(133, 180, 49);
                    bossDeathValue = ref DownedBossSystem._downedBoomerDuke;
                    break;
                case Boss.DevourerOfGods:
                    bossName = "The Devourer of Gods";
                    textColor = new Color(0, 255, 255);
                    bossDeathValue = ref DownedBossSystem._downedDoG;
                    break;
                case Boss.Yharon:
                    bossName = "Yharon";
                    textColor = new Color(255, 182, 55);
                    bossDeathValue = ref DownedBossSystem._downedYharon;
                    break;
                case Boss.Draedon:
                    bossName = "The Exo Mechs";
                    textColor = new Color(155, 255, 255);
                    bossDeathValue = ref DownedBossSystem._downedExoMechs;
                    break;
                case Boss.SupremeCalamitas:
                    bossName = "Supreme Calamitas";
                    textColor = new Color(255, 0, 0);
                    bossDeathValue = ref DownedBossSystem._downedSCal;
                    break;
            }
            bossDeathValue = !bossDeathValue;
            NPC.downedMechBossAny = NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3;
            string bossRefernceText = bossName.Last() == 's' ? bossName + "'" : bossName + "'s";
            Main.NewText($"{bossRefernceText} death is now marked as: {bossDeathValue}", textColor);
        }

        public static void ToggleAllBossDeaths()
        {
            bool killAll = NPC.downedSlimeKing;
            Main.NewText($"All bosses are now marked as {(killAll ? "alive" : "dead")}", Color.Red);

            NPC.downedSlimeKing = DownedBossSystem._downedDesertScourge = NPC.downedBoss1 = !killAll;
            DownedBossSystem._downedCrabulon = NPC.downedBoss2 = DownedBossSystem._downedHiveMind = DownedBossSystem._downedPerforator = !killAll;
            NPC.downedQueenBee = NPC.downedDeerclops = NPC.downedBoss3 = DownedBossSystem._downedSlimeGod = Main.hardMode = !killAll;
            NPC.downedQueenSlime = NPC.downedMechBoss1 = NPC.downedMechBoss2 = NPC.downedMechBoss3 = !killAll;
            DownedBossSystem._downedBrimstoneElemental = DownedBossSystem._downedAquaticScourge = DownedBossSystem._downedCryogen = !killAll;
            DownedBossSystem._downedCalamitas = NPC.downedPlantBoss = DownedBossSystem._downedLeviathan = DownedBossSystem._downedAstrumAureus = !killAll;
            NPC.downedGolemBoss = DownedBossSystem._downedPlaguebringer = NPC.downedEmpressOfLight = NPC.downedFishron = DownedBossSystem._downedRavager = !killAll;
            NPC.downedAncientCultist = DownedBossSystem._downedAstrumDeus = NPC.downedMoonlord = !killAll;
            DownedBossSystem._downedGuardians = DownedBossSystem._downedDragonfolly = DownedBossSystem._downedProvidence = !killAll;
            DownedBossSystem._downedCeaselessVoid = DownedBossSystem._downedStormWeaver = DownedBossSystem._downedSignus = !killAll;
            DownedBossSystem._downedPolterghast = DownedBossSystem._downedBoomerDuke = DownedBossSystem._downedDoG = !killAll;
            DownedBossSystem._downedYharon = DownedBossSystem._downedExoMechs = DownedBossSystem._downedSCal = !killAll;
            NPC.downedMechBossAny = !killAll;
        }
    }
}