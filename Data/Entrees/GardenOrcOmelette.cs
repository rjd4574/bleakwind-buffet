/*- GardenOrcOmelette.cs				Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Entree Garden Orc Omelette (Vegetarian omelette)
 */


using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
	public class GardenOrcOmelette
	{
		/// <summary>
		///		Gets the price of the Entree
		/// </summary>
		public double Price => 4.57;

		/// <summary>
		///		Gets the calories of the Entree
		/// </summary>
		public uint Calories => 404;

		/// <summary>
		///		Should the Entree include Broccoli
		/// </summary>
		public bool Broccoli { get; set; } = true;

		/// <summary>
		///		Should the Entree include Mushrooms
		/// </summary>
		public bool Mushrooms { get; set; } = true;

		/// <summary>
		///		Should the Entree includ Tomato
		/// </summary>
		public bool Tomato { get; set; } = true;

		/// <summary>
		///		Should the Entree includ Cheddar
		/// </summary>
		public bool Cheddar { get; set; } = true;

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree
		/// </summary>
		public List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (!Broccoli) instructions.Add("Hold broccoli");
				if (!Mushrooms) instructions.Add("Hold mushrooms");
				if (!Tomato) instructions.Add("Hold tomato");
				if (!Cheddar) instructions.Add("Hold cheddar");
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
			return "Garden Orc Omelette";
		}
	}
}
