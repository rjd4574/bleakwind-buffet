/*- BriarheartBurgerMenu.cs				Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Allows customization of the briarheart burger
 */

using System.Windows.Controls;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
namespace PointOfSale
{
	/// <summary>
	/// Interaction logic for BriarheartBurgerMenu.xaml
	/// </summary>
	public partial class BriarheartBurgerMenu : CustomizationMenu
	{
		/// <summary>
		///		Constructor, creates and initializes all componenets
		/// </summary>
		/// <param name="entree"> The entree we are customizing </param>
		public BriarheartBurgerMenu()
		{
			InitializeComponent();
		}
	}
}
