using CalamityMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalamityMod.CalPlayer;
using Terraria.GameContent;
using CalamityMod.Balancing;
// using CalamityMod.Testing;

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
                    new SpecialUIElement("Reveal the entire map.", ModContent.Request<Texture2D>("CalTestHelpers/UI/EyeTexture").Value, MapServices.RevealTheEntireMap),
                    new SpecialUIElement("Set your spawn point to your position.", TextureAssets.Item[ItemID.GoldenBed].Value, () =>
                    {
                        Main.spawnTileX = (int)(Main.LocalPlayer.position.X - 8 + Main.LocalPlayer.width / 2) / 16;
                        Main.spawnTileY = (int)(Main.LocalPlayer.position.Y + Main.LocalPlayer.height) / 16;
                        Main.NewText($"Spawn point set. Your new spawn point is: { new Vector2(Main.spawnTileX, Main.spawnTileY) }");
                    }),
                    new SpecialUIElement("Toggle enemy spawns.", ModContent.Request<Texture2D>("CalTestHelpers/UI/EnemyIcon").Value, () =>
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
                        Main.NewText($"Enemies now { (CalTestHelpersWorld.NoSpawns ? "cannot" : "can") } spawn.");
                    }),
                    new SpecialUIElement("Change the time.", ModContent.Request<Texture2D>("CalTestHelpers/UI/SunTexture").Value, () =>
                    {
                        Main.dayTime = !Main.dayTime;
                        Main.time = 0;
                        
                        Main.NewText($"It is now {(Main.dayTime ? "day" : "night")}time.");
                    }),
                    new SpecialUIElement("Stop time.", ModContent.Request<Texture2D>("CalTestHelpers/UI/WatchTexture").Value, () =>
                    {
                        CalTestHelpersWorld.FrozenTime = !CalTestHelpersWorld.FrozenTime;
                        Main.NewText($"Time has {(CalTestHelpersWorld.FrozenTime ? "stopped" : "resumed")}.");
                    }),
                    new SpecialUIElement("Toggle Prehardmode boss deaths.", ModContent.Request<Texture2D>("CalTestHelpers/UI/BladesPHM").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.BossUIRenderPHM : null;
                    }),
                    new SpecialUIElement("Toggle Hardmode boss deaths.", ModContent.Request<Texture2D>("CalTestHelpers/UI/BladesHM").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.BossUIRenderHM : null;
                    }),
                    new SpecialUIElement("Toggle Post-Moon Lord boss deaths.", ModContent.Request<Texture2D>("CalTestHelpers/UI/BladesPML").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.BossUIRenderPML : null;
                    }),
                    new SpecialUIElement("Toggle permanent upgrades.", ModContent.Request<Texture2D>("CalamityMod/Items/PermanentBoosters/BloodOrange").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.UpgradeUIRenderer : null;
                    }),
                    new SpecialUIElement("Change item stats.", ModContent.Request<Texture2D>("CalamityMod/Items/TreasureBags/MiscGrabBags/StarterBag").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.ItemEditerUIRenderer : null;
                    }),
                    new SpecialUIElement("Change projectile stats.", ModContent.Request<Texture2D>("CalamityMod/Items/Ammo/MarksmanRound").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.ProjectileEditerUIRenderer : null;
                    }),
                    /*new SpecialUIElement("Change NPC-specific stat variables.", ModContent.Request<Texture2D>("CalTestHelpers/UI/NPCIcon").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.NPCStatsUIRenderer : null;
                    }),*/
                    new SpecialUIElement("Change the universal stealth strike damage factor.", ModContent.Request<Texture2D>("CalamityMod/Items/Weapons/Rogue/Cinquedea").Value, () =>
                    {
                        CalTestHelpers.SecondaryUIToDisplay = CalTestHelpers.SecondaryUIToDisplay is null ? CalTestHelpers.StealthEditerUIRenderer : null;
                    }),
                    new SpecialUIElement("Reset changed stats.", ModContent.Request<Texture2D>("CalTestHelpers/UI/Gear").Value, () =>
                    {
                        ItemOverrideCache.ResetOverrides();
                        EntityOverrideCache.ResetOverrides();
                        // TestAdjustableFieldDatabase.ResetToDefaultValues();
                        CalTestHelpers.ItemEditerUIRenderer.ItemBeingEdited = null;
                        CalTestHelpers.ProjectileEditerUIRenderer.ProjectileBeingEdited = null;
                        CalTestHelpers.SecondaryUIToDisplay = null;
                        BalancingConstants.UniversalStealthStrikeDamageFactor = 0.5f;
                        CalTestHelpers.HaveAnyStatManipulationsBeenDone = false;
                        Main.NewText($"Stat changes have been reset.");
                    }),
                };

                elements.AddRange(CalTestHelpers.SecondaryUIElements);
                return elements;
            }
        }

        public float ResolutionRatio => Main.screenWidth / 2560f;

        public virtual Vector2 TopLeftLocation => new Vector2(Main.screenWidth - 660, 40);

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
            Texture2D categorySlotTexture = ModContent.Request<Texture2D>("CalTestHelpers/UI/CategorySlot").Value;
            foreach (var button in UIElements)
            {
                Rectangle currentRectangleArea = new Rectangle((int)TopLeftLocation.X, (int)top, (int)IconBounds.X, (int)IconBounds.Y);
                Rectangle currentRectangleAreaWorld = new Rectangle((int)(TopLeftLocation.X + Main.screenPosition.X), (int)(top + Main.screenPosition.Y), (int)IconBounds.X, (int)IconBounds.Y);

                spriteBatch.Draw(categorySlotTexture, currentRectangleArea.TopLeft(), null, Color.White, 0f, Vector2.Zero, UIScale, SpriteEffects.None, 0f);

                float iconScale = UIScale / (button.IconTexture.Size().Length() / IconBounds.Length()) * 1.2f;
                spriteBatch.Draw(button.IconTexture, currentRectangleArea.Center(), null, Color.White, 0f, button.IconTexture.Size() * 0.5f, iconScale, SpriteEffects.None, 0f);
                button.DrawDescription(spriteBatch, currentRectangleArea.TopRight() + new Vector2(4f, IconBounds.Y * 0.25f), button.TextColor is null ? TextColor : (Color)button.TextColor, UIScale);

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
                Rectangle currentRectangleArea = new Rectangle((int)TopLeftLocation.X, (int)(top - 44 * ResolutionRatio), (int)IconBounds.X, (int)IconBounds.Y);
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