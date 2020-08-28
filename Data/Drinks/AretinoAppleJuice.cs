﻿/*- AretinoAppleJuice.cs				Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Aretino Apple Juice (Apple juice)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
	public class AretinoAppleJuice
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
				return ((Size == Size.Small)	? 0.62 :
						(Size == Size.Medium)	? 0.87 :
						/* Size.Large */          1.01);
			}
		}

		/// <summary>
		///		Gets the calories of the Drink based on its size
		/// </summary>
		public uint Calories
		{
			get
			{
				return (uint)(	(Size == Size.Small)	? 44 :
								(Size == Size.Medium)	? 88 :
								/* Size.Large */          132);
			}
		}

		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		public bool Ice { get; set; } = false;

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
			return $"{EnumExt.Print(Size)} Aretino Apple Juice";
		}
	}
}
