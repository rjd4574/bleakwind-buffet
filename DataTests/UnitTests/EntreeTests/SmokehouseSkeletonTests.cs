﻿/*
 * Author: Zachery Brunner
 * Class: SmokehouseSkeletonTests.cs
 * Purpose: Test the SmokehouseSkeleton.cs class in the Data library
 */
/*- Edited by: Ryan Dentremont				Edited: 03SEP20
 * 											CIS 400 MWF @ 1330
 */

using Xunit;

// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
	/// <summary>
	///		Tests the correct functionality of the Smokehouse Skeleton Entree
	/// </summary>
	public class SmokehouseSkeletonTests
    {
		/// <summary>
		///		Ensure there is sausage by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeSausageByDefault()
        {
			Assert.True(new SmokehouseSkeleton().SausageLink);
        }

		/// <summary>
		///		Ensure there is egg by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeEggByDefault()
        {
			Assert.True(new SmokehouseSkeleton().Egg);
		}

		/// <summary>
		///		Ensure there is hashbrown by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeHashbrownsByDefault()
        {
			Assert.True(new SmokehouseSkeleton().HashBrowns);
		}

		/// <summary>
		///		Ensure there is pancake by default
		/// </summary>
		[Fact]
        public void ShouldInlcudePancakeByDefault()
        {
			Assert.True(new SmokehouseSkeleton().Pancake);
		}


		/// <summary>
		///		Ensure that sausage can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetSausage()
        {
			var entree = new SmokehouseSkeleton();

			entree.SausageLink = false;
			Assert.False(entree.SausageLink);

			entree.SausageLink = true;
			Assert.True(entree.SausageLink);
		}

		/// <summary>
		///		Ensure that egg can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetEgg()
        {
			var entree = new SmokehouseSkeleton();

			entree.Egg = false;
			Assert.False(entree.Egg);

			entree.Egg = true;
			Assert.True(entree.Egg);
		}

		/// <summary>
		///		Ensure that hashbrown can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetHashbrowns()
        {
			var entree = new SmokehouseSkeleton();

			entree.HashBrowns = false;
			Assert.False(entree.HashBrowns);

			entree.HashBrowns = true;
			Assert.True(entree.HashBrowns);
		}

		/// <summary>
		///		Ensure that pancake can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetPancake()
        {
			var entree = new SmokehouseSkeleton();

			entree.Pancake = false;
			Assert.False(entree.Pancake);

			entree.Pancake = true;
			Assert.True(entree.Pancake);
		}

		/// <summary>
		///		Ensure that the entree is priced correctly
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectPrice()
		{
			var entree = new SmokehouseSkeleton();
			Assert.Equal(5.62, entree.Price);
		}

		/// <summary>
		///		Ensure the entree has the correct amount of calories
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectCalories()
		{
			var entree = new SmokehouseSkeleton();
			Assert.Equal((uint)602, entree.Calories);
		}

		/// <summary>
		///		Ensure the correct special instructions are included
		/// </summary>
		/// <param name="includeSausage">is sausage requested</param>
		/// <param name="includeEgg">is egg requested</param>
		/// <param name="includeHashbrowns">is hashbrown requested</param>
		/// <param name="includePancake">is pancake requested</param>
		[Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSausage, bool includeEgg,
                                                            bool includeHashbrowns, bool includePancake)
        {
			var entree = new SmokehouseSkeleton();
			entree.SausageLink = includeSausage;
			entree.Egg = includeEgg;
			entree.HashBrowns = includeHashbrowns;
			entree.Pancake = includePancake;

			if (!includeSausage) Assert.Contains("Hold sausage", entree.SpecialInstructions);
			if (!includeEgg) Assert.Contains("Hold eggs", entree.SpecialInstructions);
			if (!includeHashbrowns) Assert.Contains("Hold hash browns", entree.SpecialInstructions);
			if (!includePancake) Assert.Contains("Hold pancakes", entree.SpecialInstructions);
			if (includeSausage && includeEgg && includeHashbrowns && includePancake)
				Assert.Empty(entree.SpecialInstructions);
		}

		/// <summary>
		///		Ensure the entree has the correct ToString output
		/// </summary>
		[Fact]
        public void ShouldReturnCorrectToString()
        {
			Assert.Equal("Smokehouse Skeleton", new SmokehouseSkeleton().ToString());
		}
    }
}