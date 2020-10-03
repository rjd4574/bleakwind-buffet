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
	/// Interaction logic for GardenOrcOmeletteMenu.xaml
	/// </summary>
	public partial class GardenOrcOmeletteMenu : CustomizationMenu
	{
		/// <summary>
		///		The current entree under customization
		/// </summary>
		GardenOrcOmelette _myEntree;

		/// <summary>
		///		Constructor, creates and initializes all componenets
		/// </summary>
		/// <param name="entree"> The entree we are customizing </param>
		public GardenOrcOmeletteMenu(IOrderItem entree)
		{
			InitializeComponent();
			_myEntree =(GardenOrcOmelette) entree;
			SetCheckBoxes();
		}

		/// <summary>
		///		Constructor creates an initialiezes all compoenents.
		///		Creates a new Entree
		/// </summary>
		public GardenOrcOmeletteMenu() : this(new GardenOrcOmelette()) { }

		/// <summary>
		///		Sets the check boxes to their defaults by accessing
		///		the current entree right after initialization
		/// </summary>
		private void SetCheckBoxes()
		{
			uxBroccoliCheck.IsChecked = _myEntree.Broccoli;
			uxMushroomsCheck.IsChecked = _myEntree.Mushrooms;
			uxTomatoCheck.IsChecked = _myEntree.Tomato;
			uxCheddarCheck.IsChecked = _myEntree.Cheddar;
		}

		/// <summary>
		///		Update our entree with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized entree </returns>
		protected override IOrderItem GetOrder()
		{
			_myEntree.Broccoli = uxBroccoliCheck.IsChecked == true;
			_myEntree.Mushrooms = uxMushroomsCheck.IsChecked == true;
			_myEntree.Tomato = uxTomatoCheck.IsChecked == true; ;
			_myEntree.Cheddar = uxCheddarCheck.IsChecked == true;

			return _myEntree;
		}

	}
}
