/*- DrinkValues.cs						Created: 03SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	This consolidates all information about BleakwindBuffet's 
 *	drinks all in one spot. You can change defaults/price/calories/
 *	or any other property..
 */


using BleakwindBuffet.Data.Enums;
using System;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		Allows consolidation of all the drinks' proprties
	///		for future changes.
	/// </summary>
	public static class DrinkValues
	{
		/// <summary>
		///		This is called in the constructor of a drink.
		///		All of the drink's default settings can be found here
		/// </summary>
		/// <param name="drink">reference to the drink</param>
		public static void SetDefaults(Drink drink)
		{
			if (drink is SailorSoda)
			{ 
				var soda = (SailorSoda)drink;
				soda.Size = Size.Small;
				soda.Flavor = SodaFlavor.Cherry;
				soda.Ice = true;
				return;
			}
			if (drink is MarkarthMilk)
			{
				var milk = (MarkarthMilk)drink;
				milk.Size = Size.Small;
				milk.Ice = false;
				return;
			}
			if (drink is AretinoAppleJuice)
			{
				var apple = (AretinoAppleJuice)drink;
				apple.Size = Size.Small;
				apple.Ice = false;
				return;
			}
			if (drink is CandlehearthCoffee)
			{
				var coffee = (CandlehearthCoffee)drink;
				coffee.Size = Size.Small;
				coffee.Ice = false;
				coffee.RoomForCream = false;
				coffee.Decaf = false;
				return;
			}
			if (drink is WarriorWater)
			{
				var water = (WarriorWater)drink;
				water.Size = Size.Small;
				water.Ice = true;
				water.Lemon = false;
				return;
			}
			throw new NotImplementedException("Drink Not Found");
		}

		/// <summary>
		///		Defines the prices of all drinks
		/// </summary>
		/// <param name="drink">reference to the drink</param>
		/// <returns> The price of the drink in its current state</returns>
		public static double Price(Drink drink)
		{
			if (drink is SailorSoda)
			{
				switch (drink.Size)
				{
					case Size.Small: return 1.42;
					case Size.Medium: return 1.74;
					case Size.Large: return 2.07;
					default: throw new NotImplementedException("Drink Size not Defined");
				}
			}
			if (drink is MarkarthMilk)
			{
				switch (drink.Size)
				{
					case Size.Small: return 1.05;
					case Size.Medium: return 1.11;
					case Size.Large: return 1.22;
					default: throw new NotImplementedException("Drink Size not Defined");
				}
			}
			if (drink is AretinoAppleJuice)
			{
				switch (drink.Size)
				{
					case Size.Small: return 0.62;
					case Size.Medium: return 0.87;
					case Size.Large: return 1.01;
					default: throw new NotImplementedException("Drink Size not Defined");
				}
			}
			if (drink is CandlehearthCoffee)
			{
				switch (drink.Size)
				{
					case Size.Small: return 0.75;
					case Size.Medium: return 1.25;
					case Size.Large: return 1.75;
					default: throw new NotImplementedException("Drink Size not Defined");
				}
			}
			if( drink is WarriorWater) return 0;

			throw new NotImplementedException("Drink Not Found");

		}

		/// <summary>
		///		Defines the calories in all of the drinks
		/// </summary>
		/// <param name="drink">Reference to the drink</param>
		/// <returns>The amount of calories in the drink given
		/// its current state</returns>
		public static uint Calories(Drink drink)
		{

			if (drink is SailorSoda)
			{
				switch (drink.Size)
				{
					case Size.Small: return 117;
					case Size.Medium: return 153;
					case Size.Large: return 205;
					default: throw new NotImplementedException("Drink Size not Defined");
				}
			}
			if (drink is MarkarthMilk)
			{
				switch (drink.Size)
				{
					case Size.Small: return 56;
					case Size.Medium: return 72;
					case Size.Large: return 93;
					default: throw new NotImplementedException("Drink Size not Defined");
				} 
			}
			if (drink is AretinoAppleJuice)
			{
				switch (drink.Size)
				{
					case Size.Small: return 44;
					case Size.Medium: return 88;
					case Size.Large: return 132;
					default: throw new NotImplementedException("Drink Size not Defined");
				}
			}
			if (drink is CandlehearthCoffee)
			{
				switch (drink.Size)
				{
					case Size.Small: return 7;
					case Size.Medium: return 10;
					case Size.Large: return 20;
					default: throw new NotImplementedException("Drink Size not Defined");
				}
			}
			if (drink is WarriorWater) return 0;

			throw new NotImplementedException("Drink Not Found");
		}
	}
}
