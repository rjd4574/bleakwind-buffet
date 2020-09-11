/*
 * Author: Zachery Brunner
 * Class: ThalmorTripleTests.cs
 * Purpose: Test the ThalmorTriple.cs class in the Data library
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
	///		Tests the correct functionality of the Thalmor Triple Burger Entree
	/// </summary>
	public class ThalmorTripleTests
    {
		/// <summary>
		///		Ensure that this entree inherits from Entree
		/// </summary>
		[Fact]
		public void ShouldBeAnEntree()
		{
			var entree = new ThalmorTriple();
			Assert.IsAssignableFrom<Entree>(entree);
		}

		/// <summary>
		///		Ensure there is a bun by default
		/// </summary>
		[Fact]
		public void ShouldIncludeBunByDefault()
		{
			var entree = new ThalmorTriple();
			Assert.True(entree.Bun);
		}

		/// <summary>
		///		Insure there is ketchup by default
		/// </summary>
		[Fact]
		public void ShouldIncludeKetchupByDefault()
		{
			var entree = new ThalmorTriple();
			Assert.True(entree.Ketchup);
		}

		/// <summary>
		///		Insure there is mustard by default
		/// </summary>
		[Fact]
		public void ShouldIncludeMustardByDefault()
		{
			var entree = new ThalmorTriple();
			Assert.True(entree.Mustard);
		}

		/// <summary>
		///		Ensure there is pickle by default
		/// </summary>
		[Fact]
		public void ShouldIncludePickleByDefault()
		{
			var entree = new ThalmorTriple();
			Assert.True(entree.Pickle);
		}

		/// <summary>
		///		Ensure there is cheese by default
		/// </summary>
		[Fact]
		public void ShouldIncludeCheeseByDefault()
		{
			var entree = new ThalmorTriple();
			Assert.True(entree.Cheese);
		}

		/// <summary>
		///		Ensure there is Tomato by default
		/// </summary>
		[Fact]
		public void ShouldIncludeTomatoByDefault()
		{
			var entree = new ThalmorTriple();
			Assert.True(entree.Tomato);
		}

		/// <summary>
		///		Ensure there is Lettuce by default
		/// </summary>
		[Fact]
		public void ShouldIncludeLettuceByDefault()
		{
			var entree = new ThalmorTriple();
			Assert.True(entree.Lettuce);
		}

		/// <summary>
		///		Ensure there is Mayo by default
		/// </summary>
		[Fact]
		public void ShouldIncludeMayoByDefault()
		{
			var entree = new ThalmorTriple();
			Assert.True(entree.Mayo);
		}

		/// <summary>
		///		Ensure there is bacon by default
		/// </summary>
		[Fact]
        public void ShouldIncludeBaconByDefault()
        {
			var entree = new ThalmorTriple();
			Assert.True(entree.Bacon);
		}

		/// <summary>
		///		Ensure there is egg by default
		/// </summary>
		[Fact]
        public void ShouldIncludeEggByDefault()
        {
			var entree = new ThalmorTriple();
			Assert.True(entree.Egg);
		}


		/// <summary>
		///		Ensure that bun can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
		public void ShouldBeAbleToSetBun()
		{
			var entree = new ThalmorTriple();

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
			var entree = new ThalmorTriple();

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
			var entree = new ThalmorTriple();

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
			var entree = new ThalmorTriple();

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
			var entree = new ThalmorTriple();

			entree.Cheese = false;
			Assert.False(entree.Cheese);

			entree.Cheese = true;
			Assert.True(entree.Cheese);
		}

		/// <summary>
		///		Ensure that Tomato can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
		public void ShouldBeAbleToSetTomato()
		{
			var entree = new ThalmorTriple();

			entree.Tomato = false;
			Assert.False(entree.Tomato);

			entree.Tomato = true;
			Assert.True(entree.Tomato);
		}

		/// <summary>
		///		Ensure that Lettuce can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
		public void ShouldBeAbleToSetLettuce()
		{
			var entree = new ThalmorTriple();

			entree.Lettuce = false;
			Assert.False(entree.Lettuce);

			entree.Lettuce = true;
			Assert.True(entree.Lettuce);
		}

		/// <summary>
		///		Ensure that Mayo can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
		public void ShouldBeAbleToSetMayo()
		{
			var entree = new ThalmorTriple();

			entree.Mayo = false;
			Assert.False(entree.Mayo);

			entree.Mayo = true;
			Assert.True(entree.Mayo);
		}

		/// <summary>
		///		Ensure that bacon can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetBacon()
        {
			var entree = new ThalmorTriple();

			entree.Bacon = false;
			Assert.False(entree.Bacon);

			entree.Bacon = true;
			Assert.True(entree.Bacon);
		}

		/// <summary>
		///		Ensure that egg can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetEgg()
        {
			var entree = new ThalmorTriple();

			entree.Egg = false;
			Assert.False(entree.Egg);

			entree.Egg = true;
			Assert.True(entree.Egg);
		}


		/// <summary>
		///		Ensure that the entree is priced correctly
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectPrice()
		{
			var entree = new ThalmorTriple();
			Assert.Equal(8.32, entree.Price);
		}

		/// <summary>
		///		Ensure the entree has the correct amount of calories
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectCalories()
		{
			var entree = new ThalmorTriple();
			Assert.Equal((uint)943, entree.Calories);
		}

		/// <summary>
		///		Ensure the correct special instructions are included
		/// </summary>
		/// <param name="includeBun">is bun requested</param>
		/// <param name="includeKetchup">is ketchup requested</param>
		/// <param name="includeMustard">is mustard requested</param>
		/// <param name="includePickle">is pickle requested</param>
		/// <param name="includeCheese">is cheese requested</param>
		/// <param name="includeTomato">is Tomato requested</param>
		/// <param name="includeLettuce">is lettuce requested</param>
		/// <param name="includeMayo">is mayo requested</param>
		/// <param name="includeBacon">is bacon requested</param>
		/// <param name="includeEgg">is egg requested</param>"
		[Theory]
        [InlineData(true, true, true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese, bool includeTomato,
                                                                    bool includeLettuce, bool includeMayo,
                                                                    bool includeBacon, bool includeEgg)
        {
			var entree = new ThalmorTriple();
			entree.Bun = includeBun;
			entree.Ketchup = includeKetchup;
			entree.Mustard = includeMustard;
			entree.Pickle = includePickle;
			entree.Cheese = includeCheese;
			entree.Tomato = includeTomato;
			entree.Lettuce = includeLettuce;
			entree.Mayo = includeMayo;
			entree.Bacon = includeBacon;
			entree.Egg = includeEgg;


			if (!includeBun) Assert.Contains("Hold bun", entree.SpecialInstructions);
			if (!includeKetchup) Assert.Contains("Hold ketchup", entree.SpecialInstructions);
			if (!includeMustard) Assert.Contains("Hold mustard", entree.SpecialInstructions);
			if (!includePickle) Assert.Contains("Hold pickle", entree.SpecialInstructions);
			if (!includeCheese) Assert.Contains("Hold cheese", entree.SpecialInstructions);
			if (!includeTomato) Assert.Contains("Hold tomato", entree.SpecialInstructions);
			if (!includeLettuce) Assert.Contains("Hold lettuce", entree.SpecialInstructions);
			if (!includeMayo) Assert.Contains("Hold mayo", entree.SpecialInstructions);
			if (!includeBacon) Assert.Contains("Hold bacon", entree.SpecialInstructions);
			if (!includeEgg) Assert.Contains("Hold egg", entree.SpecialInstructions);
			if (includeBun && includeKetchup && includeMustard && includePickle && includeCheese &&
				includeTomato && includeLettuce && includeMayo && includeBacon && includeEgg )
					Assert.Empty(entree.SpecialInstructions);
		}

		/// <summary>
		///		Ensure the entree has the correct ToString output
		/// </summary>
		[Fact]
        public void ShouldReturnCorrectToString()
        {
			Assert.Equal("Thalmor Triple", new ThalmorTriple().ToString());
		}
    }
}