/*- ComboTest.cs						Created: 10OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 10OCT20
 *	Tests the Combo.cs class in the Data Library
 */

using Xunit;
using System;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data;
using System.ComponentModel;
using BleakwindBuffet.Data.Sides;

namespace BleakwindBuffet.DataTests.UnitTests
{
	/// <summary>
	/// Tests the functionality and accuracy of the Combo class
	/// </summary>
	public class ComboTest
	{
		/// <summary>
		/// Ensure that the combo impliments INotify
		/// </summary>
		[Fact]
		public void ShouldImplimentINotify()
		{
			var combo = new Combo();
			Assert.IsAssignableFrom<INotifyPropertyChanged>(combo);
		}

		/// <summary>
		/// Ensure that combo impliments from IOrderItem
		/// </summary>
		[Fact]
		public void ShouldImplimentIOrderItem()
		{
			var combo = new Combo();
			Assert.IsAssignableFrom<IOrderItem>(combo);
		}

		/// <summary>
		/// When adding a new entree, the Entree property should be notified.
		/// </summary>
		[Fact]
		public void AddingEntreeNotifiesEntreeProperty()
		{
			var combo = new Combo();
			var entree = new ThalmorTriple();

			Assert.PropertyChanged(combo, "Entree", () => { combo.Add(entree); });
		}

		/// <summary>
		/// When adding a new drink, the Drink property should be notified.
		/// </summary>
		[Fact]
		public void AddingDrinkNotifiesDrinkProperty()
		{
			var combo = new Combo();
			var soda = new SailorSoda();

			Assert.PropertyChanged(combo, "Drink", () => { combo.Add(soda); });
		}

		/// <summary>
		/// When adding a new side, the Side property should be notified.
		/// </summary>
		[Fact]
		public void AddingSideNotifiesSideProperty()
		{
			var combo = new Combo();
			var side = new MadOtarGrits();

			Assert.PropertyChanged(combo, "Side", () => { combo.Add(side); });
		}

		/// <summary>
		///	when adding any new IOrderItem, common propertyChanged events should occur.
		///	Use a helper method to ensure all are being notified.
		/// </summary>
		[Fact]
		public void AddingIOrderItemNotifiesCommonProperties()
		{
			var drink = new SailorSoda();
			var entree = new BriarheartBurger();
			var side = new DragonbornWaffleFries();

			CheckPropertyChangedWhenAddingIOrderItem(drink);
			CheckPropertyChangedWhenAddingIOrderItem(entree);
			CheckPropertyChangedWhenAddingIOrderItem(side);
		
		}	

		/// <summary>
		///		Method that can be used to check all common property changed events
		///		when adding a new IOrderItem to a combo menu
		/// </summary>
		/// <param name="item"></param>
		private void CheckPropertyChangedWhenAddingIOrderItem(IOrderItem item)
		{
			var combo = new Combo();

			Assert.PropertyChanged(combo, "Price", () => { combo.Add(item); });
			Assert.PropertyChanged(combo, "Calories", () => { combo.Add(item); });
			Assert.PropertyChanged(combo, "SpecialInstructions", () => { combo.Add(item); });
		}

		/// <summary>
		///		Changing the size inside of a combo meal should force a price notification
		///		for the combo
		/// </summary>
		[Fact]
		public  void IncreasingTheSizeOfAnIOrderItemNotifiesTheComboPrice()
		{
			var combo = new Combo();
			var drink = new SailorSoda();
			drink.Size = Size.Small;
			var side = new VokunSalad();
			side.Size = Size.Small;

			combo.Add(drink);
			combo.Add(side);

			Assert.PropertyChanged(combo, "Price", () => { drink.Size = Size.Large; });
			Assert.PropertyChanged(combo, "Price", () => { side.Size = Size.Large; });
		}

