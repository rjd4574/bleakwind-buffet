/*- DoubleDraugrMenu.cs					Created: 26SEP20
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
	/// Interaction logic for GardenOrcOmeletteMenu.xaml
	/// </summary>
	public partial class GardenOrcOmeletteMenu : UserControl, IMenuItem
	{
		/// <summary>
		///		The current entree under customization
		/// </summary>
		GardenOrcOmelette _myEntree = new GardenOrcOmelette();

		/// <summary>
		///		Allows access to the current order being customized
		/// </summary>
		public IOrderItem Order => GetOrder();

		/// <summary>
		///		Constructor, initilizes componenets and sets defaults
		/// </summary>
		public GardenOrcOmeletteMenu()
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
			uxBroccoliCheck.IsChecked = _myEntree.Broccoli;
			uxMushroomsCheck.IsChecked = _myEntree.Mushrooms;
			uxTomatoCheck.IsChecked = _myEntree.Tomato;
			uxCheddarCheck.IsChecked = _myEntree.Cheddar;
		}

		/// <summary>
		///		Update our entree with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized entree </returns>
		public IOrderItem GetOrder()
		{
			_myEntree.Broccoli = uxBroccoliCheck.IsChecked == true;
			_myEntree.Mushrooms = uxMushroomsCheck.IsChecked == true;
			_myEntree.Tomato = uxTomatoCheck.IsChecked == true; ;
			_myEntree.Cheddar = uxCheddarCheck.IsChecked == true;

			return _myEntree;
		}

	}
}
