/*- BriarheartBurgerMenu.cs				Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
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
	public partial class BriarheartBurgerMenu : UserControl, IMenuItem
	{
		/// <summary>
		///		The current entree under customization
		/// </summary>
		BriarheartBurger _myEntree = new BriarheartBurger();

		/// <summary>
		///		Allows access to the current order being customized
		/// </summary>
		public IOrderItem Order => GetOrder();

		/// <summary>
		///		Constructor, initilizes componenets and sets defaults
		/// </summary>
		public BriarheartBurgerMenu()
		{
			InitializeComponent();
			SetCheckBoxes();
		}


		/// <summary>
		///		Sets the check boxes to their defaults by accessing
		///		the current entree right after initialization
		/// </summary>
		private void SetCheckBoxes()
		{
			uxBunCheck.IsChecked = _myEntree.Bun;
			uxKetchupCheck.IsChecked = _myEntree.Ketchup;
			uxMustardCheck.IsChecked = _myEntree.Mustard;
			uxPickleCheck.IsChecked = _myEntree.Pickle;
			uxCheeseCheck.IsChecked = _myEntree.Cheese;
		}

		/// <summary>
		///		Update our entree with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized entree </returns>
		public IOrderItem GetOrder()
		{
			_myEntree.Bun = uxBunCheck.IsChecked == true;
			_myEntree.Ketchup = uxKetchupCheck.IsChecked==true;
			_myEntree.Mustard = uxMustardCheck.IsChecked == true; ;
			_myEntree.Pickle = uxPickleCheck.IsChecked == true;
			_myEntree.Cheese = uxCheeseCheck.IsChecked == true;

			return _myEntree;
		}

	}
}
