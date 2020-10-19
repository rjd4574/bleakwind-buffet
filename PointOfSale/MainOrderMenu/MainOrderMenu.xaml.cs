/*- MainOrderMenu.cs					Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Defines the main order menu for the point of sale
 */

using System;
using BleakwindBuffet.Data;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using PointOfSale.Transaction;
using System.Transactions;

namespace PointOfSale
{
	/// <summary>
	///		Logic behind the point of sale's Main order menu
	/// </summary>
	public partial class MainOrderMenu : UserControl 
	{
		/// <summary>
		///		The order menu screen where user can select a menu item
		/// </summary>
		private OrderMenu _mainMenu = new OrderMenu();
		/// <summary>
		/// Current combo (if any) being built
		/// </summary>
		private ComboMenu _comboMenu;
		/// <summary>
		/// Current transaction (if any) in progress
		/// </summary>
		private TransactionControl _transaction;
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
			_mainMenu.PropertyChanged += OnCancelOrCompleteOrder;
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
		///		Set menu to its default state. 
		/// </summary>
		private void ResetMenu()
		{
			if(_comboMenu!=null)
				uxOrderMenuBorder.Child = _comboMenu;
			else
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
			// clicked on from list of all IOrderItems
			if( sender is OrderMenu )
				_orderSummary.AddItem(e.GetMenu.Order);

			// Edit Item from combo meal
			if (sender is ComboMenu menu)
				// The combo meal is the temporary default menu
				_comboMenu = menu;

			e.GetMenu.Done += OnCompleteCustomization;
			e.GetMenu.EditItemEvent += OnMenuItemSelect;
			uxOrderMenuBorder.Child = (UserControl)e.GetMenu;
		}

		/// <summary>
		///		Invoked when a user is done customizing an order.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCompleteCustomization(object sender, EventArgs e)
		{
			if( _comboMenu != null && sender is ComboMenu )
				_comboMenu =null;
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
		private void OnCancelOrCompleteOrder(object sender, PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case "Complete":	// start the transaction
					_transaction = new TransactionControl(_curOrder);
					_transaction.PropertyChanged += OnCancelOrCompleteOrder;
					uxOrderMenuBorder.Child = _transaction;
					break;
				case "Cancel":		// cancel the order
					_curOrder.CancelOrder();
					break;
				case "TransactionComplete":		// transaction complete, start new order
					_transactionHistory.Add(_curOrder);
					_transaction.PropertyChanged -= OnCancelOrCompleteOrder;
					NewOrder();
					break;
				case "TransactionCancel":		// transaction cancel, stay with this order
					_transaction.PropertyChanged -= OnCancelOrCompleteOrder;
					ResetMenu();
					break;
				default: break;
			}
			
		}

	}
}
