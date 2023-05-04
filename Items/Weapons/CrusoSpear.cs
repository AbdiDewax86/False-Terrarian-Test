using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using FalseTerrarianTest.Projectile;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using Steamworks;

namespace FalseTerrarianTest.Items.Weapons
{
	public class CrusoSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crusolium Spear"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("\'The Ancient Light\'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			// General Properties
			Item.width = 42;
			Item.height = 45;
			Item.rare = ItemRarityID.Red;
			Item.value = Item.buyPrice(0, 50, 0, 0);

			// Use Properties
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.DD2_FlameburstTowerShot;
			Item.channel = true;
			Item.noUseGraphic = true;

			// Weapon Properties
			Item.damage = 152;
			Item.DamageType = DamageClass.Melee;
			Item.knockBack = 2;
			Item.noMelee = true;

			// Ranged Properties
			Item.shoot = ModContent.ProjectileType<CrusoSlash>();
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
