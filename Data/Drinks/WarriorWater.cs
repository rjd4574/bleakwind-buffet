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
	public class WarriorWater : Drink
	{
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
		public override List<string> SpecialInstructions
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
			_name = "Warrior Water";
			DrinkValues.SetDefaults(this);
		}
	}
}
