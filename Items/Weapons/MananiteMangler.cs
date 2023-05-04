using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using FalseTerrarianTest.Projectile;
using Microsoft.Xna.Framework;

namespace FalseTerrarianTest.Items.Weapons
{
	public class MananiteMangler : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mananite Mangler"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("66% chance to not consume ammo\n\"I don't do regrets\"\nBullets have a chance to reduce enemies' defense, explode, or deal extra damage\nRight click to shoot a burst of empowered bullets");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			// General Properties
			Item.width = 152;
			Item.height = 50;
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.buyPrice(1, 0, 0, 0);

			// Use Properties
			Item.useTime = 3;
			Item.useAnimation = 3;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item40;
			//Item.noUseGraphic = true;
			Item.channel = true;

			// Weapon Properties
			Item.damage = 524;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 2;
			Item.noMelee = true;
			Item.crit = 20;

			// Ranged Properties
			//Item.shoot = ModContent.ProjectileType<MananiteManglerHeldProj>();
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 10f;
			Item.ammo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			// Rotate velocity by 20 degrees max
			Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(2.5f));

			// Spawn Projectile
			Terraria.Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			return false; //Return False so tModloader won't shoot Projectile
		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.66f; // Chance not to consume ammo
		}
		
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.MoonlordBullet;
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
