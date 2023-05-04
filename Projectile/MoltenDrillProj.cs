using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FalseTerrarianTest.Projectile
{
	public class MoltenDrillProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Drill");
		}
		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = ProjAIStyleID.Drill;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true;
			Projectile.hide = true;
			Projectile.DamageType = DamageClass.Melee;
		}
		public override void AI()
		{
			DebugParticles();
		}
		private void DebugParticles()
		{
			for (int i = 0; i < 10; ++i)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
				6, -Projectile.velocity.X * 0.1f, -Projectile.velocity.Y * 0.1f,
				0, default(Color), 1.0f);
			}
		}
	}
}
