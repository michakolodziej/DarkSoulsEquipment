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
            Projectile.penetrate = 10000;
            Projectile.timeLeft = 1000;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            if (Projectile.ai[1] == 0)
            {
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                Projectile.velocity.X = oldVelocity.X * 0.1f;
                Projectile.velocity.Y = oldVelocity.X * 0.1f;
            }
            Projectile.ai[1]++;
            if (Projectile.ai[1] >= 50)
            {
                return true;
            }
            return false;

        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 20; i++) 
            {
                Dust.NewDust(Projectile.Center, 5, 5, DustID.Lead, Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1));
            }
            base.OnKill(timeLeft);
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 20)
            {
                Projectile.velocity.Y += 0.05f;
                Projectile.velocity.X *= 0.995f;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}
