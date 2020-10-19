/*- Combo.cs							Created: 12OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 12OCT20
 *	Allows customization of the Combo Meal
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BuffetMenu = BleakwindBuffet.Data.Menu;

namespace PointOfSale
{
	/// <summary>
	/// Interaction logic for ComboMenu.xaml
	/// </summary>
	public partial class ComboMenu : CustomizationMenu
	{
		List<IOrderItem> _entreeList;
		List<IOrderItem> DrinkList => (List<IOrderItem>)BuffetMenu.DrinkItems();
		List<IOrderItem> SideList => (List<IOrderItem>)BuffetMenu.SideItems();

		public ComboMenu(IOrderItem combo)
		{
			InitializeComponent();
			DataContext = (Combo)combo;
			LoadItemLists();
			combo.PropertyChanged += OnOrderChanged;
			
		}

		private void LoadItemLists()
		{
			// Set Customization buttons to the selected IOrderItem
			uxEntreeCustomizeButton.MenuItem = ((Combo)DataContext).Entree;
			uxDrinkCustomizeButton.MenuItem = ((Combo)DataContext).Drink;
			uxSideCustomizeButton.MenuItem = ((Combo)DataContext).Side;

			// populate the options from the order lists
			foreach (IOrderItem item in ((Combo)DataContext).EntreeList)
				uxEntreeList.Items.Add(item);
			foreach (IOrderItem item in ((Combo)DataContext).DrinkList)
				uxDrinkList.Items.Add(item);
			foreach (IOrderItem item in ((Combo)DataContext).SideList)
				uxSideList.Items.Add(item);
		}

		private void OnOrderChanged(object sender, PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case "Entree":
					uxEntreeCustomizeButton.MenuItem = ((Combo)DataContext).Entree;
					break;
				case "Drink":
					uxDrinkCustomizeButton.MenuItem = ((Combo)DataContext).Drink;
					break;
				case "Side":
					uxSideCustomizeButton.MenuItem = ((Combo)DataContext).Side;
					break;
				default: break;
			}
		}
	}
}
