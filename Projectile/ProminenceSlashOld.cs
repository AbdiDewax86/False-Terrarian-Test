using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FalseTerrarianTest.Projectile
{
	public class ProminenceSlashOld : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prominence Slashes");
			Main.projFrames[Projectile.type] = 18; // 18 frames of animation
		}
		public override void SetDefaults()
		{
			Projectile.width = 92;
			Projectile.height = 92;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.aiStyle = 75;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Daybreak, 300);
		}
		public override void AI()
		{
			Projectile.velocity *= .98f;
			Animate(18, 2);

			Projectile.direction = (Projectile.spriteDirection = ((Projectile.velocity.X > 0f) ? 1 : -1));
			Projectile.rotation = Projectile.velocity.ToRotation();

			if(Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
			
			if(Projectile.spriteDirection == -1)
			{
				Projectile.rotation += MathHelper.Pi;
			}

			/*
			Player player = Main.player[Projectile.owner]; // Get Player
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float num = MathHelper.PiOver2; // half pi
			*/
		}
		private void Animate(int frames, int ticksPerFrame)
		{
			if (++Projectile.frameCounter >= ticksPerFrame)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= frames)
				{
					Projectile.frame = 0;
				}
			}
		}
	}
}
