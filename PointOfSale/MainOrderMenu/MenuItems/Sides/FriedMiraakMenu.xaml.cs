/*- FriedMiraakMenu.cs						Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Allows customization of the Fried Miraak
 */


using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data;
using System.Collections.Generic;
using System.Windows.Controls;
using SideSize = BleakwindBuffet.Data.Enums.Size;

namespace PointOfSale
{
	/// <summary>
	/// Interaction logic for DragonbornWaffleFiresMenu.xaml
	/// </summary>
	public partial class FriedMiraakMenu : CustomizationMenu
	{
		/// <summary>
		///		The current side under customization
		/// </summary>
		FriedMiraak _mySide;

		/// <summary>
		///		A list of all Size Radio buttons for easier navigation
		/// </summary>
		List<KeyValuePair<SideSize, RadioButton>> _sizes =
			new List<KeyValuePair<SideSize, RadioButton>>();

		/// <summary>
		///		Constructor. Creates a customization menu for the given side
		/// </summary>
		/// <param name="side">The side to be customized</param>
		public FriedMiraakMenu(IOrderItem side)
		{
			InitializeComponent();
			_mySide = (FriedMiraak)side;
			SetSizes();
			SetCheckBoxes();
		}

		/// <summary>
		///		Constructor. Creates a cusomization menu for a new side
		/// </summary>
		public FriedMiraakMenu() : this(new FriedMiraak()) { }

		/// <summary>
		///		Sets all size radio buttons into a keyvalue pair for easier access
		/// </summary>
		private void SetSizes()
		{
			_sizes.Add(new KeyValuePair<SideSize, RadioButton>(SideSize.Small, uxSizeSmallRadio));
			_sizes.Add(new KeyValuePair<SideSize, RadioButton>(SideSize.Medium, uxSizeMediumRadio));
			_sizes.Add(new KeyValuePair<SideSize, RadioButton>(SideSize.Large, uxSizeLargeRadio));
		}

		/// <summary>
		///		Sets the check boxes and radio buttons to their default values by referencing
		///		the current side right after initialization. 
		/// </summary>
		private void SetCheckBoxes()
		{
			//Set Default size
			foreach (KeyValuePair<SideSize, RadioButton> radio in _sizes)
			{
				if (radio.Key == _mySide.Size)
					radio.Value.IsChecked = true;
			}
		}

		/// <summary>
		///		Update our drink with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized drink </returns>
		protected override IOrderItem GetOrder()
		{
			// Set the side of the side
			foreach (KeyValuePair<SideSize, RadioButton> radio in _sizes)
			{
				if (radio.Value.IsChecked == true)
					_mySide.Size = radio.Key;
			}

			return _mySide;
		}
	}
}