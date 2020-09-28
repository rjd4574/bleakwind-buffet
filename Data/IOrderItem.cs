/*- IOrderItem.cs							Created: 09SEP20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 * 
 *	An interface to be implimented by any item that can be orderd
 */

using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data
{
	/// <summary>
	///		Interface to be implimented by any order-able item
	/// </summary>
	public interface IOrderItem
	{
		string Name { get;}


		/// <summary>
		///		Defines the price of the item
		/// </summary>
		double Price {get;}

		/// <summary>
		///		Defines the amount of calories in the item
		/// </summary>
		uint Calories { get; }

		/// <summary>
		///		A list including any special instructions for the item
		/// </summary>
		List<string> SpecialInstructions { get; }
	}
}
