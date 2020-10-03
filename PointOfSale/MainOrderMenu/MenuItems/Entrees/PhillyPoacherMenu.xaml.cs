﻿/*- PhillyPoacherMenu.cs				Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Allows customization of the philly poacher
 */

using System.Windows.Controls;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;


namespace PointOfSale
{
	/// <summary>
	/// Interaction logic for GardenOrcOmeletteMenu.xaml
	/// </summary>
	public partial class PhillyPoacherMenu : CustomizationMenu
	{
		/// <summary>
		///		The current entree under customization
		/// </summary>
		PhillyPoacher _myEntree;

		/// <summary>
		///		Constructor, creates and initializes all componenets
		/// </summary>
		/// <param name="entree"> The entree we are customizing </param>
		public PhillyPoacherMenu(IOrderItem entree)
		{
			InitializeComponent();
			_myEntree =(PhillyPoacher) entree;
			SetCheckBoxes();
		}

		/// <summary>
		///		Constructor creates an initialiezes all compoenents.
		///		Creates a new Entree
		/// </summary>
		public PhillyPoacherMenu() : this(new PhillyPoacher()) { }

		/// <summary>
		///		Sets the check boxes to their defaults by accessing
		///		the current entree right after initialization
		/// </summary>
		private void SetCheckBoxes()
		{
			uxSirloinCheck.IsChecked = _myEntree.Sirloin;
			uxOnionCheck.IsChecked = _myEntree.Onion;
			uxRollCheck.IsChecked = _myEntree.Roll;
		}

		/// <summary>
		///		Update our entree with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized entree </returns>
		protected override IOrderItem GetOrder()
		{
			_myEntree.Sirloin = uxSirloinCheck.IsChecked == true;
			_myEntree.Onion = uxOnionCheck.IsChecked == true;
			_myEntree.Roll = uxRollCheck.IsChecked == true;

			return _myEntree;
		}

	}
}
