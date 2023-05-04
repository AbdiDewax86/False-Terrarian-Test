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
	public class Prominence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prominence"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("\'The power of the solar winds condensed into a tiny blade\'\nAlternate attack performs a dash to the cursor's direction and deflects any incoming projectiles. 10 seconds cooldown");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			// General Properties
			Item.width = 40;
			Item.height = 48;
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
			Item.shoot = ModContent.ProjectileType<ProminenceSlash>();
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
		public override bool AltFunctionUse(Player player)
		{
			Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);
			Vector2 aim = Vector2.Normalize(Main.MouseWorld - rrp);
			if (aim.HasNaNs())
			{
				aim = -Vector2.UnitY;
			}
			player.velocity = aim * 35f;
			return base.AltFunctionUse(player);
		}
	}
}
