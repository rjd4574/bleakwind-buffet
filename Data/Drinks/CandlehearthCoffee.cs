/*- CandlehearthCoffee.cs				Created: 27AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 * 
 *	Defines the Drink Candlehearth Coffee (Coffee)
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		Class representing the Candle
	/// </summary>
	public class CandlehearthCoffee : Drink
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
		///		Should the drink come with room for cream
		/// </summary>
		private bool _roomForCream;
		public bool RoomForCream
		{
			get => _roomForCream;
			set
			{
				if (_roomForCream != value)
				{
					_roomForCream = value;
					base.OnPropertyChanged(new PropertyChangedEventArgs("RoomForCream"));
				}
			}
		}

		/// <summary>
		///		Should the drink be Decaf
		/// </summary>
		private bool _decaf;	//private backing variable
		public bool Decaf
		{
			get => _decaf;
			set
			{
				if (_decaf != value)
				{
					_decaf = value;
					base.OnPropertyChanged(new PropertyChangedEventArgs("Decaf"));
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
				if (RoomForCream) instructions.Add("Add cream");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this drink will be set.
		/// </summary>
		public CandlehearthCoffee()
		{
			_name = "Candlehearth Coffee";
			DrinkValues.SetDefaults( this );
		}
		
		/// <summary>
		///		Overrides ToString and returns a discription of the Drink
		/// </summary>
		/// <returns>
		///		Summery depicting the drinks attributes
		/// </returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)}{((Decaf) ? " Decaf " : " ")}{_name}";
		}
	}
}
