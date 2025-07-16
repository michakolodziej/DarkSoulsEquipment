using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSoulsEquipment.Content.Projectiles
{
    internal class BoulderProjectile2 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.damage = 90;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 5;
            Projectile.timeLeft = 1000;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item70.WithVolumeScale(0.5f), Projectile.position);
            for (int i = 0; i < 30; i++)
            {
                Dust.NewDust(Projectile.position, 10, 10, DustID.Dirt, Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-3, 3));
            }
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 14)
            {
                Projectile.velocity.Y += 0.35f;
                Projectile.velocity.X *= 0.965f;
            }
            if (Projectile.ai[0] >= 5)
            {
                Projectile.rotation += 0.08f;
            }

        }
        int bounce = 0;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounce++;
            if (bounce < 3)
            {
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            }

            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(Projectile.position, 10, 10, DustID.Dirt, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
            }

            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }

            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y * 0.4f;
            }

            if (bounce >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
