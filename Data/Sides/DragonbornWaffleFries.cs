/*- DragonbornWaffleFries.cs			Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Side Dragonborn Waffle Fries (Cajun fries)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Sides
{
	/// <summary>
	///		Describes the dragonborn waffle fries class
	/// </summary>
	public class DragonbornWaffleFries : Side
	{
		/// <summary>
		///		Constructor, this is where the default values of this side will be set.
		/// </summary>
		public DragonbornWaffleFries()
		{
			_name = "Dragonborn Waffle Fries";
			SideValues.SetDefaults(this);
		}
	}
}
