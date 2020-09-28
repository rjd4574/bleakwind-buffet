/*- CandlehearthCoffeeMenu.cs			Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
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
	public partial class CandlehearthCoffeeMenu : UserControl, IMenuItem
	{
		/// <summary>
		///		The current drink under customization
		/// </summary>
		CandlehearthCoffee _myDrink = new CandlehearthCoffee();

		/// <summary>
		///		A list of all Size Radio buttons for easier navigation
		/// </summary>
		List<KeyValuePair<DrinkSize, RadioButton>> _sizes =
			new List<KeyValuePair<DrinkSize, RadioButton>>();

		/// <summary>
		///		Allows access to the current drink being customized
		/// </summary>
		public IOrderItem Order => GetOrder();

		/// <summary>
		///		Constructor for this menu. Initializes components and sets default values
		/// </summary>
		public CandlehearthCoffeeMenu()
		{
			InitializeComponent();
			SetSizes();
			SetCheckBoxes();
		}

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

			uxDecafCheck.IsChecked = _myDrink.Decaf;
			uxRoomForCreamCheck.IsChecked = _myDrink.RoomForCream;
			uxIceCheck.IsChecked = _myDrink.Ice;
		}


		/// <summary>
		///		Update our drink with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized drink </returns>
		public IOrderItem GetOrder()
		{
			// Set the size of the drink
			foreach (KeyValuePair<DrinkSize, RadioButton> radio in _sizes)
			{
				if (radio.Value.IsChecked == true)
					_myDrink.Size = radio.Key;
			}

			_myDrink.Decaf = uxDecafCheck.IsChecked == true;
			_myDrink.RoomForCream = uxRoomForCreamCheck.IsChecked == true;
			_myDrink.Ice = uxIceCheck.IsChecked == true;

			return _myDrink;
		}
	}
}
