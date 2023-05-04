using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FalseTerrarianTest.Projectile;

namespace FalseTerrarianTest.Items.Weapons
{
	public class TeslaBladeTX : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tesla Blade TX"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A more technical reimagination of the legendary spear Gungnir\nChains lightning to 5 nearby enemies");
		}
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Spear);
			Item.width = 100;
			Item.height = 100;

			Item.damage = 86;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 18;
			Item.useAnimation = 14;
			Item.knockBack = 6;
			Item.shoot = ModContent.ProjectileType<TeslaBladeTXProj>();

			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item15;
			Item.autoReuse = true;

			/*
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shootSpeed = 2.4f;
			*/
		}
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[ModContent.ProjectileType<TeslaBladeTXProj>()] < 1;
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
