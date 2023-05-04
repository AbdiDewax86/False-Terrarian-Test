using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FalseTerrarianTest.Projectile
{
	public class TeslaBladeT8Proj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tesla Blade T8");
		}
		public override void SetDefaults()
		{
			Projectile.width = 48;
			Projectile.height = 48;

			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ownerHitCheck = true;
			Projectile.extraUpdates = 1;
			Projectile.timeLeft = 300;

			Projectile.aiStyle = ProjAIStyleID.ShortSword;
		}
		public override void AI()
		{
			base.AI();
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

			/*
			int halfProjWidth = Projectile.width / 2;
			int halfProjHeight = Projectile.height / 2;

			DrawOriginOffsetX = 0;
			DrawOffsetX = (48 / 2) - halfProjWidth;
			DrawOriginOffsetY = (48 / 2) - halfProjHeight;
			*/
		}
	}
}
