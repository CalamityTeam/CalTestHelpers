using CalTestHelpers.Items;
using CalTestHelpers;
using log4net;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalTestHelpers
{
    public class CalTestHelpersPlayer : ModPlayer
    {
        /// <summary>
        /// Used to turn off Rogue procs for the player
        /// </summary>
        public bool CannotProcRogue = false;

        //private static readonly ILog Log;

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