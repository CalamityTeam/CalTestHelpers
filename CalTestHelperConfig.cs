using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
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

		private const int MinimumStuff = 20;
		private const int MaximumStuff = 80; // over this it gets outside the box
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(40)]
		[Terraria.ModLoader.Config.Range(MinimumStuff, MaximumStuff)] //Ambiguous reference moment
		public int StuffAmountDisplay { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
		public bool InstantBossSummoning { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
		public bool Changelog { get; set;}

        [Header("Deprecated")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        public bool StoreFightInformation { get; set; }
        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message) => false;
	}
}