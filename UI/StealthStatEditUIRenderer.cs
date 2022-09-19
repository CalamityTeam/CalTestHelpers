using CalamityMod.Balancing;
using CalamityMod.CalPlayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalTestHelpers.UI
{
	public class StealthStatEditUIRenderer : GrandUIRenderer
	{
		public override float UIScale => 0.45f * ResolutionRatio;

		public override Vector2 TopLeftLocation => new Vector2(Main.screenWidth - 660 - 270 * ResolutionRatio, 50f);

		public string StealthDamageFactorText => $"Stealth Damage Factor: {Math.Round(BalancingConstants.UniversalStealthStrikeDamageFactor / 0.5f * 100f, 4)}";

		public override void DrawElements(SpriteBatch spriteBatch, float top)
		{
			Texture2D arrowTexture = ModContent.Request<Texture2D>("CalTestHelpers/UI/UpwardBoost").Value;

			// Draw the top arrow.
			Vector2 upwardArrowDrawPosition = TopLeftLocation + new Vector2(-100f, 20f) - arrowTexture.Size() * 0.5f;
			Rectangle upwardArrowArea = Utils.CenteredRectangle(upwardArrowDrawPosition, arrowTexture.Size());
			bool hoveringOverArrow = Utils.CenteredRectangle(Main.MouseScreen, Vector2.One * 2f).Intersects(upwardArrowArea);
			Color arrowColor = Color.White;
			if (hoveringOverArrow)
			{
				Main.blockMouse = true;
				Main.LocalPlayer.mouseInterface = false;
				arrowColor = Color.Yellow;
			}

			if (hoveringOverArrow && Main.mouseLeft && CalTestHelpers.GlobalTickTimer % 4 == 0) 
			{
				BalancingConstants.UniversalStealthStrikeDamageFactor -= 0.01f;
				CalTestHelpers.HaveAnyStatManipulationsBeenDone = true;
			}
			spriteBatch.Draw(arrowTexture, upwardArrowDrawPosition, null, arrowColor, 0f, arrowTexture.Size() * 0.5f, 1f, SpriteEffects.FlipVertically, 0f);

			// Draw the bottom arrow.
			Vector2 downwardArrowDrawPosition = TopLeftLocation + new Vector2(-100f, -20f) - arrowTexture.Size() * 0.5f;
			upwardArrowArea = Utils.CenteredRectangle(downwardArrowDrawPosition, arrowTexture.Size());
			hoveringOverArrow = Utils.CenteredRectangle(Main.MouseScreen, Vector2.One * 2f).Intersects(upwardArrowArea);
			arrowColor = Color.White;
			if (hoveringOverArrow)
			{
				Main.blockMouse = true;
				Main.LocalPlayer.mouseInterface = false;
				arrowColor = Color.Yellow;
			}

			if (hoveringOverArrow && Main.mouseLeft && CalTestHelpers.GlobalTickTimer % 4 == 0)
			{
				BalancingConstants.UniversalStealthStrikeDamageFactor += 0.01f;
				CalTestHelpers.HaveAnyStatManipulationsBeenDone = true;
			}

			spriteBatch.Draw(arrowTexture, downwardArrowDrawPosition, null, arrowColor, 0f, arrowTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);

			// Draw the stealth damage factor in text form.
			Vector2 textDrawPosition = downwardArrowDrawPosition + Vector2.UnitY * 50f;
			textDrawPosition.X -= FontAssets.MouseText.Value.MeasureString(StealthDamageFactorText).X * 0.5f;
			Utils.DrawBorderStringBig(spriteBatch, StealthDamageFactorText, textDrawPosition, Color.Orange, UIScale);

			// Clamp the stealth damage to 2% - 300%.
			BalancingConstants.UniversalStealthStrikeDamageFactor = Utils.Clamp(BalancingConstants.UniversalStealthStrikeDamageFactor, 0.01f, 1.5f);
		}
	}
}