using IL.Terraria.Audio;
using IL.Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace FalseTerrarianTest.Projectile
{
	public class ChlorophyteJavelinProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Javelin");
		}
		public override void SetDefaults()
		{
			// General Properties
			Projectile.width = 18;
			Projectile.height = 18;

			// Projectile Properties
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.penetrate = 5;
			Projectile.tileCollide = true;
			Projectile.ownerHitCheck = true;
			Projectile.aiStyle = 113;
			AIType = ProjectileID.BoneJavelin;

			// Other Properties
		}
		public override void AI()
		{
			if (Main.rand.Next(0, 10) < 2)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
					DustID.ChlorophyteWeapon, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f,
					0, default(Color), 1.0f);
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			SpawnProjectile(4, 360, Projectile.velocity, damage / 3 * 2, knockback / 3 * 2);
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			// Spawn Dust
			for (int i = 0; i < 10; i++)
			{
				Vector2 newVelocity = oldVelocity.RotatedByRandom(MathHelper.ToRadians(90)) * 0.5f;
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
					DustID.ChlorophyteWeapon, newVelocity.X * 0.6f, newVelocity.Y * 0.6f,
					0, default(Color), 1.0f);
			}
			SpawnProjectile(5, 360, oldVelocity, Projectile.damage / 3 * 2, Projectile.knockBack / 3 * 2);
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			return true;
		}
		private void SpawnProjectile(int num, int projectileSpread, Vector2 projectileGeneralDirection, int damage, float knockback)
		{
			Player player = Main.player[Projectile.owner];

			for (int i = 0; i < num; i++)
			{
				// Rotate velocity by 20 degrees max
				Vector2 newVelocity = projectileGeneralDirection.RotatedByRandom(MathHelper.ToRadians(projectileSpread)) * 0.5f;
				Vector2 spineSpawnLocation = Vector2.Normalize(newVelocity);

				// Change velocity randomly for visuals, higher number
				newVelocity *= 1f + Main.rand.NextFloat(-0.2f, 0.2f);

				// Spawn Projectile
				Terraria.Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.position + spineSpawnLocation * 15f, newVelocity, ModContent.ProjectileType<ChlorophyteJavelinSpine>(), damage / 2, knockback, player.whoAmI);
			}
		}
	}
}
