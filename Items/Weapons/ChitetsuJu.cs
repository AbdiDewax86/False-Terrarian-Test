using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using FalseTerrarianTest.Projectile;
using Microsoft.Xna.Framework;

namespace FalseTerrarianTest.Items.Weapons
{
	public class ChitetsuJu : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chitetsu-Ju"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("20% chance to not consume ammo\nThe sun sets early\nCursed bullets boil target's blood over time\nRight click to transform into an automatic rifle");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-28, 0);
		}
		public override void SetDefaults()
		{
			// General Properties
			Item.width = 150;
			Item.height = 60;
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.buyPrice(1, 0, 0, 0);

			// Use Properties
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.NPCDeath56;

			// Weapon Properties
			Item.damage = 4444;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 2;
			Item.noMelee = true;
			Item.crit = 35;

			// Ranged Properties
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Bullet;
		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.2f; // Chance not to consume ammo
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
