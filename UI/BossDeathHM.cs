using CalamityMod;
using CalamityMod.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalTestHelpers.UI
{
    public class BossDeathHM : BossDeathUIRenderer
    {
        public override List<SpecialUIElement> UIElements => new List<SpecialUIElement>()
        {
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.QueenSlime)), TextureAssets.NpcHeadBoss[38].Value, () => ToggleDeath(Boss.QueenSlime), GetColor(GetDownedBool(Boss.QueenSlime))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.Cryogen)), ModContent.Request<Texture2D>("CalamityMod/NPCs/Cryogen/Cryogen_Phase1_Head_Boss").Value, () => ToggleDeath(Boss.Cryogen), GetColor(GetDownedBool(Boss.Cryogen))),
            new SpecialUIElement(Language.GetTextValue(BossKeyEndsWithS, GetBossLocalizationKey(Boss.TheTwins)), TextureAssets.NpcHeadBoss[16].Value, () => ToggleDeath(Boss.TheTwins), GetColor(GetDownedBool(Boss.TheTwins))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.TheAquaticScourge)), ModContent.Request<Texture2D>("CalamityMod/NPCs/AquaticScourge/AquaticScourgeHead_Head_Boss").Value, () => ToggleDeath(Boss.TheAquaticScourge), GetColor(GetDownedBool(Boss.TheAquaticScourge))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.TheDestroyer)), TextureAssets.NpcHeadBoss[25].Value, () => ToggleDeath(Boss.TheDestroyer), GetColor(GetDownedBool(Boss.TheDestroyer))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.BrimstoneElemental)), ModContent.Request<Texture2D>("CalamityMod/NPCs/BrimstoneElemental/BrimstoneElemental_Head_Boss").Value, () => ToggleDeath(Boss.BrimstoneElemental), GetColor(GetDownedBool(Boss.BrimstoneElemental))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.SkeletronPrime)), TextureAssets.NpcHeadBoss[18].Value, () => ToggleDeath(Boss.SkeletronPrime), GetColor(GetDownedBool(Boss.SkeletronPrime))),
            new SpecialUIElement(Language.GetTextValue(BossKeyEndsWithS, GetBossLocalizationKey(Boss.Cloneamitas)), ModContent.Request<Texture2D>("CalamityMod/NPCs/CalClone/CalamitasClone_Head_Boss").Value, () => ToggleDeath(Boss.Cloneamitas), GetColor(GetDownedBool(Boss.Cloneamitas))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.Plantera)), TextureAssets.NpcHeadBoss[11].Value, () => ToggleDeath(Boss.Plantera), GetColor(GetDownedBool(Boss.Plantera))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.Leviathan)), ModContent.Request<Texture2D>("CalamityMod/NPCs/Leviathan/Leviathan_Head_Boss").Value, () => ToggleDeath(Boss.Leviathan), GetColor(GetDownedBool(Boss.Leviathan))),
            new SpecialUIElement(Language.GetTextValue(BossKeyEndsWithS, GetBossLocalizationKey(Boss.AstrumAureus)), ModContent.Request<Texture2D>("CalamityMod/NPCs/AstrumAureus/AstrumAureus_Head_Boss").Value, () => ToggleDeath(Boss.AstrumAureus), GetColor(GetDownedBool(Boss.AstrumAureus))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.Golem)), TextureAssets.NpcHeadBoss[5].Value, () => ToggleDeath(Boss.Golem), GetColor(GetDownedBool(Boss.Golem))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.PlaguebringerGoliath)), ModContent.Request<Texture2D>("CalamityMod/NPCs/PlaguebringerGoliath/PlaguebringerGoliath_Head_Boss").Value, () => ToggleDeath(Boss.PlaguebringerGoliath), GetColor(GetDownedBool(Boss.PlaguebringerGoliath))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.EmpressOfLight)), TextureAssets.NpcHeadBoss[37].Value, () => ToggleDeath(Boss.EmpressOfLight), GetColor(GetDownedBool(Boss.EmpressOfLight))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.DukeFishron)), TextureAssets.NpcHeadBoss[4].Value, () => ToggleDeath(Boss.DukeFishron), GetColor(GetDownedBool(Boss.DukeFishron))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.Ravager)), ModContent.Request<Texture2D>("CalamityMod/NPCs/Ravager/RavagerBody_Head_Boss").Value, () => ToggleDeath(Boss.Ravager), GetColor(GetDownedBool(Boss.Ravager))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.LunaticCultist)), TextureAssets.NpcHeadBoss[31].Value, () => ToggleDeath(Boss.LunaticCultist), GetColor(GetDownedBool(Boss.LunaticCultist))),
            new SpecialUIElement(Language.GetTextValue(BossKeyEndsWithS, GetBossLocalizationKey(Boss.AstrumDeus)), ModContent.Request<Texture2D>("CalamityMod/NPCs/AstrumDeus/AstrumDeusHead_Head_Boss").Value, () => ToggleDeath(Boss.AstrumDeus), GetColor(GetDownedBool(Boss.AstrumDeus))),
            new SpecialUIElement(Language.GetTextValue(BossKey, GetBossLocalizationKey(Boss.MoonLord)), TextureAssets.NpcHeadBoss[8].Value, () => ToggleDeath(Boss.MoonLord), GetColor(GetDownedBool(Boss.MoonLord))),
            new SpecialUIElement(Language.GetTextValue(GetBossLocalizationKey(Boss.AllHM)), ModContent.Request<Texture2D>("CalamityMod/Items/Weapons/Melee/TrueArkoftheAncients").Value, () => ToggleDeath(Boss.AllHM), GetColor(GetDownedBool(Boss.AllHM)))
        };

        public static void ToggleDeath(Boss bossDeathToToggle)
        {
            if (bossDeathToToggle == Boss.AllHM)
            {
                ToggleAllHMBossDeaths();
                return;
            }
            string bossName = GetBossLocalizationKey(bossDeathToToggle);
            Color textColor = Color.White;
            ref bool bossDeathValue = ref NPC.downedQueenSlime;
            switch (bossDeathToToggle)
            {
                case Boss.QueenSlime:
                    textColor = new Color(255, 129, 255);
                    bossDeathValue = ref NPC.downedQueenSlime;
                    break;
                case Boss.Cryogen:
                    textColor = new Color(174, 229, 239);
                    bossDeathValue = ref DownedBossSystem._downedCryogen;
                    break;
                case Boss.TheTwins:
                    textColor = new Color(147, 189, 198);
                    bossDeathValue = ref NPC.downedMechBoss2;
                    break;
                case Boss.TheAquaticScourge:
                    textColor = new Color(54, 156, 196);
                    bossDeathValue = ref DownedBossSystem._downedAquaticScourge;
                    break;
                case Boss.TheDestroyer:
                    textColor = new Color(147, 189, 198);
                    bossDeathValue = ref NPC.downedMechBoss1;
                    break;
                case Boss.BrimstoneElemental:
                    textColor = new Color(196, 7, 102);
                    bossDeathValue = ref DownedBossSystem._downedBrimstoneElemental;
                    break;
                case Boss.SkeletronPrime:
                    textColor = new Color(147, 189, 198);
                    bossDeathValue = ref NPC.downedMechBoss3;
                    break;
                case Boss.Cloneamitas:
                    textColor = new Color(204, 3, 0);
                    bossDeathValue = ref DownedBossSystem._downedCalamitasClone;
                    break;
                case Boss.Plantera:
                    textColor = new Color(204, 89, 209);
                    bossDeathValue = ref NPC.downedPlantBoss;
                    break;
                case Boss.Leviathan:
                    textColor = new Color(0, 199, 206);
                    bossDeathValue = ref DownedBossSystem._downedLeviathan;
                    break;
                case Boss.AstrumAureus:
                    textColor = new Color(237, 93, 83);
                    bossDeathValue = ref DownedBossSystem._downedAstrumAureus;
                    break;
                case Boss.Golem:
                    textColor = new Color(188, 62, 0);
                    bossDeathValue = ref NPC.downedGolemBoss;
                    break;
                case Boss.PlaguebringerGoliath:
                    textColor = new Color(73, 130, 57);
                    bossDeathValue = ref DownedBossSystem._downedPlaguebringer;
                    break;
                case Boss.EmpressOfLight:
                    textColor = new Color(248, 255, 129);
                    bossDeathValue = ref NPC.downedEmpressOfLight;
                    break;
                case Boss.DukeFishron:
                    textColor = new Color(89, 204, 183);
                    bossDeathValue = ref NPC.downedFishron;
                    break;
                case Boss.Ravager:
                    textColor = new Color(88, 97, 189);
                    bossDeathValue = ref DownedBossSystem._downedRavager;
                    break;
                case Boss.LunaticCultist:
                    textColor = new Color(112, 132, 211);
                    bossDeathValue = ref NPC.downedAncientCultist;
                    break;
                case Boss.AstrumDeus:
                    textColor = new Color(66, 189, 181);
                    bossDeathValue = ref DownedBossSystem._downedAstrumDeus;
                    break;
                case Boss.MoonLord:
                    textColor = new Color(0, 215, 155);
                    bossDeathValue = ref NPC.downedMoonlord;
                    break;
            }
            bossDeathValue = !bossDeathValue;
            NPC.downedMechBossAny = NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3;
            string DeadOrAlive = Language.GetTextValue(key + (bossDeathValue ? "Dead" : "Alive"));
            bool bossReferenceText = bossName.Last() == 's';
            Main.NewText(Language.GetTextValue(key + (bossReferenceText ? "ToggleEndsWithS" : "Toggle"), bossName, DeadOrAlive), textColor);
        }

        public static void ToggleAllHMBossDeaths()
        {
            bool killAll = NPC.downedQueenSlime;
            string DeadOrAlive = Language.GetTextValue(key + (killAll ? "Dead" : "Alive"));
            Main.NewText(Language.GetTextValue(key + "ToggleAllHM", DeadOrAlive), Color.Red);

            NPC.downedQueenSlime = NPC.downedMechBoss1 = NPC.downedMechBoss2 = NPC.downedMechBoss3 = !killAll;
            DownedBossSystem._downedBrimstoneElemental = DownedBossSystem._downedAquaticScourge = DownedBossSystem._downedCryogen = !killAll;
            DownedBossSystem._downedCalamitasClone = NPC.downedPlantBoss = DownedBossSystem._downedLeviathan = DownedBossSystem._downedAstrumAureus = !killAll;
            NPC.downedGolemBoss = DownedBossSystem._downedPlaguebringer = NPC.downedEmpressOfLight = NPC.downedFishron = DownedBossSystem._downedRavager = !killAll;
            NPC.downedAncientCultist = DownedBossSystem._downedAstrumDeus = NPC.downedMoonlord = !killAll;
            NPC.downedMechBossAny = !killAll;
        }
    }
}