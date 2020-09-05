/*
 * Author: Zachery Brunner
 * Class: SailorSodaTests.cs
 * Purpose: Test the SailorSoda.cs class in the Data library
 */

/*- Edited by: Ryan Dentremont				Edited: 03SEP20
 * 											CIS 400 MWF @ 1330
 */


using Xunit;

using System;
// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;
using Microsoft.VisualBasic.CompilerServices;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
	/// <summary>
	///		Test the correct functionality of the Sailor Soda class
	/// </summary>
    public class SailorSodaTests
    {
		/// <summary>
		///		Ensure there is ice by default
		/// </summary>
        [Fact]
        public void ShouldIncludeIceByDefault()
        {
			var drink = new SailorSoda();
			Assert.True(drink.Ice);
        }

		/// <summary>
		///		The default size should be small
		/// </summary>
        [Fact]
        public void ShouldBeSmallByDefault()
        {
			var drink = new SailorSoda();
			Assert.Equal(Size.Small, drink.Size);
        }

		/// <summary>
		///		Default flavor should be cherry
		/// </summary>
        [Fact]
        public void FlavorShouldBeCherryByDefault()
        {
			var drink = new SailorSoda();
			Assert.Equal(SodaFlavor.Cherry, drink.Flavor);
        }

		/// <summary>
		///		Ensure Ice can be properly set and retrieved
		///		- default is true
		/// </summary>
        [Fact]
        public void ShouldBeAbleToSetIce()
        {
			var drink = new SailorSoda();
			
			drink.Ice = false;
			Assert.False(drink.Ice);

			drink.Ice = true;
			Assert.True(drink.Ice);
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
			var drink = new SailorSoda();
			
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
		///		Ensure the flavor can be propoerly set and retrieved.
		///		- Default flavor is cherry
		///		- Shouldn't allow any Flavor not defined in Enum.SodaFlavor
		/// </summary>
		/// <exception cref="NotImplementedException">
		///		Should be thrown for invalid Flavors
		/// </exception>"
        [Fact]
        public void ShouldBeAbleToSetFlavor()
        {
			var drink = new SailorSoda();

			drink.Flavor = SodaFlavor.Blackberry;
			Assert.Equal(SodaFlavor.Blackberry, drink.Flavor);

			// Undefined Flavor (too small)
			Assert.Throws<NotImplementedException>(() =>
			{
				drink.Flavor--;
			});

			drink.Flavor = SodaFlavor.Cherry;
			Assert.Equal(SodaFlavor.Cherry, drink.Flavor);

			drink.Flavor = SodaFlavor.Grapefruit;
			Assert.Equal(SodaFlavor.Grapefruit, drink.Flavor);

			drink.Flavor = SodaFlavor.Lemon;
			Assert.Equal(SodaFlavor.Lemon, drink.Flavor);

			drink.Flavor = SodaFlavor.Peach;
			Assert.Equal(SodaFlavor.Peach, drink.Flavor);

			drink.Flavor = SodaFlavor.Watermelon;
			Assert.Equal(SodaFlavor.Watermelon, drink.Flavor);

			// Undefined Flavor (too large)
			Assert.Throws<NotImplementedException>(() =>
			{
				drink.Flavor++;
			});
		}

		/// <summary>
		///		Ensure the price of the drink matches with its size
		/// </summary>
		/// <param name="size">The set size of the drink</param>
		/// <param name="price">The expected price of the drink</param>
        [Theory]
        [InlineData(Size.Small, 1.42)]
        [InlineData(Size.Medium, 1.74)]
        [InlineData(Size.Large, 2.07)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
			var drink = new SailorSoda();
			drink.Size = size;

			Assert.Equal(price, drink.Price);
        }

		/// <summary>
		///		Ensure the calories of the drink matches with its size
		/// </summary>
		/// <param name="size">The set size of the drink</param>
		/// <param name="cal">THe expected amount of calories in the drink</param>
        [Theory]
        [InlineData(Size.Small, 117)]
        [InlineData(Size.Medium, 153)]
        [InlineData(Size.Large, 205)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
			var drink = new SailorSoda();
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
			var drink = new SailorSoda();

			drink.Ice = includeIce;

			if (includeIce) Assert.Empty(drink.SpecialInstructions);
			if (!includeIce) Assert.Contains("Hold ice",drink.SpecialInstructions);
        }
        
		/// <summary>
		///		Ensure that the drink has the correct ToString output
		///		based on its properties
		/// </summary>
		/// <param name="flavor">The flavor of the drink</param>
		/// <param name="size">The size of the drink</param>
		/// <param name="name">The expected ToString output</param>
        [Theory]
        [InlineData(SodaFlavor.Cherry, Size.Small, "Small Cherry Sailor Soda")]
        [InlineData(SodaFlavor.Cherry, Size.Medium, "Medium Cherry Sailor Soda")]
        [InlineData(SodaFlavor.Cherry, Size.Large, "Large Cherry Sailor Soda")]

        [InlineData(SodaFlavor.Blackberry, Size.Small, "Small Blackberry Sailor Soda")]
        [InlineData(SodaFlavor.Blackberry, Size.Medium, "Medium Blackberry Sailor Soda")]
        [InlineData(SodaFlavor.Blackberry, Size.Large, "Large Blackberry Sailor Soda")]

        [InlineData(SodaFlavor.Grapefruit, Size.Small, "Small Grapefruit Sailor Soda")]
        [InlineData(SodaFlavor.Grapefruit, Size.Medium, "Medium Grapefruit Sailor Soda")]
        [InlineData(SodaFlavor.Grapefruit, Size.Large, "Large Grapefruit Sailor Soda")]

        [InlineData(SodaFlavor.Lemon, Size.Small, "Small Lemon Sailor Soda")]
        [InlineData(SodaFlavor.Lemon, Size.Medium, "Medium Lemon Sailor Soda")]
        [InlineData(SodaFlavor.Lemon, Size.Large, "Large Lemon Sailor Soda")]

        [InlineData(SodaFlavor.Peach, Size.Small, "Small Peach Sailor Soda")]
        [InlineData(SodaFlavor.Peach, Size.Medium, "Medium Peach Sailor Soda")]
        [InlineData(SodaFlavor.Peach, Size.Large, "Large Peach Sailor Soda")]

        [InlineData(SodaFlavor.Watermelon, Size.Small, "Small Watermelon Sailor Soda")]
        [InlineData(SodaFlavor.Watermelon, Size.Medium, "Medium Watermelon Sailor Soda")]
        [InlineData(SodaFlavor.Watermelon, Size.Large, "Large Watermelon Sailor Soda")]
        public void ShouldHaveCorrectToStringBasedOnSizeAndFlavor(SodaFlavor flavor, Size size, string name)
        {
			var drink = new SailorSoda();

			drink.Flavor = flavor;
			drink.Size = size;

			Assert.Equal(name, drink.ToString());
        }
    }
}
