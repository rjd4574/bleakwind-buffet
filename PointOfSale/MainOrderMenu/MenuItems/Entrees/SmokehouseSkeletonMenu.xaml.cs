/*- SmokehouseSkeletonMenu.cs				Created: 26SEP20
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
	public partial class SmokehouseSkeletonMenu : UserControl, IMenuItem
	{
		/// <summary>
		///		The current entree under customization
		/// </summary>
		SmokehouseSkeleton _myEntree = new SmokehouseSkeleton();

		/// <summary>
		///		Allows access to the current order being customized
		/// </summary>
		public IOrderItem Order => GetOrder();

		/// <summary>
		///		Constructor, initilizes componenets and sets defaults
		/// </summary>
		public SmokehouseSkeletonMenu()
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
			uxSausageLinkCheck.IsChecked = _myEntree.SausageLink;
			uxEggCheck.IsChecked = _myEntree.Egg;
			uxHashBorwnsCheck.IsChecked = _myEntree.HashBrowns;
			uxPancakeCheck.IsChecked = _myEntree.Pancake;
		}

		/// <summary>
		///		Update our entree with the selected customizations and return it
		/// </summary>
		/// <returns> The requested customized entree </returns>
		public IOrderItem GetOrder()
		{
			_myEntree.SausageLink = uxSausageLinkCheck.IsChecked == true;
			_myEntree.Egg = uxEggCheck.IsChecked == true;
			_myEntree.HashBrowns = uxHashBorwnsCheck.IsChecked == true; ;
			_myEntree.Pancake = uxPancakeCheck.IsChecked == true;

			return _myEntree;
		}

	}
}
