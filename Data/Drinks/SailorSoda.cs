/*- SailorSoda.cs						Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Sailor Soda (Old-fashioned soda)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		Describes the sailor soda drink
	/// </summary>
	public class SailorSoda : Drink
	{
		/// <summary>
		///		Private backing variable for the Flavor of the drink
		/// </summary>
		private SodaFlavor _flavor;
		/// <summary>
		///		Get/Set the flavor of the drink
		/// </summary>
		public SodaFlavor Flavor
		{
			get => _flavor;
			set =>      // Only set the size if the value is valid!
				_flavor = (Enum.IsDefined(typeof(SodaFlavor), value)) ? value :
					throw new NotImplementedException("Flavor is Not Defined");
		}

		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		public bool Ice { get; set; }

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Drink
		/// </summary>
		public override List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (!Ice) instructions.Add("Hold ice");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this drink will be set.
		/// </summary>
		public SailorSoda()
		{
			_name = "Sailor Soda";
			DrinkValues.SetDefaults(this);
		}
		
		/// <summary>
		///		Overrides ToString and returns a discription of the Drink
		/// </summary>
		/// <returns>
		///		Summery depicting the drinks attributes
		/// </returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} {EnumExt.Print(Flavor)} {_name}";
		}

	}
}
