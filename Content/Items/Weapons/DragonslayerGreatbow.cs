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
using DarkSoulsEquipment.Content.Items.Weapons.Ammo;

namespace DarkSoulsEquipment.Content.Items.Weapons
{
    internal class DragonslayerGreatbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.height = 118;
            Item.width = 40;
            Item.scale = 1.25f;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Ranged;
            Item.UseSound = SoundID.Item73;
            Item.rare = ItemRarityID.Purple;

            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.damage = 200;
            Item.knockBack = 40;
            Item.crit = 15;
            Item.value = Item.buyPrice(gold: 30, silver: 50);
            Item.value = Item.sellPrice(gold: 4, silver: 40, copper: 20);

            Item.noMelee = true;
            Item.shootSpeed = 20f;

            Item.shoot = ModContent.ProjectileType<DragonslayerArrowProjectile>();
            Item.useAmmo = ModContent.ItemType<Ammo.DragonslayerArrow>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8f, 15f);
        }
    }
}
