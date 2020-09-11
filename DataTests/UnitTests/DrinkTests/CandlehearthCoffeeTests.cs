/*
 * Author: Zachery Brunner
 * Class: CandlehearthCoffeeTests.cs
 * Purpose: Test the CandlehearthCoffee.cs class in the Data library
 */
/*- Edited by: Ryan Dentremont				Edited: 03SEP20
 * 											CIS 400 MWF @ 1330
 */
using Xunit;

using System;
// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
	/// <summary>
	///		Test the correct functionality of the CandlehearthCoffee class
	/// </summary>
    public class CandlehearthCoffeeTests
    {
		/// <summary>
		///		Ensure that this drink inherits from Drink
		/// </summary>
		[Fact]
		public void ShouldBeADrink()
		{
			var coffee = new CandlehearthCoffee();
			Assert.IsAssignableFrom<Drink>(coffee);
		}

		/// <summary>
		///		Ensure there is no ice by default 
		/// </summary>
		[Fact]
        public void ShouldNotIncludeIceByDefault()
        {
			var drink = new CandlehearthCoffee();
			Assert.False(drink.Ice);
		}

		/// <summary>
		///		Ensure the drink is not decaf by default
		/// </summary>
        [Fact]
        public void ShouldNotBeDecafByDefault()
        {
			var drink = new CandlehearthCoffee();
			Assert.False(drink.Decaf);
		}

		/// <summary>
		///		Ensure there is no room for cream by default
		/// </summary>
        [Fact]
        public void ShouldNotHaveRoomForCreamByDefault()
        {
			var drink = new CandlehearthCoffee();
			Assert.False(drink.RoomForCream);
		}

		/// <summary>
		///		Ensure the drink is small by default
		/// </summary>
        [Fact]
        public void ShouldBeSmallByDefault()
        {
			var drink = new CandlehearthCoffee();
			Assert.Equal(Size.Small, drink.Size);
		}

		/// <summary>
		///		Ensure ice can be properly set and retrieved
		///		- Default is false
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetIce()
        {
			var drink = new CandlehearthCoffee();

			drink.Ice = true;
			Assert.True(drink.Ice);

			drink.Ice = false;
			Assert.False(drink.Ice);
		}

		/// <summary>
		///		Ensure decaf can be properly set and retrieved
		///		- Default is false
		/// </summary>
        [Fact]
        public void ShouldBeAbleToSetDecaf()
        {
			var drink = new CandlehearthCoffee();

			drink.Decaf = true;
			Assert.True(drink.Decaf);

			drink.Decaf = false;
			Assert.False(drink.Decaf);
		}

		/// <summary>
		///		Ensure room for cream can be properly set and retrieved
		///		- Default is false
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetRoomForCream()
        {
			var drink = new CandlehearthCoffee();

			drink.RoomForCream = true;
			Assert.True(drink.RoomForCream);

			drink.RoomForCream = false;
			Assert.False(drink.RoomForCream);	
		}

		/// <summary>
		///		Ensure the size can be properly set and retrieved.
		///		- Default size is small
		///		- Shouldn't allow any Size not defined in Enum.Size
		/// </summary>
		/// <exception cref="NotImplementedException">
		///		Should be thrown for invalid size.
		/// </exception>"
		[Fact]
        public void ShouldBeAbleToSetSize()
        {
			var drink = new CandlehearthCoffee();

			drink.Size = Size.Medium;
			Assert.Equal(Size.Medium, drink.Size);

			drink.Size = Size.Small;
			Assert.Equal(Size.Small, drink.Size);

			// Undefined size (too small)
			Assert.Throws<NotImplementedException>(() =>
			{
				drink.Size--;
			});

			drink.Size = Size.Large;
			Assert.Equal(Size.Large, drink.Size);

			// Undefined size (too large)
			Assert.Throws<NotImplementedException>(() =>
			{
				drink.Size++;
			});
		}

		/// <summary>
		///		Ensure the price of the drink matches with its size
		/// </summary>
		/// <param name="size">The set size of the drink</param>
		/// <param name="price">The expected price of the drink</param>
		[Theory]
        [InlineData(Size.Small, 0.75)]
        [InlineData(Size.Medium, 1.25)]
        [InlineData(Size.Large, 1.75)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
			var drink = new CandlehearthCoffee();
			drink.Size = size;

			Assert.Equal(price, drink.Price);
		}

		/// <summary>
		///		Ensure the calories of the drink matches with its size
		/// </summary>
		/// <param name="size">The set size of the drink</param>
		/// <param name="cal">THe expected amount of calories in the drink</param>
		[Theory]
        [InlineData(Size.Small, 7)]
        [InlineData(Size.Medium, 10)]
        [InlineData(Size.Large, 20)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
			var drink = new CandlehearthCoffee();
			drink.Size = size;

			Assert.Equal(cal, drink.Calories);
		}

		/// <summary>
		///		Ensure the correct special instructions are included
		/// </summary>
		/// <param name="includeIce">whether ice is requested in the drink</param>
		/// <param name="includeCream">whether room for cream is requested in the drink</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeCream)
        {
			var drink = new CandlehearthCoffee();

			drink.Ice = includeIce;
			drink.RoomForCream = includeCream;

			if (includeIce) Assert.Contains("Add ice", drink.SpecialInstructions);
			if (includeCream) Assert.Contains("Add cream", drink.SpecialInstructions);
			if (!includeIce && !includeCream) Assert.Empty(drink.SpecialInstructions);
		}

		/// <summary>
		///		Ensure that the drink has the correct ToString output
		///		based on its properties
		/// </summary>
		/// <param name="decaf">Whether the drink is decaf</param>
		/// <param name="size">Size of the drink</param>
		/// <param name="name">The expected ToString output</param>
		[Theory]
        [InlineData(true, Size.Small, "Small Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Medium, "Medium Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Large, "Large Decaf Candlehearth Coffee")]
        [InlineData(false, Size.Small, "Small Candlehearth Coffee")]
        [InlineData(false, Size.Medium, "Medium Candlehearth Coffee")]
        [InlineData(false, Size.Large, "Large Candlehearth Coffee")]
        public void ShouldReturnCorrectToStringBasedOnSize(bool decaf, Size size, string name)
        {
			var drink = new CandlehearthCoffee();

			drink.Size = size;
			drink.Decaf = decaf;

			Assert.Equal(name, drink.ToString());
		}
    }
}
