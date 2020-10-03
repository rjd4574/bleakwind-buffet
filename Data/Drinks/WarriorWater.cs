/*- WarriorWater.cs						Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Warrior Water (Water)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		Defines the warrior water class
	/// </summary>
	public class WarriorWater : Drink
	{
		/// <summary>
		///	Private backing variable for Ice
		/// </summary>
		private bool _ice;
		/// <summary>
		///		indicates if ice is included with this drink
		/// </summary>
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
		///		private backing variable for Lemon
		/// </summary>
		private bool _lemon;
		/// <summary>
		///		indicates if lemon is included with this drink
		/// </summary>
		public bool Lemon
		{
			get => _lemon;
			set
			{
				if (_lemon != value)
				{
					_lemon = value;
					base.OnPropertyChanged(new PropertyChangedEventArgs("Lemon"));
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
				if (!Ice) instructions.Add("Hold ice");
				if (Lemon) instructions.Add("Add lemon");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this drink will be set.
		/// </summary>
		public WarriorWater()
		{
			_name = "Warrior Water";
			DrinkValues.SetDefaults(this);
		}
	}
}
