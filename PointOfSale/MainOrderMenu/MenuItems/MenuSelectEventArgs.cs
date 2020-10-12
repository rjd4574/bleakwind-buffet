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
				if (order is BriarheartBurger) GetMenu = new BriarheartBurgerMenu();
				else if (order is DoubleDraugr) GetMenu = new DoubleDraugrMenu();
				else if (order is GardenOrcOmelette) GetMenu = new GardenOrcOmeletteMenu();
				else if (order is PhillyPoacher) GetMenu = new PhillyPoacherMenu();
				else if (order is SmokehouseSkeleton) GetMenu = new SmokehouseSkeletonMenu();
				else if (order is ThalmorTriple) GetMenu = new ThalmorTripleMenu();
				else if (order is ThugsTBone) GetMenu = new ThugsTBoneMenu();
			}
			else if (order is Drink)
			{
				if (order is AretinoAppleJuice) GetMenu = new AretinoAppleJuiceMenu();
				else if (order is CandlehearthCoffee) GetMenu = new CandlehearthCoffeeMenu();
				else if (order is MarkarthMilk) GetMenu = new MarkarthMilkMenu();
				else if (order is SailorSoda) GetMenu = new SailorSodaMenu();
				else if (order is WarriorWater) GetMenu = new WarriorWaterMenu();
			}
			else if (order is Side)
			{
				if (order is DragonbornWaffleFries) GetMenu = new DragonbornWaffleFriesMenu();
				else if (order is FriedMiraak) GetMenu = new FriedMiraakMenu();
				else if (order is MadOtarGrits) GetMenu = new MadOtarGritsMenu();
				else if (order is VokunSalad) GetMenu = new VokunSaladMenu();
			}
			GetMenu.DataContext = order;
		}
	}
}
