using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using DarkSoulsEquipment.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSoulsEquipment.Content.Items.Weapons
{
    internal class DragonslayerGreatbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.height = 118;
            Item.width = 40;
            Item.scale = 1.75f;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Ranged;
            Item.UseSound = SoundID.Item73;

            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.damage = 250;
            Item.knockBack = 40;
            Item.crit = 25;

            Item.noMelee = true;
            Item.shoot = ProjectileID.BeeArrow;
            Item.shootSpeed = 20f;

            Item.useAmmo = AmmoID.Arrow;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 20f);
        }
    }
}
