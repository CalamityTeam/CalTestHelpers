/*using CalamityMod;
// using CalamityMod.Testing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.States;
using Terraria.GameInput;
using Terraria.ModLoader.UI;
using Terraria.UI;

namespace CalTestHelpers.UI
{
    public class NPCStatManipulatorUIRenderer : GrandUIRenderer
    {
        public NPC NPCBeingEdited = null;
        public string NPCText = string.Empty;
        public bool EditingNPCText = false;

        public static readonly Regex PascalCaseSpacer = new("([a-z,0-9](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", RegexOptions.Compiled);

        public override float UIScale => 0.65f * ResolutionRatio;

        public override Vector2 TopLeftLocation => new(Main.screenWidth - 660 - 270 * ResolutionRatio, 5);

        public override void DrawElements(SpriteBatch spriteBatch, float top)
        {
            Texture2D backgroundTexture = TextureAssets.ChatBack.Value;
            Texture2D textBackgroundTexture = TextureAssets.ClothesStyleBack.Value;
            Vector2 baseDrawPosition = TopLeftLocation + Vector2.UnitY * (backgroundTexture.Width + 150f) * ResolutionRatio;
            Vector2 textDrawPosition = baseDrawPosition + new Vector2(175f, 12f) * ResolutionRatio * 0.75f;
            Vector2 backgroundDrawPosition = baseDrawPosition + Vector2.UnitX * backgroundTexture.Width * ResolutionRatio * 0.75f;

            Vector2 npcDrawPosition = baseDrawPosition;
            npcDrawPosition += Vector2.UnitX * backgroundTexture.Width * ResolutionRatio * 0.275f;
            npcDrawPosition += Vector2.UnitY * 72f * ResolutionRatio;

            float backgroundScale = ResolutionRatio;
            Vector2 textBackgroundScale = new(backgroundScale * backgroundTexture.Width / textBackgroundTexture.Width);
            textBackgroundScale.Y *= 0.5f;

            Vector2 backgroundOrigin = Vector2.UnitX * backgroundTexture.Size() * 0.5f;
            Vector2 textBackgroundOrigin = Vector2.UnitX * textBackgroundTexture.Size() * 0.5f;

            // Draw the backgrounds.
            spriteBatch.Draw(backgroundTexture, backgroundDrawPosition, null, Color.White, 0f, backgroundOrigin, backgroundScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(textBackgroundTexture, backgroundDrawPosition, null, Color.Cyan, 0f, textBackgroundOrigin, textBackgroundScale, SpriteEffects.None, 0f);

            bool pressingMouseLeft = Main.mouseLeft && Main.mouseLeftRelease;

            Vector2 textBackgroundCenter = backgroundDrawPosition + Main.screenPosition;
            textBackgroundCenter.Y += ResolutionRatio * 24f;

            Rectangle textBackgroundArea = Utils.CenteredRectangle(textBackgroundCenter, textBackgroundTexture.Size() * textBackgroundScale);
            bool mouseOverBackground = CalamityUtils.MouseHitbox.Intersects(textBackgroundArea);

            // Edit text if clicking in the bounds of the background.
            if (mouseOverBackground && pressingMouseLeft)
                EditingNPCText = true;

            // Otherwise stop editing text if clicking outside of the background.
            else if (!mouseOverBackground && pressingMouseLeft)
                EditingNPCText = false;

            if (NPCBeingEdited != null)
                DrawNPCStatManipulatorUI(spriteBatch);

            if (EditingNPCText)
                EditText(ref NPCText);

            // As well as the text.
            Utils.DrawBorderStringBig(spriteBatch, NPCText, textDrawPosition, Color.White, UIScale);

            IEnumerable<int> npcTypes = EntityOverrideCache.AttemptToLocateNPCsWithSimilarName(NPCText);

            int npcCounter = 0;
            int moveToNextLineRate = (int)((textBackgroundTexture.Width * ResolutionRatio - 18) / 36);
            bool hoveringOverIcon = false;
            foreach (int npcType in npcTypes)
            {
                List<AdjustableField> adjustableEntries = TestAdjustableFieldDatabase.AdjustableFieldsForNPC(npcType);
                if (adjustableEntries.Count <= 0)
                    continue;

                Vector2 instancedNPCDrawPosition = npcDrawPosition;

                // Ensure that the npc positions never leave the box.
                instancedNPCDrawPosition += Vector2.One * ResolutionRatio * 25f;
                instancedNPCDrawPosition.X += npcCounter % moveToNextLineRate * 36f;
                instancedNPCDrawPosition.Y += npcCounter / moveToNextLineRate * 36f;

                NPC npcToDraw = new();
                npcToDraw.CloneDefaults(npcType);

                Rectangle icon = Utils.CenteredRectangle(instancedNPCDrawPosition + Main.screenPosition, Vector2.One * 32f);

                if (CalamityUtils.MouseHitbox.Intersects(icon))
                {
                    Main.LocalPlayer.mouseInterface = Main.blockMouse = true;
                    Main.instance.MouseText(Lang.GetNPCName(npcType).Value);
                    hoveringOverIcon = true;

                    if (Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        if (NPCBeingEdited is null)
                        {
                            NPCBeingEdited = new NPC();
                            NPCBeingEdited.SetDefaults(npcType);
                        }
                        else
                            NPCBeingEdited = null;
                        EditingNPCText = true;
                    }
                }

                // Draw the npc.
                Main.instance.LoadNPC(npcType);
                Texture2D npcTexture = TextureAssets.Npc[npcType].Value;
                int totalFrames = Main.npcFrameCount[npcType];

                // This assumption of only 1 horizontal frame could be wrong, but there's no easily accessable
                // way of determining if there is a horizontal frame or not.
                Rectangle npcFrame = npcTexture.Frame(1, totalFrames, 0, (int)(Main.GlobalTimeWrappedHourly * 6.6f % totalFrames));
                Vector2 scale = Vector2.Min(new Vector2(36f) / MathHelper.Max(npcFrame.Height, npcFrame.Width), new Vector2(1f));
                spriteBatch.Draw(npcTexture, instancedNPCDrawPosition, npcFrame, Color.White, 0f, npcFrame.Size() * 0.5f, scale, SpriteEffects.None, 0f);

                npcCounter++;
            }

            // Draw the npc details when hovering over the icon box.
            if (hoveringOverIcon)
                Main.instance.MouseTextHackZoom(string.Empty);
        }

        public void DrawNPCStatManipulatorUI(SpriteBatch spriteBatch)
        {
            int totalIcons = 0;
            bool readyToDoInputUpdate = CalTestHelpers.GlobalTickTimer % 4 == 0;
            Texture2D elementBackgroundTexture = TextureAssets.ClothesStyleBack.Value;
            Vector2 elementBackgroundScale = new Vector2(1f, 0.45f) * ResolutionRatio;
            Vector2 statManipulatorOrigin = Vector2.UnitX * elementBackgroundTexture.Size() * 0.5f;
            Vector2 statManipulatorPosition = TopLeftLocation - Vector2.UnitX * (elementBackgroundTexture.Width * 0.5f - 120f) * ResolutionRatio;
            List<AdjustableField> adjustableEntries = TestAdjustableFieldDatabase.AdjustableFieldsForNPC(NPCBeingEdited.type);

            foreach (AdjustableField entry in adjustableEntries)
            {
                drawCustomManipulatorIcon($" {NPCBeingEdited.TypeName}: {entry.RegularName} - {entry.Instance}", () =>
                {
                    if (Main.mouseLeft)
                    {
                        object newEntryState = entry.Instance;
                        bool shift = Main.keyState.PressingShift();

                        // Flip bools.
                        if (newEntryState is bool b)
                            newEntryState = !b;

                        // Increment and numbers.
                        if (newEntryState is int i)
                        {
                            newEntryState = i - shift.ToDirectionInt();
                            if (entry.RangeMin is not null && (int)newEntryState < (int)entry.RangeMin)
                                newEntryState = (int)entry.RangeMin;
                            if (entry.RangeMax is not null && (int)newEntryState > (int)entry.RangeMax)
                                newEntryState = (int)entry.RangeMax;
                        }
                        if (newEntryState is float f)
                        {
                            float increment = 0.02f;
                            if (entry.RangeMin is not null && entry.RangeMax is not null)
                                increment = ((float)entry.RangeMax - (float)entry.RangeMin) * 0.008f;
                            newEntryState = (float)Math.Round(f - shift.ToDirectionInt() * increment, 2);

                            if (entry.RangeMin is not null && (float)newEntryState < (float)entry.RangeMin)
                                newEntryState = (float)entry.RangeMin;
                            if (entry.RangeMax is not null && (float)newEntryState > (float)entry.RangeMax)
                                newEntryState = (float)entry.RangeMax;
                        }
                        CalTestHelpers.HaveAnyStatManipulationsBeenDone = true;
                        entry.Instance = newEntryState;
                    }
                });
            }

            // Bleh.
            void drawCustomManipulatorIcon(string text, Action hoverOverEffects)
            {
                Vector2 baseIconDrawPosition = statManipulatorPosition;
                baseIconDrawPosition += Vector2.UnitY * elementBackgroundTexture.Height * elementBackgroundScale.Y * totalIcons;

                Vector2 topLeft = baseIconDrawPosition;
                topLeft += elementBackgroundTexture.Size() * elementBackgroundScale * new Vector2(0f, 0.5f);
                topLeft += Main.screenPosition;

                Vector2 textDrawPosition = baseIconDrawPosition;
                textDrawPosition -= elementBackgroundTexture.Size() * elementBackgroundScale * new Vector2(0.5f, -0.15f);

                Color drawColor = Color.White;
                if (CalamityUtils.MouseHitbox.Intersects(Utils.CenteredRectangle(topLeft, elementBackgroundTexture.Size() * elementBackgroundScale)))
                {
                    drawColor = Color.BlueViolet;
                    if (readyToDoInputUpdate)
                        hoverOverEffects();
                }

                spriteBatch.Draw(elementBackgroundTexture, baseIconDrawPosition, null, drawColor, 0f, statManipulatorOrigin, elementBackgroundScale, SpriteEffects.None, 0f);

                string[] lines = Utils.WordwrapString(text, FontAssets.MouseText.Value, (int)(elementBackgroundTexture.Width * elementBackgroundScale.X * 1.6f), 8, out _);
                float textScale = UIScale * 0.56f;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (line is null)
                        break;

                    if (i == 1)
                        textDrawPosition.X += UIScale * 10f;

                    Utils.DrawBorderStringBig(spriteBatch, line, textDrawPosition, Color.White, textScale);
                    textDrawPosition.Y += textScale * 40f;
                }
                totalIcons++;
            }
        }

        public void EditText(ref string text)
        {
            if (!EditingNPCText)
                return;

            if (!IngameFancyUI.CanShowVirtualKeyboard(1) || UIVirtualKeyboard.KeyboardContext != 1)
            {
                Main.editSign = true;
                PlayerInput.WritingText = true;
                Main.instance.HandleIME();
                text = Main.GetInputText(text);
                if (Main.inputTextEnter)
                {
                    text += Encoding.ASCII.GetString(new byte[] { 10 });
                    EditingNPCText = false;
                }
                if (Main.inputTextEscape)
                    EditingNPCText = false;
            }
        }
    }
}*/