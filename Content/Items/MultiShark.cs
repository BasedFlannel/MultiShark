using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultiShark.Content.Items
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class MultiShark : ModItem
	{
		private static int[] bulletIDs = 
		{
			ProjectileID.Bullet,
			ProjectileID.MeteorShot,
			ProjectileID.SilverBullet,
			ProjectileID.CrystalBullet,
			ProjectileID.CursedBullet,
			ProjectileID.ChlorophyteBullet,
			ProjectileID.BulletHighVelocity,
			ProjectileID.IchorBullet,
			ProjectileID.VenomBullet,
			ProjectileID.PartyBullet,
			ProjectileID.NanoBullet,
			ProjectileID.ExplosiveBullet,
			ProjectileID.GoldenBullet
		};
		
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.MultiShark.hjson' file.
		public override void SetDefaults()
		{
			//Visual Properties
			Item.width = 40;
			Item.height = 40;

			//Combat Properties
			Item.damage = 25;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 7;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1;
			Item.autoReuse = true;

			//Other properties
			Item.value = Item.buyPrice(gold: 9);
			Item.rare = ItemRarityID.Pink;
			
			//Creating a custom variant of Item61 sound, used for the PewMatic Horn
			Item.UseSound = new SoundStyle(SoundID.Item61.SoundPath){
				Volume = 0.9f,
				MaxInstances = 1,
				PitchVariance = 0.2f,
				SoundLimitBehavior = SoundLimitBehavior.ReplaceOldest
			};
			//Gun Specific Properties
			Item.noMelee = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
			
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Megashark, 1)
				.AddIngredient(ItemID.PewMaticHorn, 1)
				.AddIngredient(ItemID.ChlorophyteBullet, 720)
				.AddTile(TileID.WorkBenches)
				.Register();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			//This section determines what bullet will be fired			
			if(Main.rand.NextBool(70))
			{
				//1/70 random chance to be a Luminite Bullet so they're not quite as common as the others you have access to by this point
				type = ProjectileID.MoonlordBullet;
			} else {
				//randomly selects a bullet from the list above to fire.
				type = bulletIDs[Main.rand.Next(13)];
			}

		}
	}
}
