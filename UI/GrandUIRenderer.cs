using CalamityMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using CalamityMod.CalPlayer;
using Terraria.GameContent;
using CalamityMod.Balancing;
using CalamityMod.Events;
using CalamityMod.Systems;
// using CalamityMod.Testing;
using CalamityMod.NPCs;
//using CalamityMod.Items.Weapons.Summon.Whips;

namespace CalTestHelpers.UI
{
    public class GrandUIRenderer
    {
        public virtual List<SpecialUIElement> UIElements
        {
            get
            {
                List<SpecialUIElement> elements = new List<SpecialUIElement>()
                {
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.RevealMap.DisplayName"), ModContent.Request<Texture2D>("CalTestHelpers/UI/EyeTexture").Value, MapServices.RevealTheEntireMap),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.SetSpawnpoint.DisplayName"), TextureAssets.Item[ItemID.GoldenBed].Value, () =>
                    {
                        Main.spawnTileX = (int)(Main.LocalPlayer.position.X - 8 + Main.LocalPlayer.width / 2) / 16;
                        Main.spawnTileY = (int)(Main.LocalPlayer.position.Y + Main.LocalPlayer.height) / 16;
                        Main.NewText(Language.GetTextValue("Mods.CalTestHelpers.UI.SetSpawnpoint.set") + $" {new Vector2(Main.spawnTileX, Main.spawnTileY)}");
                    }),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.ToggleEnemySpawns.DisplayName"), ModContent.Request<Texture2D>("CalTestHelpers/UI/EnemyIcon").Value, () =>
                    {
                        CalTestHelpersWorld.NoSpawns = !CalTestHelpersWorld.NoSpawns;
                        if (CalTestHelpersWorld.NoSpawns)
                        {
                            for (int i = 0; i < Main.maxNPCs; i++)
                            {
                                bool isPillar = Main.npc[i].type == NPCID.LunarTowerNebula ||
                                                Main.npc[i].type == NPCID.LunarTowerSolar ||
                                                Main.npc[i].type == NPCID.LunarTowerStardust ||
                                                Main.npc[i].type == NPCID.LunarTowerVortex;
                                if (isPillar)
                                    continue;
                                if (Main.npc[i] != null && !Main.npc[i].townNPC)
                                {
                                    Main.npc[i].life = 0;
                                    if (Main.netMode == NetmodeID.Server)
                                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, i, 0f, 0f, 0f, 0);
                                }
                            }
                        }
                        //Localization making shit slightly harder
                        Main.NewText(CalTestHelpersWorld.NoSpawns ? Language.GetTextValue("Mods.CalTestHelpers.UI.ToggleEnemySpawns.CannotSpawn") : Language.GetTextValue("Mods.CalTestHelpers.UI.ToggleEnemySpawns.CanSpawn"));
                    }, CalTestHelpersWorld.NoSpawns ? Color.Green : Color.Red),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.StopTime.DisplayName"), ModContent.Request<Texture2D>("CalTestHelpers/UI/WatchTexture").Value, () =>
                    {
                        CalTestHelpersWorld.FrozenTime = !CalTestHelpersWorld.FrozenTime;
                        Main.NewText(CalTestHelpersWorld.FrozenTime ? Language.GetTextValue("Mods.CalTestHelpers.UI.StopTime.Stopped") : Language.GetTextValue("Mods.CalTestHelpers.UI.StopTime.Resumed"), CalTestHelpersWorld.FrozenTime ? Color.Cyan : Color.Goldenrod);
                    }, CalTestHelpersWorld.FrozenTime ? Color.Green : Color.Red),
                    new SpecialUIElement("Toggle Prehardmode boss deaths.", ModContent.Request<Texture2D>("CalTestHelpers/UI/BladesPHM").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.BossUIRenderPHM : null;
                    }),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.ToggleDeathsHM.DisplayName"), ModContent.Request<Texture2D>("CalTestHelpers/UI/BladesHM").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.BossUIRenderHM : null;
                    }),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.ToggleDeathsPML.DisplayName"), ModContent.Request<Texture2D>("CalTestHelpers/UI/BladesPML").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.BossUIRenderPML : null;
                    }),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.TogglePermanentUpgrades.DisplayName"), ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/BloodOrange").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.UpgradeUIRenderer : null;
                    }),
                     new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.BossRushTalkFaster.DisplayName"), Main.zenithWorld ? ModContent.Request<Texture2D>("CalamityMod/Items/SummonItems/Terminus_GFB").Value : ModContent.Request<Texture2D>("CalamityMod/Items/SummonItems/Terminus").Value, () =>
                    {
                       BossRushDialogueSystem.GottaGoFast = !BossRushDialogueSystem.GottaGoFast;
                       Main.NewText(BossRushDialogueSystem.GottaGoFast ? Language.GetTextValue("Mods.CalTestHelpers.UI.BossRushTalkFaster.TalkFast") : Language.GetTextValue("Mods.CalTestHelpers.UI.BossRushTalkFaster.TalkSlower"), BossRushEvent.XerocTextColor);
                    }, BossRushDialogueSystem.GottaGoFast ? Color.Green : Color.Red),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.ChangeItemStats.DisplayName"), ModContent.Request<Texture2D>("CalamityMod/Items/TreasureBags/MiscGrabBags/StarterBag").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.ItemEditerUIRenderer : null;
                    }, Color.Yellow),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.ChangeProjectileStats.DisplayName"), ModContent.Request<Texture2D>("CalamityMod/Items/Ammo/MarksmanRound").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.ProjectileEditerUIRenderer : null;
                    }, Color.Yellow),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.ChangeUniversalStealthFactor.DisplayName"), ModContent.Request<Texture2D>("CalamityMod/Items/Weapons/Rogue/Cinquedea").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.StealthEditerUIRenderer : null;
                    }, Color.Yellow),
                    new SpecialUIElement(Language.GetTextValue("Mods.CalTestHelpers.UI.ResetStats.DisplayName"), ModContent.Request<Texture2D>("CalTestHelpers/UI/Gear").Value, () =>
                    {
                        ItemOverrideCache.ResetOverrides();
                        EntityOverrideCache.ResetOverrides();
                        CalTestHelpers.ItemEditerUIRenderer.ItemBeingEdited = null;
                        Main.NewText(Language.GetTextValue("Mods.CalTestHelpers.UI.ResetStats.Reset"));
                    }, Color.Yellow),
                };

                /*
                // Just so it doesnt error WeakReferences are used, this is to find if its summoner branch or not
                Mod Calamity = GetInstance<CalTestHelpers>().Calamity;
                if (Calamity.TryFind("ArdorBlossomStar", out ModItem SummonerBranch))
                {
                    SpecialUIElement ToggleWhips = new SpecialUIElement("Toggle Whip tag (Dev versions only)", TextureAssets.Item[ItemID.BlandWhip].Value, () =>
                    {
                        Calamity.Call("ToggleWhipTag");
                        //im not gonna bother localizing something only the dev server can see, unless a dev requests
                        Main.NewText($"Tag damage is now {(CalamityGlobalNPC.DisableMultWhipTag ? "flat" : "multiplicative")}.");
                    }, CalamityGlobalNPC.DisableMultWhipTag ? Color.Green : Color.Red);
                    elements.Add(ToggleWhips);
                }
                */
                //Add all elements
                elements.AddRange(CalTestHelpers.SecondaryUIElements);
                return elements;
            }
        }

        //keep at this, 1920 makes the icons MASSIVE
        public static float ResolutionRatio => Main.screenWidth / 2560f;

        //this is to move the button
        public virtual Vector2 TopLeftLocation => new Vector2(Main.screenWidth - 450, 120);

        public static Vector2 SecondaryTopLeftLocation => new Vector2(Main.screenWidth - 450 - 350 * ResolutionRatio, 40);

        public virtual float UIScale => ResolutionRatio;

        public virtual Color TextColor => Color.Cyan;

        public virtual Vector2 IconBounds => new Vector2(44f * UIScale);

        public virtual void DrawElements(SpriteBatch spriteBatch, float top)
        {
            //Load items as otherwise the icons will not appear for these vanilla items
            Main.instance.LoadItem(ItemID.GoldenBed);
            Main.instance.LoadItem(ItemID.DemonHeart);
            Main.instance.LoadItem(ItemID.AegisCrystal);
            Main.instance.LoadItem(ItemID.ArcaneCrystal);
            Main.instance.LoadItem(ItemID.AegisFruit);
            Main.instance.LoadItem(ItemID.Ambrosia);
            Main.instance.LoadItem(ItemID.GummyWorm);
            Main.instance.LoadItem(ItemID.GalaxyPearl);
            Main.instance.LoadItem(ItemID.ArtisanLoaf);
            Main.instance.LoadItem(ItemID.BlandWhip);
            Texture2D categorySlotTexture = ModContent.Request<Texture2D>("CalTestHelpers/UI/CategorySlot").Value;
            foreach (var button in UIElements)
            {
                Rectangle currentRectangleArea = new Rectangle((int)TopLeftLocation.X-150, (int)top, (int)IconBounds.X, (int)IconBounds.Y);
                Rectangle currentRectangleAreaWorld = new Rectangle((int)(TopLeftLocation.X-150 + Main.screenPosition.X), (int)(top + Main.screenPosition.Y), (int)IconBounds.X, (int)IconBounds.Y);

                //White is default but colors could be changed here
                spriteBatch.Draw(categorySlotTexture, currentRectangleArea.TopLeft(), null, Color.White, 0f, Vector2.Zero, UIScale, SpriteEffects.None, 0f);

                //makes the icons in the UI
                float iconScale = UIScale / (button.IconTexture.Size().Length() / IconBounds.Length()) * 1.1f;
                spriteBatch.Draw(button.IconTexture, currentRectangleArea.Center(), null, Color.White, 0f, button.IconTexture.Size() * 0.5f, iconScale, SpriteEffects.None, 0f);

                //make the buttons
                button.DrawDescription(spriteBatch, currentRectangleArea.TopRight() + new Vector2(5f, IconBounds.Y * 0.25f), button.TextColor is null ? TextColor : (Color)button.TextColor, UIScale*0.85f);

                if (button.OnClick != null && CalamityUtils.MouseHitbox.Intersects(currentRectangleAreaWorld))
                {
                    Main.blockMouse = Main.LocalPlayer.mouseInterface = true;
                    // Activate the event if the button is pressed.
                    if ((Main.mouseLeft && Main.mouseLeftRelease) || (Main.mouseRight && Main.mouseRightRelease))
                    {
                        button.OnClick();
                    }
                }
                top += IconBounds.Y;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float top = TopLeftLocation.Y;
            if (GetType() == typeof(GrandUIRenderer))
            {
                Texture2D toggleIcon = ModContent.Request<Texture2D>("CalTestHelpers/UI/GrandUIToggle").Value;
                Rectangle currentRectangleArea = new Rectangle((int)TopLeftLocation.X-150, (int)(top - 50 * ResolutionRatio), (int)(IconBounds.X*1.1f), (int)(IconBounds.Y*1.1f));
                Rectangle currentRectangleAreaWorld = new Rectangle((int)(TopLeftLocation.X + Main.screenPosition.X), (int)(currentRectangleArea.Y + Main.screenPosition.Y), (int)IconBounds.X, (int)IconBounds.Y);
                spriteBatch.Draw(toggleIcon, currentRectangleArea.Center(), null, Color.White, 0f, toggleIcon.Size() * 0.5f, ResolutionRatio * 0.6f, SpriteEffects.None, 0f);

                if (CalamityUtils.MouseHitbox.Intersects(currentRectangleAreaWorld))
                {
                    // Activate the event if the button is pressed.
                    Main.blockMouse = Main.LocalPlayer.mouseInterface = true;
                    if (Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        CalTestHelpers.ShouldDisplayUIs = !CalTestHelpers.ShouldDisplayUIs;
                    }
                }
            }

            if (!CalTestHelpers.ShouldDisplayUIs)
                return;

            DrawElements(spriteBatch, top);
        }
    }
}