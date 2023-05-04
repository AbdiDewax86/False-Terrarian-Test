using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FalseTerrarianTest.Projectile;
using Microsoft.Xna.Framework;

namespace FalseTerrarianTest.Items.Weapons
{
	public class MoltenDrill : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Drill"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Can Mine Lihzahrd Bricks");
		}

		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Melee;
			Item.width = 20;
			Item.height = 12;
			Item.useTime = 7;
			Item.useAnimation = 25;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.pick = 210;
			Item.tileBoost++;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 22, 50, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<MoltenDrillProj>();
			Item.shootSpeed = 40f;
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
