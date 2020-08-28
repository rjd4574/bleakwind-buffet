/*- WarriorWater.cs						Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Warrior Water (Water)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
	class WarriorWater
	{ 
		/// <summary>
		///		What size is the drink
		/// </summary>
		public Size Size { get; set; } = Size.Small;

		/// <summary>
		///		Gets the price of the Drink based on its size
		/// </summary>
		public double Price => 0.0;

		/// <summary>
		///		Gets the calories of the Drink based on its size
		/// </summary>
		public uint Calories => 0;

		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		public bool Ice { get; set; } = true;

		/// <summary>
		///		Should the drink come with lemon
		/// </summary>
		public bool Lemon { get; set; } = false;

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
		///		Overrides ToString and returns a discription of the Drink
		/// </summary>
		/// <returns>
		///		Summery depicting the drinks attributes
		/// </returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} Warrior Water";
		}
	}
}
