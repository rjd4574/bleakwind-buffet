/*- OrderMenu.cs						Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Allows selection of an order item. Dynamically created
 *	buttons allows for buttons to be taken on/off the menu
 *	with minimal update to this code
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using System.ComponentModel;

namespace PointOfSale
{
	/// <summary>
	///		Interaction logic for OrderMenu.xaml
	/// </summary>
	public partial class OrderMenu : UserControl, INotifyPropertyChanged
	{
		/// <summary>
		///		Event activates when any of the menu items are selected
		/// </summary>
		public event EventHandler<MenuSelectEventArgs> CurrentMenuItem;

		/// <summary>
		/// Used to notify of a canceled or completed Order
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///		Constructor, Initializes the main components and dynamically draws
		///		buttons to represent all items on the Menu
		/// </summary>
		public OrderMenu()
		{
			InitializeComponent();
			InitializeDynamicComponents();
		}

		/// <summary>
		///		Begins initialization of dynamically created components
		/// </summary>
		private void InitializeDynamicComponents()
		{
			InitializeButtons((List<IOrderItem>)BleakwindBuffet.Data.Menu.EntreeItems(), 0);
			InitializeButtons((List<IOrderItem>)BleakwindBuffet.Data.Menu.DrinkItems(), 1);
			InitializeButtons((List<IOrderItem>)BleakwindBuffet.Data.Menu.SideItems(), 2);
			uxAddComboButton.MenuItem = new Combo();
			uxAddComboButton.Click += ItemSelect;
		}

		/// <summary>
		///		Place the buttons on the display and add the click events
		/// </summary>
		/// <param name="item"> list of all menu items (Entree,Drink, or Side)</param>
		/// <param name="col"> Defines which column the items should be placed in </param>
		private void InitializeButtons(List<IOrderItem> item, int col)
		{
			for (int row = 0; row < item.Count; row++)
			{
				OrderButton b = new OrderButton();
				b.Content = item[row].Name;
				b.MenuItem = item[row];
				b.Click += ItemSelect;
				Grid.SetColumn(b, col);
				Grid.SetRow(b, row+1);
				uxOrderMenu.Children.Add(b);
			}
		}


		/// <summary>
		///		When a new menu item is selected from the screen, a menuitem action is
		///		invoked with a new IOrderItem of the type that was just selected. It is important
		///		to create a new instance here as the user isn't looking to edit a past item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemSelect(Object sender, EventArgs e)
		{
			if(sender is OrderButton butt)
			{
				var newItem = (IOrderItem)Activator.CreateInstance(butt.MenuItem.GetType());
				CurrentMenuItem?.Invoke(this, new MenuSelectEventArgs(newItem));
			}
		}

		/// <summary>
		/// Sends notification that this order has been completed. 
		/// Property is whether the order is to be completed or cancelled.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelOrCompleteOrderClick(object sender, RoutedEventArgs e)
		{
			if (!(sender is Button))
				return;
			switch(((Button)sender).Name)
			{
				case "uxCancelOrderButton":
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cancel"));
					break;
				case "uxCompleteOrderButton":
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Complete"));
					break;
				default: break;
			}
		}
	}
}
