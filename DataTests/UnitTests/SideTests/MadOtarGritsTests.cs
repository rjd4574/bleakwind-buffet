﻿/*
 * Author: Zachery Brunner
 * Class: MadOtarGritsTests.cs
 * Purpose: Test the MadOtarGrits.cs class in the Data library
 */
/*- Edited by: Ryan Dentremont				Last Modified: 01OCT20
 * 											CIS 400 MWF @ 1330
 */
using Xunit;
using System;
// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
	/// <summary>
	///		Tests the correct functionality of Mad Otar Grits side class
	/// </summary>
	public class MadOtarGritsTests
    {
		/// <summary>
		///		Ensure this IOrderItem is implimenting the required
		///		INotifyPropertyChanged Interface
		/// </summary>
		[Fact]
		public void ShouldImplimentINotify()
		{
			var orderItem = new MadOtarGrits();
			Assert.IsAssignableFrom<INotifyPropertyChanged>(orderItem);
		}

		/// <summary>
		///		Ensure that this side notifies size when size is changed
		///		Property
		/// </summary>
		[Fact]
		public void ChangingSizeNotifiesSizeProperty()
		{
			var side = new MadOtarGrits();
			side.Size = Size.Small;        // Notify will only work when property is changed

			Assert.PropertyChanged(side, "Size", () => { side.Size = Size.Large; });
			Assert.PropertyChanged(side, "Size", () => { side.Size = Size.Medium; });
			Assert.PropertyChanged(side, "Size", () => { side.Size = Size.Small; });
		}

		/// <summary>
		///		Ensure that this side notifies price when size is changed
		/// </summary>
		[Fact]
		public void ChangingSizeNotifiesPriceProperty()
		{
			var side = new MadOtarGrits();
			side.Size = Size.Small;        // Notify will only work when property is changed

			Assert.PropertyChanged(side, "Price", () => { side.Size = Size.Large; });
			Assert.PropertyChanged(side, "Price", () => { side.Size = Size.Medium; });
			Assert.PropertyChanged(side, "Price", () => { side.Size = Size.Small; });
		}

		/// <summary>
		///		Ensure that this side notifies Calories when size is changed
		/// </summary>
		[Fact]
		public void ChangingSizeNotifiesCaloriesProperty()
		{
			var side = new MadOtarGrits();
			side.Size = Size.Small;        // Notify will only work when property is changed

			Assert.PropertyChanged(side, "Calories", () => { side.Size = Size.Large; });
			Assert.PropertyChanged(side, "Calories", () => { side.Size = Size.Medium; });
			Assert.PropertyChanged(side, "Calories", () => { side.Size = Size.Small; });
		}

		/// <summary>
		///		Ensure that this side inherits from Side
		/// </summary>
		[Fact]
		public void ShouldBeASide()
		{
			var side = new MadOtarGrits();
			Assert.IsAssignableFrom<Side>(side);
		}

		/// <summary>
		///		Ensure that this item implements the IOrderItem interface
		/// </summary>
		[Fact]
		public void ShouldBeAnIOrderItem()
		{
			var orderItem = new MadOtarGrits();
			Assert.IsAssignableFrom<IOrderItem>(orderItem);
		}

		/// <summary>
		///		Ensure the side is small by default
		/// </summary>
		[Fact]
		public void ShouldBeSmallByDefault()
		{
			Assert.Equal(Size.Small, new MadOtarGrits().Size);
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
			var side = new MadOtarGrits();

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
			Assert.Empty(new MadOtarGrits().SpecialInstructions);
		}

		/// <summary>
		///		Ensure the price of the side matches with its size
		/// </summary>
		/// <param name="size">The set size of the side</param>
		/// <param name="price">The expected price of the side</param>
		[Theory]
        [InlineData(Size.Small, 1.22)]
        [InlineData(Size.Medium, 1.58)]
        [InlineData(Size.Large, 1.93)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
			var side = new MadOtarGrits();
			side.Size = size;

			Assert.Equal(price, side.Price);
		}

		/// <summary>
		///		Ensure the calories of the side matches with its size
		/// </summary>
		/// <param name="size">The set size of the side</param>
		/// <param name="cal">THe expected amount of calories in the side</param>
		[Theory]
        [InlineData(Size.Small, 105)]
        [InlineData(Size.Medium, 142)]
        [InlineData(Size.Large, 179)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint cal)
        {
			var side = new MadOtarGrits();
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
        [InlineData(Size.Small, "Small Mad Otar Grits")]
        [InlineData(Size.Medium, "Medium Mad Otar Grits")]
        [InlineData(Size.Large, "Large Mad Otar Grits")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
			var side = new MadOtarGrits();
			side.Size = size;
			Assert.Equal(name, side.ToString());
		}
    }
}