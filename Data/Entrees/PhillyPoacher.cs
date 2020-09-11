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
	/// <summary>
	///		Describes the phillypoacher class
	/// </summary>
	public class PhillyPoacher : Entree
	{
		/// <summary>
		///		Should the Entree include Sirloin
		/// </summary>
		public bool Sirloin { get; set; } 

		/// <summary>
		///		Should the Entree include mushroom
		/// </summary>
		public bool Onion { get; set; } 

		/// <summary>
		///		Should the Entree includ a roll
		/// </summary>
		public bool Roll { get; set; } 

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree
		/// </summary>
		public override List<string> SpecialInstructions
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
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public PhillyPoacher()
		{
			_name = "Philly Poacher";
			EntreeValues.SetDefaults(this);
		}
	}
}
