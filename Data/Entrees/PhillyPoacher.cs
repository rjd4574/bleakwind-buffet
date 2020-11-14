/*- PhillyPoacher.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 01Oct20
 *	Defines the Entree Philly Poacher (Philly cheesesteak sandwich)
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		Describes the phillypoacher class
	/// </summary>
	public class PhillyPoacher : Entree
	{
		/// <summary>
		///		Private backing variable for Sirloin
		/// </summary>
		private bool _sirloin;
		/// <summary>
		///		Should the Entree include Sirloin
		/// </summary>
		public bool Sirloin
		{
			get => _sirloin;
			set
			{
				if (_sirloin != value)
				{
					_sirloin = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Sirloin"));
				}
			}
		}

		/// <summary>
		/// private backing variable for Onion
		/// </summary>
		private bool _onion;
		/// <summary>
		///		Should the Entree include mushroom
		/// </summary>
		public bool Onion
		{
			get => _onion;
			set
			{
				if (_onion != value)
				{
					_onion = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Onion"));
				}
			}
		}

		/// <summary>
		/// private backing variable for Roll
		/// </summary>
		private bool _roll;
		/// <summary>
		///		Should the Entree includ a roll
		/// </summary>
		public bool Roll
		{
			get => _roll;
			set
			{
				if (_roll != value)
				{
					_roll = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Roll"));
				}
			}
		}

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree
		/// </summary>
		public override List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (!Sirloin) instructions.Add("Hold sirloin");
				if (!Onion) instructions.Add("Hold onions");
				if (!Roll) instructions.Add("Hold roll");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public PhillyPoacher()
		{
			_name = "Philly Poacher";
			_description = "Cheesesteak sandwich made from grilled sirloin, topped with onions on a fried roll.";
			EntreeValues.SetDefaults(this);
		}
	}
}
