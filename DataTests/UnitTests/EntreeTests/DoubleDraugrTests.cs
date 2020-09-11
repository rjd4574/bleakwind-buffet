/*
 * Author: Zachery Brunner
 * Class: DoubleDraugrTests.cs
 * Purpose: Test the DoubleDraugr.cs class in the Data library
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
	///		Tests the correct functionality of the Double Drauger Burger Entree
	/// </summary>
	public class DoubleDraugrTests
    {
		/// <summary>
		///		Ensure that this entree inherits from Entree
		/// </summary>
		[Fact]
		public void ShouldBeAnEntree()
		{
			var entree = new DoubleDraugr();
			Assert.IsAssignableFrom<Entree>(entree);
		}

		/// <summary>
		///		Ensure there is a bun by default
		/// </summary>
		[Fact]
		public void ShouldIncludeBunByDefault()
		{
			var entree = new DoubleDraugr();
			Assert.True(entree.Bun);
		}

		/// <summary>
		///		Insure there is ketchup by default
		/// </summary>
		[Fact]
		public void ShouldIncludeKetchupByDefault()
		{
			var entree = new DoubleDraugr();
			Assert.True(entree.Ketchup);
		}

		/// <summary>
		///		Insure there is mustard by default
		/// </summary>
		[Fact]
		public void ShouldIncludeMustardByDefault()
		{
			var entree = new DoubleDraugr();
			Assert.True(entree.Mustard);
		}

		/// <summary>
		///		Ensure there is pickle by default
		/// </summary>
		[Fact]
		public void ShouldIncludePickleByDefault()
		{
			var entree = new DoubleDraugr();
			Assert.True(entree.Pickle);
		}

		/// <summary>
		///		Ensure there is cheese by default
		/// </summary>
		[Fact]
		public void ShouldIncludeCheeseByDefault()
		{
			var entree = new DoubleDraugr();
			Assert.True(entree.Cheese);
		}

		/// <summary>
		///		Ensure there is Tomato by default
		/// </summary>
		[Fact]
        public void ShouldIncludeTomatoByDefault()
        {
			var entree = new DoubleDraugr();
			Assert.True(entree.Tomato);
		}

		/// <summary>
		///		Ensure there is Lettuce by default
		/// </summary>
		[Fact]
        public void ShouldIncludeLettuceByDefault()
        {
			var entree = new DoubleDraugr();
			Assert.True(entree.Lettuce);
		}

		/// <summary>
		///		Ensure there is Mayo by default
		/// </summary>
		[Fact]
        public void ShouldIncludeMayoByDefault()
        {
			var entree = new DoubleDraugr();
			Assert.True(entree.Mayo);
		}


		/// <summary>
		///		Ensure that bun can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
		public void ShouldBeAbleToSetBun()
		{
			var entree = new DoubleDraugr();

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
			var entree = new DoubleDraugr();

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
			var entree = new DoubleDraugr();

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
			var entree = new DoubleDraugr();

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
			var entree = new DoubleDraugr();

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
			var entree = new DoubleDraugr();

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
			var entree = new DoubleDraugr();

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
			var entree = new DoubleDraugr();

			entree.Mayo = false;
			Assert.False(entree.Mayo);

			entree.Mayo = true;
			Assert.True(entree.Mayo);
		}

		/// <summary>
		///		Ensure that the entree is priced correctly
		/// </summary>
		[Fact]
        public void ShouldReturnCorrectPrice()
        {
			var entree = new DoubleDraugr();
			Assert.Equal(7.32, entree.Price);
		}

		/// <summary>
		///		Ensure the entree has the correct amount of calories
		/// </summary>
		[Fact]
        public void ShouldReturnCorrectCalories()
        {
			var entree = new DoubleDraugr();
			Assert.Equal((uint)743, entree.Calories);
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
		[Theory]
        [InlineData(true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese, bool includeTomato,
                                                                    bool includeLettuce, bool includeMayo)
        {
			var entree = new DoubleDraugr();
			entree.Bun = includeBun;
			entree.Ketchup = includeKetchup;
			entree.Mustard = includeMustard;
			entree.Pickle = includePickle;
			entree.Cheese = includeCheese;
			entree.Tomato = includeTomato;
			entree.Lettuce = includeLettuce;
			entree.Mayo= includeMayo;


			if (!includeBun) Assert.Contains("Hold bun", entree.SpecialInstructions);
			if (!includeKetchup) Assert.Contains("Hold ketchup", entree.SpecialInstructions);
			if (!includeMustard) Assert.Contains("Hold mustard", entree.SpecialInstructions);
			if (!includePickle) Assert.Contains("Hold pickle", entree.SpecialInstructions);
			if (!includeCheese) Assert.Contains("Hold cheese", entree.SpecialInstructions);
			if (!includeTomato) Assert.Contains("Hold tomato", entree.SpecialInstructions);
			if (!includeLettuce) Assert.Contains("Hold lettuce", entree.SpecialInstructions);
			if (!includeMayo) Assert.Contains("Hold mayo", entree.SpecialInstructions);
			if (includeBun && includeKetchup && includeMustard && includePickle && includeCheese &&
				includeTomato && includeLettuce && includeMayo)	Assert.Empty(entree.SpecialInstructions);
		}
		/// <summary>
		///		Ensure the entree has the correct ToString output
		/// </summary>
		[Fact]
        public void ShouldReturnCorrectToString()
        {
			Assert.Equal("Double Draugr", new DoubleDraugr().ToString());
		}
    }
}