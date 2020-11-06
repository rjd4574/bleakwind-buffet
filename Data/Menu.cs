/*- Menu.cs									Created: 09SEP20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Updated: 06NO20
 *	Static class that Allows retrieval of all items on the menu: Drinks, Entrees, and Sides
 */

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BleakwindBuffet.Data
{
	/// <summary>
	///		Represents a menu, allowing access to the different items available to order
	/// </summary>
	public static class Menu
	{
		public static string[] Types
		{
			get => new string[]
			{
				"Entree",
				"Drink",
				"Side"
			};
		}

		/// <summary>
		/// Creates a list of Entree items that can be ordered
		/// </summary>
		/// <returns>All Entree items in the 'Menu'</returns>
		public static IEnumerable<IOrderItem> Entrees()
		{
			List<IOrderItem> list = new List<IOrderItem>();

			
			list.Add(new BriarheartBurger());
			list.Add(new DoubleDraugr());
			list.Add(new GardenOrcOmelette());
			list.Add(new PhillyPoacher());
			list.Add(new SmokehouseSkeleton());
			list.Add(new ThalmorTriple());
			list.Add(new ThugsTBone());
			return list;
		}

		/// <summary>
		///		Creates a list of Side items that can be ordered
		/// </summary>
		/// <returns>All Side items in the 'Menu'</returns>
		public static IEnumerable<IOrderItem> Sides()
		{
			List<IOrderItem> list = new List<IOrderItem>();

			Side side;
			foreach (Size size in Enum.GetValues(typeof(Size)))
			{
				side = new DragonbornWaffleFries();
				side.Size = size;
				list.Add(side);

				side = new FriedMiraak();
				side.Size = size;
				list.Add(side);

				side = new MadOtarGrits();
				side.Size = size;
				list.Add(side);

				side = new VokunSalad();
				side.Size = size;
				list.Add(side);
			}
			return list;
		}

		/// <summary>
		/// Creates as list of all Drink items that can be ordered
		/// </summary>
		/// <returns>All Drink items in the 'Menu'</returns>
		public static IEnumerable<IOrderItem> Drinks()
		{
			List<IOrderItem> list = new List<IOrderItem>();

			Drink drink;
			foreach (Size size in Enum.GetValues(typeof(Size)))
			{
				drink = new AretinoAppleJuice();
				drink.Size = size;
				list.Add(drink);

				for (int i = 0; i < 2; i++)
				{
					drink = new CandlehearthCoffee();
					drink.Size = size;
					((CandlehearthCoffee)drink).Decaf = (i == 0) ? false : true;
					list.Add(drink);
				}

				drink = new MarkarthMilk();
				drink.Size = size;
				list.Add(drink);

				foreach (SodaFlavor flavor in Enum.GetValues(typeof(SodaFlavor)))
				{

					drink = new SailorSoda();
					drink.Size = size;
					((SailorSoda)drink).Flavor = flavor;
					list.Add(drink);
				}

				drink = new WarriorWater();
				drink.Size = size;
				list.Add(drink);
			}

			return list;
		}

		/// <summary>
		///	creates a list of all items that can be ordered
		///	(Entree, Side, and Drink)
		/// </summary>
		/// <returns>All items in the 'Menu'</returns>
		public static IEnumerable<IOrderItem> FullMenu()
		{
			List<IOrderItem> list = (List<IOrderItem>)Entrees();
			list.AddRange((List<IOrderItem>)Sides());
			list.AddRange((List<IOrderItem>)Drinks());

			return list;
		}

		/// <summary>
		/// Allows a search of all menu types with the given search criterea.
		/// Search is based on whether the ToString of the IOrderItem contains
		/// the search string
		/// </summary>
		/// <param name="type">type of order (entree/drink/side)</param>
		/// <param name="search">search criterea to match</param>
		/// <returns></returns>
		public static IEnumerable<IOrderItem> Search(string type, string search)
		{
			List<IOrderItem> results = new List<IOrderItem>();

			switch(type)
			{
				// Entree
				case "Entree":
					if (search == null) return Entrees();
					foreach (IOrderItem item in Entrees())
						if (item.String.ToLower().Contains(search.ToLower())) results.Add(item);
					return results;
				// Drink
				case "Drink":
					if (search == null) return Drinks();
					foreach (IOrderItem item in Drinks())
						if (item.String.ToLower().Contains(search.ToLower())) results.Add(item);
					return results;
				// Entree
				case "Side":
					if (search == null) return Sides();
					foreach (IOrderItem item in Sides())
						if (item.String.ToLower().Contains(search.ToLower())) results.Add(item);
					return results;

				default: return null;
				throw new NotImplementedException($"Menu type is not recognized: {type}");
			}
		}

		/// <summary>
		/// Allows filtering search results to ensure they fit between a calorie range
		/// </summary>
		/// <param name="orders">list of menu items to be filtered</param>
		/// <param name="min">min amount of calories item must have</param>
		/// <param name="max">max amount of calories item must have</param>
		/// <returns>List of IOrderItems who's calories are within the privided range</returns>
		public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> orders, float? min, float? max)
		{
			if (min == null && max == null) return orders;
			List<IOrderItem> results = new List<IOrderItem>();

			if( min == null )
			{
				foreach (IOrderItem order in orders)
					if (order.Calories <= max) results.Add(order);
				return results;
			}
			if( max == null )
			{
				foreach (IOrderItem order in orders)
					if (order.Calories >= min) results.Add(order);
				return results;
			}
			foreach (IOrderItem order in orders)
				if (order.Calories >= min && order.Calories <= max) results.Add(order);
			return results;
		}

		/// <summary>
		/// Allows filtering search results to ensure they fit between a price range
		/// </summary>
		/// <param name="orders">list of menu items to be filtered</param>
		/// <param name="min">min price item must have</param>
		/// <param name="max">max price item must have</param>
		/// <returns>List of IOrderItems who's price is within the privided range</returns>
		public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> orders, float? min, float? max)
		{
			if (min == null && max == null) return orders;
			List<IOrderItem> results = new List<IOrderItem>();

			if (min == null)
			{
				foreach (IOrderItem order in orders)
					if (order.Price <= max) results.Add(order);
				return results;
			}
			if (max == null)
			{
				foreach (IOrderItem order in orders)
					if (order.Price >= min) results.Add(order);
				return results;
			}
			foreach (IOrderItem order in orders)
				if (order.Price >= min && order.Price <= max) results.Add(order);
			return results;
		}






		/// <summary>
		///		Creates one instance of every Entree
		/// </summary>
		/// <returns> A list of Entree items </returns>
		public static IEnumerable<IOrderItem> EntreeItems()
		{
			List<IOrderItem> list = new List<IOrderItem>();


			list.Add(new BriarheartBurger());
			list.Add(new DoubleDraugr());
			list.Add(new GardenOrcOmelette());
			list.Add(new PhillyPoacher());
			list.Add(new SmokehouseSkeleton());
			list.Add(new ThalmorTriple());
			list.Add(new ThugsTBone());
			return list;
		}

		/// <summary>
		///		Creates one instance of every Drink
		/// </summary>
		/// <returns> A list of Drink items </returns>
		public static IEnumerable<IOrderItem> DrinkItems()
		{
			List<IOrderItem> list = new List<IOrderItem>();
			list.Add(new AretinoAppleJuice());
			list.Add(new CandlehearthCoffee());
			list.Add(new MarkarthMilk());
			list.Add(new SailorSoda());
			list.Add(new WarriorWater());

			return list;
		}

		/// <summary>
		///		Creates one instance of every Side
		/// </summary>
		/// <returns> A list of Side items </returns>
		public static IEnumerable<IOrderItem> SideItems()
		{
			List<IOrderItem> list = new List<IOrderItem>();

			list.Add(new DragonbornWaffleFries());
			list.Add(new FriedMiraak());
			list.Add(new MadOtarGrits());
			list.Add(new VokunSalad());

			return list;
		}


	}
}
