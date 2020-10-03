/*- WarriorWaterMenu.cs					Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Allows customization of the Warrior water
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
	public partial class WarriorWaterMenu : CustomizationMenu
	{
		/// <summary>
		///		The current drink under customization
		/// </summary>
		WarriorWater _myDrink;

		/// <summary>
		///		A list of all Size Radio buttons for easier navigation
		/// </summary>
		List<KeyValuePair<DrinkSize, RadioButton>> _sizes =
			new List<KeyValuePair<DrinkSize, RadioButton>>();

		/// <summary>
		///		Constructor for this menu. Initialize all componenents with the supplied drink
		/// </summary>
		/// <param name="drink">The drink to be customized</param>
		public WarriorWaterMenu(IOrderItem drink)
		{
			InitializeComponent();
			_myDrink = (WarriorWater)drink;
			SetSizes();
			SetCheckBoxes();
		}

		/// <summary>
		///  Constructor for this menu. Initialize all components with a new drink
		/// </summary>
		public WarriorWaterMenu() : this(new WarriorWater()) { }

		/// <summary>
		///		Sets all size radio buttons into a keyvalue pair for easier access
		/// </summary>
		private void SetSizes()
		{
			_sizes.Add(new KeyValuePair<DrinkSize, RadioButton>(DrinkSize.Small, uxSizeSmallRadio));
			_sizes.Add(new KeyValuePair<DrinkSize, RadioButton>(DrinkSize.Medium, uxSizeMediumRadio));
			_sizes.Add(new KeyValuePair<DrinkSize, RadioButton>(DrinkSize.Large, uxSizeLargeRadio));
		}

		/// <summary>
		///		Sets the check boxes and radio buttons to their default values by referencing
		///		the current drink right after initialization. 
		/// </summary>
		private void SetCheckBoxes()
		{
			//Set Default size
			foreach (KeyValuePair<DrinkSize, RadioButton> radio in _sizes)
			{
				if (radio.Key == _myDrink.Size)
					radio.Value.IsChecked = true;
			}

			uxIceCheck.IsChecked = _myDrink.Ice;
			uxLemonCheck.IsChecked= _myDrink.Lemon;
		}

		/// <summary>
		///		Update our drink with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized drink </returns>
		protected override IOrderItem GetOrder()
		{
			// Set the size of the drink
			foreach (KeyValuePair<DrinkSize, RadioButton> radio in _sizes)
			{
				if (radio.Value.IsChecked == true)
					_myDrink.Size = radio.Key;
			}

			_myDrink.Ice = uxIceCheck.IsChecked == true;
			_myDrink.Lemon = uxLemonCheck.IsChecked == true;

			return _myDrink;
		}
	}
}
