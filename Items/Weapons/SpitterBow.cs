using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using FalseTerrarianTest.Projectile;
using Microsoft.Xna.Framework;

namespace FalseTerrarianTest.Items.Weapons
{
	public class SpitterBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spitter Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("30% chance to not consume ammo\nWildly shoots short ranged clumps of sand");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			// General Properties
			Item.width = 30;
			Item.height = 52;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 10, 0, 0);

			// Use Properties
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.NPCDeath11;

			// Weapon Properties
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 0;
			Item.noMelee = true;

			// Ranged Properties
			Item.shoot = ModContent.ProjectileType<SpitterBowSandProj>();
			//Item.shoot = ProjectileID.PurificationPowder; // Weird Default for All guns
			Item.shootSpeed = 4f;
			Item.useAmmo = AmmoID.Arrow;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int NumProjectile = Main.rand.Next(1, 4);
			//const int NumProjectile = 2; //Projectile Count

			for (int i = 0; i < NumProjectile; i++)
			{
				// Rotate velocity by 20 degrees max
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

				// Change velocity randomly for visuals, higher number
				newVelocity *= 1f + Main.rand.NextFloat(-0.2f, 0.2f);

				// Spawn Projectile
				Terraria.Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false; //Return False so tModloader won't shoot Projectile
		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.3f; //30% Chance not to consume ammo
		}
		
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<SpitterBowSandProj>();
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
