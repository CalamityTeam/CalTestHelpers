using Terraria;

namespace CalTestHelpers
{
	public static partial class ILEdits
	{
		private static void OverrideItemSetDefaultData(Terraria.On_Item.orig_SetDefaults_int_bool_ItemVariant orig, Item self, int Type, bool noMatCheck,Terraria.GameContent.Items.ItemVariant variant)
		{
			orig(self, Type, noMatCheck,variant);

			// This should only happen at load-time.
			if (ItemOverrideCache.DamageOverrides is null)
				return;

			if (ItemOverrideCache.DamageOverrides[Type] > 0)
				self.damage = ItemOverrideCache.DamageOverrides[Type];

			if (ItemOverrideCache.UseTimeOverrides[Type] > 0)
				self.useTime = ItemOverrideCache.UseTimeOverrides[Type];

			if (ItemOverrideCache.UseAnimationOverrides[Type] > 0)
				self.useAnimation = ItemOverrideCache.UseAnimationOverrides[Type];

			if (ItemOverrideCache.ShootSpeedOverrides[Type] > 0f)
				self.shootSpeed = ItemOverrideCache.ShootSpeedOverrides[Type];

			if (ItemOverrideCache.ManaCostOverrides[Type] > 0)
				self.mana = ItemOverrideCache.ManaCostOverrides[Type];
		}

		private static void OverrideProjectileSetDefaultData(Terraria.On_Projectile.orig_SetDefaults orig, Projectile self, int Type)
		{
			orig(self, Type);

			// This should only happen at load-time.
			if (EntityOverrideCache.LocalIFrameOverrides is null)
				return;

			if (EntityOverrideCache.LocalIFrameOverrides[Type] != -2)
				self.localNPCHitCooldown = EntityOverrideCache.LocalIFrameOverrides[Type];

			if (EntityOverrideCache.StaticIFrameOverrides[Type] != -2)
				self.idStaticNPCHitCooldown = EntityOverrideCache.StaticIFrameOverrides[Type];
		}
	}
}