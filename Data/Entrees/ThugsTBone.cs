/*- PhillyPoacher.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Entree Thugs T-Bone (T-Bone)
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{

	/// <summary>
	/// Describes the thugs T-Bone class
	/// </summary>
	public class ThugsTBone
	{
		/// <summary>
		///		Represents the name of the entree as a string.
		/// </summary>
		private string _name = "Thugs T-Bone";

		/// <summary>
		///		Gets the price of the Entree
		/// </summary>
		public double Price => EntreeValues.Price(_name);

		/// <summary>
		///		Gets the calories of the Entree
		/// </summary>
		public uint Calories => EntreeValues.Calories(_name);

		/// <summary>
		///		There are no special instructions available for this Entree,
		///		This results in return of an empty list
		/// </summary>
		public List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public ThugsTBone()
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
