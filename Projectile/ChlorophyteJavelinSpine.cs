using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FalseTerrarianTest.Projectile
{
	public class ChlorophyteJavelinSpine : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Spine");
		}
		public override void SetDefaults()
		{
			// General Properties
			Projectile.width = 22;
			Projectile.height = 22;

			// Projectile Properties
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.ownerHitCheck = true;
			Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
			AIType = ProjectileID.ThrowingKnife;
		}
		public override void AI()
		{
			if (Main.rand.Next(0, 20) < 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
					DustID.ChlorophyteWeapon, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f,
					0, default(Color), 1.0f);
			}
		}
	}
}
