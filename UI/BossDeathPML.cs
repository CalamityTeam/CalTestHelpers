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
    public class BossDeathPML : BossDeathUIRenderer
    {
        public override List<SpecialUIElement> UIElements => new List<SpecialUIElement>()
        {
            new SpecialUIElement("Toggle The Profaned Guardians' Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/ProfanedGuardians/ProfanedGuardianCommander_Head_Boss").Value, () => ToggleDeath(Boss.ProfanedGuardians), GetColor(GetDownedBool(Boss.ProfanedGuardians))),
            new SpecialUIElement("Toggle Dragonfolly's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Bumblebirb/Birb_Head_Boss").Value, () => ToggleDeath(Boss.Dragonfolly), GetColor(GetDownedBool(Boss.Dragonfolly))),
            new SpecialUIElement("Toggle Providence's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Providence/Providence_Head_Boss").Value, () => ToggleDeath(Boss.Providence), GetColor(GetDownedBool(Boss.Providence))),
            new SpecialUIElement("Toggle Ceaseless Void's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/CeaselessVoid/CeaselessVoid_Head_Boss").Value, () => ToggleDeath(Boss.CeaselessVoid), GetColor(GetDownedBool(Boss.CeaselessVoid))),
            new SpecialUIElement("Toggle Storm Weaver's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/StormWeaver/StormWeaverHeadNaked_Head_Boss").Value, () => ToggleDeath(Boss.StormWeaver), GetColor(GetDownedBool(Boss.StormWeaver))),
            new SpecialUIElement("Toggle Signus' Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Signus/Signus_Head_Boss").Value, () => ToggleDeath(Boss.Signus), GetColor(GetDownedBool(Boss.Signus))),
            new SpecialUIElement("Toggle Polterghast's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Polterghast/Polterghast_Head_Boss").Value, () => ToggleDeath(Boss.Polterghast), GetColor(GetDownedBool(Boss.Polterghast))),
            new SpecialUIElement("Toggle Old Duke's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/OldDuke/OldDuke_Head_Boss").Value, () => ToggleDeath(Boss.OldDuke), GetColor(GetDownedBool(Boss.OldDuke))),
            new SpecialUIElement("Toggle The Devourer of Gods' Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/DevourerofGods/DevourerofGodsHeadS_Head_Boss").Value, () => ToggleDeath(Boss.DevourerOfGods), GetColor(GetDownedBool(Boss.DevourerOfGods))),
            new SpecialUIElement("Toggle Yharon's Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/Yharon/Yharon_Head_Boss").Value, () => ToggleDeath(Boss.Yharon), GetColor(GetDownedBool(Boss.Yharon))),
            new SpecialUIElement("Toggle The Exo Mechs' Death.", ModContent.Request<Texture2D>("CalTestHelpers/UI/TemporaryDraedonIcon").Value, () => ToggleDeath(Boss.Draedon), GetColor(GetDownedBool(Boss.Draedon))),
            new SpecialUIElement("Toggle Supreme Witch, Calamitas' Death.", ModContent.Request<Texture2D>("CalamityMod/NPCs/SupremeCalamitas/HoodlessHeadIcon").Value, () => ToggleDeath(Boss.Calamitas), GetColor(GetDownedBool(Boss.Calamitas))),
            new SpecialUIElement("Toggle all post-Moon Lord boss Deaths.", ModContent.Request<Texture2D>("CalamityMod/Items/Weapons/Melee/ArkoftheCosmos").Value, () => ToggleDeath(Boss.AllPML), GetColor(GetDownedBool(Boss.AllPML))),
            new SpecialUIElement("Toggle all boss Deaths.", ModContent.Request<Texture2D>("CalamityMod/Items/SummonItems/Terminus").Value, () => ToggleDeath(Boss.All), GetColor(GetDownedBool(Boss.All)))
        };

        public static void ToggleDeath(Boss bossDeathToToggle)
        {
            if (bossDeathToToggle == Boss.AllPML)
            {
                ToggleAllPMLBossDeaths();
                return;
            }
            if (bossDeathToToggle == Boss.All)
            {
                ToggleAllBossDeaths();
                return;
            }
            string bossName = string.Empty;
            Color textColor = Color.White;
            ref bool bossDeathValue = ref DownedBossSystem._downedGuardians;
            switch (bossDeathToToggle)
            {
                case Boss.ProfanedGuardians:
                    bossName = "The Profaned Guardians";
                    textColor = new Color(255, 159, 0);
                    bossDeathValue = ref DownedBossSystem._downedGuardians;
                    break;
                case Boss.Dragonfolly:
                    bossName = "Dragonfolly";
                    textColor = new Color(255, 20, 20);
                    bossDeathValue = ref DownedBossSystem._downedDragonfolly;
                    break;
                case Boss.Providence:
                    bossName = "Providence";
                    textColor = new Color(255, 159, 0);
                    bossDeathValue = ref DownedBossSystem._downedProvidence;
                    break;
                case Boss.CeaselessVoid:
                    bossName = "Ceaseless Void";
                    textColor = new Color(125, 100, 153);
                    bossDeathValue = ref DownedBossSystem._downedCeaselessVoid;
                    break;
                case Boss.StormWeaver:
                    bossName = "Storm Weaver";
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
                    bossName = "Old Duke";
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
                case Boss.Calamitas:
                    bossName = "Supreme Witch, Calamitas";
                    textColor = new Color(255, 0, 0);
                    bossDeathValue = ref DownedBossSystem._downedCalamitas;
                    break;
            }
            bossDeathValue = !bossDeathValue;
            NPC.downedMechBossAny = NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3;
            string bossReferenceText = bossName.Last() == 's' ? bossName + "'" : bossName + "'s";
            Main.NewText($"{bossReferenceText} death is now marked as: {bossDeathValue}", textColor);
        }

        public static void ToggleAllPMLBossDeaths()
        {
            bool killAll = DownedBossSystem._downedGuardians;
            Main.NewText($"All post-Moon Lord bosses are now marked as {(killAll ? "alive" : "dead")}", Color.Red);

            DownedBossSystem._downedGuardians = DownedBossSystem._downedDragonfolly = DownedBossSystem._downedProvidence = !killAll;
            DownedBossSystem._downedCeaselessVoid = DownedBossSystem._downedStormWeaver = DownedBossSystem._downedSignus = !killAll;
            DownedBossSystem._downedPolterghast = DownedBossSystem._downedBoomerDuke = DownedBossSystem._downedDoG = !killAll;
            DownedBossSystem._downedYharon = DownedBossSystem._downedExoMechs = DownedBossSystem._downedCalamitas = !killAll;
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
            DownedBossSystem._downedCalamitasClone = NPC.downedPlantBoss = DownedBossSystem._downedLeviathan = DownedBossSystem._downedAstrumAureus = !killAll;
            NPC.downedGolemBoss = DownedBossSystem._downedPlaguebringer = NPC.downedEmpressOfLight = NPC.downedFishron = DownedBossSystem._downedRavager = !killAll;
            NPC.downedAncientCultist = DownedBossSystem._downedAstrumDeus = NPC.downedMoonlord = !killAll;
            DownedBossSystem._downedGuardians = DownedBossSystem._downedDragonfolly = DownedBossSystem._downedProvidence = !killAll;
            DownedBossSystem._downedCeaselessVoid = DownedBossSystem._downedStormWeaver = DownedBossSystem._downedSignus = !killAll;
            DownedBossSystem._downedPolterghast = DownedBossSystem._downedBoomerDuke = DownedBossSystem._downedDoG = !killAll;
            DownedBossSystem._downedYharon = DownedBossSystem._downedExoMechs = DownedBossSystem._downedCalamitas = !killAll;
            NPC.downedMechBossAny = !killAll;
        }
    }
}