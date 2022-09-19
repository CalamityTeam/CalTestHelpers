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
    public class BossDeathHM : BossDeathUIRenderer
    {
        public override List<SpecialUIElement> UIElements => new List<SpecialUIElement>()
        {
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
            new SpecialUIElement("Toggle The Moon Lord's Death.", TextureAssets.NpcHeadBoss[8].Value, () => ToggleDeath(Boss.MoonLord))
        };

        public static void ToggleDeath(Boss bossDeathToToggle)
        {
            string bossName = string.Empty;
            Color textColor = Color.White;
            ref bool bossDeathValue = ref NPC.downedQueenSlime;
            switch (bossDeathToToggle)
            {
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
            }
            bossDeathValue = !bossDeathValue;
            NPC.downedMechBossAny = NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3;
            string bossRefernceText = bossName.Last() == 's' ? bossName + "'" : bossName + "'s";
            Main.NewText($"{bossRefernceText} death is now marked as: {bossDeathValue}", textColor);
        }
    }
}