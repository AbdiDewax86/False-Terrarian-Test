using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FalseTerrarianTest.Projectile
{
	public class MananiteManglerProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mananite Mangler Projectile");
		}
		public override void SetDefaults()
		{
			// General Properties
			Projectile.width = 10;
			Projectile.height = 10;

			// Projectile Properties
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.penetrate = 30;
			Projectile.tileCollide = true;
			Projectile.ownerHitCheck = true;
			Projectile.aiStyle = 1;

			// Other Properties
			Projectile.usesLocalNPCImmunity = true;
			AIType = ProjectileID.MoonlordBullet;
		}
	}
}
