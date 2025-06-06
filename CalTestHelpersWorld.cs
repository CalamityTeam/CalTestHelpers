using CalamityMod.CalPlayer;
using CalamityMod.Projectiles.Boss;
using CalamityMod.World;
using CalTestHelpers.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace CalTestHelpers
{
    public class CalTestHelpersWorld : ModSystem
    {
        public static int OriginalTime;
        public static int BossKillTimeFrames;
        public static bool NoSpawns = false;
        public static bool FrozenTime = false;
        public static List<int> BossKillDPS = new List<int>();

        public override void SaveWorldData(TagCompound tag)
        {
            tag["NoSpawns"] = NoSpawns;
            tag["FrozenTime"] = FrozenTime;
        }
        public override void LoadWorldData(TagCompound tag)
        {
            NoSpawns = tag.GetBool("NoSpawns");
            FrozenTime = tag.GetBool("FrozenTime");
        }
        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(NoSpawns);
            writer.Write(FrozenTime);
        }
        public override void NetReceive(BinaryReader reader)
        {
            NoSpawns = reader.ReadBoolean();
            FrozenTime = reader.ReadBoolean();
        }

        public override void PostUpdateWorld()
        {
            if (FrozenTime && Main.netMode == NetmodeID.SinglePlayer)
                Main.time -= Main.dayRate;

            if (CalamityPlayer.areThereAnyDamnBosses && !Main.LocalPlayer.dead)
            {
                BossKillTimeFrames++;

                // Incorporate any new DPS values as they come.
                if (Main.LocalPlayer.dpsDamage != BossKillDPS.LastOrDefault())
                {
                    BossKillDPS.Add(Main.LocalPlayer.dpsDamage);
                }
            }
            else if (BossKillTimeFrames >= 2)
            {
                if (CalTestHelperConfig.Instance.BossDeathStatMessages)
                {
                    double averageDPS = BossKillDPS.Count == 0 ? 0f : BossKillDPS.Average();
                    double maxDPS = BossKillDPS.Count == 0 ? 0f : BossKillDPS.Max();
                    string timeString = TimeSpan.FromSeconds(BossKillTimeFrames / 60f).ToString(@"hh\:mm\:ss");
                    string textToDisplay = $"Time Elapsed: {timeString}\n" +
                                           $"Average DPS: {averageDPS}\n" +
                                           $"Maximum DPS: {maxDPS}\n" +
                                           $"DPS Instability Factor: {(maxDPS + 1f) / (averageDPS + 1f)}";

                    // Newlines fuck text displays up.
                    foreach (var snippet in textToDisplay.Split('\n'))
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                            Main.NewText(snippet, Color.Crimson);
                        else if (Main.netMode == NetmodeID.Server)
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(snippet), Color.Crimson);
                    }
                }

                if (CalTestHelperConfig.Instance.StoreFightInformation)
                    FightInformationPrintManager.SaveFightInformation();

                BossKillDPS.Clear();
                BossKillTimeFrames = 0;
            }
            if (CalTestHelperConfig.Instance.InstantBossSummoning)
                if (CalamityWorld.DraedonSummonCountdown > 0)
                    CalamityWorld.DraedonSummonCountdown = 1;
            // Scal goes on Global Projectile since Xyk made the value of the ritual a constant
        }

        public override void PostUpdateEverything()
        {
            CalTestHelpers.GlobalTickTimer++;
            if (CalTestHelpers.HasDonePostLoading)
                return;

            ItemOverrideCache.Load();
            EntityOverrideCache.Load();
            CalTestHelpers.HasDonePostLoading = true;
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseIndex = layers.FindIndex(layer => layer.Name == "Vanilla: Mouse Text");
            if (mouseIndex != -1)
            {
                layers.Insert(mouseIndex, new LegacyGameInterfaceLayer("Special UIs", () =>
                {
                    if (!Main.inFancyUI && Main.playerInventory)
                    {
                        CalTestHelpers.UltimateUI.Draw(Main.spriteBatch);
                        if (CalTestHelpers.SecondaryUIToDisplay != null)
                            CalTestHelpers.SecondaryUIToDisplay.Draw(Main.spriteBatch);
                    }

                    // Draw a gear at the bottom of the screen if any stat manipulations have been done
                    // This is done to prevent cheating by nohitters (who use this mod).
                    // If you attempt to remove this behavior and do something like this, I am not responsible.
                    if (CalTestHelpers.HaveAnyStatManipulationsBeenDone)
                    {
                        Texture2D gearTexture = ModContent.Request<Texture2D>("CalTestHelpers/UI/Gear").Value;
                        Vector2 gearDrawPosition = new Vector2(Main.screenWidth - 400f, Main.screenHeight - 60f);
                        Main.spriteBatch.Draw(gearTexture, gearDrawPosition, null, Color.Cyan, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    return true;
                }, InterfaceScaleType.UI));
            }
        }

        public override void PostDrawFullscreenMap(ref string mouseText) => MapServices.TryToTeleportPlayerOnMap();
    }
}