/*- DoubleDraugrMenu.cs					Created: 26SEP20
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
	/// Interaction logic for DoubleDraugrMenu.xaml
	/// </summary>
	public partial class DoubleDraugrMenu : CustomizationMenu
	{
		/// <summary>
		///		The current entree under customization
		/// </summary>
		DoubleDraugr _myEntree;

		/// <summary>
		///		Constructor, creates and initializes all componenets
		/// </summary>
		/// <param name="entree"> The entree we are customizing </param>
		public DoubleDraugrMenu(IOrderItem entree)
		{
			InitializeComponent();
			_myEntree =(DoubleDraugr) entree;
			SetCheckBoxes();
		}

		/// <summary>
		///		Constructor creates an initialiezes all compoenents.
		///		Creates a new Entree
		/// </summary>
		public DoubleDraugrMenu() : this(new DoubleDraugr()){}

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
			uxTomatoCheck.IsChecked = _myEntree.Tomato;
			uxLettuceCheck.IsChecked = _myEntree.Lettuce;
			uxMayoCheck.IsChecked = _myEntree.Mayo;
		}

		/// <summary>
		///		Update our entree with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized entree </returns>
		protected override IOrderItem GetOrder()
		{
			_myEntree.Bun = uxBunCheck.IsChecked == true;
			_myEntree.Ketchup = uxKetchupCheck.IsChecked == true;
			_myEntree.Mustard = uxMustardCheck.IsChecked == true; ;
			_myEntree.Pickle = uxPickleCheck.IsChecked == true;
			_myEntree.Cheese = uxCheeseCheck.IsChecked == true;
			_myEntree.Tomato = uxTomatoCheck.IsChecked == true;
			_myEntree.Lettuce = uxLettuceCheck.IsChecked == true;
			_myEntree.Mayo = uxMayoCheck.IsChecked == true;

			return _myEntree;
		}

	}
}
