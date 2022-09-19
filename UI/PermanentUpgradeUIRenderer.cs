using CalamityMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalTestHelpers.UI
{
    public class PermanentUpgradeUIRenderer : GrandUIRenderer
    {
        public enum PlayerUpgrade
        {
            BloodOrange,
            MiracleFruit,
            Elderberry,
            Dragonfruit,
            CometShard,
            EtherealCore,
            PhantomHeart,
            MushroomPlasmaRoot,
            InfernalBlood,
            RedLightningContainer,
            ElectrolyteGelPack,
            StarlightFuelCell,
            Ectoheart,
            DemonHeart,
            CelestialOnion
        }
        public override List<SpecialUIElement> UIElements => new List<SpecialUIElement>()
        {
            new SpecialUIElement("Toggle Blood Orange", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/BloodOrange").Value, () => ToggleUpgrade(PlayerUpgrade.BloodOrange)),
            new SpecialUIElement("Toggle Miracle Fruit", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/MiracleFruit").Value, () => ToggleUpgrade(PlayerUpgrade.MiracleFruit)),
            new SpecialUIElement("Toggle Elderberry", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/Elderberry").Value, () => ToggleUpgrade(PlayerUpgrade.Elderberry)),
            new SpecialUIElement("Toggle Dragonfruit", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/Dragonfruit").Value, () => ToggleUpgrade(PlayerUpgrade.Dragonfruit)),
            new SpecialUIElement("Toggle Comet Shard", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/CometShard").Value, () => ToggleUpgrade(PlayerUpgrade.CometShard)),
            new SpecialUIElement("Toggle Ethereal Core", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/EtherealCore").Value, () => ToggleUpgrade(PlayerUpgrade.EtherealCore)),
            new SpecialUIElement("Toggle Phantom Heart", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/PhantomHeart").Value, () => ToggleUpgrade(PlayerUpgrade.PhantomHeart)),
            new SpecialUIElement("Toggle Mushroom Plasma Root", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/MushroomPlasmaRoot").Value, () => ToggleUpgrade(PlayerUpgrade.MushroomPlasmaRoot)),
            new SpecialUIElement("Toggle Infernal Blood", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/InfernalBlood").Value, () => ToggleUpgrade(PlayerUpgrade.InfernalBlood)),
            new SpecialUIElement("Toggle Red Lightning Container", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/RedLightningContainer").Value, () => ToggleUpgrade(PlayerUpgrade.RedLightningContainer)),
            new SpecialUIElement("Toggle Electrolyte Gel Pack", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/ElectrolyteGelPack").Value, () => ToggleUpgrade(PlayerUpgrade.ElectrolyteGelPack)),
            new SpecialUIElement("Toggle Starlight Fuel Cell", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/StarlightFuelCell").Value, () => ToggleUpgrade(PlayerUpgrade.StarlightFuelCell)),
            new SpecialUIElement("Toggle Ectoheart", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/Ectoheart").Value, () => ToggleUpgrade(PlayerUpgrade.Ectoheart)),
            new SpecialUIElement("Toggle Demon Heart", TextureAssets.Item[ItemID.DemonHeart].Value, () => ToggleUpgrade(PlayerUpgrade.DemonHeart)),
            new SpecialUIElement("Toggle Celestial Onion", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/CelestialOnion").Value, () => ToggleUpgrade(PlayerUpgrade.CelestialOnion)),
        };
        public override float UIScale => ResolutionRatio;

        public override Vector2 TopLeftLocation => new Vector2(Main.screenWidth - 660 - 270 * ResolutionRatio, 40);

        public static void ToggleUpgrade(PlayerUpgrade upgradeToToggle)
        {
            string upgradeName = string.Empty;
            Color textColor = Color.White;
            ref bool upgradeValue = ref Main.LocalPlayer.Calamity().bOrange;
            switch (upgradeToToggle)
            {
                case PlayerUpgrade.BloodOrange:
                    upgradeName = "Blood Orange";
                    textColor = new Color(226, 86, 55);
                    upgradeValue = ref Main.LocalPlayer.Calamity().bOrange;
                    break;
                case PlayerUpgrade.MiracleFruit:
                    upgradeName = "Miracle Fruit";
                    textColor = new Color(107, 206, 84);
                    upgradeValue = ref Main.LocalPlayer.Calamity().mFruit;
                    break;
                case PlayerUpgrade.Elderberry:
                    upgradeName = "Elderberry";
                    textColor = new Color(58, 167, 255);
                    upgradeValue = ref Main.LocalPlayer.Calamity().eBerry;
                    break;
                case PlayerUpgrade.Dragonfruit:
                    upgradeName = "Dragonfruit";
                    textColor = new Color(56, 122, 175);
                    upgradeValue = ref Main.LocalPlayer.Calamity().dFruit;
                    break;
                case PlayerUpgrade.CometShard:
                    upgradeName = "Comet Shard";
                    textColor = new Color(66, 189, 181);
                    upgradeValue = ref Main.LocalPlayer.Calamity().cShard;
                    break;
                case PlayerUpgrade.EtherealCore:
                    upgradeName = "Ethereal Core";
                    textColor = new Color(237, 93, 83);
                    upgradeValue = ref Main.LocalPlayer.Calamity().eCore;
                    break;
                case PlayerUpgrade.PhantomHeart:
                    upgradeName = "Phantom Heart";
                    textColor = new Color(255, 84, 146);
                    upgradeValue = ref Main.LocalPlayer.Calamity().pHeart;
                    break;
                case PlayerUpgrade.MushroomPlasmaRoot:
                    upgradeName = "Mushroom Plasma Root";
                    textColor = new Color(133, 255, 237);
                    upgradeValue = ref Main.LocalPlayer.Calamity().rageBoostOne;
                    break;
                case PlayerUpgrade.InfernalBlood:
                    upgradeName = "Infernal Blood";
                    textColor = new Color(72, 30, 142);
                    upgradeValue = ref Main.LocalPlayer.Calamity().rageBoostTwo;
                    break;
                case PlayerUpgrade.RedLightningContainer:
                    upgradeName = "Red Lightning Container";
                    textColor = new Color(192, 30, 83);
                    upgradeValue = ref Main.LocalPlayer.Calamity().rageBoostThree;
                    break;
                case PlayerUpgrade.ElectrolyteGelPack:
                    upgradeName = "Electrolyte Gel Pack";
                    textColor = new Color(201, 221, 255);
                    upgradeValue = ref Main.LocalPlayer.Calamity().adrenalineBoostOne;
                    break;
                case PlayerUpgrade.StarlightFuelCell:
                    upgradeName = "Starlight Fuel Cell";
                    textColor = new Color(255, 164, 94);
                    upgradeValue = ref Main.LocalPlayer.Calamity().adrenalineBoostTwo;
                    break;
                case PlayerUpgrade.Ectoheart:
                    upgradeName = "Ectoheart";
                    textColor = new Color(200, 111, 145);
                    upgradeValue = ref Main.LocalPlayer.Calamity().adrenalineBoostThree;
                    break;
                case PlayerUpgrade.DemonHeart:
                    upgradeName = "Demon Heart";
                    textColor = new Color(160, 64, 120);
                    upgradeValue = ref Main.LocalPlayer.extraAccessory;
                    break;
                case PlayerUpgrade.CelestialOnion:
                    upgradeName = "Celestial Onion";
                    textColor = new Color(132, 203, 127);
                    upgradeValue = ref Main.LocalPlayer.Calamity().extraAccessoryML;
                    break;
            }
            upgradeValue = !upgradeValue;
            Main.NewText($"The {upgradeName} effect is now marked as: {upgradeValue}", textColor);
        }
    }
}