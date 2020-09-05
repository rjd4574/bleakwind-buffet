/*- SailorSoda.cs						Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Sailor Soda (Old-fashioned soda)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		Describes the sailor soda drink
	/// </summary>
	public class SailorSoda
	{
		/// <summary>
		///		Represents the name of the drink as a string.
		/// </summary>
		private string _name = "Sailor Soda";

		/// <summary>
		///		Private backing variable for the size of the drink
		/// </summary>
		private Size _size;
		/// <summary>
		///		Private backing variable for the flavor of the drink
		/// </summary>
		private SodaFlavor _flavor;

		/// <summary>
		///		The size of the drink
		/// </summary>
		/// <Exception cref="System.NotImplementedException">
		///		Thrown when Size is invalid
		/// </Exception>
		public Size Size
		{
			get => _size;
			set =>		// Only set the size if the value is valid!
				_size = (Enum.IsDefined(typeof(Size), value)) ? value :
					throw new NotImplementedException("Size is Not Defined");
		}

		/// <summary>
		///		Gets the price of the Drink based on its size
		/// </summary>
		public double Price => DrinkValues.Price(_name, Size);

		/// <summary>
		///		Gets the calories of the Drink based on its size
		/// </summary>
		public uint Calories => DrinkValues.Calories(_name, Size);

		/// <summary>
		///		Get/Set the flavor of the drink
		/// </summary>
		public SodaFlavor Flavor
		{
			get => _flavor;
			set =>      // Only set the size if the value is valid!
				_flavor = (Enum.IsDefined(typeof(SodaFlavor), value)) ? value :
					throw new NotImplementedException("Flavor is Not Defined");
		}

		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		public bool Ice { get; set; }

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Drink
		/// </summary>
		public List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (!Ice) instructions.Add("Hold ice");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this drink will be set.
		/// </summary>
		public SailorSoda()
		{
			DrinkValues.SetDefaults(_name,this);
		}

		/// <summary>
		///		Overrides ToString and returns a discription of the Drink
		/// </summary>
		/// <returns>
		///		Summery depicting the drinks attributes
		/// </returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} {EnumExt.Print(Flavor)} {_name}";
		}

	}
}
