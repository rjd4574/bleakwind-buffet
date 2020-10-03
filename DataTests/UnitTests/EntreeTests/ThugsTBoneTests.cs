/*
 * Author: Zachery Brunner
 * Class: ThugsTBoneTests.cs
 * Purpose: Test the ThugsTBone.cs class in the Data library
 */
/*- Edited by: Ryan Dentremont				Edited: 03SEP20
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
	///		Tests the correct functionality of the Thugs T-Bone Entree
	/// </summary>
	public class ThugsTBoneTests
    {
		/// <summary>
		///		Ensure this IOrderItem is implimenting the required
		///		INotifyPropertyChanged Interface
		/// </summary>
		[Fact]
		public void ShouldImplimentINotify()
		{
			var orderItem = new ThugsTBone();
			Assert.IsAssignableFrom<INotifyPropertyChanged>(orderItem);
		}

		/// <summary>
		///		Ensure that this entree inherits from Entree
		/// </summary>
		[Fact]
		public void ShouldBeAnEntree()
		{
			var entree = new ThugsTBone();
			Assert.IsAssignableFrom<Entree>(entree);
		}

		/// <summary>
		///		Ensure that this item implements the IOrderItem interface
		/// </summary>
		[Fact]
		public void ShouldBeAnIOrderItem()
		{
			var orderItem = new ThugsTBone();
			Assert.IsAssignableFrom<IOrderItem>(orderItem);
		}

		/// <summary>
		///		Ensure that the entree is priced correctly
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectPrice()
		{
			var entree = new ThugsTBone();
			Assert.Equal(6.44, entree.Price);
		}

		/// <summary>
		///		Ensure the entree has the correct amount of calories
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectCalories()
		{
			var entree = new ThugsTBone();
			Assert.Equal((uint)982, entree.Calories);
		}

		/// <summary>
		///		Ensure the special instructions list is empty
		/// </summary>
		[Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
			Assert.Empty(new ThugsTBone().SpecialInstructions);
        }

		/// <summary>
		///		Ensure the entree has the correct ToString output
		/// </summary>
		[Fact]
		public void ShouldReturnCorrectToString()
		{
			Assert.Equal("Thugs T-Bone", new ThugsTBone().ToString());
		}
	}
}