using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalTestHelpers
{
	public class CalTestHelpersPlayer : ModPlayer
	{
        public int statChangeCooldown = 0;

        public override void UpdateDead()
        {
			statChangeCooldown = 0;
		}

        public override void PostUpdateMiscEffects()
        {
			if (statChangeCooldown > 0)
				statChangeCooldown--;
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (CalTestHelpers.ToggleUIsHotkey.JustPressed)
				CalTestHelpers.ShouldDisplayUIs = !CalTestHelpers.ShouldDisplayUIs;
		}
	}
}