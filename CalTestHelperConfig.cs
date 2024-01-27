using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Terraria.ModLoader.Config;

namespace CalTestHelpers
{
	[Label("Config")]
	[BackgroundColor(0, 50, 78, 216)]
	public class CalTestHelperConfig : ModConfig
	{
		public static CalTestHelperConfig Instance;
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Label("Boss Death Stat Chat Messages")]
		[BackgroundColor(128, 129, 225, 192)]
		[DefaultValue(true)]
		[Tooltip("Enables the the boss death stat chat messages. Includes fight time, average DPS, and max DPS.")]
		public bool BossDeathStatMessages { get; set; }

		[Label("Store Boss Fight Information")]
		[BackgroundColor(128, 129, 225, 192)]
		[DefaultValue(false)]
		[Tooltip("Enables the the boss death stat chat messages. Includes fight time, average DPS, and max DPS.")]
		public bool StoreFightInformation { get; set; }

		private const int MinimumStuff = 20;
		private const int MaximumStuff = 80; // over this it gets outside the box
        [Label("Amount of stuff to display in menus")]
        [BackgroundColor(128, 129, 225, 192)]
        [DefaultValue(40)]
		[Terraria.ModLoader.Config.Range(MinimumStuff,MaximumStuff)] //Ambiguous reference moment
        [Tooltip("How many projectiles should the Projectile and item stat editor display")]
        public int StuffAmountDisplay { get; set; }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) => false;
	}
}