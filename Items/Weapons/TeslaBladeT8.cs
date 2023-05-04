using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FalseTerrarianTest.Projectile;

namespace FalseTerrarianTest.Items.Weapons
{
	public class TeslaBladeT8 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tesla Blade T8"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Chains lightning to 2 nearby enemies");
		}
		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 48;

			Item.damage = 21;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 6;

			//Item.shoot = ModContent.ProjectileType<TeslaBladeT8Proj>();
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shootSpeed = 1.5f;
			Item.shoot = ModContent.ProjectileType<TeslaBladeT8Proj>();

			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item15;
			Item.autoReuse = false;
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
