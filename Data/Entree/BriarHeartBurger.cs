/*- BriarHeartBurger.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Entree Briarheart Burger (A 1/4 lb Burger)
 */


using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BleakwindBuffet.Data.Entree
{
	public class BriarHeartBurger
	{
		/// <summary>
		///		Gets the price of the burger
		/// </summary>
		public double Price => 6.32;

		/// <summary>
		///		Gets the calories of the burger
		/// </summary>
		public uint Calories => 732;

		/// <summary>
		///		Should the burger have a bun
		/// </summary>
		public bool Bun { get; set;	} = true;

		/// <summary>
		///		Should there be ketchup on the burger
		/// </summary>
		public bool Ketchup { get; set; } = true;

		/// <summary>
		///		Should there be mustard on the burger
		/// </summary>
		public bool Mustard { get; set; } = true;

		/// <summary>
		///		Should there be pickle on the burger
		/// </summary>
		public bool Pickle { get; set; } = true;

		/// <summary>
		///		Should there be cheese on the burger
		/// </summary>
		public bool Cheese { get; set; } = true;

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the burger
		/// </summary>
		public List<string> SpecialInstructions
		{
			get
			{
				List<string>	instructions = new List<string>();
				if (!Bun)		instructions.Add("Hold bun");
				if (!Ketchup)	instructions.Add("Hold ketchup");
				if (!Mustard)	instructions.Add("Hold mustard");
				if (!Pickle)	instructions.Add("Hold pickle");
				if (!Cheese)	instructions.Add("Hold cheese");
				return instructions;
			}
		}

		/// <summary>
		///		Overrides and returns what Entree this represents
		/// </summary>
		/// <returns>
		///		This burger's name!
		/// </returns>
		public override string ToString()
		{
			return "Briarheart Burger";
		}
	}
}
