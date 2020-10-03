/*- OrderSummary.cs						Created: 01OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Keeps a working list of ordered items as well as the price.	
 *	It is the equivelent of keeping a working reciept
 */

using BleakwindBuffet.Data;
using System;
using System.Collections.Generic;
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
		public OrderSummary()
		{
			InitializeComponent();
			UpdatePrice();
		}

		/// <summary>
		///		Update the price of the order. This can be called any time there
		///		is a change to the list
		/// </summary>
		private void UpdatePrice()
		{
			double subtotal = 0;
			foreach (IOrderItem item in _reciept)
				subtotal += item.Price;
			uxSubTotal.Text = String.Format("Subtotal: ${0:0.00}", subtotal);
			uxTax.Text = string.Format("Tax: ${0:0.00}", (subtotal * TAX));
			uxTotal.Text = string.Format("Grand Total: ${0:0.00}", (subtotal * (1 + TAX)));
		}

		/// <summary>
		///		Add an item to the list, or add an updated item's information
		///		back into the list
		/// </summary>
		/// <param name="item">item to be added into the list</param>
		public void AddItem(IOrderItem item )
		{
			// if the reciept still contains an instance of this item, then
			// the item needs to be updated.
			if (_reciept.Contains(item))
				uxOrderList.Items[_reciept.IndexOf(item)] = item.ToString();
			// Otherwise add it to both lists
			else
			{
				_reciept.Add(item);
				uxOrderList.Items.Add(item.ToString());
			}	
			UpdatePrice();
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
				_reciept.RemoveAt(uxOrderList.SelectedIndex);
				uxOrderList.Items.RemoveAt(uxOrderList.SelectedIndex);
				UpdatePrice();
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
				EditMenuItem?.Invoke(this, new MenuSelectEventArgs(_reciept[uxOrderList.SelectedIndex]));
			}
		}
	}
}
