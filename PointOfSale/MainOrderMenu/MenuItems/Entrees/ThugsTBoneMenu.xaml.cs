/*- ThugsTBoneMenu.cs				Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Allows customization of the Smokehouse Skeleton
 */


using System.Windows.Controls;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;


namespace PointOfSale
{
	/// <summary>
	/// Interaction logic for GardenOrcOmeletteMenu.xaml
	/// </summary>
	public partial class ThugsTBoneMenu : UserControl, IMenuItem
	{
		/// <summary>
		///		The current entree under customization
		/// </summary>
		ThugsTBone _myEntree = new ThugsTBone();

		/// <summary>
		///		Allows access to the current order being customized
		/// </summary>
		public IOrderItem Order => GetOrder();

		/// <summary>
		///		Constructor, initilizes componenets and sets defaults
		/// </summary>
		public ThugsTBoneMenu()
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
			// No options
		}

		/// <summary>
		///		Update our entree with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized entree </returns>
		public IOrderItem GetOrder()
		{
			// No options
			return _myEntree;
		}

	}
}
