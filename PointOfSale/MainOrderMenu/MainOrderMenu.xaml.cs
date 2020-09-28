/*- MainOrderMenu.cs					Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
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
	public partial class MainOrderMenu : UserControl
	{
		/// <summary>
		///		Tax Rate
		/// </summary>
		private static double TAX = .10;
		/// <summary>
		///		The order menu screen where user can select a menu item
		/// </summary>
		private OrderMenu _menu = new OrderMenu();
		/// <summary>
		///		Item menu used to customize selection
		/// </summary>
		private IMenuItem _menuItem;
		/// <summary>
		///		Collection of all IOrderItems in the current order
		/// </summary>
		private List<IOrderItem> _orderedItems = new List<IOrderItem>();

		/// <summary>
		///		Constructor. Set up and initialize all components in the point of sale
		/// </summary>
		public MainOrderMenu()
		{
			InitializeComponent();
			ResetMenu();
			UpdatePrice();
		}

		/// <summary>
		///		Set menu to its default state. 
		/// </summary>
		private void ResetMenu()
		{
			uxOrderMenuBorder.Child = _menu;
			uxMenuBackButton.IsEnabled = false;
			uxMenuNextButton.IsEnabled = true;
			uxPlaceOrderButton.IsEnabled = false;
			uxMenuAddOrderButton.IsEnabled = false;			
		}

		/// <summary>
		///		Allows customization of selected IOrderItem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NextButtonClick(object sender, RoutedEventArgs e)
		{
			// Activate the customization screen for the selection
			ActivateCustomizationScreen(_menu.Selection);
			// make sure the proper buttons are enabled/disabled
			uxMenuAddOrderButton.IsEnabled = true;
			uxMenuNextButton.IsEnabled = false;
			uxMenuBackButton.IsEnabled = true;
		}

		/// <summary>
		///		Allow the user to back out of its previous selction without
		///		buying anything
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BackButtonClick ( Object sender, RoutedEventArgs e)
		{
			ResetMenu();
		}

		/// <summary>
		///		Adds selected items with its customizations to the list
		///		of ordered items for this transaction
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddToOrderClick(object sender, RoutedEventArgs e)
		{
			_orderedItems.Add(_menuItem.Order);
			uxOrderListView.Items.Add(_menuItem.Order.ToString());
			UpdatePrice();
			ResetMenu();
		}

		/// <summary>
		///		Remove an item from the order list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RemoveOrderClick( object sender, RoutedEventArgs e)
		{
			_orderedItems.RemoveAt(uxOrderListView.SelectedIndex);
			uxOrderListView.Items.RemoveAt(uxOrderListView.SelectedIndex);
			UpdatePrice();
		}

		/// <summary>
		///		This method can be called anytime there has been a change to the 
		///		order. It will re-calculate the price and display it in your summery
		/// </summary>
		private void UpdatePrice()
		{
			double subtotal = 0;
			foreach (IOrderItem item in _orderedItems)
				subtotal += item.Price;
			uxSubtotalBlock.Text = String.Format("Subtotal: ${0:0.00}", subtotal);
			uxTaxBlock.Text = string.Format("Tax: ${0:0.00}", (subtotal*TAX));
			uxGrandTotal.Text = string.Format("Grand Total: ${0:0.00}", (subtotal * (1+TAX)));
		}

		/// <summary>
		///		Identifies the exact type of IOrderItem requested,
		///		and brings up the customization screen for that item
		/// </summary>
		/// <param name="order"> the IOrderItem currently selected </param>
		private void ActivateCustomizationScreen(IOrderItem order)
		{
			if (order is Entree)
			{
				if (order is BriarheartBurger) _menuItem = new BriarheartBurgerMenu();
				else if (order is DoubleDraugr) _menuItem = new DoubleDraugrMenu();
				else if (order is GardenOrcOmelette) _menuItem = new GardenOrcOmeletteMenu();
				else if (order is PhillyPoacher) _menuItem = new PhillyPoacherMenu();
				else if (order is SmokehouseSkeleton) _menuItem = new SmokehouseSkeletonMenu();
				else if (order is ThalmorTriple) _menuItem = new ThalmorTripleMenu();
				else if (order is ThugsTBone) _menuItem = new ThugsTBoneMenu();
			}
			else if ( order is Drink)
			{
				if (order is AretinoAppleJuice) _menuItem = new AretinoAppleJuiceMenu();
				else if (order is CandlehearthCoffee) _menuItem = new CandlehearthCoffeeMenu();
				else if (order is MarkarthMilk) _menuItem = new MarkarthMilkMenu();
				else if (order is SailorSoda) _menuItem = new SailorSodaMenu();
				else if (order is WarriorWater) _menuItem = new WarriorWaterMenu();
			}
			else if ( order is Side)
			{
				if (order is DragonbornWaffleFries) _menuItem = new DragonbornWaffleFriesMenu();
				else if (order is FriedMiraak) _menuItem = new FriedMiraakMenu();
				else if (order is MadOtarGrits) _menuItem = new MadOtarGritsMenu();
				else if (order is VokunSalad) _menuItem = new VokunSaladMenu();
			}

			uxOrderMenuBorder.Child = (UserControl)_menuItem;
		}
	}
}
