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
        public override void OnEnterWorld()
        {
            if (CalTestHelperConfig.Instance.Changelog)
            {
                Player p = Main.LocalPlayer;
                int changelog = Item.NewItem(p.GetSource_Misc("CalTestHelpers_Changelog"), (int)p.position.X, (int)p.position.Y, p.width, p.height, ModContent.ItemType<Changelog>());
                //Multiplayer moment
                if (Main.netMode == NetmodeID.Server)
                {
                    Main.timeItemSlotCannotBeReusedFor[changelog] = 54000;
                    NetMessage.SendData(MessageID.InstancedItem, p.whoAmI, -1, null, changelog);
                }
            }
            Mod Calamity = ModContent.GetInstance<CalTestHelpers>().Calamity;
            //bool SummonerBranch = Calamity.TryFind("ArdorBlossomStar", out ModItem ArdorBlossomStar);
            //Log.Info($"Summoner branch: {SummonerBranch}");
            //Main.NewText($"Summoner branch: {SummonerBranch}");
        }
    }
}