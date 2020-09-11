/*- WarriorWater.cs						Created: 03SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Tests the WarriorWater.cs class in the Data library
 */


using Xunit;

using System;
// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
	/// <summary>
	///		Tests the correct functionality of Warrior Water class
	/// </summary>
	public class WarriorWaterTest
	{
		/// <summary>
		///		Ensure that this drink inherits from Drink
		/// </summary>
		[Fact]
		public void ShouldBeADrink()
		{
			var water = new WarriorWater();
			Assert.IsAssignableFrom<Drink>(water);
		}

		/// <summary>
		///		Ensure there is ice by default 
		/// </summary>
		[Fact]
		public void ShouldIncludeIceByDefault()
		{
			var drink = new WarriorWater();
			Assert.True(drink.Ice);
		}

		/// <summary>
		///		Ensure the drink does not have lemon by default
		/// </summary>
		[Fact]
		public void ShouldNotHaveLemonByDefault()
		{
			var drink = new WarriorWater();
			Assert.False(drink.Lemon);
		}

		/// <summary>
		///		Ensure the drink is small by default
		/// </summary>
		[Fact]
		public void ShouldBeSmallByDefault()
		{
			var drink = new WarriorWater();
			Assert.Equal(Size.Small, drink.Size);
		}

		/// <summary>
		///		Ensure ice can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
		public void ShouldBeAbleToSetIce()
		{
			var drink = new WarriorWater();

			drink.Ice = false;
			Assert.False(drink.Ice);

			drink.Ice = true;
			Assert.True(drink.Ice);
		}

		/// <summary>
		///		Ensure lemon can be properly set and retrieved
		///		- Default is false
		/// </summary>
		[Fact]
		public void ShouldBeAbleToSetLemon()
		{
			var drink = new CandlehearthCoffee();

			drink.Decaf = true;
			Assert.True(drink.Decaf);

			drink.Decaf = false;
			Assert.False(drink.Decaf);
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
			var drink = new WarriorWater();

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
		[InlineData(Size.Small, 0)]
		[InlineData(Size.Medium, 0)]
		[InlineData(Size.Large, 0)]
		public void ShouldHaveCorrectPriceForSize(Size size, double price)
		{
			var drink = new WarriorWater();
			drink.Size = size;

			Assert.Equal(price, drink.Price);
		}

		/// <summary>
		///		Ensure the calories of the drink matches with its size
		/// </summary>
		/// <param name="size">The set size of the drink</param>
		/// <param name="cal">THe expected amount of calories in the drink</param>
		[Theory]
		[InlineData(Size.Small, 0)]
		[InlineData(Size.Medium, 0)]
		[InlineData(Size.Large, 0)]
		public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
		{
			var drink = new WarriorWater();
			drink.Size = size;

			Assert.Equal(cal, drink.Calories);
		}

		/// <summary>
		///		Ensure the correct special instructions are included
		/// </summary>
		/// <param name="includeIce">whether ice is requested in the drink</param>
		/// <param name="includeLemon">whether room for cream is requested in the drink</param>
		[Theory]
		[InlineData(true, true)]
		[InlineData(true, false)]
		[InlineData(false, true)]
		[InlineData(false, false)]
		public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeLemon)
		{
			var drink = new WarriorWater();

			drink.Ice = includeIce;
			drink.Lemon = includeLemon;

			if (!includeIce) Assert.Contains("Hold ice", drink.SpecialInstructions);
			if (includeLemon) Assert.Contains("Add lemon", drink.SpecialInstructions);
			if (includeIce && !includeLemon) Assert.Empty(drink.SpecialInstructions);
		}

		/// <summary>
		///		Ensure that the drink has the correct ToString output
		///		based on its properties
		/// </summary>
		/// <param name="decaf">Whether the drink is decaf</param>
		/// <param name="size">Size of the drink</param>
		/// <param name="name">The expected ToString output</param>
		[Theory]
		[InlineData(Size.Small, "Small Warrior Water")]
		[InlineData(Size.Medium, "Medium Warrior Water")]
		[InlineData(Size.Large, "Large Warrior Water")]
		public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
		{
			var drink = new WarriorWater();

			drink.Size = size;

			Assert.Equal(name, drink.ToString());
		}
	}
}
