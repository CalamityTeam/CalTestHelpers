using CalamityMod.World;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using ReLogic.Content;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.GameContent.Personalities;
using Terraria.Localization;

namespace CalTestHelpers
{
    public partial class CalTestHelpersGlobalItem : GlobalItem
    {
        public override bool ReforgePrice(Item item, ref int reforgePrice, ref bool canApplyDiscount)
        {
            reforgePrice = 0;
            return false;
        }
        /*
        public override void PostReforge(Item item)
        {
            // Calculate the item's reforge cost.
            int value = item.value;
            Player p = Main.LocalPlayer;
            ItemLoader.ReforgePrice(item, ref value, ref p.discountAvailable);

            //Clear Bandit's money since you are getting it back
            CalamityWorld.MoneyStolenByBandit = 0;

            //Become back your money
            int[] coinCounts = Utils.CoinsSplit(value);
            if (coinCounts[0] > 0)
                Item.NewItem(Main.LocalPlayer.GetSource_Loot(), Main.LocalPlayer.Center, ItemID.CopperCoin, coinCounts[0]);
            if (coinCounts[1] > 0)
                Item.NewItem(Main.LocalPlayer.GetSource_Loot(), Main.LocalPlayer.Center, ItemID.SilverCoin, coinCounts[1]);
            if (coinCounts[2] > 0)
                Item.NewItem(Main.LocalPlayer.GetSource_Loot(), Main.LocalPlayer.Center, ItemID.GoldCoin, coinCounts[2]);
            if (coinCounts[3] > 0)
                Item.NewItem(Main.LocalPlayer.GetSource_Loot(), Main.LocalPlayer.Center, ItemID.PlatinumCoin, coinCounts[3]);
        }
        */
    }
}
