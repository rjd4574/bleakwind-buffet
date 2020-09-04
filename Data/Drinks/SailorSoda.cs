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
	public class SailorSoda
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
				return ((Size == Size.Small)	? 1.42 :
						(Size == Size.Medium)	? 1.74 :
						/* Size.Large */          2.07);
			}
		}

		/// <summary>
		///		Gets the calories of the Drink based on its size
		/// </summary>
		public uint Calories
		{
			get
			{
				return (uint)(	(Size == Size.Small)	? 117 :
								(Size == Size.Medium)	? 153 :
								/* Size.Large */          205);
			}
		}

		/// <summary>
		///		Get/Set the flavor of the drink
		/// </summary>
		public SodaFlavor Flavor { get; set; } = SodaFlavor.Cherry;

		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		public bool Ice { get; set; } = true;

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Drink
		/// </summary>
		public List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (Ice) instructions.Add("Hold ice");
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
			return $"{EnumExt.Print(Size)} {EnumExt.Print(Flavor)} Sailor Soda";
		}

	}
}
