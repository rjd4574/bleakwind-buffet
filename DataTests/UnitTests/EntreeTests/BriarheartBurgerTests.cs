/*
 * Author: Zachery Brunner
 * Class: BriarheartBurgerTests.cs
 * Purpose: Test the BriarheartBurger.cs class in the Data library
 */
/*- Edited by: Ryan Dentremont				Edited: 03SEP20
 * 											CIS 400 MWF @ 1330
 */

using Xunit;

// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
	/// <summary>
	///		Tests the correct functionality of the Briarheart Burger Entree
	/// </summary>
    public class BriarheartBurgerTests
    {
		/// <summary>
		///		Ensure this IOrderItem is implimenting the required
		///		INotifyPropertyChanged Interface
		/// </summary>
		[Fact]
		public void ShouldImplimentINotify()
		{
			var orderItem = new BriarheartBurger();
			Assert.IsAssignableFrom<INotifyPropertyChanged>(orderItem);
		}

		/// <summary>
		///		Ensure that this Entree notifies Bun when Bun is changed
		/// </summary>
		[Fact]
		public void ChangingBunNotifiesBunProperty()
		{
			var entree = new BriarheartBurger();
			entree.Bun = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Bun", () => { entree.Bun = true; });
			Assert.PropertyChanged(entree, "Bun", () => { entree.Bun = false; });
		}

		/// <summary>
		///		Ensure that this Entree notifies Ketchup when Ketchup is changed
		/// </summary>
		[Fact]
		public void ChangingKetchupNotifiesKetchupProperty()
		{
			var entree = new BriarheartBurger();
			entree.Ketchup = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Ketchup", () => { entree.Ketchup = true; });
			Assert.PropertyChanged(entree, "Ketchup", () => { entree.Ketchup = false; });
		}

		/// <summary>
		///		Ensure that this Entree notifies Mustard when Mustard is changed
		/// </summary>
		[Fact]
		public void ChangingMustardNotifiesMustardProperty()
		{
			var entree = new BriarheartBurger();
			entree.Mustard = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Mustard", () => { entree.Mustard = true; });
			Assert.PropertyChanged(entree, "Mustard", () => { entree.Mustard = false; });
		}

		/// <summary>
		///		Ensure that this Entree notifies Pickle when Pickle is changed
		/// </summary>
		[Fact]
		public void ChangingPickleNotifiesPickleProperty()
		{
			var entree = new BriarheartBurger();
			entree.Pickle = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Pickle", () => { entree.Pickle = true; });
			Assert.PropertyChanged(entree, "Pickle", () => { entree.Pickle = false; });
		}

		/// <summary>
		///		Ensure that this Entree notifies Cheese when Cheese is changed
		/// </summary>
		[Fact]
		public void ChangingCheeseNotifiesCheeseProperty()
		{
			var entree = new BriarheartBurger();
			entree.Cheese = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Cheese", () => { entree.Cheese = true; });
			Assert.PropertyChanged(entree, "Cheese", () => { entree.Cheese = false; });
		}

		/// <summary>
		///		Ensure that this entree inherits from Entree
		/// </summary>
		[Fact]
		public void ShouldBeAnEntree()
		{
			var entree = new BriarheartBurger();
			Assert.IsAssignableFrom<Entree>(entree);
		}

		/// <summary>
		///		Ensure that this item implements the IOrderItem interface
		/// </summary>
		[Fact]
		public void ShouldBeAnIOrderItem()
		{
			var orderItem = new BriarheartBurger();
			Assert.IsAssignableFrom<IOrderItem>(orderItem);
		}

		/// <summary>
		///		Ensure there is a bun by default
		/// </summary>
		[Fact]
        public void ShouldIncludeBunByDefault()
        {
			var entree = new BriarheartBurger();
			Assert.True(entree.Bun);
        }

		/// <summary>
		///		Insure there is ketchup by default
		/// </summary>
        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
			var entree = new BriarheartBurger();
			Assert.True(entree.Ketchup);
		}

		/// <summary>
		///		Insure there is mustard by default
		/// </summary>
        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
			var entree = new BriarheartBurger();
			Assert.True(entree.Mustard);
		}

		/// <summary>
		///		Ensure there is pickle by default
		/// </summary>
        [Fact]
        public void ShouldIncludePickleByDefault()
        {
			var entree = new BriarheartBurger();
			Assert.True(entree.Pickle);
		}

		/// <summary>
		///		Ensure there is cheese by default
		/// </summary>
        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
			var entree = new BriarheartBurger();
			Assert.True(entree.Cheese);
		}

		/// <summary>
		///		Ensure that bun can be properly set and retrieved
		///		- Default is true
		/// </summary>
        [Fact]
        public void ShouldBeAbleToSetBun()
        {
			var entree = new BriarheartBurger();

			entree.Bun = false;
			Assert.False(entree.Bun);

			entree.Bun = true;
			Assert.True(entree.Bun);
        }

		/// <summary>
		///		Ensure that kethup can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetKetchup()
        {
			var entree = new BriarheartBurger();

			entree.Ketchup = false;
			Assert.False(entree.Ketchup);

			entree.Ketchup = true;
			Assert.True(entree.Ketchup);
		}

		/// <summary>
		///		Ensure that Mustard can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetMustard()
        {
			var entree = new BriarheartBurger();

			entree.Mustard = false;
			Assert.False(entree.Mustard);

			entree.Mustard = true;
			Assert.True(entree.Mustard);
		}

		/// <summary>
		///		Ensure that Pickle can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetPickle()
        {
			var entree = new BriarheartBurger();

			entree.Pickle = false;
			Assert.False(entree.Pickle);

			entree.Pickle = true;
			Assert.True(entree.Pickle);
		}

		/// <summary>
		///		Ensure that Cheese can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetCheese()
        {
			var entree = new BriarheartBurger();

			entree.Cheese = false;
			Assert.False(entree.Cheese);

			entree.Cheese = true;
			Assert.True(entree.Cheese);
		}

		/// <summary>
		///		Ensure that the entree is priced correctly
		/// </summary>
        [Fact]
        public void ShouldReturnCorrectPrice()
        {
			var entree = new BriarheartBurger();
			Assert.Equal(6.32, entree.Price);
        }

		/// <summary>
		///		Ensure the entree has the correct amount of calories
		/// </summary>
        [Fact]
        public void ShouldReturnCorrectCalories()
        {
			var entree = new BriarheartBurger();
			Assert.Equal((uint)743, entree.Calories);
		}

		/// <summary>
		///		Ensure the correct special instructions are included
		/// </summary>
		/// <param name="includeBun">is bun requested</param>
		/// <param name="includeKetchup">is ketchup requested</param>
		/// <param name="includeMustard">is mustard requested</param>
		/// <param name="includePickle">is pickle requested</param>
		/// <param name="includeCheese">is cheese requested</param>
		[Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese)
        {
			var entree = new BriarheartBurger();
			entree.Bun = includeBun;
			entree.Ketchup = includeKetchup;
			entree.Mustard = includeMustard;
			entree.Pickle = includePickle;
			entree.Cheese = includeCheese;

			if (!includeBun) Assert.Contains("Hold bun",entree.SpecialInstructions);
			if (!includeKetchup) Assert.Contains("Hold ketchup", entree.SpecialInstructions);
			if (!includeMustard) Assert.Contains("Hold mustard", entree.SpecialInstructions);
			if (!includePickle) Assert.Contains("Hold pickle", entree.SpecialInstructions);
			if (!includeCheese) Assert.Contains("Hold cheese", entree.SpecialInstructions);
			if (includeBun && includeKetchup && includeMustard && includePickle && includeCheese)
				Assert.Empty(entree.SpecialInstructions);
		}

		/// <summary>
		///		Ensure the entree has the correct ToString output
		/// </summary>
        [Fact]
        public void ShouldReturnCorrectToString()
        {
			Assert.Equal("Briarheart Burger", new BriarheartBurger().ToString());
        }
    }
}