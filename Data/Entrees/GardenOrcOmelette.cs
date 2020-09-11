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
	/// <summary>
	///		Desbribes the garden orc omelette class
	/// </summary>
	public class GardenOrcOmelette : Entree
	{
		/// <summary>
		///		Should the Entree include Broccoli
		/// </summary>
		public bool Broccoli { get; set; }

		/// <summary>
		///		Should the Entree include Mushrooms
		/// </summary>
		public bool Mushrooms { get; set; } 

		/// <summary>
		///		Should the Entree includ Tomato
		/// </summary>
		public bool Tomato { get; set; } 

		/// <summary>
		///		Should the Entree includ Cheddar
		/// </summary>
		public bool Cheddar { get; set; }

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree
		/// </summary>
		public override List<string> SpecialInstructions
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
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public GardenOrcOmelette()
		{
			_name = "Garden Orc Omelette";
			EntreeValues.SetDefaults(this);
		}
	}
}
