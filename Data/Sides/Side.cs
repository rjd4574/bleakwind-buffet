/*- Side.cs								Created: 09SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the common proprerties of a side
 */

using System;
using System.Collections.Generic;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
	/// <summary>
	///		A base class representing the common properties of a side
	/// </summary>
	public abstract class Side : IOrderItem
	{
		/// <summary>
		///		Protected backing variable for the name of the side
		/// </summary>
		protected string _name;

		/// <summary>
		/// The name of the side
		/// </summary>
		public string Name { get; }

		/// <summary>
		///		Private backing variable for the Size of the side
		/// </summary>
		private Size _size;

		/// <summary>
		///		What size is the side
		/// </summary>
		public Size Size
		{
			get => _size;
			set =>      // Only set the size if the value is valid!
				_size = (Enum.IsDefined(typeof(Size), value)) ? value :
					throw new NotImplementedException("Size is Not Defined");
		}

		/// <summary>
		///		Gets the price of the side based on its size
		/// </summary>
		public double Price => SideValues.Price(this);

		/// <summary>
		///		Gets the calories of the side based on its size
		/// </summary>
		public uint Calories => SideValues.Calories(this);

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the side. The base will return an empty set
		///		of instructions. If the child has special Instruction options
		///		it should override this method
		/// </summary>
		public virtual List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		All sides must be able to represent themselves using a valid ToString. 
		///		Base ToString will include the size and name of the side. If the child
		///		requires further description it should override this method.
		/// </summary>
		/// <returns>A string representation of the side</returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} {_name}";
		}
	}
}
