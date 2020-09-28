/*- Entree.cs							Created: 09SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the common proprerties of an Entree
 */

using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		A base class representing the common properties of an Entree
	/// </summary>
	public abstract class Entree : IOrderItem
	{
		/// <summary>
		///		Protected backing variable for the name of the Entree
		/// </summary>
		protected string _name;

		/// <summary>
		/// The name of the Entree
		/// </summary>
		public string Name => _name;

		/// <summary>
		///		Gets the price of the Entree
		/// </summary>
		public double Price => EntreeValues.Price(this);

		/// <summary>
		///		Gets the calories of the Entree
		/// </summary>
		public uint Calories => EntreeValues.Calories(this);

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree. The base will return an empty set
		///		of instructions. If the child has special Instruction options
		///		it should override this method
		/// </summary>
		public virtual List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		All Entrees must be able to represent themselves using a valid ToString 
		///		The base class will return just the name of the Entree. Any child requiring 
		///		a different description should override this method.
		/// </summary>
		/// <returns>A string representation of the Entree</returns>
		public override string ToString()
		{
			return _name;
		}
	}
}
