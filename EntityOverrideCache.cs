using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace CalTestHelpers
{
	public class EntityOverrideCache
	{
		internal static List<Projectile> LoadedProjectiles = new();
		//internal static List<NPC> LoadedNPCs = new();
		internal static List<string> ProjectileNames = new();
		//internal static List<string> NPCNames = new();

		public static int[] StaticIFrameOverrides;
		public static int[] LocalIFrameOverrides;

		internal static void Load()
		{
			LoadedProjectiles = new List<Projectile>();
			ProjectileNames = new List<string>();
			//NPCNames = new List<string>();

			StaticIFrameOverrides = new int[ProjectileLoader.ProjectileCount];
			LocalIFrameOverrides = new int[ProjectileLoader.ProjectileCount];

			for (int i = 0; i < ProjectileLoader.ProjectileCount; i++)
			{
				Projectile projectile = new();
				projectile.SetDefaults(i);

				LoadedProjectiles.Add(projectile);

				string projectileName = projectile.Name.ToLower();
				projectileName = string.Concat(projectileName.Where(c => !char.IsWhiteSpace(c)));

				ProjectileNames.Add(projectileName);

				StaticIFrameOverrides[i] = LocalIFrameOverrides[i] = -2;
			}

			/*for (int i = 0; i < NPCLoader.NPCCount; i++)
            {
				NPC npc = new();
				npc.SetDefaults(i);

				LoadedNPCs.Add(npc);

				string npcName = npc.TypeName.ToLower();
				npcName = string.Concat(npcName.Where(c => !char.IsWhiteSpace(c)));

				NPCNames.Add(npcName);
			}*/
		}

		internal static void Unload()
		{
			LoadedProjectiles = null;
			ProjectileNames = null;
			StaticIFrameOverrides = null;
			LocalIFrameOverrides = null;
		}

		public static void ResetOverrides()
		{
			for (int i = 0; i < StaticIFrameOverrides.Length; i++)
				StaticIFrameOverrides[i] = LocalIFrameOverrides[i] = -2;
		}

		public static IEnumerable<int> AttemptToLocateProjectilesWithSimilarName(string name)
		{
			if (string.IsNullOrEmpty(name))
				yield break;

			name = name.ToLower();

			// Remove whitespace from the name.
			name = string.Concat(name.Where(c => !char.IsWhiteSpace(c)));

			IEnumerable<string> similarProjectileNames = ProjectileNames.Where(n => n.Contains(name)).Take(80);
			foreach (string itemName in similarProjectileNames)
				yield return ProjectileNames.IndexOf(itemName);
		}

		/*public static IEnumerable<int> AttemptToLocateNPCsWithSimilarName(string name)
		{
			if (string.IsNullOrEmpty(name))
				yield break;

			name = name.ToLower();

			// Remove whitespace from the name.
			name = string.Concat(name.Where(c => !char.IsWhiteSpace(c)));

			IEnumerable<string> similarProjectileNames = NPCNames.Where(n => n.Contains(name)).Take(20);
			foreach (string itemName in similarProjectileNames)
				yield return NPCNames.IndexOf(itemName);
		}*/
	}
}