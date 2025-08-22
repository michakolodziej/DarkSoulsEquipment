using DarkSoulsEquipment.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSoulsEquipment.Content.Projectiles
{
    internal class SoulSpearProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 13;
            Projectile.width = 13;
            DrawOriginOffsetX = 5;
            Projectile.scale = 1.5f;
            Projectile.aiStyle = 0;
            Projectile.damage = 250;
            Projectile.penetrate = 3;
            Projectile.CritChance = 10;
            Projectile.knockBack = 5;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
        }
        public override void AI()
        {
            var source = Projectile.GetSource_FromAI();
            Projectile.rotation = Projectile.velocity.ToRotation();
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDust(Projectile.Center, 0, 0, DustID.FrostStaff, 0, 0, 0, Color.LightBlue, 1f);
            }
        }
    }
}