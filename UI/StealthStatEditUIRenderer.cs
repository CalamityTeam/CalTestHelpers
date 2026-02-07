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
		public const double OriginalStealthFactor = 0.42; //Taken from Cal Code, should be changed to match the stealth factor
		public override float UIScale => 0.5f * ResolutionRatio;

		public override Vector2 TopLeftLocation => new Vector2(Main.screenWidth - 660 - 175 * ResolutionRatio, 50f);

		public string StealthDamageFactorText => $"Stealth Damage Factor: x{Math.Round(BalancingConstants.UniversalStealthStrikeDamageFactor, 4)}";

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

			if (hoveringOverArrow && Main.mouseLeft && CalTestHelpers.GlobalTickTimer % 8 == 0) 
			{
				BalancingConstants.UniversalStealthStrikeDamageFactor -= 0.005f;
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
				BalancingConstants.UniversalStealthStrikeDamageFactor += 0.005f;
				CalTestHelpers.HaveAnyStatManipulationsBeenDone = true;
			}

			spriteBatch.Draw(arrowTexture, downwardArrowDrawPosition, null, arrowColor, 0f, arrowTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);

			// Draw the stealth damage factor in text form.
			Vector2 textDrawPosition = downwardArrowDrawPosition + Vector2.UnitY * 50f;
			textDrawPosition.X -= FontAssets.MouseText.Value.MeasureString(StealthDamageFactorText).X * 0.5f;
			Utils.DrawBorderStringBig(spriteBatch, StealthDamageFactorText, textDrawPosition, Color.Orange, UIScale);

			// Clamp the stealth damage to 1% - 500%. or x0.01 - x5
			BalancingConstants.UniversalStealthStrikeDamageFactor = Utils.Clamp(BalancingConstants.UniversalStealthStrikeDamageFactor, 0.005f, 2.5f);
		}

		public static void ResetStealth()
		{
			BalancingConstants.UniversalStealthStrikeDamageFactor = OriginalStealthFactor;
		}
	}
}