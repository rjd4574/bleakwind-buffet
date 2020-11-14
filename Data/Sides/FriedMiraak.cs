/*- FriedMiraak.cs						Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Side Fried Miraak (Hash brown pancakes)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Sides
{
	/// <summary>
	///		Describes the fried miraak class
	/// </summary>
	public class FriedMiraak : Side
	{
		/// <summary>
		///		Constructor, this is where the default values of this drink will be set.
		/// </summary>
		public FriedMiraak()
		{
			_name = "Fried Miraak";
			_description = "Perfectly prepared hash brown pancakes.";
			SideValues.SetDefaults(this);
		}
	}
}
