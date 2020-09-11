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
		/// <param name="entree">A reference to the drink</param>
		public static void SetDefaults(Entree entree)
		{
			if (entree is BriarheartBurger)
			{
				var burger = (BriarheartBurger)entree;
				burger.Bun = true;
				burger.Ketchup = true;
				burger.Mustard = true;
				burger.Pickle = true;
				burger.Cheese = true;
				return;
			}
			if (entree is DoubleDraugr)
			{
				var draugr = (DoubleDraugr)entree;
				draugr.Bun = true;
				draugr.Ketchup = true;
				draugr.Mustard = true;
				draugr.Pickle = true;
				draugr.Cheese = true;
				draugr.Tomato = true;
				draugr.Lettuce = true;
				draugr.Mayo = true;
				return;
			}
			if (entree is ThalmorTriple)
			{
				var triple = (ThalmorTriple)entree;
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
				return;
			}
			if (entree is SmokehouseSkeleton)
			{
				var house = (SmokehouseSkeleton)entree;
				house.SausageLink = true;
				house.Egg = true;
				house.HashBrowns = true;
				house.Pancake = true;
				return;
			}
			if (entree is GardenOrcOmelette)
			{
				var orc = (GardenOrcOmelette)entree;
				orc.Broccoli = true;
				orc.Mushrooms = true;
				orc.Tomato = true;
				orc.Cheddar = true;
				return;
			}
			if (entree is PhillyPoacher)
			{
				var philly = (PhillyPoacher)entree;
				philly.Sirloin = true;
				philly.Onion = true;
				philly.Roll = true;
				return;
			}
			if(entree is ThugsTBone) return;

			throw new NotImplementedException("Entree Not Found");
		}

		/// <summary>
		///		Defines the prices of all Entrees
		/// </summary>
		/// <param name="entree">Reference to the Entree</param>
		/// <returns>The price of the given entree</returns>
		public static double Price(Entree entree)
		{
			if(entree is BriarheartBurger) return 6.32;
			if (entree is DoubleDraugr) return 7.32;
			if (entree is ThalmorTriple) return 8.32;
			if (entree is SmokehouseSkeleton) return 5.62;
			if (entree is GardenOrcOmelette) return 4.57;
			if (entree is PhillyPoacher) return 7.23;
			if (entree is ThugsTBone) return 6.44;
			
			throw new NotImplementedException("Entree Not Found");
		}

		/// <summary>
		///		Defines the calories in all of the Entrees
		/// </summary>
		/// <param name="entree">Reference to teh entree</param>
		/// <param name="size">The size of the drink</param>
		/// <returns>The amount of calories in the Entree</returns>
		public static uint Calories(Entree entree)
		{
			if (entree is BriarheartBurger) return 743;
			if (entree is DoubleDraugr)return 743;
			if (entree is ThalmorTriple) return 943;
			if (entree is SmokehouseSkeleton) return 602;
			if (entree is GardenOrcOmelette) return 404;
			if (entree is PhillyPoacher) return 784;
			if (entree is ThugsTBone) return 982;

			throw new NotImplementedException("Entree Not Found");
		}
	}
}
