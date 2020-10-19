/*- CustomizationMenu.cs				Created: 01OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Abstract class containing common functionality of all Customization Menu's
 */

using BleakwindBuffet.Data;
using System;
using System.Windows.Controls;
using System.Windows;

namespace PointOfSale
{
	/// <summary>
	///		Base class for user control wpf custom menu's
	/// </summary>
	public abstract partial class CustomizationMenu : UserControl
	{
		public event EventHandler<MenuSelectEventArgs> EditItemEvent;
		/// <summary>
		///		Event that activates when the order is done being customized.
		/// </summary>
		public event EventHandler Done;

		/// <summary>
		///		Allows access to IOrderItem with its customizations
		/// </summary>
		public IOrderItem Order => (IOrderItem)DataContext;
		
		/// <summary>
		///		Place Order Button invokes a place order event when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void PlaceOrderClick(object sender, RoutedEventArgs e)
		{
			Done?.Invoke(this, e);
		}

		protected void EditItemClick(object sender, RoutedEventArgs e)
		{
			if (sender is OrderButton butt && butt.MenuItem != null)
				EditItemEvent?.Invoke(this, new MenuSelectEventArgs(butt.MenuItem));
		}
	}
}
