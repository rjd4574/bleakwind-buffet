/*
 * Author: Zachery Brunner
 * Class: FriedMiraakTests.cs
 * Purpose: Test the FriedMiraak.cs class in the Data library
 */
/*- Edited by: Ryan Dentremont				Edited: 03SEP20
 * 											CIS 400 MWF @ 1330
 */
using Xunit;
using System;
// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
	/// <summary>
	///		Tests the correct functionality of Fried Miraak side class
	/// </summary>
	public class FriedMiraakTests
    {
		/// <summary>
		///		Ensure that this side inherits from Side
		/// </summary>
		[Fact]
		public void ShouldBeASide()
		{
			var side = new FriedMiraak();
			Assert.IsAssignableFrom<Side>(side);
		}

		/// <summary>
		///		Ensure that this item implements the IOrderItem interface
		/// </summary>
		[Fact]
		public void ShouldBeAnIOrderItem()
		{
			var orderItem = new FriedMiraak();
			Assert.IsAssignableFrom<IOrderItem>(orderItem);
		}

		/// <summary>
		///		Ensure the side is small by default
		/// </summary>
		[Fact]
		public void ShouldBeSmallByDefault()
		{
			Assert.Equal(Size.Small, new FriedMiraak().Size);
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
			var side = new FriedMiraak();

			side.Size = Size.Medium;
			Assert.Equal(Size.Medium, side.Size);

			side.Size = Size.Small;
			Assert.Equal(Size.Small, side.Size);

			// Undefined size (too small)
			Assert.Throws<NotImplementedException>(() =>
			{
				side.Size--;
			});

			side.Size = Size.Large;
			Assert.Equal(Size.Large, side.Size);

			// Undefined size (too large)
			Assert.Throws<NotImplementedException>(() =>
			{
				side.Size++;
			});
		}

		/// <summary>
		///		Ensure the list of special instructions is empty
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectSpecialInstructions()
		{
			Assert.Empty(new FriedMiraak().SpecialInstructions);
		}

		/// <summary>
		///		Ensure the price of the side matches with its size
		/// </summary>
		/// <param name="size">The set size of the side</param>
		/// <param name="price">The expected price of the side</param>
		[Theory]
        [InlineData(Size.Small, 1.78)]
        [InlineData(Size.Medium, 2.01)]
        [InlineData(Size.Large, 2.88)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
			var side = new FriedMiraak();
			side.Size = size;

			Assert.Equal(price, side.Price);
		}

		/// <summary>
		///		Ensure the calories of the side matches with its size
		/// </summary>
		/// <param name="size">The set size of the side</param>
		/// <param name="cal">THe expected amount of calories in the side</param>
		[Theory]
        [InlineData(Size.Small, 151)]
        [InlineData(Size.Medium, 236)]
        [InlineData(Size.Large, 306)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint cal)
        {
			var side = new FriedMiraak();
			side.Size = size;

			Assert.Equal(cal, side.Calories);
		}

		/// <summary>
		///		Ensure that the side has the correct ToString output
		///		based on its properties
		/// </summary>
		/// <param name="size">Size of the side</param>
		/// <param name="name">The expected ToString output</param>
		[Theory]
        [InlineData(Size.Small, "Small Fried Miraak")]
        [InlineData(Size.Medium, "Medium Fried Miraak")]
        [InlineData(Size.Large, "Large Fried Miraak")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
			var side = new FriedMiraak();
			side.Size = size;
			Assert.Equal(name, side.ToString());
		}
    }
}