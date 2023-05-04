using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FalseTerrarianTest.Projectile
{
	public class SpitterBowSandProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spitter Bow Sand");
		}
		public override void SetDefaults()
		{
			// General Properties
			Projectile.width = 14;
			Projectile.height = 14;

			// Projectile Properties
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.ownerHitCheck = true;
			Projectile.aiStyle = ProjAIStyleID.Arrow;

			// Other Properties
			Projectile.usesLocalNPCImmunity = true;
		}
		public override void AI()
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 
				DustID.Sand, -Projectile.velocity.X*0.1f, -Projectile.velocity.Y*0.1f, 
				0, default(Color), 1.0f);
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			// Spawn Dust
			for (int i = 0; i < 5; i++)
			{
				Vector2 newVelocity = oldVelocity.RotatedByRandom(MathHelper.ToRadians(90)) * 0.5f;
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
					DustID.Sand, newVelocity.X * 0.6f, newVelocity.Y * 0.6f,
					0, default(Color), 1.0f);
			}
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			return true;
		}
	}
}
