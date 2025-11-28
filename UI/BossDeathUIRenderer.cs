using CalamityMod;
using CalamityMod.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace CalTestHelpers.UI
{
    public abstract class BossDeathUIRenderer : GrandUIRenderer
    {

        public static string key = "Mods.CalTestHelpers.UI.ToggleDeaths.";

        public static string BossKey = "Mods.CalTestHelpers.UI.ToggleDeaths.ToggleBossDeath";

        public static string BossKeyEndsWithS = "Mods.CalTestHelpers.UI.ToggleDeaths.ToggleBossDeathEndsWithS";
        public enum Boss
        {
            KingSlime,
            DesertScourge,
            GiantClam,
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
            AllPHM,
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
            AllHM,
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
            Calamitas,
            Wyrm,
            AllPML,
            All
        }

        public static Color GetColor(bool bossDeath) => bossDeath ? Color.Green : Color.Red;

        public static string GetBossLocalizationKey(Boss BossKey)
        {
            string bossName = string.Empty;
            //Taking keys from vanilla or the main mod
            if (!CalTestHelperConfig.Instance.ManualLocalizationOverride)
            {
                switch (BossKey)
                {
                    case Boss.KingSlime:
                        bossName = Lang.GetNPCNameValue(NPCID.KingSlime);
                        break;
                    case Boss.DesertScourge:
                        bossName = CalamityUtils.GetTextValue("NPCs.DesertScourgeHead.DisplayName");
                        break;
                    case Boss.GiantClam:
                        bossName = CalamityUtils.GetTextValue(Main.zenithWorld ? Main.hardMode ? "NPCs.SupremeClamitas" : "NPCs.Clamitas" : "NPCs.GiantClam.DisplayName");
                        break;
                    case Boss.EyeOfCthulhu:
                        bossName = Lang.GetNPCNameValue(NPCID.EyeofCthulhu);
                        break;
                    case Boss.Crabulon:
                        bossName = CalamityUtils.GetTextValue("NPCs.Crabulon.DisplayName");
                        break;
                    case Boss.EaterOfWorlds:
                        bossName = Lang.GetNPCNameValue(NPCID.EaterofWorldsHead);
                        break;
                    case Boss.BrainOfCthulhu:
                        bossName = Lang.GetNPCNameValue(NPCID.BrainofCthulhu);
                        break;
                    case Boss.HiveMind:
                        bossName = CalamityUtils.GetTextValue("NPCs.HiveMind.DisplayName");
                        break;
                    case Boss.Perforators:
                        bossName = Language.GetTextValue(key + "Perforators");
                        break;
                    case Boss.QueenBee:
                        bossName = Lang.GetNPCNameValue(NPCID.QueenBee);
                        break;
                    case Boss.Deerclops:
                        bossName = Lang.GetNPCNameValue(NPCID.Deerclops);
                        break;
                    case Boss.Skeletron:
                        bossName = Lang.GetNPCNameValue(NPCID.SkeletronHead);
                        break;
                    case Boss.SlimeGod:
                        bossName = CalamityUtils.GetTextValue("NPCs.SlimeGodCore.DisplayName");
                        break;
                    case Boss.WallOfFlesh:
                        bossName = Lang.GetNPCNameValue(NPCID.WallofFlesh);
                        break;
                    case Boss.AllPHM:
                        bossName = Language.GetTextValue(key + "AllPreHM");
                        break;
                    case Boss.QueenSlime:
                        bossName = Lang.GetNPCNameValue(NPCID.QueenSlimeBoss);
                        break;
                    case Boss.Cryogen:
                        bossName = CalamityUtils.GetTextValue("NPCs.Cryogen.DisplayName");
                        break;
                    case Boss.TheTwins:
                        bossName = Language.GetTextValue(key + "Twins");
                        break;
                    case Boss.TheAquaticScourge:
                        bossName = CalamityUtils.GetTextValue("NPCs.AquaticScourgeHead.DisplayName");
                        break;
                    case Boss.TheDestroyer:
                        bossName = Language.GetTextValue(key + "Destroyer");
                        break;
                    case Boss.BrimstoneElemental:
                        bossName = CalamityUtils.GetTextValue("NPCs.BrimstoneElemental.DisplayName");
                        break;
                    case Boss.SkeletronPrime:
                        bossName = Lang.GetNPCNameValue(NPCID.SkeletronPrime);
                        break;
                    case Boss.Cloneamitas:
                        bossName = CalamityUtils.GetTextValue("NPCs.CalamitasClone.DisplayName");
                        break;
                    case Boss.Plantera:
                        bossName = Lang.GetNPCNameValue(NPCID.Plantera);
                        break;
                    case Boss.Leviathan:
                        bossName = Language.GetTextValue(key + "Leviathan");
                        break;
                    case Boss.AstrumAureus:
                        bossName = CalamityUtils.GetTextValue("NPCs.AstrumAureus.DisplayName");
                        break;
                    case Boss.Golem:
                        bossName = Lang.GetNPCNameValue(NPCID.Golem);
                        break;
                    case Boss.PlaguebringerGoliath:
                        bossName = Language.GetTextValue(key + "PBG");
                        break;
                    case Boss.DukeFishron:
                        bossName = Lang.GetNPCNameValue(NPCID.DukeFishron);
                        break;
                    case Boss.Ravager:
                        bossName = CalamityUtils.GetTextValue("NPCs.RavagerBody.DisplayName");
                        break;
                    case Boss.EmpressOfLight:
                        bossName = Lang.GetNPCNameValue(NPCID.HallowBoss);
                        break;
                    case Boss.LunaticCultist:
                        bossName = Lang.GetNPCNameValue(NPCID.CultistBoss);
                        break;
                    case Boss.AstrumDeus:
                        bossName = CalamityUtils.GetTextValue("NPCs.AstrumDeusHead.DisplayName");
                        break;
                    case Boss.MoonLord:
                        bossName = Lang.GetNPCNameValue(NPCID.MoonLordHead);
                        break;
                    case Boss.AllHM:
                        bossName = Language.GetTextValue(key + "AllHM");
                        break;
                    case Boss.ProfanedGuardians:
                        bossName = Language.GetTextValue(key + "ProfanedGuardians");
                        break;
                    case Boss.Dragonfolly:
                        bossName = Main.zenithWorld ? CalamityUtils.GetTextValue("NPCs.Bumblebirb") : CalamityUtils.GetTextValue("NPCs.Bumblefuck.DisplayName");
                        break;
                    case Boss.Providence:
                        bossName = Language.GetTextValue(key + "Providence");
                        break;
                    case Boss.StormWeaver:
                        bossName = CalamityUtils.GetTextValue("NPCs.StormWeaverHead.DisplayName");
                        break;
                    case Boss.CeaselessVoid:
                        bossName = CalamityUtils.GetTextValue("NPCs.CeaselessVoid.DisplayName");
                        break;
                    case Boss.Signus:
                        bossName = Language.GetTextValue(key + "Signus");
                        break;
                    case Boss.Polterghast:
                        bossName = CalamityUtils.GetTextValue("NPCs.Polterghast.DisplayName");
                        break;
                    case Boss.OldDuke:
                        bossName = Main.zenithWorld ? CalamityUtils.GetTextValue("NPCs.BoomerDuke") : CalamityUtils.GetTextValue("NPCs.OldDuke.DisplayName");
                        break;
                    case Boss.DevourerOfGods:
                        bossName = Language.GetTextValue(key + "DoG");
                        break;
                    case Boss.Yharon:
                        bossName = Language.GetTextValue(key + "Yharon");
                        break;
                    case Boss.Draedon:
                        bossName = Language.GetTextValue(key + "ExoMechs");
                        break;
                    case Boss.Calamitas:
                        bossName = Language.GetTextValue(key + "SCal");
                        break;
                    case Boss.Wyrm:
                        bossName = Main.zenithWorld ? CalamityUtils.GetTextValue("NPCs.Jared") : CalamityUtils.GetTextValue("NPCs.PrimordialWyrmHead.DisplayName");
                        break;
                    case Boss.AllPML:
                        bossName = Language.GetTextValue(key + "AllPML");
                        break;
                    case Boss.All:
                        bossName = Language.GetTextValue(key + "All");
                        break;
                }
            }
            else
            {
                switch (BossKey)
                {
                    case Boss.KingSlime:
                        bossName = Language.GetTextValue(key +"KingSlime");
                        break;
                    case Boss.DesertScourge:
                        bossName = Language.GetTextValue(key + "DesertScourge");
                        break;
                    case Boss.GiantClam:
                        bossName = Language.GetTextValue(key+ (Main.zenithWorld ? Main.hardMode ? "SupremeClamitas" : "Clamitas" : "Clam"));
                        break;
                    case Boss.EyeOfCthulhu:
                        bossName = Language.GetTextValue(key + "EoC");
                        break;
                    case Boss.Crabulon:
                        bossName = Language.GetTextValue(key + "Crabulon");
                        break;
                    case Boss.EaterOfWorlds:
                        bossName = Language.GetTextValue(key + "EoW");
                        break;
                    case Boss.BrainOfCthulhu:
                        bossName = Language.GetTextValue(key + "BoC");
                        break;
                    case Boss.HiveMind:
                        bossName = Language.GetTextValue(key + "HiveMind");
                        break;
                    case Boss.Perforators:
                        bossName = Language.GetTextValue(key + "Perforators");
                        break;
                    case Boss.QueenBee:
                        bossName = Language.GetTextValue(key + "QueenBee");
                        break;
                    case Boss.Deerclops:
                        bossName = Language.GetTextValue(key + "Deerclops");
                        break;
                    case Boss.Skeletron:
                        bossName = Language.GetTextValue(key + "Skeletron");
                        break;
                    case Boss.SlimeGod:
                        bossName = Language.GetTextValue(key + "SlimeGod");
                        break;
                    case Boss.WallOfFlesh:
                        bossName = Language.GetTextValue(key + "WoF");
                        break;
                    case Boss.AllPHM:
                        bossName = Language.GetTextValue(key + "AllPreHM");
                        break;
                    case Boss.QueenSlime:
                        bossName = Language.GetTextValue(key + "QueenSlime");
                        break;
                    case Boss.Cryogen:
                        bossName = Language.GetTextValue(key + "Cryogen");
                        break;
                    case Boss.TheTwins:
                        bossName = Language.GetTextValue(key + "Twins");
                        break;
                    case Boss.TheAquaticScourge:
                        bossName = Language.GetTextValue(key + "AquaticScourge");
                        break;
                    case Boss.TheDestroyer:
                        bossName = Language.GetTextValue(key + "Destroyer");
                        break;
                    case Boss.BrimstoneElemental:
                        bossName = Language.GetTextValue(key + "Brimmy");
                        break;
                    case Boss.SkeletronPrime:
                        bossName = Language.GetTextValue(key + "SkeletronPrime");
                        break;
                    case Boss.Cloneamitas:
                        bossName = Language.GetTextValue(key + "CalClone");
                        break;
                    case Boss.Plantera:
                        bossName = Language.GetTextValue(key + "Plantera");
                        break;
                    case Boss.Leviathan:
                        bossName = Language.GetTextValue(key + "Leviathan");
                        break;
                    case Boss.AstrumAureus:
                        bossName = Language.GetTextValue(key + "Aureus");
                        break;
                    case Boss.Golem:
                        bossName = Language.GetTextValue(key + "Golem");
                        break;
                    case Boss.PlaguebringerGoliath:
                        bossName = Language.GetTextValue(key + "PBG");
                        break;
                    case Boss.DukeFishron:
                        bossName = Language.GetTextValue(key + "DukeFishron");
                        break;
                    case Boss.Ravager:
                        bossName = Language.GetTextValue(key + "Ravager");
                        break;
                    case Boss.EmpressOfLight:
                        bossName = Language.GetTextValue(key + "EoL");
                        break;
                    case Boss.LunaticCultist:
                        bossName = Language.GetTextValue(key + "Cultist");
                        break;
                    case Boss.AstrumDeus:
                        bossName = Language.GetTextValue(key + "Deus");
                        break;
                    case Boss.MoonLord:
                        bossName = Language.GetTextValue(key + "MoonLord");
                        break;
                    case Boss.AllHM:
                        bossName = Language.GetTextValue(key + "AllHM");
                        break;
                    case Boss.ProfanedGuardians:
                        bossName = Language.GetTextValue(key + "ProfanedGuardians");
                        break;
                    case Boss.Dragonfolly:
                        bossName = Language.GetTextValue(key + (Main.zenithWorld ? "Bumblebirb" : "DFolly"));
                        break;
                    case Boss.Providence:
                        bossName = Language.GetTextValue(key + "Providence");
                        break;
                    case Boss.StormWeaver:
                        bossName = Language.GetTextValue(key + "SW");
                        break;
                    case Boss.CeaselessVoid:
                        bossName = Language.GetTextValue(key + "Void");
                        break;
                    case Boss.Signus:
                        bossName = Language.GetTextValue(key + "Signus");
                        break;
                    case Boss.Polterghast:
                        bossName = Language.GetTextValue(key + "Polterghast");
                        break;
                    case Boss.OldDuke:
                        bossName = Language.GetTextValue(key + (Main.zenithWorld ? "Boomerfish" : "OldFart"));
                        break;
                    case Boss.DevourerOfGods:
                        bossName = Language.GetTextValue(key + "DoG");
                        break;
                    case Boss.Yharon:
                        bossName = Language.GetTextValue(key + "Yharon");
                        break;
                    case Boss.Draedon:
                        bossName = Language.GetTextValue(key + "ExoMechs");
                        break;
                    case Boss.Calamitas:
                        bossName = Language.GetTextValue(key + "SCal");
                        break;
                    case Boss.Wyrm:
                        bossName = Language.GetTextValue(key + (Main.zenithWorld ? "Jared" : "Wyrm"));
                        break;
                    case Boss.AllPML:
                        bossName = Language.GetTextValue(key + "AllPML");
                        break;
                    case Boss.All:
                        bossName = Language.GetTextValue(key + "All");
                        break;
                }
            }
            return bossName;
        }

        public static bool GetDownedBool(Boss bossDeathToToggle)
        {
            switch (bossDeathToToggle)
            {
				case Boss.All:
				case Boss.AllPHM:
                case Boss.KingSlime:
                    return NPC.downedSlimeKing;
                case Boss.DesertScourge:
                    return DownedBossSystem._downedDesertScourge;
                case Boss.GiantClam:
                    return DownedBossSystem._downedCLAM;
                case Boss.EyeOfCthulhu:
                    return NPC.downedBoss1;
                case Boss.Crabulon:
                    return DownedBossSystem._downedCrabulon;
                case Boss.EaterOfWorlds:
                case Boss.BrainOfCthulhu:
                    return NPC.downedBoss2;
                case Boss.HiveMind:
                    return DownedBossSystem._downedHiveMind;
                case Boss.Perforators:
                    return DownedBossSystem._downedPerforator;
                case Boss.QueenBee:
                    return NPC.downedQueenBee;
                case Boss.Deerclops:
                    return NPC.downedDeerclops;
                case Boss.Skeletron:
                    return NPC.downedBoss3;
                case Boss.SlimeGod:
                    return DownedBossSystem._downedSlimeGod;
                case Boss.WallOfFlesh:
                    return Main.hardMode;
				case Boss.AllHM:
                case Boss.QueenSlime:
                    return NPC.downedQueenSlime;
                case Boss.Cryogen:
                    return DownedBossSystem._downedCryogen;
                case Boss.TheTwins:
                    return NPC.downedMechBoss2;
                case Boss.BrimstoneElemental:
                    return DownedBossSystem._downedBrimstoneElemental;
                case Boss.TheDestroyer:
                    return NPC.downedMechBoss1;
                case Boss.TheAquaticScourge:
                    return DownedBossSystem._downedAquaticScourge;
                case Boss.SkeletronPrime:
                    return NPC.downedMechBoss3;
                case Boss.Cloneamitas:
                    return DownedBossSystem._downedCalamitasClone;
                case Boss.Plantera:
                    return NPC.downedPlantBoss;
                case Boss.Leviathan:
                    return DownedBossSystem._downedLeviathan;
                case Boss.AstrumAureus:
                    return DownedBossSystem._downedAstrumAureus;
                case Boss.Golem:
                    return NPC.downedGolemBoss;
                case Boss.PlaguebringerGoliath:
                    return DownedBossSystem._downedPlaguebringer;
                case Boss.EmpressOfLight:
                    return NPC.downedEmpressOfLight;
                case Boss.DukeFishron:
                    return NPC.downedFishron;
                case Boss.Ravager:
                    return DownedBossSystem._downedRavager;
                case Boss.LunaticCultist:
                    return NPC.downedAncientCultist;
                case Boss.AstrumDeus:
                    return DownedBossSystem._downedAstrumDeus;
                case Boss.MoonLord:
                    return NPC.downedMoonlord;
				case Boss.AllPML:
                case Boss.ProfanedGuardians:
                    return DownedBossSystem._downedGuardians;
                case Boss.Dragonfolly:
                    return DownedBossSystem._downedDragonfolly;
                case Boss.Providence:
                    return DownedBossSystem._downedProvidence;
                case Boss.CeaselessVoid:
                    return DownedBossSystem._downedCeaselessVoid;
                case Boss.StormWeaver:
                    return DownedBossSystem._downedStormWeaver;
                case Boss.Signus:
                    return DownedBossSystem._downedSignus;
                case Boss.Polterghast:
                    return DownedBossSystem._downedPolterghast;
                case Boss.OldDuke:
                    return DownedBossSystem._downedBoomerDuke;
                case Boss.DevourerOfGods:
                    return DownedBossSystem._downedDoG;
                case Boss.Yharon:
                    return DownedBossSystem._downedYharon;
                case Boss.Draedon:
                    return DownedBossSystem._downedExoMechs;
                case Boss.Calamitas:
                    return DownedBossSystem._downedCalamitas;
                case Boss.Wyrm:
                    return DownedBossSystem._downedPrimordialWyrm;
            }
			return false;
        }

        public override Vector2 TopLeftLocation => SecondaryTopLeftLocation;
    }
}