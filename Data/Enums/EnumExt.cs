/*- EnumExt.cs							Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	An extention enum's functionality, allowing us to more easily 
 *	express the values/properties of our enums as we see fit
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Enums
{
	public static class EnumExt
	{
		/// <summary>
		///		Allows user to translate our enum into a string representation
		/// </summary>
		/// <param name="flavor">
		///		SodaFlavor enum to be translated into a string
		/// </param>
		/// <returns>
		///		returns a string value that represents flavor
		/// </returns>
		public static string Print( SodaFlavor flavor )
		{
			switch(flavor)
			{
				case SodaFlavor.Blackberry:
					return "Blackberry";
				case SodaFlavor.Cherry:
					return "Cherry";
				case SodaFlavor.Grapefruit:
					return "Grapefruit";
				case SodaFlavor.Lemon:
					return "Lemon";
				case SodaFlavor.Peach:
					return "Peach";
				case SodaFlavor.Watermelon:
					return "Watermelon";
				default:
					throw new ArgumentOutOfRangeException("Soda Flavor Doesn't Exist");
			}
		}

		/// <summary>
		///		Allows user to translate our enum into a string representation
		/// </summary>
		/// <param name="size">
		///		Sizer enum to be translated into a string
		/// </param>
		/// <returns>
		///		returns a string value that represents Size
		/// </returns>
		public static string Print( Size size )
		{
			switch( size )
			{
				case Size.Small:
					return "Small";
				case Size.Medium:
					return "Medium";
				case Size.Large:
					return "Large";
				default:
					throw new ArgumentOutOfRangeException("Size Doesn't Exist");
			}
		}
	}
}
