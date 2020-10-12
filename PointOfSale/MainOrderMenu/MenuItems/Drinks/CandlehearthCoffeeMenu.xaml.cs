/*- CandlehearthCoffeeMenu.cs			Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Allows customization of the Candlehearth Coffee
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using DrinkSize = BleakwindBuffet.Data.Enums.Size;

namespace PointOfSale
{
	/// <summary>
	/// Interaction logic for AretinoAppleJuiceMenu.xaml
	/// </summary>
	public partial class CandlehearthCoffeeMenu : CustomizationMenu
	{
		/// <summary>
		///		Constructor for this menu. Initialize all componenents with the supplied drink
		/// </summary>
		/// <param name="drink">The drink to be customized</param>
		public CandlehearthCoffeeMenu()
		{
			InitializeComponent();
		}
	}
}
