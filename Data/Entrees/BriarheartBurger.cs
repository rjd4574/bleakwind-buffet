/*- BriarheartBurger.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Entree Briarheart Burger (A 1/4 lb Burger)
 */

using System.Collections.Generic;


namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		Describes the briarheart burger class
	/// </summary>
	public class BriarheartBurger
	{
		/// <summary>
		///		Represents the name of the entree as a string.
		/// </summary>
		private string _name = "Briarheart Burger";

		/// <summary>
		///		Gets the price of the burger
		/// </summary>
		public double Price => EntreeValues.Price(_name);

		/// <summary>
		///		Gets the calories of the burger
		/// </summary>
		public uint Calories => EntreeValues.Calories(_name);

		/// <summary>
		///		Should the burger have a bun
		/// </summary>
		public bool Bun { get; set;	}

		/// <summary>
		///		Should there be ketchup on the burger
		/// </summary>
		public bool Ketchup { get; set; }

		/// <summary>
		///		Should there be mustard on the burger
		/// </summary>
		public bool Mustard { get; set; }

		/// <summary>
		///		Should there be pickle on the burger
		/// </summary>
		public bool Pickle { get; set; } 

		/// <summary>
		///		Should there be cheese on the burger
		/// </summary>
		public bool Cheese { get; set; }

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
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public BriarheartBurger()
		{
			EntreeValues.SetDefaults(_name, this);
		}

		/// <summary>
		///		Overrides and returns what Entree this represents
		/// </summary>
		/// <returns>
		///		This burger's name!
		/// </returns>
		public override string ToString()
		{
			return _name;
		}
	}
}
