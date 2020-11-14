/*- BriarheartBurger.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last modified: 01OCT20
 *	Defines the Entree Briarheart Burger (A 1/4 lb Burger)
 */

using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		Describes the briarheart burger class
	/// </summary>
	public class BriarheartBurger : Entree
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
				if(_bun != value)
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
		///		Create a list of special instructions to be followed
		///		when making the burger
		/// </summary>
		public override List<string> SpecialInstructions
		{
			get
			{
				List<string>	instructions = new List<string>();
				if (!Bun)		instructions.Add("Hold bun");
				if (!Ketchup)	instructions.Add("Hold ketchup");
				if (!Mustard)	instructions.Add("Hold mustard");
				if (!Pickle)	instructions.Add("Hold pickle");
				if (!Cheese)	instructions.Add("Hold cheese");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public BriarheartBurger()
		{
			_name = "Briarheart Burger";
			_description = "Single patty burger on a brioche bun. Comes with ketchup, mustard, pickle, and cheese.";
			EntreeValues.SetDefaults(this);
		}
	}
}
