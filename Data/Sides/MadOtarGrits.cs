/*- MadOtarGrits.cs						Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Side Mad Otar Grits (Cheesy Grits)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
	public class MadOtarGrits
	{
		/// <summary>
		///		What size is the Side
		/// </summary>
		public Size Size { get; set; } = Size.Small;

		/// <summary>
		///		Gets the price of the side based on its size
		/// </summary>
		public double Price
		{
			get
			{
				return ((Size == Size.Small)	? 1.22 :
						(Size == Size.Medium)	? 1.58 :
						/* Size.Large */          1.93);
			}
		}

		/// <summary>
		///		Gets the calories of the side based on its size
		/// </summary>
		public uint Calories
		{
			get
			{
				return (uint)(	(Size == Size.Small)	? 105 :
								(Size == Size.Medium)	? 142 :
								/* Size.Large */          179);
			}
		}

		/// <summary>
		///		There are no special instructions available for sides,
		///		This results in return of an empty list
		/// </summary>
		public List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		Overrides ToString and returns a discription of the side
		/// </summary>
		/// <returns>
		///		Summery depicting the side attributes
		/// </returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} Mad Otar Grits";
		}
	}
}
