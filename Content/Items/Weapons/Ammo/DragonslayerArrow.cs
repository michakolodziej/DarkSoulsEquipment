using System;
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
            Item.rare = ItemRarityID.LightPurple;

            Item.damage = 50;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 5;

            Item.maxStack = 999;
            Item.consumable = true;

            Item.ammo = Item.type;
            Item.shoot = ModContent.ProjectileType<DragonslayerArrowProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(333);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
