/*
 * Author: Zachery Brunner
 * Class: MarkarthMilkTests.cs
 * Purpose: Test the MarkarthMilk.cs class in the Data library
 */

/*- Edited by: Ryan Dentremont						Edited: 03SEP20
 * 													CIS 400 MWF @ 1330
 */
using Xunit;
using System;
// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data;


namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
	/// <summary>
	///		Tests the correct functionality of the MarkarthMilk class
	/// </summary>
	public class MarkarthMilkTests
    {
		/// <summary>
		///		Ensure that this drink inherits from Drink
		/// </summary>
		[Fact]
		public void ShouldBeADrink()
		{
			var milk = new MarkarthMilk();
			Assert.IsAssignableFrom<Drink>(milk);
		}

		/// <summary>
		///		Ensure that this item implements the IOrderItem interface
		/// </summary>
		[Fact]
		public void ShouldBeAnIOrderItem()
		{
			var orderItem = new MarkarthMilk();
			Assert.IsAssignableFrom<IOrderItem>(orderItem);
		}

		/// <summary>
		///		Ensure the drink does not include Ice by default
		/// </summary>
		[Fact]
        public void ShouldNotIncludeIceByDefault()
        {
			var drink = new MarkarthMilk();
			Assert.False(drink.Ice);
        }

		/// <summary>
		///		Ensure the default size of the drink is small
		/// </summary>
        [Fact]
        public void ShouldBySmallByDefault()
        {
			var drink = new MarkarthMilk();
			Assert.Equal(Size.Small, drink.Size);
        }

		/// <summary>
		///		Ensure Ice can be properly set and retrieved
		///		- default is false
		/// </summary>
        [Fact]
        public void ShouldByAbleToSetIce()
        {
			var drink = new MarkarthMilk();

			drink.Ice = true;
			Assert.True(drink.Ice);

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
			var drink = new MarkarthMilk();

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
        [InlineData(Size.Small, 1.05)]
        [InlineData(Size.Medium, 1.11)]
        [InlineData(Size.Large, 1.22)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
			var drink = new MarkarthMilk();
			drink.Size = size;

			Assert.Equal(price, drink.Price);
		}

		/// <summary>
		///		Ensure the calories of the drink matches with its size
		/// </summary>
		/// <param name="size">The set size of the drink</param>
		/// <param name="cal">THe expected amount of calories in the drink</param>
		[Theory]
        [InlineData(Size.Small, 56)]
        [InlineData(Size.Medium, 72)]
        [InlineData(Size.Large, 93)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
			var drink = new MarkarthMilk();
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
			var drink = new MarkarthMilk();

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
        [InlineData(Size.Small, "Small Markarth Milk")]
        [InlineData(Size.Medium, "Medium Markarth Milk")]
        [InlineData(Size.Large, "Large Markarth Milk")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
			var drink = new MarkarthMilk();

			drink.Size = size;

			Assert.Equal(name, drink.ToString());
		}
    }
}