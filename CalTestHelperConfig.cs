using System.ComponentModel;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace CalTestHelpers
{
    //[BackgroundColor(0, 50, 78, 216)] //Default
    [BackgroundColor(49, 32, 36, 216)] //Calamity
    public class CalTestHelperConfig : ModConfig
    {
        public static CalTestHelperConfig Instance;
        public override ConfigScope Mode => ConfigScope.ClientSide;


        [Header("Configs")]
        //[BackgroundColor(128, 129, 225, 192)] default Terraria
        [BackgroundColor(192, 54, 64, 192)] // Calamity
        [DefaultValue(true)]
        public bool BossDeathStatMessages { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(true)]
        public bool InstantBossSummoning { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(true)]
        public bool Changelog { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [SliderColor(224, 165, 56, 128)]
        [Range(0.8f, 1.5f)]
        [DefaultValue(1f)]
        [Increment(0.05f)]
        [DrawTicks]
        public float UISize { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(true)]

        public bool FreeReforges { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]

        public bool ManualLocalizationOverride { get; set; }

        [Header("Deprecated")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(40)]
        [Range(20, 80)] //Over 80 it gets outside the box vertically
        public int StuffAmountDisplay { get; set; }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message) => false;
    }
}