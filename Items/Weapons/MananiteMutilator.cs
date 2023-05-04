using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FalseTerrarianTest.Projectile;
using Microsoft.Xna.Framework;

namespace FalseTerrarianTest.Items.Weapons
{
	public class MananiteMutilator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mananite Mutilator"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The Great Communicator\nAttacks bleed life essence out of enemies\nRight-click to tear the fabric of reality and inflict huge damage");
		}
		
		public override void SetDefaults()
		{
			Item.damage = 874;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 7;
			Item.useAnimation = 25;
			Item.knockBack = 6;
			Item.axe = 150;
			Item.tileBoost++;

			Item.width = 20;
			Item.height = 12;
			Item.UseSound = SoundID.Item23;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.channel = true;
			Item.useStyle = ItemUseStyleID.Shoot;

			Item.value = Item.buyPrice(0, 22, 50, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<MananiteMutilatorProj>();
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
