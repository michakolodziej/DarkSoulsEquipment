using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSoulsEquipment.Content.Projectiles
{
    internal class DragonslayerArrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 5;
            Projectile.height = 5;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 10;
            Projectile.timeLeft = 1000;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                Dust.NewDust(Projectile.Center, 5, 5, DustID.Lead, Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1));
                Dust.NewDust(Projectile.Center, 5, 5, DustID.Smoke, Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1), 0, default, 1.5f);
            }
            int explosionRadius = 60;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.Distance(Projectile.Center) < explosionRadius)
                {
                    int direction = (npc.Center.X > Projectile.Center.X) ? 1 : -1;
                    float damage = Projectile.damage * 0.5f;
                    Main.player[Projectile.owner].ApplyDamageToNPC(npc, (int)damage, 6f, direction, false, DamageClass.Ranged, false);
                }
            }
            SoundEngine.PlaySound(SoundID.NPCDeath14.WithPitchOffset(-0.4f).WithVolumeScale(0.7f), Projectile.position);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 50; i++) 
            {
                Dust.NewDust(Projectile.Center, 0, 0, DustID.Blood, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
            }
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 10)
            {
                Projectile.velocity.Y += 0.05f;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}
