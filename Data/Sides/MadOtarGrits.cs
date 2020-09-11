/*- MadOtarGrits.cs						Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Side Mad Otar Grits (Cheesy Grits)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Sides
{
	/// <summary>
	///		Describes the mad otar grits class
	/// </summary>
	public class MadOtarGrits : Side
	{
		/// <summary>
		///		Constructor, this is where the default values of this side will be set.
		/// </summary>
		public MadOtarGrits()
		{
			_name = "Mad Otar Grits";
			SideValues.SetDefaults(this);
		}
	}
}
