/*
 * Author: Zachery Brunner
 * Class: PhillyPoacherTests.cs
 * Purpose: Test the PhillyPoacher.cs class in the Data library
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
	///		Tests the correct functionality of the Garden Orc Omelette Entree
	/// </summary>
	public class PhillyPoacherTests
    {
		/// <summary>
		///		Ensure there is Sirloin by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeSirloinByDefault()
        {
			Assert.True(new PhillyPoacher().Sirloin);
        }

		/// <summary>
		///		Ensure there is Onion by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeOnionByDefault()
        {
			Assert.True(new PhillyPoacher().Onion);
		}

		/// <summary>
		///		Ensure there is Roll by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeRollByDefault()
        {
			Assert.True(new PhillyPoacher().Roll);
		}

		/// <summary>
		///		Ensure that Sirloin can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetSirloin()
        {
			var entree = new PhillyPoacher();

			entree.Sirloin = false;
			Assert.False(entree.Sirloin);

			entree.Sirloin = true;
			Assert.True(entree.Sirloin);
		}

		/// <summary>
		///		Ensure that Onion can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetOnions()
        {
			var entree = new PhillyPoacher();

			entree.Onion = false;
			Assert.False(entree.Onion);

			entree.Onion = true;
			Assert.True(entree.Onion);
		}

		/// <summary>
		///		Ensure that Roll can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetRoll()
        {
			var entree = new PhillyPoacher();

			entree.Roll = false;
			Assert.False(entree.Roll);

			entree.Roll = true;
			Assert.True(entree.Roll);
		}

		/// <summary>
		///		Ensure that the entree is priced correctly
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectPrice()
		{
			var entree = new PhillyPoacher();
			Assert.Equal(7.23, entree.Price);
		}

		/// <summary>
		///		Ensure the entree has the correct amount of calories
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectCalories()
		{
			var entree = new PhillyPoacher();
			Assert.Equal((uint)784, entree.Calories);
		}

		/// <summary>
		///		Ensure the correct special instructions are included
		/// </summary>
		/// <param name="includeSirloin">is broccoli requested</param>
		/// <param name="includeOnion">is onion requested</param>
		/// <param name="includeRoll">is roll requested</param>
		[Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSirloin, bool includeOnion,
                                                            bool includeRoll)
        {
			var entree = new PhillyPoacher();
			entree.Sirloin = includeSirloin;
			entree.Onion = includeOnion;
			entree.Roll = includeRoll;

			if (!includeSirloin) Assert.Contains("Hold sirloin", entree.SpecialInstructions);
			if (!includeOnion) Assert.Contains("Hold onions", entree.SpecialInstructions);
			if (!includeRoll) Assert.Contains("Hold roll", entree.SpecialInstructions);
			if (includeSirloin && includeOnion && includeRoll) Assert.Empty(entree.SpecialInstructions);
		}

		/// <summary>
		///		Ensure the entree has the correct ToString output
		/// </summary>
		[Fact]
        public void ShouldReturnCorrectToString()
        {
			Assert.Equal("Philly Poacher", new PhillyPoacher().ToString());
		}
    }
}