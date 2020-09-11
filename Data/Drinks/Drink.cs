/*- Drink.cs							Created: 09SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the common proprerties of a Drink
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		A base class representing the common properties of a Drink
	/// </summary>
	public abstract class Drink : IOrderItem
	{
		/// <summary>
		///		Protected backing variable for the name of the drink
		/// </summary>
		protected string _name;

		/// <summary>
		/// The name of the drink
		/// </summary>
		public string Name { get; }

		/// <summary>
		///		Private backing variable for the Size of the drink
		/// </summary>
		private Size _size;

		/// <summary>
		///		What size is the drink
		/// </summary>
		public Size Size
		{
			get => _size;
			set =>      // Only set the size if the value is valid!
				_size = (Enum.IsDefined(typeof(Size), value)) ? value :
					throw new NotImplementedException("Size is Not Defined");
		}

		/// <summary>
		///		Gets the price of the Drink based on its size
		/// </summary>
		public double Price => DrinkValues.Price(this);

		/// <summary>
		///		Gets the calories of the Drink based on its size
		/// </summary>
		public uint Calories => DrinkValues.Calories(this);

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Drink. The base will return an empty set
		///		of instructions. If the child has special Instruction options
		///		it should override this method
		/// </summary>
		public virtual List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		All Drinks must be able to represent themselves using a valid ToString. 
		///		Base ToString will include the size and name of the drink. If the child
		///		requires further description it should override this method.
		/// </summary>
		/// <returns>A string representation of the drink</returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} {_name}";
		}
	}
}
