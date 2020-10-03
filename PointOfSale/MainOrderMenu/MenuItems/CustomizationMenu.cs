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
		/// <summary>
		///		Event that activates when the order has been cancelled.
		/// </summary>
		public event EventHandler CancelOrder;

		/// <summary>
		/// Event that activates when the order is confirmed
		/// </summary>
		public event EventHandler PlaceOrder;

		/// <summary>
		///		Allows access to IOrderItem with its customizations
		/// </summary>
		public IOrderItem Order => GetOrder();

		/// <summary>
		///		Requires Inheriting classes to contain the GetOrder.
		///		Updates the current IOrderItem to the customizations selected
		///		by the user
		/// </summary>
		/// <returns>The current customized order</returns>
		protected abstract IOrderItem GetOrder();

		/// <summary>
		///		Cancel Order Button invokes a cancel order event 
		///		when clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void CancelOrderClick(object sender, RoutedEventArgs e)
		{
			CancelOrder?.Invoke(this, e);
		}
		
		/// <summary>
		///		Place Order Button invokes a place order event when clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void PlaceOrderClick(object sender, RoutedEventArgs e)
		{
			PlaceOrder?.Invoke(this, e);
		}
	}
}
