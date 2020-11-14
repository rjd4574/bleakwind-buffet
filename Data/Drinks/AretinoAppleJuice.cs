/*- AretinoAppleJuice.cs				Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 01OCT20
 *	Defines the Drink Aretino Apple Juice (Apple juice)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		Class representing the Aretino Apple Juice
	/// </summary>
	public class AretinoAppleJuice : Drink
	{
		/// <summary>
		///		Should the drink come with ice
		/// </summary>
		private bool _ice;	//private backing variable
		public bool Ice 
		{
			get => _ice;
			set
			{
				if( _ice != value )
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
		public AretinoAppleJuice()
		{
			_name = "Aretino Apple Juice";
			_description = "Fresh squeezed apple juice.";
			DrinkValues.SetDefaults(this);
		}
	}
}
