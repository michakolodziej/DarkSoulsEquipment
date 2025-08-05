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
    internal class Greatsword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;
            Item.scale = 3f;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.damage = 100;
            Item.knockBack = 15;
            Item.crit = 5;
            Item.UseSound = SoundID.Item1;

            Item.autoReuse = false;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(gold: 35, silver: 50);
            Item.value = Item.sellPrice(gold: 5, silver: 33, copper: 33);
            

            Item.noUseGraphic = false;
            Item.noMelee = false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 15);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 60;
                Item.useAnimation = 60;
                Item.UseSound = SoundID.Item70;
                Item.shoot = ModContent.ProjectileType<BoulderProjectile2>();
                Item.shootSpeed = 17.5f;
            }
            else
            {
                Item.useTime = 30;
                Item.useAnimation = 30;
                Item.UseSound = SoundID.Item1;
                Item.shoot = ProjectileID.None;
            }

            return base.CanUseItem(player);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frozen, 1500);
            Vector2 explosionCenter = target.Center;
            SoundEngine.PlaySound(SoundID.Item14, explosionCenter);
            for (int i = 0; i < 30; i++)
            {
                Dust.NewDust(explosionCenter, 10, 10, DustID.Lead, Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1));
            }
        }
    }
}
