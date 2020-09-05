/*- SideValues.cs						Created: 03SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	This consolidates all information about BleakwindBuffet's 
 *	sides all in one spot. You can change defaults/price/calories/
 *	or any other property.
 */

using BleakwindBuffet.Data.Enums;
using System;

namespace BleakwindBuffet.Data.Sides
{
	/// <summary>
	///		Allows consolidation of all the sides' proprties
	///		for future changes.
	/// </summary>
	public static class SideValues
	{
		/// <summary>
		///		This is called in the constructor of a side.
		///		All of the drink's default settings can be found here
		/// </summary>
		/// <param name="side">The name of the side</param>
		/// <param name="d">A reference to the side</param>
		public static void SetDefaults(string side, Object s)
		{
			switch (side)
			{
				case "Vokun Salad":
					var salad = (VokunSalad)s;
					salad.Size = Size.Small;
					break;
				case "Fried Miraak":
					var miraak = (FriedMiraak)s;
					miraak.Size = Size.Small;
					break;
				case "Mad Otar Grits":
					var grits = (MadOtarGrits)s;
					grits.Size = Size.Small;
					break;
				case "Dragonborn Waffle Fries":
					var fries = (DragonbornWaffleFries)s;
					fries.Size = Size.Small;
					break;
				default: throw new NotImplementedException("Side Not Found");
			}
		}

		/// <summary>
		///		Defines the prices of all side
		/// </summary>
		/// <param name="side">The name of the side</param>
		/// <param name="size">The size of the side</param>
		/// <returns>THe price of the drink given its name and size</returns>
		public static double Price(string side, Size size)
		{
			switch (side)
			{
				case "Vokun Salad":
					switch (size)
					{
						case Size.Small: return 0.93;
						case Size.Medium: return 1.28;
						case Size.Large: return 1.82;
						default: throw new NotImplementedException("Side Size not Defined");
					}
				case "Fried Miraak":
					switch (size)
					{
						case Size.Small: return 1.78;
						case Size.Medium: return 2.01;
						case Size.Large: return 2.88;
						default: throw new NotImplementedException("Side Size not Defined");
					}
				case "Mad Otar Grits": 
					switch (size)
					{
						case Size.Small: return 1.22;
						case Size.Medium: return 1.58;
						case Size.Large: return 1.93;
						default: throw new NotImplementedException("Side Size not Defined");
					}
				case "Dragonborn Waffle Fries":
					switch (size)
					{
						case Size.Small: return 0.42;
						case Size.Medium: return 0.76;
						case Size.Large: return 0.96;
						default: throw new NotImplementedException("Side Size not Defined");
					}
				default: throw new NotImplementedException("Side Not Found");
			}
		}

		/// <summary>
		///		Defines the calories in all of the side
		/// </summary>
		/// <param name="side">The name of the side</param>
		/// <param name="size">The size of the side</param>
		/// <returns>The amount of calories in the drink given its 
		/// name and size
		/// </returns>
		public static uint Calories(string side, Size size)
		{
			switch (side)
			{
				case "Vokun Salad":
					switch (size)
					{
						case Size.Small: return 41;
						case Size.Medium: return 52;
						case Size.Large: return 73;
						default: throw new NotImplementedException("Side Size not Defined");
					}
				case "Fried Miraak":
					switch (size)
					{
						case Size.Small: return 151;
						case Size.Medium: return 236;
						case Size.Large: return 306;
						default: throw new NotImplementedException("Side Size not Defined");
					}
				case "Mad Otar Grits":
					switch (size)
					{
						case Size.Small: return 105;
						case Size.Medium: return 142;
						case Size.Large: return 179;
						default: throw new NotImplementedException("Side Size not Defined");
					}
				case "Dragonborn Waffle Fries":
					switch (size)
					{
						case Size.Small: return 77;
						case Size.Medium: return 89;
						case Size.Large: return 100;
						default: throw new NotImplementedException("Side Size not Defined");
					}
				default: throw new NotImplementedException("Side Not Found");
			}
		}
	}
}

/* copy/paste for creating new definitions 
switch (side)
{
	case "Vokun Salad": return;
	case "Fried Miraak": return;
	case "Mad Otar Grits": return;
	case "Dragonborn Waffle Fries": return;
	default: throw new NotImplementedException("Side Not Found");
}
*/
