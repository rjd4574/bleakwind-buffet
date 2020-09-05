/*- DrinkValues.cs						Created: 03SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	This consolidates all information about BleakwindBuffet's 
 *	Entrees all in one spot. You can change defaults/price/calories/
 *	or any other property.
 */


using System;


namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	 ///		Allows consolidation of all the Entrees' proprties
	 ///		for future changes.
	 /// </summary>
	public static class EntreeValues
	{
		/// <summary>
		///		This is called in the constructor of a drink.
		///		All of the drink's default settings can be found here
		/// </summary>
		/// <param name="entree">The name of the drink</param>
		/// <param name="food">A reference to the drink</param>
		public static void SetDefaults(string entree, Object food)
		{
			switch (entree)
			{
				case "Briarheart Burger":
					var burger = (BriarheartBurger)food;
					burger.Bun = true;
					burger.Ketchup = true;
					burger.Mustard = true;
					burger.Pickle = true;
					burger.Cheese = true;
					break;
				case "Double Draugr":
					var draugr = (DoubleDraugr)food;
					draugr.Bun = true;
					draugr.Ketchup = true;
					draugr.Mustard = true;
					draugr.Pickle = true;
					draugr.Cheese = true;
					draugr.Tomato = true;
					draugr.Lettuce = true;
					draugr.Mayo = true;
					break;
				case "Thalmor Triple":
					var triple = (ThalmorTriple)food;
					triple.Bun = true;
					triple.Ketchup = true;
					triple.Mustard = true;
					triple.Pickle = true;
					triple.Cheese = true;
					triple.Tomato = true;
					triple.Lettuce = true;
					triple.Mayo = true;
					triple.Bacon = true;
					triple.Egg = true;
					break;
				case "Smokehouse Skeleton":
					var house = (SmokehouseSkeleton)food;
					house.SausageLink = true;
					house.Egg = true;
					house.HashBrowns = true;
					house.Pancake = true;
					break;
				case "Garden Orc Omelette":
					var orc = (GardenOrcOmelette)food;
					orc.Broccoli = true;
					orc.Mushrooms = true;
					orc.Tomato = true;
					orc.Cheddar = true;
					break;
				case "Philly Poacher": 
					var philly = (PhillyPoacher)food;
					philly.Sirloin = true;
					philly.Onion = true;
					philly.Roll = true;
					break;
				case "Thugs T-Bone": return;
				default: throw new NotImplementedException("Entree Not Found");
			}
		}

		/// <summary>
		///		Defines the prices of all drinks
		/// </summary>
		/// <param name="entree">The name of the drink</param>
		/// <param name="size">The size of the drink</param>
		/// <returns>THe price of the drink given its name and size</returns>
		public static double Price(string entree)
		{
			switch (entree)
			{
				case "Briarheart Burger": return 6.32;
				case "Double Draugr": return 7.32;
				case "Thalmor Triple": return 8.32;
				case "Smokehouse Skeleton": return 5.62;
				case "Garden Orc Omelette": return 4.57;
				case "Philly Poacher": return 7.23;
				case "Thugs T-Bone": return 6.44;
				default: throw new NotImplementedException("Entree Not Found");

			}
		}

		/// <summary>
		///		Defines the calories in all of the drinks
		/// </summary>
		/// <param name="entree">The name of the drink</param>
		/// <param name="size">The size of the drink</param>
		/// <returns>The amount of calories in the drink given its 
		/// name and size
		/// </returns>
		public static uint Calories(string entree)
		{
			switch (entree)
			{
				case "Briarheart Burger": return 743;
				case "Double Draugr": return 743;
				case "Thalmor Triple": return 943;
				case "Smokehouse Skeleton": return 602;
				case "Garden Orc Omelette": return 404;
				case "Philly Poacher": return 784;
				case "Thugs T-Bone": return 982;
				default: throw new NotImplementedException("Entree Not Found");
			}
		}
	}
}


/*	This can be used to copy/paste a new set of definitions for Entrees
		switch(entree)
		{
			case "Briarheart Burger": return ;
			case "Double Draugr": return;
			case "Thalmor Triple": return;
			case "Smokehouse Skeleton": return;
			case "Garden Orc Omelette":return;
			case "Philly Poacher": return;
			case "Thugs T-Bone":return;
			default: throw new NotImplementedException("Entree Not Found");
		}
*/