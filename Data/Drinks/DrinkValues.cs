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
		/// <param name="drink">The name of the drink</param>
		/// <param name="d">A reference to the drink</param>
		public static void SetDefaults(string drink, Object d)
		{
			switch(drink)
			{
				case "Sailor Soda":
					var soda = (SailorSoda)d;
					soda.Size = Size.Small;
					soda.Flavor = SodaFlavor.Cherry;
					soda.Ice = true;
					break;
				case "Markarth Milk":
					var milk = (MarkarthMilk)d;
					milk.Size = Size.Small;
					milk.Ice = false;
					break;
				case "Aretino Apple Juice":
					var apple = (AretinoAppleJuice)d;
					apple.Size = Size.Small;
					apple.Ice = false;
					break;
				case "Candlehearth Coffee":
					var coffee = (CandlehearthCoffee)d;
					coffee.Size = Size.Small;
					coffee.Ice = false;
					coffee.RoomForCream = false;
					break;
				case "Warrior Water":
					var water = (WarriorWater)d;
					water.Size = Size.Small;
					water.Ice = true;
					water.Lemon = false;
					break;
				default: throw new NotImplementedException("Drink Not Found");
			}
		}

		/// <summary>
		///		Defines the prices of all drinks
		/// </summary>
		/// <param name="drink">The name of the drink</param>
		/// <param name="size">The size of the drink</param>
		/// <returns>THe price of the drink given its name and size</returns>
		public static double Price(string drink, Size size)
		{
			switch(drink)
			{
				case "Sailor Soda":
					switch(size)
					{
						case Size.Small: return 1.42;
						case Size.Medium: return 1.74;
						case Size.Large: return 2.07;
						default: throw new NotImplementedException("Drink Size not Defined");
					}
				case "Markarth Milk":
					switch (size)
					{
						case Size.Small: return 1.05;
						case Size.Medium: return 1.11;
						case Size.Large: return 1.22;
						default: throw new NotImplementedException("Drink Size not Defined");
					}
				case "Aretino Apple Juice":
					switch (size)
					{
						case Size.Small: return 0.62;
						case Size.Medium: return 0.87;
						case Size.Large: return 1.01;
						default: throw new NotImplementedException("Drink Size not Defined");
					}

				case "Candlehearth Coffee":
					switch (size)
					{
						case Size.Small: return 0.75;
						case Size.Medium: return 1.25;
						case Size.Large: return 1.75;
						default: throw new NotImplementedException("Drink Size not Defined");
					}
				case "Warrior Water": return 0;
				default: throw new NotImplementedException("Drink Not Found");

			}
		}

		/// <summary>
		///		Defines the calories in all of the drinks
		/// </summary>
		/// <param name="drink">The name of the drink</param>
		/// <param name="size">The size of the drink</param>
		/// <returns>The amount of calories in the drink given its 
		/// name and size
		/// </returns>
		public static uint Calories(string drink, Size size)
		{
			switch (drink)
			{
				case "Sailor Soda":
					switch (size)
					{
						case Size.Small: return 117;
						case Size.Medium: return 153;
						case Size.Large: return 205;
						default: throw new NotImplementedException("Drink Size not Defined");
					}
				case "Markarth Milk":
					switch (size)
					{
						case Size.Small: return 56;
						case Size.Medium: return 72;
						case Size.Large: return 93;
						default: throw new NotImplementedException("Drink Size not Defined");
					}
				case "Aretino Apple Juice":
					switch (size)
					{
						case Size.Small: return 44;
						case Size.Medium: return 88;
						case Size.Large: return 132;
						default: throw new NotImplementedException("Drink Size not Defined");
					}

				case "Candlehearth Coffee":
					switch (size)
					{
						case Size.Small: return 7;
						case Size.Medium: return 10;
						case Size.Large: return 20;
						default: throw new NotImplementedException("Drink Size not Defined");
					}
				case "Warrior Water": return 0;
				default: throw new NotImplementedException("Drink Not Found");
			}
		}
	}
}

/*	This can be used to copy/paste a new set of definitions for drinks
		switch(drink)
		{
			case "Sailor Soda": return ;
			case "Markarth Milk": return;
			case "Aretino Apple Juice": return;
			case "Candlehearth Coffee": return;
			case "Warrior Water":return;
			default: throw new NotImplementedException("Drink Not Found");
		}
*/
