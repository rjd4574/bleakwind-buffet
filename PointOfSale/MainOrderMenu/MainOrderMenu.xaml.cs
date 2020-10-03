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
		private OrderSummary _orderSummary = new OrderSummary();

		/// <summary>
		///		Constructor. Set up and initialize all components in the point of sale
		/// </summary>
		public MainOrderMenu()
		{
			InitializeComponent();
			ResetMenu();
			_mainMenu.CurrentMenuItem += OnMenuItemSelect;
			_orderSummary.EditMenuItem += OnMenuItemSelect;
		}

		/// <summary>
		///		Set menu to its default state. 
		/// </summary>
		private void ResetMenu()
		{
			uxOrderMenuBorder.Child = _mainMenu;
			uxOrderSummaryBorder.Child = _orderSummary;
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
			e.GetMenu.CancelOrder += OnCancelOrder;
			e.GetMenu.PlaceOrder += OnPlaceOrder;
			uxOrderMenuBorder.Child = (UserControl)e.GetMenu;
		}

		/// <summary>
		///		Invoked when the user backs out of a customization window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCancelOrder(object sender, EventArgs e)
		{
			ResetMenu();
		}

		/// <summary>
		///		Invoked when a user places an order. THis order can 
		///		either be a new order, or an edit of a previously
		///		ordered item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPlaceOrder(object sender, EventArgs e)
		{
			if(sender is CustomizationMenu menuItem )
			{
				_orderSummary.AddItem(menuItem.Order);
				ResetMenu();
			}
		}
	}
}
