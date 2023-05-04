using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FalseTerrarianTest.Projectile
{
	public class ChlorophyteHatchetProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Hatchet");
		}
		public override void SetDefaults()
		{
			// General Properties
			Projectile.width = 30;
			Projectile.height = 30;

			// Projectile Properties
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.tileCollide = true;
			Projectile.ownerHitCheck = true;
			Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
			AIType = ProjectileID.Shuriken;

			// Other Properties
		}
		public override void AI()
		{
			if (Main.rand.Next(0,10) < 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
					DustID.ChlorophyteWeapon, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f,
					0, default(Color), 1.0f);
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			// Spawn Dust
			for (int i = 0; i < 5; i++)
			{
				Vector2 newVelocity = oldVelocity.RotatedByRandom(MathHelper.ToRadians(90)) * 0.5f;
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
					DustID.ChlorophyteWeapon, newVelocity.X * 0.6f, newVelocity.Y * 0.6f,
					0, default(Color), 1.0f);
			}
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			return true;
		}
	}
}
