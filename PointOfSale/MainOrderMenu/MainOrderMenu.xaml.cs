/*- MainOrderMenu.cs					Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Defines the main order menu for the point of sale
 */

using System;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Media;

namespace PointOfSale
{
	/// <summary>
	///		Logic behind the point of sale's Main order menu
	/// </summary>
	public partial class MainOrderMenu :UserControl 
	{
		/// <summary>
		///		The order menu screen where user can select a menu item
		/// </summary>
		private OrderMenu _mainMenu = new OrderMenu();
		/// <summary>
		/// The order summery screen that keeps track of the items in the order thus far
		/// </summary>
		private OrderSummary _orderSummary;
		/// <summary>
		/// The current order
		/// </summary>
		private Order _curOrder;
		/// <summary>
		/// Keeps a history of all the completed orders
		/// </summary>
		private List<Order> _transactionHistory = new List<Order>();

		/// <summary>
		///		Constructor. Set up and initialize all components in the point of sale
		/// </summary>
		public MainOrderMenu()
		{
			InitializeComponent();
			NewOrder();
			ResetMenu();
			_mainMenu.CurrentMenuItem += OnMenuItemSelect;
			_orderSummary.EditMenuItem += OnMenuItemSelect;
		}

		/// <summary>
		/// Sets the order summary with a new order
		/// </summary>
		private void NewOrder()
		{
			_curOrder = new Order();
			_orderSummary = new OrderSummary(_curOrder);
			_orderSummary.EditMenuItem += OnMenuItemSelect;
			ResetMenu();
		}

		/// <summary>
		/// Enables or disables the navigation buttons
		/// </summary>
		/// <param name="en">true for buttons enabling, false if not</param>
		private void EnableNavButtons(bool en)
		{
			uxCancelButton.IsEnabled = en;
			uxPlaceOrderButton.IsEnabled = en;
		}

		/// <summary>
		///		Set menu to its default state. 
		/// </summary>
		private void ResetMenu()
		{
			uxOrderMenuBorder.Child = _mainMenu;
			uxOrderSummaryBorder.Child = _orderSummary;
			EnableNavButtons(true);
		}

		/// <summary>
		///		Action to be taken when the user has made a selection indicating
		///		that they want to customize a menu item. This typically happens on
		///		a selection of a menu item, but can also be invoked through a request
		///		to edit a previously ordered item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuItemSelect(object sender, MenuSelectEventArgs e)
		{
			if( sender is OrderMenu )
				_orderSummary.AddItem(e.GetMenu.Order);
			EnableNavButtons(false);

			e.GetMenu.Done += OnCompleteCustomization;
			uxOrderMenuBorder.Child = (UserControl)e.GetMenu;
		}

		/// <summary>
		///		Invoked when a user is done customizing an order.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCompleteCustomization(object sender, EventArgs e)
		{
			if(sender is CustomizationMenu menuItem )
			{
				ResetMenu();
			}
		}

		/// <summary>
		///		When the complete order button is pressed, save this order
		///		in the completed orders list and start a new one
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OrderCompleteClick(object sender, RoutedEventArgs e)
		{
			_transactionHistory.Add(_curOrder);
			NewOrder();
		}

		/// <summary>
		///  This order has been cancelled. Remove all references in the order so it can be used
		///  for a new one
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OrderCancelledClick(object sender, RoutedEventArgs e)
		{
			_curOrder.CancelOrder();
		}
	}
}
