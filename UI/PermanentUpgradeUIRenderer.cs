using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.PermanentBoosters;
// using CalamityMod.Testing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalTestHelpers.UI
{
    public class PermanentUpgradeUIRenderer : GrandUIRenderer
    {
        public enum PlayerUpgrade
        {
            SanguineTangerine,
            MiracleFruit,
            TaintedCloudberry,
            SacredStrawberry,
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
            MinecartUpgradeKit,
        }

        public string key = "Mods.CalTestHelpers.UI.TogglePermanentUpgrades.Toggle";
        public static string key2 = "Mods.CalTestHelpers.UI.TogglePermanentUpgrades."; //No clue why the fuck this one needs to be static
        public override List<SpecialUIElement> UIElements => new List<SpecialUIElement>()
        {
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.SanguineTangerine)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/SanguineTangerine").Value, () => ToggleUpgrade(PlayerUpgrade.SanguineTangerine), GetColor(HasUpgrade(PlayerUpgrade.SanguineTangerine))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.MiracleFruit)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/MiracleFruit").Value, () => ToggleUpgrade(PlayerUpgrade.MiracleFruit), GetColor(HasUpgrade(PlayerUpgrade.MiracleFruit))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.TaintedCloudberry)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/TaintedCloudberry").Value, () => ToggleUpgrade(PlayerUpgrade.TaintedCloudberry), GetColor(HasUpgrade(PlayerUpgrade.TaintedCloudberry))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.SacredStrawberry)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/SacredStrawberry").Value, () => ToggleUpgrade(PlayerUpgrade.SacredStrawberry), GetColor(HasUpgrade(PlayerUpgrade.SacredStrawberry))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.CometShard)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/CometShard").Value, () => ToggleUpgrade(PlayerUpgrade.CometShard), GetColor(HasUpgrade(PlayerUpgrade.CometShard))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.EtherealCore)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/EtherealCore").Value, () => ToggleUpgrade(PlayerUpgrade.EtherealCore), GetColor(HasUpgrade(PlayerUpgrade.EtherealCore))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.PhantomHeart)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/PhantomHeart").Value, () => ToggleUpgrade(PlayerUpgrade.PhantomHeart), GetColor(HasUpgrade(PlayerUpgrade.PhantomHeart))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.MushroomPlasmaRoot)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/MushroomPlasmaRoot").Value, () => ToggleUpgrade(PlayerUpgrade.MushroomPlasmaRoot), GetColor(HasUpgrade(PlayerUpgrade.MushroomPlasmaRoot))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.InfernalBlood)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/InfernalBlood").Value, () => ToggleUpgrade(PlayerUpgrade.InfernalBlood), GetColor(HasUpgrade(PlayerUpgrade.InfernalBlood))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.RedLightningContainer)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/RedLightningContainer").Value, () => ToggleUpgrade(PlayerUpgrade.RedLightningContainer), GetColor(HasUpgrade(PlayerUpgrade.RedLightningContainer))),
                    //This looks like a bar of soap
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.ElectrolyteGelPack)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/ElectrolyteGelPack").Value, () => ToggleUpgrade(PlayerUpgrade.ElectrolyteGelPack), GetColor(HasUpgrade(PlayerUpgrade.ElectrolyteGelPack))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.StarlightFuelCell)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/StarlightFuelCell").Value, () => ToggleUpgrade(PlayerUpgrade.StarlightFuelCell), GetColor(HasUpgrade(PlayerUpgrade.StarlightFuelCell))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.Ectoheart)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/Ectoheart").Value, () => ToggleUpgrade(PlayerUpgrade.Ectoheart), GetColor(HasUpgrade(PlayerUpgrade.Ectoheart))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.DemonHeart)), TextureAssets.Item[ItemID.DemonHeart].Value, () => ToggleUpgrade(PlayerUpgrade.DemonHeart), GetColor(HasUpgrade(PlayerUpgrade.DemonHeart))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.CelestialOnion)), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/CelestialOnion").Value, () => ToggleUpgrade(PlayerUpgrade.CelestialOnion), GetColor(HasUpgrade(PlayerUpgrade.CelestialOnion))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.VitalCrystal)), TextureAssets.Item[ItemID.AegisCrystal].Value, () => ToggleUpgrade(PlayerUpgrade.VitalCrystal), GetColor(HasUpgrade(PlayerUpgrade.VitalCrystal))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.ArcaneCrystal)), TextureAssets.Item[ItemID.ArcaneCrystal].Value, () => ToggleUpgrade(PlayerUpgrade.ArcaneCrystal), GetColor(HasUpgrade(PlayerUpgrade.ArcaneCrystal))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.AegisFruit)), TextureAssets.Item[ItemID.AegisFruit].Value, () => ToggleUpgrade(PlayerUpgrade.AegisFruit), GetColor(HasUpgrade(PlayerUpgrade.AegisFruit))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.Ambrosia)), TextureAssets.Item[ItemID.Ambrosia].Value, () => ToggleUpgrade(PlayerUpgrade.Ambrosia), GetColor(HasUpgrade(PlayerUpgrade.Ambrosia))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.GummyWorm)), TextureAssets.Item[ItemID.GummyWorm].Value, () => ToggleUpgrade(PlayerUpgrade.GummyWorm), GetColor(HasUpgrade(PlayerUpgrade.GummyWorm))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.GalaxyPearl)), TextureAssets.Item[ItemID.GalaxyPearl].Value, () => ToggleUpgrade(PlayerUpgrade.GalaxyPearl), GetColor(HasUpgrade(PlayerUpgrade.GalaxyPearl))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.ArtisanLoaf)), TextureAssets.Item[ItemID.ArtisanLoaf].Value, () => ToggleUpgrade(PlayerUpgrade.ArtisanLoaf), GetColor(HasUpgrade(PlayerUpgrade.ArtisanLoaf))),
                    new SpecialUIElement(Language.GetTextValue(key,GetUpgradeName(PlayerUpgrade.MinecartUpgradeKit)), TextureAssets.Item[ItemID.MinecartPowerup].Value, () => ToggleUpgrade(PlayerUpgrade.MinecartUpgradeKit), GetColor(HasUpgrade(PlayerUpgrade.MinecartUpgradeKit))),
        };

        public override Vector2 TopLeftLocation => SecondaryTopLeftLocation;

        public static Color GetColor(bool hasUpgrade) => hasUpgrade ? Color.Green : Color.Red;

        public static string GetUpgradeName(PlayerUpgrade upgrade)
        {
            string UpgradeName = string.Empty;
            if (!CalTestHelperConfig.Instance.ManualLocalizationOverride)
            {
                switch (upgrade)
                {
                    case PlayerUpgrade.SanguineTangerine:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<SanguineTangerine>()).Value;
                        break;
                    case PlayerUpgrade.MiracleFruit:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<MiracleFruit>()).Value;
                        break;
                    case PlayerUpgrade.TaintedCloudberry:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<TaintedCloudberry>()).Value;
                        break;
                    case PlayerUpgrade.SacredStrawberry:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<SacredStrawberry>()).Value;
                        break;
                    case PlayerUpgrade.CometShard:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<CometShard>()).Value;
                        break;
                    case PlayerUpgrade.EtherealCore:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<EtherealCore>()).Value;
                        break;
                    case PlayerUpgrade.PhantomHeart:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<PhantomHeart>()).Value;
                        break;
                    case PlayerUpgrade.MushroomPlasmaRoot:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<MushroomPlasmaRoot>()).Value;
                        break;
                    case PlayerUpgrade.InfernalBlood:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<InfernalBlood>()).Value;
                        break;
                    case PlayerUpgrade.RedLightningContainer:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<RedLightningContainer>()).Value;
                        break;
                    case PlayerUpgrade.ElectrolyteGelPack:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<ElectrolyteGelPack>()).Value;
                        break;
                    case PlayerUpgrade.StarlightFuelCell:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<StarlightFuelCell>()).Value;
                        break;
                    case PlayerUpgrade.Ectoheart:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<Ectoheart>()).Value;
                        break;
                    case PlayerUpgrade.DemonHeart:
                        UpgradeName = Lang.GetItemNameValue(ItemID.DemonHeart);
                        break;
                    case PlayerUpgrade.CelestialOnion:
                        UpgradeName = CalamityUtils.GetItemName(ModContent.ItemType<CelestialOnion>()).Value;
                        break;
                    case PlayerUpgrade.VitalCrystal:
                        UpgradeName = Lang.GetItemNameValue(ItemID.AegisCrystal);
                        break;
                    case PlayerUpgrade.ArcaneCrystal:
                        UpgradeName = Lang.GetItemNameValue(ItemID.ArcaneCrystal);
                        break;
                    case PlayerUpgrade.AegisFruit:
                        UpgradeName = Lang.GetItemNameValue(ItemID.AegisFruit);
                        break;
                    case PlayerUpgrade.Ambrosia:
                        UpgradeName = Lang.GetItemNameValue(ItemID.Ambrosia);
                        break;
                    case PlayerUpgrade.GummyWorm:
                        UpgradeName = Lang.GetItemNameValue(ItemID.GummyWorm);
                        break;
                    case PlayerUpgrade.GalaxyPearl:
                        UpgradeName = Lang.GetItemNameValue(ItemID.GalaxyPearl);
                        break;
                    case PlayerUpgrade.ArtisanLoaf:
                        UpgradeName = Lang.GetItemNameValue(ItemID.ArtisanLoaf);
                        break;
                    case PlayerUpgrade.MinecartUpgradeKit:
                        UpgradeName = Lang.GetItemNameValue(ItemID.MinecartPowerup);
                        break;
                }
            }
            else
            {
                switch (upgrade)
                {
                    case PlayerUpgrade.SanguineTangerine:
                        UpgradeName = Language.GetTextValue(key2 + "SanguineTangerine");
                        break;
                    case PlayerUpgrade.MiracleFruit:
                        UpgradeName = Language.GetTextValue(key2 + "MiracleFruit");
                        break;
                    case PlayerUpgrade.TaintedCloudberry:
                        UpgradeName = Language.GetTextValue(key2 + "TaintedCloudberry");
                        break;
                    case PlayerUpgrade.SacredStrawberry:
                        UpgradeName = Language.GetTextValue(key2 + "SacredStrawberry");
                        break;
                    case PlayerUpgrade.CometShard:
                        UpgradeName = Language.GetTextValue(key2 + "CometShard");
                        break;
                    case PlayerUpgrade.EtherealCore:
                        UpgradeName = Language.GetTextValue(key2 + "EtherealCore");
                        break;
                    case PlayerUpgrade.PhantomHeart:
                        UpgradeName = Language.GetTextValue(key2 + "PhantomHeart");
                        break;
                    case PlayerUpgrade.MushroomPlasmaRoot:
                        UpgradeName = Language.GetTextValue(key2 + "MushroomPlasmaRoot");
                        break;
                    case PlayerUpgrade.InfernalBlood:
                        UpgradeName = Language.GetTextValue(key2 + "InfernalBlood");
                        break;
                    case PlayerUpgrade.RedLightningContainer:
                        UpgradeName = Language.GetTextValue(key2 + "RedLightningContainer");
                        break;
                    case PlayerUpgrade.ElectrolyteGelPack:
                        UpgradeName = Language.GetTextValue(key2 + "Electrolyte");
                        break;
                    case PlayerUpgrade.StarlightFuelCell:
                        UpgradeName = Language.GetTextValue(key2 + "StarlightFuelCell");
                        break;
                    case PlayerUpgrade.Ectoheart:
                        UpgradeName = Language.GetTextValue(key2 + "Ectoheart");
                        break;
                    case PlayerUpgrade.DemonHeart:
                        UpgradeName = Language.GetTextValue(key2 + "DemonHeart");
                        break;
                    case PlayerUpgrade.CelestialOnion:
                        UpgradeName = Language.GetTextValue(key2 + "CelestialOnion");
                        break;
                    case PlayerUpgrade.VitalCrystal:
                        UpgradeName = Language.GetTextValue(key2 + "VitalCrystal");
                        break;
                    case PlayerUpgrade.ArcaneCrystal:
                        UpgradeName = Language.GetTextValue(key2 + "ArcaneCrystal");
                        break;
                    case PlayerUpgrade.AegisFruit:
                        UpgradeName = Language.GetTextValue(key2 + "AegisFruit");
                        break;
                    case PlayerUpgrade.Ambrosia:
                        UpgradeName = Language.GetTextValue(key2 + "Ambrosia");
                        break;
                    case PlayerUpgrade.GummyWorm:
                        UpgradeName = Language.GetTextValue(key2 + "GummyWorm");
                        break;
                    case PlayerUpgrade.GalaxyPearl:
                        UpgradeName = Language.GetTextValue(key2 + "GalaxyPearl");
                        break;
                    case PlayerUpgrade.ArtisanLoaf:
                        UpgradeName = Language.GetTextValue(key2 + "Bread");
                        break;
                    case PlayerUpgrade.MinecartUpgradeKit:
                        UpgradeName = Language.GetTextValue(key2 + "Mechcart");
                        break;
                }
            }

            return UpgradeName;
        }

        public static void ToggleUpgrade(PlayerUpgrade upgradeToToggle)
        {
            string upgradeName = GetUpgradeName(upgradeToToggle);
            Color textColor = Color.White;
            ref bool upgradeValue = ref Main.LocalPlayer.Calamity().sTangerine;
            switch (upgradeToToggle)
            {
                case PlayerUpgrade.SanguineTangerine:
                    textColor = new Color(226, 86, 55);
                    upgradeValue = ref Main.LocalPlayer.Calamity().sTangerine;
                    break;
                case PlayerUpgrade.MiracleFruit:
                    textColor = new Color(150, 41, 186);
                    upgradeValue = ref Main.LocalPlayer.Calamity().mFruit;
                    break;
                case PlayerUpgrade.TaintedCloudberry:
                    textColor = new Color(58, 167, 255);
                    upgradeValue = ref Main.LocalPlayer.Calamity().tCloudberry;
                    break;
                case PlayerUpgrade.SacredStrawberry:
                    textColor = new Color(176, 0, 59);
                    upgradeValue = ref Main.LocalPlayer.Calamity().sStrawberry;
                    break;
                case PlayerUpgrade.CometShard:
                    textColor = new Color(66, 189, 181);
                    upgradeValue = ref Main.LocalPlayer.Calamity().cShard;
                    break;
                case PlayerUpgrade.EtherealCore:
                    textColor = new Color(237, 93, 83);
                    upgradeValue = ref Main.LocalPlayer.Calamity().eCore;
                    break;
                case PlayerUpgrade.PhantomHeart:
                    textColor = new Color(255, 84, 146);
                    upgradeValue = ref Main.LocalPlayer.Calamity().pHeart;
                    break;
                case PlayerUpgrade.MushroomPlasmaRoot:
                    textColor = new Color(133, 255, 237);
                    upgradeValue = ref Main.LocalPlayer.Calamity().rageBoostOne;
                    break;
                case PlayerUpgrade.InfernalBlood:
                    textColor = new Color(72, 30, 142);
                    upgradeValue = ref Main.LocalPlayer.Calamity().rageBoostTwo;
                    break;
                case PlayerUpgrade.RedLightningContainer:
                    textColor = new Color(192, 30, 83);
                    upgradeValue = ref Main.LocalPlayer.Calamity().rageBoostThree;
                    break;
                case PlayerUpgrade.ElectrolyteGelPack:
                    textColor = new Color(201, 221, 255);
                    upgradeValue = ref Main.LocalPlayer.Calamity().adrenalineBoostOne;
                    break;
                case PlayerUpgrade.StarlightFuelCell:
                    textColor = new Color(255, 164, 94);
                    upgradeValue = ref Main.LocalPlayer.Calamity().adrenalineBoostTwo;
                    break;
                case PlayerUpgrade.Ectoheart:
                    textColor = new Color(200, 111, 145);
                    upgradeValue = ref Main.LocalPlayer.Calamity().adrenalineBoostThree;
                    break;
                case PlayerUpgrade.DemonHeart:
                    textColor = new Color(160, 64, 120);
                    upgradeValue = ref Main.LocalPlayer.extraAccessory;
                    break;
                case PlayerUpgrade.CelestialOnion:
                    textColor = new Color(132, 203, 127);
                    upgradeValue = ref Main.LocalPlayer.Calamity().extraAccessoryML;
                    break;
                case PlayerUpgrade.VitalCrystal:
                    textColor = new Color(216, 126, 224);
                    upgradeValue = ref Main.LocalPlayer.usedAegisCrystal;
                    break;
                case PlayerUpgrade.ArcaneCrystal:
                    textColor = new Color(173, 96, 214);
                    upgradeValue = ref Main.LocalPlayer.usedArcaneCrystal;
                    break;
                case PlayerUpgrade.AegisFruit:
                    textColor = new Color(191, 133, 222);
                    upgradeValue = ref Main.LocalPlayer.usedAegisFruit;
                    break;
                case PlayerUpgrade.Ambrosia:
                    textColor = new Color(214, 158, 15);
                    upgradeValue = ref Main.LocalPlayer.usedAmbrosia;
                    break;
                case PlayerUpgrade.GummyWorm:
                    textColor = new Color(214, 19, 172);
                    upgradeValue = ref Main.LocalPlayer.usedGummyWorm;
                    break;
                case PlayerUpgrade.GalaxyPearl:
                    textColor = new Color(88, 39, 168);
                    upgradeValue = ref Main.LocalPlayer.usedGalaxyPearl;
                    break;
                case PlayerUpgrade.ArtisanLoaf:
                    textColor = new Color(199, 111, 24);
                    upgradeValue = ref Main.LocalPlayer.ateArtisanBread;
                    break;
                case PlayerUpgrade.MinecartUpgradeKit:
                    textColor = new Color(102, 102, 102);
                    upgradeValue = ref Main.LocalPlayer.unlockedSuperCart;
                    break;
            }
            upgradeValue = !upgradeValue;
            Main.NewText(Language.GetTextValue("Mods.CalTestHelpers.UI.TogglePermanentUpgrades.ToggleItem", upgradeName, upgradeValue), textColor);
        }

        public static bool HasUpgrade(PlayerUpgrade upgradeToToggle)
        {
            switch (upgradeToToggle)
            {
                case PlayerUpgrade.SanguineTangerine:
                    return Main.LocalPlayer.Calamity().sTangerine;
                case PlayerUpgrade.MiracleFruit:
                    return Main.LocalPlayer.Calamity().mFruit;
                case PlayerUpgrade.TaintedCloudberry:
                    return Main.LocalPlayer.Calamity().tCloudberry;
                case PlayerUpgrade.SacredStrawberry:
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
                case PlayerUpgrade.MinecartUpgradeKit:
                    return Main.LocalPlayer.unlockedSuperCart;
            }
            return false;
        }
    }
}