		/// <summary>
		///		Changing the size inside of a combo meal should force a Calories notification
		///		for the combo
		/// </summary>
		[Fact]
		public void IncreasingTheSizeOfAnIOrderItemNotifiesTheComboCalories()
		{
			var combo = new Combo();
			var drink = new SailorSoda();
			drink.Size = Size.Small;
			var side = new VokunSalad();
			side.Size = Size.Small;

			combo.Add(drink);
			combo.Add(side);

			Assert.PropertyChanged(combo, "Calories", () => { drink.Size = Size.Large; });
			Assert.PropertyChanged(combo, "Calories", () => { side.Size = Size.Large; });
		}

		/// <summary>
		/// Changing the customization values of an item in the combo should notify the 
		/// special instructions property
		/// </summary>
		[Fact]
		public void ChangingCustomizationOfIOrderItemsInComboNotifiesSpecialInstructions()
		{
			var combo = new Combo();
			var entree = new ThalmorTriple();
			entree.Bun = false;
			var drink = new SailorSoda();
			drink.Ice = false;

			combo.Add(entree);
			combo.Add(drink);

			Assert.PropertyChanged(combo, "SpecialInstructions", () => { entree.Bun = true; });
			Assert.PropertyChanged(combo, "SpecialInstructions", () => { drink.Ice = true; });
		}

		/// <summary>
		///		Add only one of the three meals and test their special instructions. This ensures
		///		the code gracefully handles not having a full combo meal.
		/// </summary>
		[Fact]
		public  void SpecialInstructionsShouldContainCorrectInstructionsForIncompleteCombo()
		{
			var combo = new Combo();
			AddTestEntree(combo);
			TestEntreeSpecialInstructions(combo);
			Assert.Equal(3, combo.SpecialInstructions.Count);

			combo = new Combo();
			AddTestDrink(combo);
			TestDrinkSpecialInstructions(combo);
			Assert.Equal(2, combo.SpecialInstructions.Count);

			combo = new Combo();
			AddTestSide(combo);
			TestSideSpecialInstructions(combo);
			Assert.Equal(1, combo.SpecialInstructions.Count);
		}

		/// <summary>
		/// Add all three meals into the combo and make sure it has the corrects special instructions
		/// </summary>
		[Fact]
		public void SpecialInstructionsShouldContainCorrectInstructionsForCompleteCombo()
		{
			var combo = new Combo();
			AddTestEntree(combo);
			AddTestDrink(combo);
			AddTestSide(combo);

			TestEntreeSpecialInstructions(combo);
			TestSideSpecialInstructions(combo);
			TestDrinkSpecialInstructions(combo);
		}


		/// <summary>
		///		Adds an entree into the given combo for testing.
		/// </summary>
		/// <param name="combo"></param>
		private void AddTestEntree(Combo combo)
		{
			var entree = new BriarheartBurger();
			entree.Ketchup = false;
			entree.Cheese = false;
			combo.Add(entree);
		}
		/// <summary>
		///		Tests that the combo contains teh correct special instructions for the
		///		'test entree'
		/// </summary>
		/// <param name="meal"></param>
		public  void TestEntreeSpecialInstructions(Combo meal)
		{
			Assert.Contains("=>Briarheart Burger",meal.SpecialInstructions);
			Assert.Contains("\t-->Hold ketchup", meal.SpecialInstructions);
			Assert.Contains("\t-->Hold cheese", meal.SpecialInstructions);
		}

		/// <summary>
		///		Adds an drink into the given combo for testing.
		/// </summary>
		/// <param name="combo"></param>
		private void AddTestDrink(Combo combo)
		{
			var drink = new CandlehearthCoffee();
			drink.Size = Size.Medium;
			drink.Decaf = true;
			drink.RoomForCream = true;

			combo.Add(drink);
		}
		/// <summary>
		///		Tests that the combo contains teh correct special instructions for the
		///		'test drink'
		/// </summary>
		/// <param name="meal"></param>
		public void TestDrinkSpecialInstructions(Combo meal)
		{
			
			Assert.Contains("=>Medium Decaf Candlehearth Coffee", meal.SpecialInstructions);
			Assert.Contains("\t-->Add cream", meal.SpecialInstructions);
		}

