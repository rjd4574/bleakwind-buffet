/*
 * Author: Zachery Brunner
 * Class: GardenOrcOmeletteTests.cs
 * Purpose: Test the GardenOrcOmelette.cs class in the Data library
 */
/*- Edited by: Ryan Dentremont				Last Modified: 01OCT20
 * 											CIS 400 MWF @ 1330
 */

using Xunit;

// Using the exact namespaces requited to ensure no typo's
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
	/// <summary>
	///		Tests the correct functionality of the Garden Orc Omelette Entree
	/// </summary>
	public class GardenOrcOmeletteTests
    {
		/// <summary>
		///		Ensure this IOrderItem is implimenting the required
		///		INotifyPropertyChanged Interface
		/// </summary>
		[Fact]
		public void ShouldImplimentINotify()
		{
			var orderItem = new GardenOrcOmelette();
			Assert.IsAssignableFrom<INotifyPropertyChanged>(orderItem);
		}

		/// <summary>
		///		Ensure that this Entree notifies Broccoli when Broccoli is changed
		/// </summary>
		[Fact]
		public void ChangingBroccolinNotifiesBroccoliProperty()
		{
			var entree = new GardenOrcOmelette();
			entree.Broccoli = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Broccoli", () => { entree.Broccoli = true; });
			Assert.PropertyChanged(entree, "Broccoli", () => { entree.Broccoli = false; });
		}

		/// <summary>
		///		Ensure that this Entree notifies Mushrooms when Mushrooms is changed
		/// </summary>
		[Fact]
		public void ChangingMushroomsNotifiesMushroomsProperty()
		{
			var entree = new GardenOrcOmelette();
			entree.Mushrooms = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Mushrooms", () => { entree.Mushrooms = true; });
			Assert.PropertyChanged(entree, "Mushrooms", () => { entree.Mushrooms = false; });
		}

		/// <summary>
		///		Ensure that this Entree notifies Tomato when Tomato is changed
		/// </summary>
		[Fact]
		public void ChangingMustardNotifiesMustardProperty()
		{
			var entree = new GardenOrcOmelette();
			entree.Tomato = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Tomato", () => { entree.Tomato = true; });
			Assert.PropertyChanged(entree, "Tomato", () => { entree.Tomato = false; });
		}

		/// <summary>
		///		Ensure that this Entree notifies Cheddar when Cheddar is changed
		/// </summary>
		[Fact]
		public void ChangingCheddarNotifiesCheddarProperty()
		{
			var entree = new GardenOrcOmelette();
			entree.Cheddar = false;  // notify will only work when property is changed

			Assert.PropertyChanged(entree, "Cheddar", () => { entree.Cheddar = true; });
			Assert.PropertyChanged(entree, "Cheddar", () => { entree.Cheddar = false; });
		}

		/// <summary>
		///		Ensure that this entree inherits from Entree
		/// </summary>
		[Fact]
		public void ShouldBeAnEntree()
		{
			var entree = new GardenOrcOmelette();
			Assert.IsAssignableFrom<Entree>(entree);
		}

		/// <summary>
		///		Ensure that this item implements the IOrderItem interface
		/// </summary>
		[Fact]
		public void ShouldBeAnIOrderItem()
		{
			var orderItem = new GardenOrcOmelette();
			Assert.IsAssignableFrom<IOrderItem>(orderItem);
		}

		/// <summary>
		///		Ensure there is broccoli by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeBroccoliByDefault()
        {
			Assert.True(new GardenOrcOmelette().Broccoli);
        }

		/// <summary>
		///		Ensure there is mushroom by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeMushroomsByDefault()
        {
			Assert.True(new GardenOrcOmelette().Mushrooms);
		}

		/// <summary>
		///		Ensure there is tomato by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeTomatoByDefault()
        {
			Assert.True(new GardenOrcOmelette().Tomato);
		}

		/// <summary>
		///		Ensure there is cheddar by default
		/// </summary>
		[Fact]
        public void ShouldInlcudeCheddarByDefault()
        {
			Assert.True(new GardenOrcOmelette().Cheddar);
		}

		/// <summary>
		///		Ensure that broccoli can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetBroccoli()
        {
			var entree = new GardenOrcOmelette();

			entree.Broccoli = false;
			Assert.False(entree.Broccoli);

			entree.Broccoli = true;
			Assert.True(entree.Broccoli);
		}

		/// <summary>
		///		Ensure that mushroom can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetMushrooms()
        {
			var entree = new GardenOrcOmelette();

			entree.Mushrooms = false;
			Assert.False(entree.Mushrooms);

			entree.Mushrooms = true;
			Assert.True(entree.Mushrooms);
		}

		/// <summary>
		///		Ensure that tomato can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetTomato()
        {
			var entree = new GardenOrcOmelette();

			entree.Tomato = false;
			Assert.False(entree.Tomato);

			entree.Tomato = true;
			Assert.True(entree.Tomato);
		}

		/// <summary>
		///		Ensure that cheddar can be properly set and retrieved
		///		- Default is true
		/// </summary>
		[Fact]
        public void ShouldBeAbleToSetCheddar()
        {
			var entree = new GardenOrcOmelette();

			entree.Cheddar = false;
			Assert.False(entree.Cheddar);

			entree.Cheddar = true;
			Assert.True(entree.Cheddar);
		}


		/// <summary>
		///		Ensure that the entree is priced correctly
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectPrice()
		{
			var entree = new GardenOrcOmelette();
			Assert.Equal(4.57, entree.Price);
		}

		/// <summary>
		///		Ensure the entree has the correct amount of calories
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectCalories()
		{
			var entree = new GardenOrcOmelette();
			Assert.Equal((uint)404, entree.Calories);
		}

		/// <summary>
		///		Ensure the correct special instructions are included
		/// </summary>
		/// <param name="includeBroccoli">is broccoli requested</param>
		/// <param name="includeMushrooms">is mushroom requested</param>
		/// <param name="includeTomato">is tomato requested</param>
		/// <param name="includeCheddar">is cheddar requested</param>
		[Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBroccoli, bool includeMushrooms,
                                                            bool includeTomato, bool includeCheddar)
        {
			var entree = new GardenOrcOmelette();
			entree.Broccoli = includeBroccoli;
			entree.Mushrooms= includeMushrooms;
			entree.Tomato = includeTomato;
			entree.Cheddar = includeCheddar;

			if (!includeBroccoli) Assert.Contains("Hold broccoli", entree.SpecialInstructions);
			if (!includeMushrooms) Assert.Contains("Hold mushrooms", entree.SpecialInstructions);
			if (!includeTomato) Assert.Contains("Hold tomato", entree.SpecialInstructions);
			if (!includeCheddar) Assert.Contains("Hold cheddar", entree.SpecialInstructions);
			if (includeBroccoli && includeMushrooms && includeTomato && includeCheddar)
				Assert.Empty(entree.SpecialInstructions);
		}

		/// <summary>
		///		Ensure the entree has the correct ToString output
		/// </summary>
		[Fact]
        public void ShouldReturnCorrectToString()
        {
			Assert.Equal("Garden Orc Omelette", new GardenOrcOmelette().ToString());
		}
    }
}