using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultiShark.Content.Items
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class MultiShark : ModItem
	{
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
			Item.UseSound = SoundID.Item61;

			//Gun Specific Properties
			Item.noMelee = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
			
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Megashark, 1);
			recipe.AddIngredient(ItemID.PewMaticHorn, 1);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 720);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
