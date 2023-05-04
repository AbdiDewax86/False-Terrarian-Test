using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FalseTerrarianTest.Projectile
{
	public class TeslaBladeTXProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tesla Blade TX");
		}
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1.25f; //Default scaling for melee stuff
			// Half Projectile Sprite (Spear) Size
			Projectile.width = 64;
			Projectile.height = 64;

			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true;
			Projectile.extraUpdates = 1;
			Projectile.timeLeft = 600;
			Projectile.hide = true;

			Projectile.aiStyle = ProjAIStyleID.Spear;
		}
		public float movementFactor
		{
			get => Projectile.ai[0] - 0.3f;
			set => Projectile.ai[0] = value;
		}
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Vector2 ownerMountedCenter = player.RotatedRelativePoint(player.MountedCenter, true);

			Projectile.direction = player.direction;
			player.heldProj = Projectile.whoAmI;
			player.itemTime = player.itemAnimation;

			// Set Projectile Center
			//Projectile.position.X = (ownerMountedCenter.X - (float)Projectile.width / 2);
			//Projectile.position.Y = (ownerMountedCenter.Y - (float)Projectile.height / 2);

			Projectile.ai[1] += 1f;

			if (!player.frozen)
			{
				if (movementFactor == 0)
				{
					movementFactor = 2.6f;
					Projectile.netUpdate = true;
				}
				if (player.itemAnimation < player.itemAnimationMax / 3)
					movementFactor -= 1.8f; //Retract Spear
				else
					movementFactor += 2.7f; //Thrust Spear
			}
			Projectile.position += Projectile.velocity * movementFactor;
			if (player.itemAnimation == 0)
				Projectile.Kill();
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(-135f);
			if (Projectile.spriteDirection == -1)
				Projectile.rotation -= MathHelper.ToRadians(90f);

			//DebugParticles();
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
