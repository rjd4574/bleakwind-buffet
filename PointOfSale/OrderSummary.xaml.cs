/*- OrderSummary.cs						Created: 01OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Keeps a working list of ordered items as well as the price.	
 *	It is the equivelent of keeping a working reciept
 */

using BleakwindBuffet.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointOfSale
{
	/// <summary>
	/// Interaction logic for OrderSummary.xaml
	/// </summary>
	public partial class OrderSummary : UserControl
	{
		/// <summary>
		///		List containing all items ordered
		/// </summary>
		private List<IOrderItem> _reciept = new List<IOrderItem>();

		/// <summary>
		/// represents this order and the dataconext of this order
		/// </summary>
		private Order _myOrder;

		/// <summary>
		///		Tax Rate
		/// </summary>
		private static double TAX = .10;

		/// <summary>
		/// Event handler to indicate when a menu item needs to be edited
		/// </summary>
		public event EventHandler<MenuSelectEventArgs> EditMenuItem;

		/// <summary>
		///		Constructor. Initializes the order summary
		/// </summary>
		public OrderSummary(Order myOrder)
		{
			InitializeComponent();
			DataContext = myOrder;
			_myOrder = myOrder;
			_myOrder.CollectionChanged += UpdateOrderListener;
		}

		public void UpdateOrderListener(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch(e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					foreach (IOrderItem item in e.NewItems)
						AddSummary(item);
					break;
			}
		}
		
		public void AddSummary(IOrderItem item)
		{
			//uxList
		}

		/// <summary>
		///		Add an item to the list, or add an updated item's information
		///		back into the list
		/// </summary>
		/// <param name="item">item to be added into the list</param>
		public void AddItem(IOrderItem item )
		{
			_myOrder.Add(item);
		}

		/// <summary>
		///		Removes the selected item from the order lists
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RemoveItemClick(object sender, RoutedEventArgs e)
		{
			if (uxOrderList.SelectedItems.Count > 0)
			{
				_myOrder.Remove((IOrderItem)uxOrderList.SelectedItem);
			}
		}

		/// <summary>
		///		Allow the user to re-enter the customization menu and
		///		edit a previous order
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EditItemClick(object sender, RoutedEventArgs e)
		{
			if(uxOrderList.SelectedItems.Count > 0)
			{
				EditMenuItem?.Invoke(this, new MenuSelectEventArgs((IOrderItem)uxOrderList.SelectedItem));
			}
		}

	}
}
