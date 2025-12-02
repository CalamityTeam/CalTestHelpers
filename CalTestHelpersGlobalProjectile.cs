using CalamityMod;
using CalamityMod.Dusts;
using CalamityMod.NPCs.SupremeCalamitas;
using CalamityMod.Particles;
using CalamityMod.Projectiles.Boss;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalTestHelpers
{
    public class CalTestHelpersGlobalProjectile : GlobalProjectile
    {
        //public SCalRitualDrama ritual;
        public override void AI(Projectile projectile)
        {
            if (projectile.type == ModContent.ProjectileType<SCalRitualDrama>() && !NPC.AnyNPCs(ModContent.NPCType<SupremeCalamitas>()) && CalTestHelperConfig.Instance.InstantBossSummoning)
            {
                //ritual.SummonSCal(); //This wont work outside of the file due to not being static

                //If only functions worked like Python ones, gotta copy the code then
                //Permision granted by Xyk

                Vector2 spawnPosition = projectile.Center - new Vector2(53f, 39f);
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC scal = CalamityUtils.SpawnBossBetter(spawnPosition, ModContent.NPCType<SupremeCalamitas>());
                    if (projectile.ai[1] == 1)
                    {
                        scal.ModNPC<SupremeCalamitas>().permafrost = true;
                    }
                }

                // Make a laugh sound and create a burst of brimstone dust.
                SoundStyle SpawnSound = projectile.ai[1] == 1 ? SoundID.Item107 : SupremeCalamitas.SpawnSound;
                SoundEngine.PlaySound(SpawnSound, projectile.Center);

                // Make a sudden screen shake.
                Main.LocalPlayer.Calamity().GeneralScreenShakePower = Utils.GetLerpValue(3400f, 1560f, Main.LocalPlayer.Distance(projectile.Center), true) * 16f;

                // Generate a dust explosion at the ritual's position.
                for (int i = 0; i < 90; i++)
                {
                    Dust spawnDust = Dust.NewDustPerfect(projectile.Center, projectile.ai[1] == 1 ? (int)CalamityDusts.PurpleCosmilite : (int)CalamityDusts.Brimstone, new Vector2(30, 30).RotatedByRandom(100) * Main.rand.NextFloat(0.05f, 1.2f));
                    spawnDust.noGravity = true;
                    spawnDust.scale = Main.rand.NextFloat(1.2f, 2.3f);
                }
                for (int i = 0; i < 40; i++)
                {
                    Vector2 sparkVel = new Vector2(20, 20).RotatedByRandom(100) * Main.rand.NextFloat(0.1f, 1.1f);
                    GlowOrbParticle orb = new GlowOrbParticle(projectile.Center + sparkVel * 2, sparkVel, false, 120, Main.rand.NextFloat(1.55f, 2.75f), projectile.ai[1] == 1 ? Color.Magenta : Color.Red, true, true);
                    GeneralParticleHandler.SpawnParticle(orb);
                }
                Particle pulse = new DirectionalPulseRing(projectile.Center, Vector2.Zero, projectile.ai[1] == 1 ? Color.Magenta : Color.Red, new Vector2(2f, 2f), 0, 0f, 2.7f, 60);
                GeneralParticleHandler.SpawnParticle(pulse);
                Particle pulse2 = new DirectionalPulseRing(projectile.Center, Vector2.Zero, projectile.ai[1] == 1 ? Color.Magenta : new Color(121, 21, 77), new Vector2(2f, 2f), 0, 0f, 2.1f, 60);
                GeneralParticleHandler.SpawnParticle(pulse2);

                projectile.Kill();
            }
        }
    }
}
