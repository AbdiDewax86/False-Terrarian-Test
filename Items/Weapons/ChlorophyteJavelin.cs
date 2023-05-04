using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using FalseTerrarianTest.Projectile;
using Microsoft.Xna.Framework;

namespace FalseTerrarianTest.Items.Weapons
{
	public class ChlorophyteJavelin : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Javelin"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Throws piercing chlorophyte javelin that bursts into spines on hit");
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
			Item.damage = 58;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 3;
			Item.noMelee = true;

			// Ranged Properties
			Item.shoot = ModContent.ProjectileType<ChlorophyteJavelinProj>();
			Item.shootSpeed = 20f;
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
