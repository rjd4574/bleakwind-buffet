﻿/*- SailorSodaMenu.cs					Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Allows customization of the SailorSoda
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using DrinkSize = BleakwindBuffet.Data.Enums.Size;

namespace PointOfSale
{
	/// <summary>
	/// Interaction logic for AretinoAppleJuiceMenu.xaml
	/// </summary>
	public partial class SailorSodaMenu : UserControl, IMenuItem
	{
		/// <summary>
		///		The current drink under customization
		/// </summary>
		SailorSoda _myDrink = new SailorSoda();

		/// <summary>
		///		A list of all Size Radio buttons for easier navigation
		/// </summary>
		List<KeyValuePair<DrinkSize, RadioButton>> _sizes =
			new List<KeyValuePair<DrinkSize, RadioButton>>();

		/// <summary>
		///		A list of all flavor Radio buttons for easier navigation
		/// </summary>
		List<KeyValuePair<SodaFlavor, RadioButton>> _flavors =
			new List<KeyValuePair<SodaFlavor, RadioButton>>();

		/// <summary>
		///		Allows access to the current drink being customized
		/// </summary>
		public IOrderItem Order => GetOrder();

		/// <summary>
		///		Constructor for this menu. Initializes components and sets default values
		/// </summary>
		public SailorSodaMenu()
		{
			InitializeComponent();
			SetSizes();
			SetFlavors();
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
		///		Sets all flavor radio buttons into a keyvalue pair for easier access
		/// </summary>
		private void SetFlavors()
		{
			_flavors.Add(new KeyValuePair<SodaFlavor, RadioButton>(SodaFlavor.Blackberry, uxFlavorBlackberryRadio));
			_flavors.Add(new KeyValuePair<SodaFlavor, RadioButton>(SodaFlavor.Cherry, uxFlavorCherryRadio));
			_flavors.Add(new KeyValuePair<SodaFlavor, RadioButton>(SodaFlavor.Grapefruit, uxFlavorGrapefruitRadio));
			_flavors.Add(new KeyValuePair<SodaFlavor, RadioButton>(SodaFlavor.Lemon, uxFlavorLemonRadio));
			_flavors.Add(new KeyValuePair<SodaFlavor, RadioButton>(SodaFlavor.Peach, uxFlavorPeachRadio));
			_flavors.Add(new KeyValuePair<SodaFlavor, RadioButton>(SodaFlavor.Watermelon, uxFlavorWatermelonRadio));
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

			// Set default flavor
			foreach( KeyValuePair<SodaFlavor,RadioButton> radio in _flavors)
			{
				if (radio.Key == _myDrink.Flavor)
					radio.Value.IsChecked = true;
			}

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

			// Set the flavor of the drink
			foreach (KeyValuePair<SodaFlavor, RadioButton> radio in _flavors)
			{
				if (radio.Value.IsChecked == true)
					_myDrink.Flavor = radio.Key;
			}

			_myDrink.Ice = uxIceCheck.IsChecked == true;

			return _myDrink;
		}
	}
}