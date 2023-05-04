using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using FalseTerrarianTest.Projectile;
using Microsoft.Xna.Framework;

namespace FalseTerrarianTest.Items.Weapons
{
	public class ChlorophyteHatchet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Hatchet"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Throws three Chlorophyte Hatchets");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
		}
		public override void SetDefaults()
		{
			// General Properties
			Item.width = 38;
			Item.height = 38;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 10, 0, 0);

			// Use Properties
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.noUseGraphic = true;

			// Weapon Properties
			Item.damage = 67;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 3;
			Item.noMelee = true;

			// Ranged Properties
			Item.shoot = ModContent.ProjectileType<ChlorophyteHatchetProj>();
			Item.shootSpeed = 15f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{

			for (int i = 0; i < 3; i++)
			{
				// Rotate velocity by 20 degrees max
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));

				// Change velocity randomly for visuals, higher number
				newVelocity *= 1f + Main.rand.NextFloat(-0.2f, 0.2f);

				// Spawn Projectile
				Terraria.Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false; //Return False so tModloader won't shoot Projectile
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
