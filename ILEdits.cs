namespace CalTestHelpers
{
	public static partial class ILEdits
	{
		public static void Load()
		{
            Terraria.On_Item.SetDefaults_int_bool_ItemVariant += OverrideItemSetDefaultData;
			Terraria.On_Projectile.SetDefaults += OverrideProjectileSetDefaultData;
		}

        public static void Unload()
		{
			Terraria.On_Item.SetDefaults_int_bool_ItemVariant -= OverrideItemSetDefaultData;
			Terraria.On_Projectile.SetDefaults -= OverrideProjectileSetDefaultData;
		}
	}
}