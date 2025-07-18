﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using DarkSoulsEquipment.Content.Projectiles;

namespace DarkSoulsEquipment.Content.Items.Weapons.Ammo
{
    internal class DragonslayerArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }
        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 86;

            Item.damage = 100;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 5;

            Item.maxStack = 999;
            Item.consumable = true;

            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<DragonslayerArrowProjectile>();
        }
    }
}
