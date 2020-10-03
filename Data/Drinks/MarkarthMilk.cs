/*- MarkarthMilk.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Markarth Milk (2% milk)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		Describes the Markarth Milk class
	/// </summary>
	public class MarkarthMilk : Drink
	{
		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		private bool _ice;  //private backing variable
		public bool Ice
		{
			get => _ice;
			set
			{
				if (_ice != value)
				{
					_ice = value;
					base.OnPropertyChanged(new PropertyChangedEventArgs("Ice"));
				}
			}
		}

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Drink
		/// </summary>
		public override List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (Ice) instructions.Add("Add ice");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this drink will be set.
		/// </summary>
		public MarkarthMilk()
		{
			_name = "Markarth Milk";
			DrinkValues.SetDefaults(this);
		}
	}
}
