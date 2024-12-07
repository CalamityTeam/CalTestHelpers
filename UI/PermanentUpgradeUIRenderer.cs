using CalamityMod;
// using CalamityMod.Testing;
using CalamityMod.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalTestHelpers.UI
{
    public class PermanentUpgradeUIRenderer : GrandUIRenderer
    {
        public static bool NimbleBounderPresent = false;
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
            CelestialOnion,
            VitalCrystal,
            ArcaneCrystal,
            AegisFruit,
            Ambrosia,
            GummyWorm,
            GalaxyPearl,
            ArtisanLoaf,
            NimbleBounder
        }

        public string key = "Mods.CalTestHelpers.UI.TogglePermanentUpgrades.";
        public override List<SpecialUIElement> UIElements => new List<SpecialUIElement>()
        {
                    new SpecialUIElement(Language.GetTextValue(key+"SanguineTangerine"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/SanguineTangerine").Value, () => ToggleUpgrade(PlayerUpgrade.BloodOrange), GetColor(HasUpgrade(PlayerUpgrade.BloodOrange))),
                    new SpecialUIElement(Language.GetTextValue(key+"MiracleFruit"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/MiracleFruit").Value, () => ToggleUpgrade(PlayerUpgrade.MiracleFruit), GetColor(HasUpgrade(PlayerUpgrade.MiracleFruit))),
                    new SpecialUIElement(Language.GetTextValue(key+"TaintedCloudberry"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/TaintedCloudberry").Value, () => ToggleUpgrade(PlayerUpgrade.Elderberry), GetColor(HasUpgrade(PlayerUpgrade.Elderberry))),
                    new SpecialUIElement(Language.GetTextValue(key+"SacredStrawberry"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/SacredStrawberry").Value, () => ToggleUpgrade(PlayerUpgrade.Dragonfruit), GetColor(HasUpgrade(PlayerUpgrade.Dragonfruit))),
                    new SpecialUIElement(Language.GetTextValue(key+"CometShard"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/CometShard").Value, () => ToggleUpgrade(PlayerUpgrade.CometShard), GetColor(HasUpgrade(PlayerUpgrade.CometShard))),
                    new SpecialUIElement(Language.GetTextValue(key+"EtherealCore"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/EtherealCore").Value, () => ToggleUpgrade(PlayerUpgrade.EtherealCore), GetColor(HasUpgrade(PlayerUpgrade.EtherealCore))),
                    new SpecialUIElement(Language.GetTextValue(key+"PhantomHeart"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/PhantomHeart").Value, () => ToggleUpgrade(PlayerUpgrade.PhantomHeart), GetColor(HasUpgrade(PlayerUpgrade.PhantomHeart))),
                    new SpecialUIElement(Language.GetTextValue(key+"MushroomPlasmaRoot"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/MushroomPlasmaRoot").Value, () => ToggleUpgrade(PlayerUpgrade.MushroomPlasmaRoot), GetColor(HasUpgrade(PlayerUpgrade.MushroomPlasmaRoot))),
                    new SpecialUIElement(Language.GetTextValue(key+"InfernalBlood"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/InfernalBlood").Value, () => ToggleUpgrade(PlayerUpgrade.InfernalBlood), GetColor(HasUpgrade(PlayerUpgrade.InfernalBlood))),
                    new SpecialUIElement(Language.GetTextValue(key+"RedLightningContainer"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/RedLightningContainer").Value, () => ToggleUpgrade(PlayerUpgrade.RedLightningContainer), GetColor(HasUpgrade(PlayerUpgrade.RedLightningContainer))),
                    //This looks like a bar of soap
                    new SpecialUIElement(Language.GetTextValue(key+"NotBarOfSoap"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/ElectrolyteGelPack").Value, () => ToggleUpgrade(PlayerUpgrade.ElectrolyteGelPack), GetColor(HasUpgrade(PlayerUpgrade.ElectrolyteGelPack))),
                    new SpecialUIElement(Language.GetTextValue(key+"StarlightFuelCell"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/StarlightFuelCell").Value, () => ToggleUpgrade(PlayerUpgrade.StarlightFuelCell), GetColor(HasUpgrade(PlayerUpgrade.StarlightFuelCell))),
                    new SpecialUIElement(Language.GetTextValue(key+"Ectoheart"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/Ectoheart").Value, () => ToggleUpgrade(PlayerUpgrade.Ectoheart), GetColor(HasUpgrade(PlayerUpgrade.Ectoheart))),
                    new SpecialUIElement(Language.GetTextValue(key+"DemonHeart"), TextureAssets.Item[ItemID.DemonHeart].Value, () => ToggleUpgrade(PlayerUpgrade.DemonHeart), GetColor(HasUpgrade(PlayerUpgrade.DemonHeart))),
                    new SpecialUIElement(Language.GetTextValue(key+"CelestialOnion"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/CelestialOnion").Value, () => ToggleUpgrade(PlayerUpgrade.CelestialOnion), GetColor(HasUpgrade(PlayerUpgrade.CelestialOnion))),
                    new SpecialUIElement(Language.GetTextValue(key+"VitalCrystal"), TextureAssets.Item[ItemID.AegisCrystal].Value, () => ToggleUpgrade(PlayerUpgrade.VitalCrystal), GetColor(HasUpgrade(PlayerUpgrade.VitalCrystal))),
                    new SpecialUIElement(Language.GetTextValue(key+"ArcaneCrystal"), TextureAssets.Item[ItemID.ArcaneCrystal].Value, () => ToggleUpgrade(PlayerUpgrade.ArcaneCrystal), GetColor(HasUpgrade(PlayerUpgrade.ArcaneCrystal))),
                    new SpecialUIElement(Language.GetTextValue(key+"AegisFruit"), TextureAssets.Item[ItemID.AegisFruit].Value, () => ToggleUpgrade(PlayerUpgrade.AegisFruit), GetColor(HasUpgrade(PlayerUpgrade.AegisFruit))),
                    new SpecialUIElement(Language.GetTextValue(key+"Ambrosia"), TextureAssets.Item[ItemID.Ambrosia].Value, () => ToggleUpgrade(PlayerUpgrade.Ambrosia), GetColor(HasUpgrade(PlayerUpgrade.Ambrosia))),
                    new SpecialUIElement(Language.GetTextValue(key+"GummyWorm"), TextureAssets.Item[ItemID.GummyWorm].Value, () => ToggleUpgrade(PlayerUpgrade.GummyWorm), GetColor(HasUpgrade(PlayerUpgrade.GummyWorm))),
                    new SpecialUIElement(Language.GetTextValue(key+"GalaxyPearl"), TextureAssets.Item[ItemID.GalaxyPearl].Value, () => ToggleUpgrade(PlayerUpgrade.GalaxyPearl), GetColor(HasUpgrade(PlayerUpgrade.GalaxyPearl))),
                    new SpecialUIElement(Language.GetTextValue(key+"Bread"), TextureAssets.Item[ItemID.ArtisanLoaf].Value, () => ToggleUpgrade(PlayerUpgrade.ArtisanLoaf), GetColor(HasUpgrade(PlayerUpgrade.ArtisanLoaf))),
                    new SpecialUIElement(Language.GetTextValue(key+"NimbleBounder"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/NimbleBounder").Value, () => ToggleUpgrade(PlayerUpgrade.NimbleBounder), GetColor(HasUpgrade(PlayerUpgrade.NimbleBounder))),
        };

        public override Vector2 TopLeftLocation => new Vector2(Main.screenWidth - 450 - 350 * ResolutionRatio, 40);

        public static Color GetColor(bool hasUpgrade) => hasUpgrade ? Color.Green : Color.Red;

        public static void ToggleUpgrade(PlayerUpgrade upgradeToToggle)
        {
            string upgradeName = string.Empty;
            Color textColor = Color.White;
            ref bool upgradeValue = ref Main.LocalPlayer.Calamity().sTangerine;
            switch (upgradeToToggle)
            {
                case PlayerUpgrade.BloodOrange:
                    upgradeName = "Sanguine Tangerine";
                    textColor = new Color(226, 86, 55);
                    upgradeValue = ref Main.LocalPlayer.Calamity().sTangerine;
                    break;
                case PlayerUpgrade.MiracleFruit:
                    upgradeName = "Miracle Fruit";
                    textColor = new Color(107, 206, 84);
                    upgradeValue = ref Main.LocalPlayer.Calamity().mFruit;
                    break;
                case PlayerUpgrade.Elderberry:
                    upgradeName = "Tainted Cloudberry";
                    textColor = new Color(58, 167, 255);
                    upgradeValue = ref Main.LocalPlayer.Calamity().tCloudberry;
                    break;
                case PlayerUpgrade.Dragonfruit:
                    upgradeName = "Sacred Strawberry";
                    textColor = new Color(56, 122, 175);
                    upgradeValue = ref Main.LocalPlayer.Calamity().sStrawberry;
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
                case PlayerUpgrade.VitalCrystal:
                    upgradeName = "Vital Crystal";
                    textColor = new Color(216, 126, 224);
                    upgradeValue = ref Main.LocalPlayer.usedAegisCrystal;
                    break;
                case PlayerUpgrade.ArcaneCrystal:
                    upgradeName = "Arcane Crystal";
                    textColor = new Color(173, 96, 214);
                    upgradeValue = ref Main.LocalPlayer.usedArcaneCrystal;
                    break;
                case PlayerUpgrade.AegisFruit:
                    upgradeName = "Aegis Fruit";
                    textColor = new Color(191, 133, 222);
                    upgradeValue = ref Main.LocalPlayer.usedAegisFruit;
                    break;
                case PlayerUpgrade.Ambrosia:
                    upgradeName = "Ambrosia";
                    textColor = new Color(214, 158, 15);
                    upgradeValue = ref Main.LocalPlayer.usedAmbrosia;
                    break;
                case PlayerUpgrade.GummyWorm:
                    upgradeName = "Gummy Worm";
                    textColor = new Color(214, 19, 172);
                    upgradeValue = ref Main.LocalPlayer.usedGummyWorm;
                    break;
                case PlayerUpgrade.GalaxyPearl:
                    upgradeName = "Galaxy Pearl";
                    textColor = new Color(88, 39, 168);
                    upgradeValue = ref Main.LocalPlayer.usedGalaxyPearl;
                    break;
                case PlayerUpgrade.ArtisanLoaf:
                    upgradeName = "Artisan Loaf";
                    textColor = new Color(199, 111, 24);
                    upgradeValue = ref Main.LocalPlayer.ateArtisanBread;
                    break;
                case PlayerUpgrade.NimbleBounder:
                    upgradeName = "Nimble Bounder";
                    textColor = new Color(200, 111, 145);
                    upgradeValue = ref Main.LocalPlayer.Calamity().nimbleBounderBoost;
                    break;
            }
            upgradeValue = !upgradeValue;
            Main.NewText($"The {upgradeName} effect is now marked as: {upgradeValue}", textColor);
        }

        public static bool HasUpgrade(PlayerUpgrade upgradeToToggle)
        {
            switch (upgradeToToggle)
            {
                case PlayerUpgrade.BloodOrange:
                    return Main.LocalPlayer.Calamity().sTangerine;
                case PlayerUpgrade.MiracleFruit:
                    return Main.LocalPlayer.Calamity().mFruit;
                case PlayerUpgrade.Elderberry:
                    return Main.LocalPlayer.Calamity().tCloudberry;
                case PlayerUpgrade.Dragonfruit:
                    return Main.LocalPlayer.Calamity().sStrawberry;
                case PlayerUpgrade.CometShard:
                    return Main.LocalPlayer.Calamity().cShard;
                case PlayerUpgrade.EtherealCore:
                    return Main.LocalPlayer.Calamity().eCore;
                case PlayerUpgrade.PhantomHeart:
                    return Main.LocalPlayer.Calamity().pHeart;
                case PlayerUpgrade.MushroomPlasmaRoot:
                    return Main.LocalPlayer.Calamity().rageBoostOne;
                case PlayerUpgrade.InfernalBlood:
                    return Main.LocalPlayer.Calamity().rageBoostTwo;
                case PlayerUpgrade.RedLightningContainer:
                    return Main.LocalPlayer.Calamity().rageBoostThree;
                case PlayerUpgrade.ElectrolyteGelPack:
                    return Main.LocalPlayer.Calamity().adrenalineBoostOne;
                case PlayerUpgrade.StarlightFuelCell:
                    return Main.LocalPlayer.Calamity().adrenalineBoostTwo;
                case PlayerUpgrade.Ectoheart:
                    return Main.LocalPlayer.Calamity().adrenalineBoostThree;
                case PlayerUpgrade.DemonHeart:
                    return Main.LocalPlayer.extraAccessory;
                case PlayerUpgrade.CelestialOnion:
                    return Main.LocalPlayer.Calamity().extraAccessoryML;
                case PlayerUpgrade.VitalCrystal:
                    return Main.LocalPlayer.usedAegisCrystal;
                case PlayerUpgrade.ArcaneCrystal:
                    return Main.LocalPlayer.usedArcaneCrystal;
                case PlayerUpgrade.AegisFruit:
                    return Main.LocalPlayer.usedAegisFruit;
                case PlayerUpgrade.Ambrosia:
                    return Main.LocalPlayer.usedAmbrosia;
                case PlayerUpgrade.GummyWorm:
                    return Main.LocalPlayer.usedGummyWorm;
                case PlayerUpgrade.GalaxyPearl:
                    return Main.LocalPlayer.usedGalaxyPearl;
                case PlayerUpgrade.ArtisanLoaf:
                    return Main.LocalPlayer.ateArtisanBread;
                case PlayerUpgrade.NimbleBounder:
                    return Main.LocalPlayer.Calamity().nimbleBounderBoost;
            }
            return false;
        }
    }
}