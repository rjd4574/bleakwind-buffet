/*- OrderMenu.cs						Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
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

namespace PointOfSale
{
	/// <summary>
	///		Interaction logic for OrderMenu.xaml
	/// </summary>
	public partial class OrderMenu : UserControl
	{
		/// <summary>
		///		Difine the uniform size for all buttons
		/// </summary>
		private int uxButtonWidth = 30;
		private int uxButtonHeight = 4;
		private int uxButtonStartRow = 1;
		/// <summary>
		///		How many buttons long the UI should accomidate 
		/// </summary>
		private int _numRows = 7;

		/// <summary>
		///		The current selection from the user. Only
		///		one item can be selected at a time. After initialization
		///		WarriorWater will be the default selection
		/// </summary>
		private OrderButton _currentOrder = null;
		/// <summary>
		///		Getter that allows access to which item is currently selected
		/// </summary>
		public IOrderItem Selection => _currentOrder.MenuItem;

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
			SetGrid();
			InitializeButtons((List<IOrderItem>)BleakwindBuffet.Data.Menu.EntreeItems(), 1);
			InitializeButtons((List<IOrderItem>)BleakwindBuffet.Data.Menu.DrinkItems(), 2);
			InitializeButtons((List<IOrderItem>)BleakwindBuffet.Data.Menu.SideItems(), 3);
		}

		/// <summary>
		///		Creates the grids around the buttons.
		/// </summary>
		private void SetGrid()
		{
			// Set the rows: 3 rows to one button. This needs to be fixed to padding later.
			for (int row = 0; row < _numRows + uxButtonStartRow; row++)
			{
				RowDefinition r = new RowDefinition();
				r.Height = new GridLength(1, GridUnitType.Star);
				uxOrderMenu.RowDefinitions.Add(r);
				r = new RowDefinition();
				r.Height = new GridLength(uxButtonHeight, GridUnitType.Star);
				uxOrderMenu.RowDefinitions.Add(r);
				r = new RowDefinition();
				r.Height = new GridLength(1, GridUnitType.Star);
				uxOrderMenu.RowDefinitions.Add(r);
			}

			// Set the Coloumns: 3 columns to one button. THis needs to be fixed to padding later.
			for (int col = 0; col < 3; col++)
			{
				ColumnDefinition c = new ColumnDefinition();
				c.Width = new GridLength(1, GridUnitType.Star);
				uxOrderMenu.ColumnDefinitions.Add(c);
				c = new ColumnDefinition();
				c.Width = new GridLength(uxButtonWidth, GridUnitType.Star);
				uxOrderMenu.ColumnDefinitions.Add(c);
				c = new ColumnDefinition();
				c.Width = new GridLength(1, GridUnitType.Star);
				uxOrderMenu.ColumnDefinitions.Add(c);
			}

			// Heading For this menu display
			TextBlock t = new TextBlock();
			t.Text = "Add To Order";
			t.FontSize = 20;
			t.TextAlignment = TextAlignment.Center;
			t.FontWeight = FontWeights.Bold;
			Grid.SetColumn(t, 4);
			Grid.SetRow(t, 1);
			uxOrderMenu.Children.Add(t);
		}

		/// <summary>
		///		Place the buttons on the display and add the click events
		/// </summary>
		/// <param name="item"> list of all menu items (Entree,Drink, or Side)</param>
		/// <param name="col"> Defines which column the items should be placed in </param>
		private void InitializeButtons(List<IOrderItem> item, int col)
		{
			for (int i = 0; i < item.Count; i++)
			{
				OrderButton b = new OrderButton();
				b.Content = item[i].Name;
				b.MenuItem = item[i];
				b.Click += ItemSelect;
				Grid.SetColumn(b, (col * 3) - 2);
				Grid.SetRow(b, ((i + uxButtonStartRow) * 3) + 1);
				uxOrderMenu.Children.Add(b);

				//	The default selection is a water
				if (b.MenuItem is WarriorWater)
				{
					b.IsChecked = true;
					_currentOrder = b;
				}
			}
		}

		/// <summary>
		///		Allows selection of an item. Only one item can be selected at a time
		///		When a new selection is made, the previous one is deselected and the 
		///		new selection is saved
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemSelect(Object sender, EventArgs e)
		{
			if(_currentOrder != null) _currentOrder.IsChecked = false;
			_currentOrder = (OrderButton)sender;
			_currentOrder.IsChecked = true;
		}
	}
}
