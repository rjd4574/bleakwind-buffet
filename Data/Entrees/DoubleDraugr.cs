/*- DoubleDraugr.cs						Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 20OCT20
 *	Defines the Entree Double Draugr (A 1/2 lb Burger)
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		Describes the Double draugr burger class
	/// </summary>
	public class DoubleDraugr : Entree
	{
		/// <summary>
		///		Private backing variable for Bun
		/// </summary>
		private bool _bun;
		/// <summary>
		///		Indicates if a bun is included in this order
		/// </summary>
		public bool Bun
		{
			get => _bun;
			set
			{
				if (_bun != value)
				{
					_bun = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Bun"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for Ketchup
		/// </summary>
		private bool _ketchup;
		/// <summary>
		///		Indicates if Ketchup is included in this order
		/// </summary>
		public bool Ketchup
		{
			get => _ketchup;
			set
			{
				if (_ketchup != value)
				{
					_ketchup = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Ketchup"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for Mustard
		/// </summary>
		private bool _mustard;
		/// <summary>
		///		Indicates if Mustard is included in this order
		/// </summary>
		public bool Mustard
		{
			get => _mustard;
			set
			{
				if (_mustard != value)
				{
					_mustard = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Mustard"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for Pickle
		/// </summary>
		private bool _pickle;
		/// <summary>
		///		Should there be pickle on the burger
		/// </summary>
		public bool Pickle
		{
			get => _pickle;
			set
			{
				if (_pickle != value)
				{
					_pickle = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Pickle"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for Cheese
		/// </summary>
		private bool _cheese;
		/// <summary>
		///		Should there be cheese on the burger
		/// </summary>
		public bool Cheese
		{
			get => _cheese;
			set
			{
				if (_cheese != value)
				{
					_cheese = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Cheese"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for Tomato
		/// </summary>
		private bool _tomato;
		/// <summary>
		///		Should there be Tomato on the burger
		/// </summary>
		public bool Tomato
		{
			get => _tomato;
			set
			{
				if (_tomato != value)
				{
					_tomato = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Tomato"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for Lettuce
		/// </summary>
		private bool _lettuce;
		/// <summary>
		///		Should there be Lettuce on the burger
		/// </summary>
		public bool Lettuce
		{
			get => _lettuce;
			set
			{
				if (_lettuce != value)
				{
					_lettuce = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Lettuce"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for Mayo
		/// </summary>
		private bool _mayo;
		/// <summary>
		///		Should there be Mayo on the burger
		/// </summary>
		public bool Mayo
		{
			get => _mayo;
			set
			{
				if (_mayo != value)
				{
					_mayo = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Mayo"));
				}
			}
		}

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the burger
		/// </summary>
		public override List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (!Bun) instructions.Add("Hold bun");
				if (!Ketchup) instructions.Add("Hold ketchup");
				if (!Mustard) instructions.Add("Hold mustard");
				if (!Pickle) instructions.Add("Hold pickle");
				if (!Cheese) instructions.Add("Hold cheese");
				if (!Tomato) instructions.Add("Hold tomato");
				if (!Lettuce) instructions.Add("Hold lettuce");
				if (!Mayo) instructions.Add("Hold mayo");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public DoubleDraugr()
		{
			_name = "Double Draugr";
			EntreeValues.SetDefaults(this);
		}
	}
}
