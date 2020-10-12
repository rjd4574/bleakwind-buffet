/*- OrderTest.cs						Created: 10OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 10OCT20
 *	Tests the Order.cs class in the Data Library
 */

using Xunit;
using System;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data;
using System.ComponentModel;
using BleakwindBuffet.Data.Sides;
using System.Collections.Specialized;
using System.Collections;

namespace BleakwindBuffet.DataTests.UnitTests
{
	public class OrderTest
	{
		#region Interfaces
		/// <summary>
		/// Ensure that the Order impliments INotifyPropertyChanged
		/// </summary>
		[Fact]
		public void ShouldImplimentINotifyPropertyChanged()
		{
			var order = new Order();
			Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
		}

		/// <summary>
		/// Ensure that Order impliments from IOrderItem
		/// </summary>
		[Fact]
		public void ShouldImplimentINotifyCollectionChanged()
		{
			var order = new Order();
			Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
		}

		/// <summary>
		/// Ensure that Order impliments from ICollection
		/// </summary>
		[Fact]
		public void ShouldImplimentICollection()
		{
			var order = new Order();
			Assert.IsAssignableFrom<ICollection>(order);
		}
		#endregion

		#region CollectionChanged Event
		/// <summary>
		/// When adding a new IOrderItem, the correct property changed events
		/// should be triggered
		/// </summary>
		[Fact]
		public void AddingEntreeNotifiesEntreeProperty()
		{
			var order = new Order();
			var entree = new ThalmorTriple();
			var drink = new AretinoAppleJuice();
			var side = new VokunSalad();

			Assert.PropertyChanged(order, "Subtotal", () => { order.Add(entree); });
			Assert.PropertyChanged(order, "Tax", () => { order.Add(drink); });
			Assert.PropertyChanged(order, "Total", () => { order.Add(side); });
			Assert.PropertyChanged(order, "Calories", () => { order.Add(new BriarheartBurger()); });
		}

		/// <summary>
		/// When removing a new IOrderItem, the correct property changed events
		/// should be triggered
		/// </summary>
		[Fact]
		public void RemovingEntreeNotifiesEntreeProperty()
		{
			var order = new Order();
			var entree = new ThalmorTriple();
			var drink = new AretinoAppleJuice();
			var side = new VokunSalad();
			var item = new DragonbornWaffleFries();
			order.Add(entree);
			order.Add(drink);
			order.Add(side);
			order.Add(item);

			Assert.PropertyChanged(order, "Subtotal", () => { order.Remove(entree); });
			Assert.PropertyChanged(order, "Tax", () => { order.Remove(drink); });
			Assert.PropertyChanged(order, "Total", () => { order.Remove(side); });
			Assert.PropertyChanged(order, "Calories", () => { order.Remove(item); });
		}


		#endregion

		#region PropertyChanged Event

		/// <summary>
		/// Checks all notification properties that should be changed when an item
		/// within an order changes.
		/// </summary>
		/// <param name="property"></param>
		[Theory]
		[InlineData("Subtotal")]
		[InlineData("Tax")]
		[InlineData("Total")]
		[InlineData("Calories")]

		public void ChangingOrderItemNotifiesSubtotal(string property)
		{
			var order = new Order();
			var drink = new SailorSoda();
			drink.Size = Size.Small;
			var side = new VokunSalad();
			side.Size = Size.Small;
			order.Add(drink);
			order.Add(side);

			Assert.PropertyChanged(order, property, () => { drink.Size = Size.Large; });
			Assert.PropertyChanged(order, property, () => { side.Size = Size.Large; });
		}
		#endregion

		#region Accurate Returns

		/// <summary>
		///		The Price is RIGHT! make sure as we add in new items to the order
		///		(or change them) the price is updating correctly
		/// </summary>
		[Fact]
		public void PriceIsAccurate()
		{
			var order = new Order();
			var entree = new SmokehouseSkeleton();
			var drink = new CandlehearthCoffee();
			drink.Size = Size.Medium;
			var side = new MadOtarGrits();
			side.Size = Size.Large;

			PriceChecker(order, 0);
			order.Add(entree);
			PriceChecker(order, entree.Price);
			order.Add(drink);
			PriceChecker(order, (entree.Price + drink.Price));
			order.Add(side);
			PriceChecker(order, (entree.Price + drink.Price + side.Price));
			drink.Size = Size.Small;
			PriceChecker(order, (entree.Price + drink.Price + side.Price));
		}

		/// <summary>
		/// Helper method to break down and test the different components of the price:
		///		subtotal, tax, and total
		/// </summary>
		/// <param name="order">the order object being tested</param>
		/// <param name="subtotal">the subtotal that we expect</param>
		public void PriceChecker(Order order, double subtotal)
		{
			double tax = order.SalesTax;
			Assert.Equal(subtotal, order.Subtotal);
			Assert.Equal((subtotal * tax), order.Tax);
			Assert.Equal((subtotal * (1 + tax)), order.Total);
		}

		/// <summary>
		/// Check to make sure the calories stay up to date as we add in or change items
		/// </summary>
		[Fact]
		public void CaloriesIsAccurate()
		{
			var order = new Order();
			var entree = new SmokehouseSkeleton();
			var drink = new CandlehearthCoffee();
			drink.Size = Size.Medium;
			var side = new MadOtarGrits();
			side.Size = Size.Large;

			Assert.Equal((uint)0, order.Calories);
			order.Add(entree);
			Assert.Equal(entree.Calories, order.Calories);
			order.Add(drink);
			Assert.Equal((entree.Calories + drink.Calories), order.Calories);
			order.Add(side);
			Assert.Equal((entree.Calories + drink.Calories + side.Calories), order.Calories);
			side.Size = Size.Small;
			Assert.Equal((entree.Calories + drink.Calories + side.Calories), order.Calories);
		}
		#endregion

		#region Valid Ticket Numbers

		/// <summary>
		/// Make sure that every ticket order is incrimenting the ticket number.
		/// They should all be unique.
		/// </summary>
		[Fact]
		public void TicketNumberIncrementEachOrder()
		{
			int ticketNumber = new Order().TicketNumber;
			Assert.Equal(++ticketNumber, new Order().TicketNumber);
			Assert.Equal(++ticketNumber, new Order().TicketNumber);
			Assert.Equal(++ticketNumber, new Order().TicketNumber);
			Assert.Equal(++ticketNumber, new Order().TicketNumber);
			Assert.Equal(++ticketNumber, new Order().TicketNumber);
		}

		#endregion

		#region Tax gets and sets
		/// <summary>
		/// Ensure that the sales tax get and set work properly
		/// Default value should also be .12
		/// </summary>
		[Fact]
		public void TaxGetsAndSetsDefaultOf12()
		{
			var order = new Order();
			Assert.Equal(0.12, order.SalesTax);
			order.SalesTax = .20;
			Assert.Equal(.20, order.SalesTax);
		}
		#endregion

		#region Cancel Order

		/// <summary>
		/// Make sure that canceling an order removes all ordered items.
		/// </summary>
		[Fact]
		public void CancelOrderRemovesAllOrdersFromList()
		{
			var order = new Order();
			order.Add(new AretinoAppleJuice());
			order.Add(new BriarheartBurger());
			order.Add(new VokunSalad());

			Assert.Equal(3, order.Count);
			order.CancelOrder();
			Assert.Equal(0, order.Count);
		}
		#endregion
	}
}
