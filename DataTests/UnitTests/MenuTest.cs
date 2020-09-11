/*- MenuTest.cs							Created: 09SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Tests the Menu.cs class in the Data library
*/

using System.Collections.Generic;
using Xunit;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System.Linq;

namespace BleakwindBuffet.DataTests.UnitTests
{

	/// <summary>
	///		Tests the correct functionality of the Menu 
	/// </summary>
	public class MenuTest
	{
		/// <summary>
		/// Array containing all of the string valuese of the entrees
		/// </summary>
		private string[] _entrees = {"Briarheart Burger","Double Draugr","Thalmor Triple","Smokehouse Skeleton",
									"Garden Orc Omelette","Philly Poacher","Thugs T-Bone" };
		/// <summary>
		/// Array containing all of the string valuese of the drinks
		/// </summary>
		private string[] _drinks = { "Aretino Apple Juice", "Candlehearth Coffee", "Decaf Candlehearth Coffee",
									"Markarth Milk", "Warrior Water" };
		/// <summary>
		/// Array containing all of the string valuese of the sides
		/// </summary>
		private string[] _sides = { "Vokun Salad", "Fried Miraak", "Mad Otar Grits", "Dragonborn Waffle Fries" };
		/// <summary>
		/// Array containing all of the string valuese of the Enum Sizes
		/// </summary>
		private string[] _sizes = { "Small", "Medium", "Large" };
		/// <summary>
		/// Array containing all of the string valuese of the Enum flavors
		/// </summary>
		private string[] _flavors = { "Blackberry", "Cherry", "Grapefruit", "Lemon", "Peach", "Watermelon" };


		/// <summary>
		///		Ensure that the	menu returns the correct 
		///		IEnumberable list of entree items
		/// </summary>
		[Fact]
		public void MenuShouldReturnTheCorrectEntrees()
		{
			CheckForAllEntreeItems(Menu.Entrees());
		}

		/// <summary>
		///		Ensure the menu returns the correct number of IEnumberable entree items
		///		This can be used to ensure no duplicate items
		/// </summary>
		[Fact]
		public void MenuShouldReturnTheCorrectNumberOfEntrees()
		{
			Assert.Equal(7, Menu.Entrees().Count());
		}

		/// <summary>
		///		Ensure the menu returns the correct number of IEnumberable drink items
		///		This can be used to ensure no duplicate items
		/// </summary>
		[Fact]
		public void MenuShouldReturnTheCorrectDrinks()
		{
			CheckForAllDrinkItems(Menu.Drinks());
		}

		/// <summary>
		///		Ensure the menu returns the correct number of IEnumberable drink items
		///		This can be used to ensure no duplicate items
		/// </summary>
		[Fact]
		public void MenuShouldReturnTheCorrectNumberOfDrinks()
		{
			Assert.Equal(33, Menu.Drinks().Count());
		}

		/// <summary>
		///		Ensure the menu returns the correct number of IEnumberable side items
		///		This can be used to ensure no duplicate items
		/// </summary>
		[Fact]
		public void MenuShouldReturnTheCorrectSides()
		{
			CheckForAllSideItems(Menu.Sides());
		}

		/// <summary>
		///		Ensure the menu returns the correct number of IEnumberable side items
		///		This can be used to ensure no duplicate items
		/// </summary>
		[Fact]
		public void MenuShouldReturnTheCorrectNumberOfSides()
		{
			Assert.Equal(12, Menu.Sides().Count());
		}

		/// <summary>
		///		Ensure the menu returns the correct number of IEnumberable items
		///		This should return every IOrderItem on the list (Entree, Drink, and Side)
		///		To do this, we can make use of the previously built in test for entree,
		///		drink, and side on the same list.
		/// </summary>
		[Fact]
		public void MenuShouldReturnTheCorrectFullMenu()
		{
			IEnumerable<IOrderItem> fullMenu = Menu.FullMenu();
			CheckForAllEntreeItems(fullMenu);
			CheckForAllDrinkItems(fullMenu);
			CheckForAllSideItems(fullMenu);
		}

		/// <summary>
		///		Ensure the menu returns the correct number of IEnumberable items
		///		This can be used to ensure no duplicate items
		/// </summary>
		[Fact]
		public void MenuShouldReturnTheCorrectNumberOfFullMenuItems()
		{
			Assert.Equal(52, Menu.FullMenu().Count());
		}

		/// <summary>
		///		Testing method can be called by any test. When passed a list, it will
		///		check to make sure it contains an instance of every defined Entree type.
		///		Comparison is completed through the use of their ToString().
		/// </summary>
		/// <param name="menuItems">List of Entree from the menu to be checked</param>
		private void CheckForAllEntreeItems(IEnumerable<IOrderItem> menuItems)
		{
			foreach( string entree in _entrees)
				Assert.Contains(menuItems, (e) => e.ToString().Equals($"{entree}"));
		}

		/// <summary>
		///		Testing method can be called by any test. When passed a list, it will
		///		check to make sure it contains an instance of every defined Drink type.
		///		Comparison is completed through the use of their ToString().
		/// </summary>
		/// <param name="menuItems">List of Drink from the menu to be checked</param>
		private void CheckForAllDrinkItems(IEnumerable<IOrderItem> menuItems)
		{
			foreach( string drink in _drinks)
			{
				foreach( string size in _sizes)
				{
					Assert.Contains(menuItems, (e) => e.ToString().Equals($"{size} {drink}"));
					foreach( string flavor in _flavors)
						Assert.Contains(menuItems, (e) => e.ToString().Equals($"{size} {flavor} Sailor Soda"));
				}
			}
		}

		/// <summary>
		///		Testing method can be called by any test. When passed a list, it will
		///		check to make sure it contains an instance of every defined Side type.
		///		Comparison is completed through the use of their ToString().
		/// </summary>
		/// <param name="menuItems">List of Side from the menu to be checked</param>
		private void CheckForAllSideItems(IEnumerable<IOrderItem> menuItems)
		{
			foreach (string side in _sides)
			{ 
				foreach (string size in _sizes)
					Assert.Contains(menuItems, (e) => e.ToString().Equals($"{size} {side}"));
			}
		}
	}
}