/*- CandleHearthCoffee.cs				Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Candlehearth Coffee (Coffee)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
	class CandleHearthCoffee
	{ 
		/// <summary>
		///		What size is the drink
		/// </summary>
		public Size Size { get; set; } = Size.Small;

		/// <summary>
		///		Gets the price of the Drink based on its size
		/// </summary>
		public double Price
		{
			get
			{
				return ((Size == Size.Small)	? 0.75 :
						(Size == Size.Medium)	? 1.25 :
						/* Size.Large */          1.75);
			}
		}

		/// <summary>
		///		Gets the calories of the Drink based on its size
		/// </summary>
		public uint Calories
		{
			get
			{
				return (uint)(	(Size == Size.Small)	? 7 :
								(Size == Size.Medium)	? 10 :
								/* Size.Large */          20);
			}
		}

		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		public bool Ice { get; set; } = false;

		/// <summary>
		///		Should the drink come with room for cream
		/// </summary>
		public bool RoomForCream { get; set; } = false;

		/// <summary>
		///		Should the drink be Decaf
		/// </summary>
		public bool Decaf { get; set; } = false;

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Drink
		/// </summary>
		public List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (Ice) instructions.Add("Add ice");
				if (RoomForCream) instructions.Add("Add cream");
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
			return $"{EnumExt.Print(Size)} {((Decaf) ? "Decaf" : "")} Candlehearth Coffee";
		}
	}
}
