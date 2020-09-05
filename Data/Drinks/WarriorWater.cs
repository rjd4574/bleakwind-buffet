/*- WarriorWater.cs						Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Warrior Water (Water)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		Defines the warrior water class
	/// </summary>
	public class WarriorWater
	{
		/// <summary>
		///		Represents the name of the drink as a string.
		/// </summary>
		private string _name = "Warrior Water";

		/// <summary>
		///		Private backing variable for the size of the drink
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
		public double Price => DrinkValues.Price(_name, Size);

		/// <summary>
		///		Gets the calories of the Drink based on its size
		/// </summary>
		public uint Calories => DrinkValues.Calories(_name, Size);

		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		public bool Ice { get; set; }

		/// <summary>
		///		Should the drink come with lemon
		/// </summary>
		public bool Lemon { get; set; }

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
				if (Lemon) instructions.Add("Add lemon");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this drink will be set.
		/// </summary>
		public WarriorWater()
		{
			DrinkValues.SetDefaults(_name, this);
		}

		/// <summary>
		///		Overrides ToString and returns a discription of the Drink
		/// </summary>
		/// <returns>
		///		Summery depicting the drinks attributes
		/// </returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} {_name}";
		}
	}
}
