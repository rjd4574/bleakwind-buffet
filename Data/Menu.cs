/*- Menu.cs									Created: 09SEP20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 * 
 *	Static class that Allows retrieval of all items on the menu: Drinks, Entrees, and Sides
 */

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BleakwindBuffet.Data
{
	/// <summary>
	///		Represents a menu, allowing access to the different items available to order
	/// </summary>
	public static class Menu
	{
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
	}
}
