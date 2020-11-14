/*- VokunSalad.cs						Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Side Vokun Salad (A fruit salad)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
	/// <summary>
	///		Definition of the vokun salad class
	/// </summary>
	public class VokunSalad : Side
	{
		/// <summary>
		///		Constructor, this is where the default values of this side will be set.
		/// </summary>
		public VokunSalad()
		{
			_name = "Vokun Salad";
			_description = "A seasonal fruit salad of mellons, berries, mango, grape, apple, and oranges.";
			SideValues.SetDefaults(this);
		}
	}
}
