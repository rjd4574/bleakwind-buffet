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
	public class VokunSalad
	{
		/// <summary>
		///		Represents the name of the side as a string.
		/// </summary>
		private string _name = "Vokun Salad";

		/// <summary>
		///		Private backing variable for the size of the side
		/// </summary>
		private Size _size;

		/// <summary>
		///		What size is the side
		/// </summary>
		public Size Size
		{
			get => _size;
			set =>      // Only set the size if the value is valid!
				_size = (Enum.IsDefined(typeof(Size), value)) ? value :
					throw new NotImplementedException("Size is Not Defined");
		}

		/// <summary>
		///		Gets the price of the side based on its size
		/// </summary>
		public double Price => SideValues.Price(_name, Size);

		/// <summary>
		///		Gets the calories of the side based on its size
		/// </summary>
		public uint Calories => SideValues.Calories(_name, Size);

		/// <summary>
		///		There are no special instructions available for sides,
		///		This results in return of an empty list
		/// </summary>
		public List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		Constructor, this is where the default values of this side will be set.
		/// </summary>
		public VokunSalad()
		{
			SideValues.SetDefaults(_name, this);
		}

		/// <summary>
		///		Overrides ToString and returns a discription of the side
		/// </summary>
		/// <returns>
		///		Summery depicting the side attributes
		/// </returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} {_name}";
		}
	}
}
