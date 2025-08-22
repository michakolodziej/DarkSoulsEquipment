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

namespace DarkSoulsEquipment.Content.Items.Weapons
{
    internal class SoulSpearScroll : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 79;
            Item.height = 90;
            Item.scale = 0.7f;
            Item.noMelee = true;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Magic;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.mana = 20;

            Item.damage = 200;
            Item.crit = 10;
            Item.knockBack = 5;

            Item.autoReuse = false;
            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.buyPrice(gold: 20, silver: 50);
            Item.value = Item.sellPrice(gold: 4, silver: 33, copper: 33);

            Item.UseSound = SoundID.Item67.WithPitchOffset(0.3f).WithVolumeScale(0.8f);
            Item.shoot = ModContent.ProjectileType<SoulSpearProjectile>();
            Item.shootSpeed = 18f;
        }
    }
}