		/// <summary>
		///		Adds an side into the given combo for testing.
		/// </summary>
		/// <param name="combo"></param>
		private void AddTestSide(Combo combo)
		{
			var side = new FriedMiraak();
			side.Size = Size.Large;

			combo.Add(side);
		}
		/// <summary>
		///		Tests that the combo contains teh correct special instructions for the
		///		'test Side'
		/// </summary>
		/// <param name="meal"></param>
		public void TestSideSpecialInstructions(Combo meal)
		{
			Assert.Contains("=>Large Fried Miraak", meal.SpecialInstructions);
		}

		/// <summary>
		///		Ensure that the IsComplete property is true when the combo meal has been filled
		///		with an entree, drink and side
		/// </summary>
		[Fact]
		public void IsCompleteTrueWhenCompleteCombo()
		{
			var combo = new Combo(new BriarheartBurger(), new AretinoAppleJuice(), new VokunSalad());
			Assert.True(combo.IsComplete);
		}

		/// <summary>
		/// Ensure that IsComplete property is false when the combo meal does not have
		/// one of each entree, drink, and side.
		/// </summary>
		[Fact]
		public void IsCompleteFalseWhenNotCompleteCombo()
		{
			var combo = new Combo();
			Assert.False(combo.IsComplete);
			AddTestDrink(combo);
			Assert.False(combo.IsComplete);
			AddTestEntree(combo);
			Assert.False(combo.IsComplete);

			combo = new Combo();
			AddTestSide(combo);
			Assert.False(combo.IsComplete);
			AddTestDrink(combo);
			Assert.False(combo.IsComplete);
		}

		/// <summary>
		///		Ensure that the combo reflects the correct price. These are incomplete
		///		combo's, so the discount should not apply.
		/// </summary>
		[Fact]
		public void ComboHasCorrectPriceForIncompleteCombo()
		{
			var combo = new Combo();
			var drink = new AretinoAppleJuice();
			var entree = new BriarheartBurger();
			var side = new VokunSalad();
			Assert.Equal(0, combo.Price);

			combo.Add(drink);
			Assert.Equal(drink.Price, combo.Price);
			combo.Add(entree);
			Assert.Equal((drink.Price + entree.Price), combo.Price);

			combo = new Combo();
			combo.Add(side);
			Assert.Equal(side.Price, combo.Price);
			combo.Add(drink);
			Assert.Equal((side.Price + drink.Price), combo.Price);
		}

		/// <summary>
		///		Ensure the combo reflects the correct price and a discount when it is complete
		/// </summary>
		[Fact]
		public void ComboHasCorrectPriceForCompleteCombo()
		{
			var drink = new AretinoAppleJuice();
			var entree = new BriarheartBurger();
			var side = new VokunSalad();
			var combo = new Combo(entree, drink, side);

			Assert.Equal((drink.Price + entree.Price + side.Price - 1.00), combo.Price);
		}

		/// <summary>
		///		Ensure that the combo reflects the correct calories.
		///		This to ensure null IOrderItems are handled gracefully
		/// </summary>
		[Fact]
		public void ComboHasCorrectCaloriesForIncompleteCombo()
		{
			var combo = new Combo();
			var drink = new AretinoAppleJuice();
			var entree = new BriarheartBurger();
			var side = new VokunSalad();
			Assert.Equal((uint)0, combo.Calories);

			combo.Add(drink);
			Assert.Equal(drink.Calories, combo.Calories);
			combo.Add(entree);
			Assert.Equal((drink.Calories + entree.Calories), combo.Calories);

			combo = new Combo();
			combo.Add(side);
			Assert.Equal(side.Calories, combo.Calories);
			combo.Add(drink);
			Assert.Equal((side.Calories + drink.Calories), combo.Calories);
		}

		/// <summary>
		///		Ensure the combo reflects the correct Calories when it is complete
		/// </summary>
		[Fact]
		public void ComboHasCorrectCaloriesForCompleteCombo()
		{
			var drink = new AretinoAppleJuice();
			var entree = new BriarheartBurger();
			var side = new VokunSalad();
			var combo = new Combo(entree, drink, side);

			Assert.Equal((drink.Calories + entree.Calories + side.Calories), combo.Calories);
		}
	}
}
