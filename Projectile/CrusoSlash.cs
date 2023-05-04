using System;
using System.IO;
using FalseTerrarianTest.Items.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using IL.Terraria.DataStructures;
using Mono.Cecil;
using rail;

namespace FalseTerrarianTest.Projectile
{
	class CrusoSlash : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 20;
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Arkhalis);
			Projectile.scale = 1.5f;
			Projectile.width = 360;
			Projectile.height = 360;
			Projectile.ownerHitCheck = false;
		}
		/*
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			// Basically just adds buff/debuff
			target.AddBuff(BuffID.Daybreak, 300);
		}
		*/
		public override void AI()
		{
			Player player = Main.player[Projectile.owner]; // Get owner (player)
			Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true); // Get owner position
			player.heldProj = Projectile.whoAmI; // Get projectile

			// Timers
			Projectile.ai[0]++;

			// Functions
			UpdatePlayerVisuals(player, rrp);
			UpdateAim(rrp);

			if (!player.channel)
			{
				Projectile.Kill(); // Kill projectile if player doesn't channel
			}

			Animate(20, 2);
		}
		public override bool PreDraw(ref Color lightColor) // PreDraw for holdout projectiles
		{
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipVertically : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			// Always at full brightness, regardless of the surrounding light.
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
		private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
		{
			Projectile.Center = playerHandPos; // Place the Holdout Projectile directly into the player's hand at all times.
			Projectile.rotation = Projectile.velocity.ToRotation(); // Rotate Projectile to velocity (No more rotate if sprite is facing right, rotate 90 degs if facing up, etc.
			Projectile.spriteDirection = Projectile.direction; // Rotate sprite to direction

			// Change player variables to reflect projectile's holdout
			// Constantly resetting player.itemTime and player.itemAnimation prevents the player from switching items or doing anything else.
			player.ChangeDir(Projectile.direction);
			player.heldProj = Projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;

			// If you do not multiply by Projectile.direction, the player's hand will point the wrong direction while facing left.
			player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
		}
		private void UpdateAim(Vector2 source)
		{
			// Get the player's current aiming direction as a normalized vector.
			Vector2 aim = Vector2.Normalize(Main.MouseWorld - source);
			if (aim.HasNaNs())
			{
				aim = -Vector2.UnitY;
			}
			if (aim != Projectile.velocity)
			{
				Projectile.netUpdate = true;
			}

			//Position projectile by aim * x units away from player. Value obtained from predetermined value in sprite (how far away is the dummy from the center of the sprite)
			Projectile.position = Projectile.position + aim * 195;
			Projectile.rotation = aim.ToRotation();
			Projectile.velocity = aim;
		}
		private void PlaySoundRepeat(int interval) // Repeat sound for every interval
		{
			// Play sound intermittently while using, using the vanilla Projectile variable soundDelay.
			if (Projectile.soundDelay <= 0)
			{
				Projectile.soundDelay = interval;

				// On the very first frame, the sound playing is skipped. This way it doesn't overlap the starting hiss sound.
				if (Projectile.ai[0] > 1f)
				{
					SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, Projectile.position);
				}
			}
		}
		private void PlaySoundOnce() // Play sound once lol
		{
			if (Projectile.ai[0] > 1f)
			{
				SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, Projectile.position);
			}
		}
		private void Animate(int frames, int ticksPerFrame) // Animate Sprite and play sounds
		{
			if (++Projectile.frameCounter >= ticksPerFrame)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= frames)
				{
					Projectile.frame = 0;
				}
				if (Projectile.frame == 3 || Projectile.frame == 11) // Play sounds on select frames
				{
					PlaySoundOnce();
					Particles(Projectile.Center, Projectile.width, Projectile.height, 3, 100);
				}
			}
		}
		private void Particles(Vector2 source, int width, int height, int intensity = 1, int rate = 30) // Basically just spawns dusts
		{
			source.X -= width / 2;
			source.Y -= height / 2;
			if (intensity <= 1)
			{
				intensity = 1;
			}
			if (rate >= 101 || rate < 1)
			{
				rate = 50;
			}
			if(Main.rand.Next(1, 100) <= rate)
			{
				for (int i = 0; i < intensity; ++i)
				{
					Dust.NewDustDirect(source, width, height, 55, Projectile.velocity.X * 10f - Main.rand.NextFloat(-3f, 3f),
						Projectile.velocity.Y * 10f - Main.rand.NextFloat(-3f, 3f), 0, default(Color), 1.5f);
				}
			}
		}
		private void DebugParticles() // Test particle spam for hitbox visualization
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