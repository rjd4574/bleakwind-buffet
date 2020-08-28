/*- PhillyPoacher.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Entree Thugs T-Bone (T-Bone)
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entree
{
	public class ThugsTBone
	{
		/// <summary>
		///		Gets the price of the Entree
		/// </summary>
		public double Price => 6.44;

		/// <summary>
		///		Gets the calories of the Entree
		/// </summary>
		public uint Calories => 982;

		/// <summary>
		///		There are no special instructions available for this Entree,
		///		This results in return of an empty list
		/// </summary>
		public List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		Overrides ToString and returns what Entree this represents
		/// </summary>
		/// <returns>
		///		This Entree's name!
		/// </returns>
		public override string ToString()
		{
			return "Thugs T-Bone";
		}
	}
}
