/*- SmokehouseSkeleton.cs				Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Entree Smokehouse Skeleton (Breakfast combo)
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		Describes the smokehouse skeleton class
	/// </summary>
	public class SmokehouseSkeleton
	{
		/// <summary>
		///		Represents the name of the entree as a string.
		/// </summary>
		private string _name = "Smokehouse Skeleton";

		/// <summary>
		///		Gets the price of the Entree
		/// </summary>
		public double Price => EntreeValues.Price(_name);

		/// <summary>
		///		Gets the calories of the Entree
		/// </summary>
		public uint Calories => EntreeValues.Calories(_name);

		/// <summary>
		///		Should the Entree include Sausage Links
		/// </summary>
		public bool SausageLink { get; set; }

		/// <summary>
		///		Should the Entree include Eggs
		/// </summary>
		public bool Egg { get; set; }

		/// <summary>
		///		Should the Entree includ hash browns
		/// </summary>
		public bool HashBrowns { get; set; }

		/// <summary>
		///		Should the Entree includ pancakes
		/// </summary>
		public bool Pancake { get; set; }

		/// <summary>
		///		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree
		/// </summary>
		/// </summary>
		public List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (!SausageLink) instructions.Add("Hold sausage");
				if (!Egg) instructions.Add("Hold eggs");
				if (!HashBrowns) instructions.Add("Hold hash browns");
				if (!Pancake) instructions.Add("Hold pancakes");
				return instructions;
			}
		}
		/// <summary>
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public SmokehouseSkeleton()
		{
			EntreeValues.SetDefaults(_name, this);
		}

		/// <summary>
		///		Overrides ToString and returns what Entree this represents
		/// </summary>
		/// <returns>
		///		This Entree's name!
		/// </returns>
		public override string ToString()
		{
			return _name;
		}
	}
}
