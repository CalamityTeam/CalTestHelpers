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
            AllPML,
            All
        }

        public static Color GetColor(bool bossDeath) => bossDeath ? Color.Green : Color.Red;

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
            }
			return false;
        }

        public override Vector2 TopLeftLocation => SecondaryTopLeftLocation;
    }
}