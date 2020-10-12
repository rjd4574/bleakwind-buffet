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
		///		Constructor. Creates a customization menu for the given side
		/// </summary>
		/// <param name="side">The side to be customized</param>
		public FriedMiraakMenu()
		{
			InitializeComponent();
		}
	}
}