/*- Order.cs							Created: 10OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 10OCT20
 *	Represents an individual order of IOrderItems.
 */

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace BleakwindBuffet.Data
{
	/// <summary>
	/// class representing a current order from our point of sale
	/// Observable collection impliments Icollection, INotify, and INotifyPropertyChanged;
	/// so we don't have to state it again here.
	/// </summary>
	public class Order : ObservableCollection<IOrderItem>
	{
		/// <summary>
		///  Represents the latest order's number. There is one ticket number
		///  for all orders, all should be unique.
		/// </summary>
		private static int _ticketNumber = 1;

		/// <summary>
		/// represents this order's number
		/// </summary>
		public int TicketNumber { get; }

		/// <summary>
		/// Represents the sales tax for the sale
		/// </summary>
		public double SalesTax { get; set; } = 0.12;

		/// <summary>
		/// private backing variable for Subtotal
		/// </summary>
		private double _subtotal = 0;
		/// <summary>
		/// price of the order before tax
		/// </summary>
		public double Subtotal => _subtotal;

		/// <summary>
		/// The amount of tax to be payed for the order
		/// </summary>
		public double Tax => _subtotal * SalesTax;

		/// <summary>
		/// total price after tax for the order
		/// </summary>
		public double Total => _subtotal * (1+SalesTax);

		/// <summary>
		/// private backing variable for Calories
		/// </summary>
		private uint _calories = 0;
		/// <summary>
		/// Total calories of all items in this order
		/// </summary>
		public uint Calories => _calories;

		/// <summary>
		///		Constructor for this order. Gives the order a unique ticket number.
		/// </summary>
		public Order()
		{
			TicketNumber = _ticketNumber++;
			CollectionChanged += OrderChangedListener;
		}

		/// <summary>
		///		Listens for when items have been added/removed from the list and either adds
		///		or removes event listners and makes the proper notifications.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OrderChangedListener(Object sender, NotifyCollectionChangedEventArgs e)
		{
			switch( e.Action )
			{
				case NotifyCollectionChangedAction.Add:
					foreach (IOrderItem item in e.NewItems)
						item.PropertyChanged += OrderItemUpdateListener;
					break;
				case NotifyCollectionChangedAction.Remove:
					foreach (IOrderItem item in e.OldItems)
						item.PropertyChanged -= OrderItemUpdateListener;
					break;
				case NotifyCollectionChangedAction.Reset:
					throw new NotImplementedException("Order does not support NotifyCOllectionChangedAction.Reset");
			}
			NotifyPriceChange();
			NotifyCaloriesChange();
		}

		/// <summary>
		///		Updates the subtotal price of this order and sends out the proper notifications
		///		for the subtotal, tax, and total price
		/// </summary>
		private void NotifyPriceChange()
		{
			_subtotal = 0;
			foreach (IOrderItem item in this)
				_subtotal += item.Price;

			OnPropertyChanged(new PropertyChangedEventArgs("Subtotal"));
			OnPropertyChanged(new PropertyChangedEventArgs("Tax"));
			OnPropertyChanged(new PropertyChangedEventArgs("Total"));
		}

		/// <summary>
		/// updates the calories of this order and sends out the proper
		/// notification to the calories.
		/// </summary>
		private void NotifyCaloriesChange()
		{
			_calories = 0;
			foreach (IOrderItem item in this)
				_calories += item.Calories;

			OnPropertyChanged(new PropertyChangedEventArgs("Calories"));
		}

		/// <summary>
		///		Listens for a change in all orderd items price and calorie properties
		///		if one occurs, use helper methods to take correct actions.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OrderItemUpdateListener(object sender, PropertyChangedEventArgs e)
		{
			switch( e.PropertyName )
			{
				case "Price":
					NotifyPriceChange();
					break;
				case "Calories":
					NotifyCaloriesChange();
					break;
				default:
					OnPropertyChanged(new PropertyChangedEventArgs(e.PropertyName));
					break;
			}
		}

		/// <summary>
		/// Easy method to call that will remove all IOrderItems without worry of
		/// memory leaks
		/// </summary>
		public void CancelOrder()
		{ 
			while (Count > 0)
				RemoveAt(0);
		}
	}
}
