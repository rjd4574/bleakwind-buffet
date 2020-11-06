/*- MenuTest.cs							Created: 09SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Updated 06NOV20
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
using System;

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
		private static string[] _entrees = {"Briarheart Burger","Double Draugr","Thalmor Triple","Smokehouse Skeleton",
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
		/// Checks to make sure all items can be searched for by their
		/// name, size, or flavor. Searches are forced to uppercase
		/// to ensure search is case insensitive. 
		/// </summary>
		[Fact]
		public void MenuSearchShouldFilterCorrectOrders()
		{
			foreach (string search in _entrees)
				MatchSearchCriteria(search.ToUpper()) ;
			foreach (string search in _drinks)
				MatchSearchCriteria(search.ToUpper());
			foreach (string search in _sides)
				MatchSearchCriteria(search.ToUpper());
			foreach (string search in _sizes)
				MatchSearchCriteria(search.ToUpper());
			foreach (string search in _flavors)
				MatchSearchCriteria(search.ToUpper());
			//Test null search
			MatchSearchCriteria("");
		}

		/// <summary>
		/// Helper method for search filter. Searches for 
		/// the critera and ensures the menu.search comes back
		/// with the same results for Entrees, drinks, and sides
		/// </summary>
		/// <param name="search">Search criterea to match</param>
		private void MatchSearchCriteria(string search)
		{

			IEnumerable<IOrderItem> list;

			foreach (string type in Menu.Types)
			{
				list = Menu.Search(type, search);
				switch ( type )
				{
					case "Entree":
						foreach(IOrderItem item in Menu.Entrees() )
						{
							if (item.String.ToLower().Contains(search.ToLower()))
								Assert.Contains(list, (e) => e.ToString().Equals(item.ToString())); 
						}
						break;
					case "Drink":
						foreach (IOrderItem item in Menu.Drinks())
						{
							if (item.String.ToLower().Contains(search.ToLower()))
								Assert.Contains(list, (e) => e.ToString().Equals(item.ToString()));
						}
						break;
					case "Side":
						foreach (IOrderItem item in Menu.Sides())
						{
							if (item.String.ToLower().Contains(search.ToLower()))
								Assert.Contains(list, (e) => e.ToString().Equals(item.ToString()));
						}
						break;
					default: Assert.True(false);
						break;
				}
			}
				

		}

		/// <summary>
		/// Test to make sure that Manu can filter a list by the amount of calories contained in the order correctly
		/// </summary>
		[Fact]
		public void FilterByCaloriesShouldFilterCorrectOrders()
		{
			// No filter
			Assert.Equal(Menu.FullMenu().ToString(), Menu.FilterByCalories(Menu.FullMenu(), null, null).ToString());
			var full = Menu.FullMenu();
			IEnumerable<IOrderItem> list;


			// min calories only
			for (int min = 0; min <= 1000; min++)
			{
				list = Menu.FilterByCalories(Menu.FullMenu(), min, null);
				
				foreach (IOrderItem item in list)
					Assert.True(item.Calories >= min);

				foreach (IOrderItem item in Menu.FullMenu())
					if (item.Calories >= min)
						Assert.Contains(list, (e) => e.ToString().Equals(item.ToString()));
			}

			// max calories only
			for (int max = 0; max <= 1000; max++)
			{
				list = Menu.FilterByCalories(Menu.FullMenu(), null, max);

				foreach (IOrderItem item in list)
					Assert.True(item.Calories <= max);

				foreach (IOrderItem item in Menu.FullMenu())
					if (item.Calories <= max)
						Assert.Contains(list, (e) => e.ToString().Equals(item.ToString()));
			}

			// both a min and a max
			// Testing every possible calorie option takes too long, skip by hundreds.
			for (int min = 0; min <= 1000; min+=100)
			{
				for (int max = 0; max <= 1000; max+=100)
				{

					list = Menu.FilterByCalories(Menu.FullMenu(), min, max);

					foreach (IOrderItem item in list)
						Assert.True(item.Calories >= min && item.Calories <= max);

					foreach (IOrderItem item in Menu.FullMenu())
						if (item.Calories >= min && item.Calories <= max )
							Assert.Contains(list, (e) => e.ToString().Equals(item.ToString()));
				}
			}
		}

		/// <summary>
		/// Test to make sure that the menu can filter a list by the price of the order correctly
		/// </summary>
		[Fact]
		public void FilterByPriceShouldFilterCorrectOrders()
		{
			// No filter
			Assert.Equal(Menu.FullMenu().ToString(), Menu.FilterByPrice(Menu.FullMenu(), null, null).ToString());
			var full = Menu.FullMenu();
			IEnumerable<IOrderItem> list;


			// min Price only
			for (float min = 0; min <= 10.00; min+=.01f)
			{
				min = (float)Math.Round(min * 100f) / 100f;

				list = Menu.FilterByPrice(Menu.FullMenu(), min, null);

				foreach (IOrderItem item in list)
					Assert.True(item.Price >= min);

				foreach (IOrderItem item in Menu.FullMenu())
					if (item.Price >= min)
						Assert.Contains(list, (e) => e.ToString().Equals(item.ToString()));
			}

			// max Price only
			for (float max = 0; max <= 10.00; max+= .01f)
			{
				max = (float)Math.Round(max * 100f) / 100f;
				list = Menu.FilterByPrice(Menu.FullMenu(), null, max);

				foreach (IOrderItem item in list)
					Assert.True(item.Price <= max);

				foreach (IOrderItem item in Menu.FullMenu())
					if (item.Price <= max)
						Assert.Contains(list, (e) => e.ToString().Equals(item.ToString()));
			}

			// both a min and a max
			// Testing every possible calorie option takes too long, skip by Dimes.
			for (float min = 0; min <= 10.00; min += 1f)
			{
				for (float max = 0; max <= 10.00; max += .1f)
				{
					min = (float)Math.Round(min * 100f) / 100f;
					max = (float)Math.Round(max * 100f) / 100f;

					list = Menu.FilterByPrice(Menu.FullMenu(), min, max);

					foreach (IOrderItem item in list)
						Assert.True(item.Price >= min && item.Price <= max);

					foreach (IOrderItem item in Menu.FullMenu())
						if (item.Price >= min && item.Price <= max)
							Assert.Contains(list, (e) => e.ToString().Equals(item.ToString()));
				}
			}
		}














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