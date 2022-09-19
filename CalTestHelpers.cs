using CalTestHelpers.UI;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace CalTestHelpers
{
    public class CalTestHelpers : Mod
    {
        internal static Mod Calamity = null;
        public static bool ShouldDisplayUIs
        {
            get;
            set;
        } = false;

        public static GrandUIRenderer UltimateUI
        {
            get;
            internal set;
        } = new();

        public static BossDeathPHM BossUIRenderPHM
        {
            get;
            internal set;
        } = new();
        public static BossDeathHM BossUIRenderHM
        {
            get;
            internal set;
        } = new();
        public static BossDeathPML BossUIRenderPML
        {
            get;
            internal set;
        } = new();

        public static PermanentUpgradeUIRenderer UpgradeUIRenderer
        {
            get;
            internal set;
        } = new();

        public static ItemStatEditUIRenderer ItemEditerUIRenderer
        {
            get;
            internal set;
        } = new();

        public static ProjectileStatEditUIRenderer ProjectileEditerUIRenderer
        {
            get;
            internal set;
        } = new();

        /*public static NPCStatManipulatorUIRenderer NPCStatsUIRenderer
        {
            get;
            internal set;
        } = new();*/

        public static StealthStatEditUIRenderer StealthEditerUIRenderer
        {
            get;
            internal set;
        } = new();

        public static List<SpecialUIElement> SecondaryUIElements
        {
            get;
            internal set;
        } = new();

        internal static GrandUIRenderer SecondaryUIToDisplay;

        public static ModKeybind ToggleUIsHotkey;
        public static int GlobalTickTimer { get; internal set; }

        internal static bool HaveAnyStatManipulationsBeenDone = false;
        internal static bool HasDonePostLoading = false;
        public override void Load()
        {
            ToggleUIsHotkey = KeybindLoader.RegisterKeybind(this, "Toggle Test UIs", "Q");
            Calamity = ModLoader.GetMod("CalamityMod");
            ILEdits.Load();
        }

        public override void Unload()
        {
            ToggleUIsHotkey = null;
            Calamity = null;
            ILEdits.Unload();
            EntityOverrideCache.Unload();
            ItemOverrideCache.Unload();
        }

        public override object Call(params object[] args)
        {
            if (args.Length >= 2 && args[0] is string command)
            {
                switch (command.ToLower())
                {
                    case "addtograndui":
                        if (args[1] is SpecialUIElement renderer)
                            SecondaryUIElements.Add(renderer);
                        break;
                }
            }
            return null;
        }
    }
}