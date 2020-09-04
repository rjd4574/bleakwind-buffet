/*- PhillyPoacher.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Entree Philly Poacher (Philly cheesesteak sandwich)
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
	public class PhillyPoacher
	{
		/// <summary>
		///		Gets the price of the Entree
		/// </summary>
		public double Price => 7.23;

		/// <summary>
		///		Gets the calories of the Entree
		/// </summary>
		public uint Calories => 784;

		/// <summary>
		///		Should the Entree include Sirloin
		/// </summary>
		public bool Sirloin { get; set; } = true;

		/// <summary>
		///		Should the Entree include mushroom
		/// </summary>
		public bool Onion { get; set; } = true;

		/// <summary>
		///		Should the Entree includ a roll
		/// </summary>
		public bool Roll { get; set; } = true;

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree
		/// </summary>
		public List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (!Sirloin) instructions.Add("Hold sirloin");
				if (!Onion) instructions.Add("Hold onions");
				if (!Roll) instructions.Add("Hold roll");
				return instructions;
			}
		}

		/// <summary>
		///		Overrides ToString and returns what Entree this represents
		/// </summary>
		/// <returns>
		///		This Entree's name!
		/// </returns>
		public override string ToString()
		{
			return "Philly Poacher";
		}
	}
}
