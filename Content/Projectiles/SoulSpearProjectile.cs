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
            Projectile.height = 10;
            Projectile.width = 10;
            Projectile.scale = 1.5f;
            Projectile.aiStyle = 0;
            Projectile.damage = 250;
            Projectile.penetrate = 4;
            Projectile.CritChance = 10;
            Projectile.knockBack = 5;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
        }
        public override void AI()
        {
            float homingRange = 300f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(Projectile.Center, 0, 0, DustID.FrostStaff, 0, 0, 0, Color.LightBlue, 2f);
                Main.dust[dust].noGravity = true;
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 15)
            {
                NPC target = null;
                float closestDistSq = homingRange * homingRange;
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc == null || !npc.active) continue;
                    if (npc.friendly || npc.CountsAsACritter || npc.life <= 0 || npc.dontTakeDamage) continue;
                    if (npc.townNPC || npc.type == NPCID.TargetDummy) continue;

                    float distSq = Vector2.DistanceSquared(npc.Center, Projectile.Center);
                    if (distSq < closestDistSq)
                    {
                        closestDistSq = distSq;
                        target = npc;
                    }
                }

                if (target != null)
                {
                    Vector2 desired = target.Center - Projectile.Center;
                    desired.Normalize();
                    Projectile.velocity = Projectile.velocity * 0.95f + desired;

                    if (Projectile.owner == Main.myPlayer)
                    {
                        Projectile.netUpdate = true;
                    }
                }
            }
        }
    }
}