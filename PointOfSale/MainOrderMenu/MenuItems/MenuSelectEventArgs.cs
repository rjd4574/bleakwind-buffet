/*- MenuSelectEventArgs.cs					Created: 01OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Defines an event that occurs involving an IOrderItem relating to its
 *	Corresponding OrderMenu. The IOrderItem is passed as part of the constructor
 *	and its customization menu can be retrieved on request
 */

using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data;
using System.Windows.Input;
using System.Windows;

namespace PointOfSale
{
	/// <summary>
	///		Describes an event args involving a menu select
	/// </summary>
	public class MenuSelectEventArgs : EventArgs
	{
		/// <summary>
		///  Creates a menu customization screen based on the passed IOrderItem
		/// </summary>
		public CustomizationMenu GetMenu { get; private set; }

		/// <summary>
		///		Constructor, creates teh new event and creates the appropriate customization menu.
		/// </summary>
		/// <param name="order"></param>
		public MenuSelectEventArgs(IOrderItem order)
		{
			if (order is Entree)
			{
				if (order is BriarheartBurger) GetMenu = new BriarheartBurgerMenu(order);
				else if (order is DoubleDraugr) GetMenu = new DoubleDraugrMenu(order);
				else if (order is GardenOrcOmelette) GetMenu = new GardenOrcOmeletteMenu(order);
				else if (order is PhillyPoacher) GetMenu = new PhillyPoacherMenu(order);
				else if (order is SmokehouseSkeleton) GetMenu = new SmokehouseSkeletonMenu(order);
				else if (order is ThalmorTriple) GetMenu = new ThalmorTripleMenu(order);
				else if (order is ThugsTBone) GetMenu = new ThugsTBoneMenu(order);
			}
			else if (order is Drink)
			{
				if (order is AretinoAppleJuice) GetMenu = new AretinoAppleJuiceMenu(order);
				else if (order is CandlehearthCoffee) GetMenu = new CandlehearthCoffeeMenu(order);
				else if (order is MarkarthMilk) GetMenu = new MarkarthMilkMenu(order);
				else if (order is SailorSoda) GetMenu = new SailorSodaMenu(order);
				else if (order is WarriorWater) GetMenu = new WarriorWaterMenu(order);
			}
			else if (order is Side)
			{
				if (order is DragonbornWaffleFries) GetMenu = new DragonbornWaffleFriesMenu(order);
				else if (order is FriedMiraak) GetMenu = new FriedMiraakMenu(order);
				else if (order is MadOtarGrits) GetMenu = new MadOtarGritsMenu(order);
				else if (order is VokunSalad) GetMenu = new VokunSaladMenu(order);
			}
		}
	}
}
