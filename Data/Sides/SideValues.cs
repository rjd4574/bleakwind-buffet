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
		///		All of the Side's default settings can be found here
		/// </summary>
		/// <param name="side">Reference to the sidee</param>
		///  <exception cref="NotImplementedException">if the side or size types are not implimented</exception>"
		public static void SetDefaults(Side side)
		{
			if (side is VokunSalad)
			{
				side.Size = Size.Small;
				return;
			}
			if (side is FriedMiraak)
			{
				side.Size = Size.Small;
				return;
			}
			if (side is MadOtarGrits)
			{
				side.Size = Size.Small;
				return;
			}
			if (side is DragonbornWaffleFries)
			{
				side.Size = Size.Small;
				return;
			}
			
			throw new NotImplementedException("Side Not Found");
		}

		/// <summary>
		///		Defines the prices of all sides
		/// </summary>
		/// <param name="side">reference to the side</param>
		/// <param name="size">The size of the side</param>
		/// <returns>THe price of the Side in its current state</returns>
		/// <exception cref="NotImplementedException">if the side or size types are not implimented</exception>"
		public static double Price(Side side)
		{
			if (side is VokunSalad)
			{
				switch (side.Size)
				{
					case Size.Small: return 0.93;
					case Size.Medium: return 1.28;
					case Size.Large: return 1.82;
					default: throw new NotImplementedException("Side Size not Defined");
				}
			}
			if (side is FriedMiraak)
			{
				switch (side.Size)
				{
					case Size.Small: return 1.78;
					case Size.Medium: return 2.01;
					case Size.Large: return 2.88;
					default: throw new NotImplementedException("Side Size not Defined");
				}
			}
			if (side is MadOtarGrits)
			{
				switch (side.Size)
				{
					case Size.Small: return 1.22;
					case Size.Medium: return 1.58;
					case Size.Large: return 1.93;
					default: throw new NotImplementedException("Side Size not Defined");
				}
			}
			if (side is DragonbornWaffleFries)
			{
				switch (side.Size)
				{
					case Size.Small: return 0.42;
					case Size.Medium: return 0.76;
					case Size.Large: return 0.96;
					default: throw new NotImplementedException("Side Size not Defined");
				}
			}
				
			throw new NotImplementedException("Side Not Found");
		}

		/// <summary>
		///		Defines the calories in all of the sides
		/// </summary>
		/// <param name="side">reference to the side</param>
		/// <returns>The amount of calories in the side given its 
		/// name and size</returns>
		/// <exception cref="NotImplementedException">if the side or size types are not implimented</exception>"
		public static uint Calories(Side side)
		{
			if (side is VokunSalad)
			{
				switch (side.Size)
				{
					case Size.Small: return 41;
					case Size.Medium: return 52;
					case Size.Large: return 73;
					default: throw new NotImplementedException("Side Size not Defined");
				}
			}
			if (side is FriedMiraak)
			{
				switch (side.Size)
				{
					case Size.Small: return 151;
					case Size.Medium: return 236;
					case Size.Large: return 306;
					default: throw new NotImplementedException("Side Size not Defined");
				}
			}
			if (side is MadOtarGrits)
			{
				switch (side.Size)
				{
					case Size.Small: return 105;
					case Size.Medium: return 142;
					case Size.Large: return 179;
					default: throw new NotImplementedException("Side Size not Defined");
				}
			}
			if (side is DragonbornWaffleFries)
			{
				switch (side.Size)
				{
					case Size.Small: return 77;
					case Size.Medium: return 89;
					case Size.Large: return 100;
					default: throw new NotImplementedException("Side Size not Defined");
				}
			}
			
			throw new NotImplementedException("Side Not Found");
		}
	}
}


