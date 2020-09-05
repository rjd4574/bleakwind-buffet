/*
 * Author: Zachery Brunner
 * Class: AretinoAppleJuiceTests.cs
 * Purpose: Test the AretinoAppleJuice.cs class in the Data library
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
	///		Test the functionality of the Aretino Apple Juice class
	/// </summary>
    public class AretinoAppleJuiceTests
    {
		/// <summary>
		///		Ensure there is no ice by default
		/// </summary>
        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {
			var drink = new AretinoAppleJuice();
			Assert.False(drink.Ice);
        }

		/// <summary>
		///		Ensure the default size is small
		/// </summary>
        [Fact]
        public void ShouldBeSmallByDefault()
        {
			var drink = new AretinoAppleJuice();
			Assert.Equal(Size.Small, drink.Size);
        }

		/// <summary>
		///		Ensure Ice can be properly set and retrieved
		///		- default is false
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetIce()
        {
			var drink = new AretinoAppleJuice();

			drink.Ice = true;
			Assert.True (drink.Ice);

			drink.Ice = false;
			Assert.False(drink.Ice);
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
			var drink = new AretinoAppleJuice();

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
        [InlineData(Size.Small, 0.62)]
        [InlineData(Size.Medium, 0.87)]
        [InlineData(Size.Large, 1.01)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
			var drink = new AretinoAppleJuice();
			drink.Size = size;

			Assert.Equal(price, drink.Price);
		}

		/// <summary>
		///		Ensure the calories of the drink matches with its size
		/// </summary>
		/// <param name="size">The set size of the drink</param>
		/// <param name="cal">THe expected amount of calories in the drink</param>
		[Theory]
        [InlineData(Size.Small, 44)]
        [InlineData(Size.Medium, 88)]
        [InlineData(Size.Large, 132)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
			var drink = new AretinoAppleJuice();
			drink.Size = size;

			Assert.Equal(cal, drink.Calories);
		}

		/// <summary>
		///		Ensure the correct special instructions are included
		/// </summary>
		/// <param name="includeIce">Whether or not Ice is requested in the drink</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce)
        {
			var drink = new AretinoAppleJuice();

			drink.Ice = includeIce;

			if (!includeIce) Assert.Empty(drink.SpecialInstructions);
			if (includeIce) Assert.Contains("Add ice", drink.SpecialInstructions);
		}

		/// <summary>
		///		Ensure that the drink has the correct ToString output
		///		based on its properties
		/// </summary>
		/// <param name="size">The size of the drink</param>
		/// <param name="name">The expected ToString output</param>
		[Theory]
        [InlineData(Size.Small, "Small Aretino Apple Juice")]
        [InlineData(Size.Medium, "Medium Aretino Apple Juice")]
        [InlineData(Size.Large, "Large Aretino Apple Juice")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
			var drink = new AretinoAppleJuice();

			drink.Size = size;

			Assert.Equal(name, drink.ToString());
		}
    }
}