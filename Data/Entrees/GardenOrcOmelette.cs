/*- GardenOrcOmelette.cs				Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 01OCT20
 *	Defines the Entree Garden Orc Omelette (Vegetarian omelette)
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		Desbribes the garden orc omelette class
	/// </summary>
	public class GardenOrcOmelette : Entree
	{
		/// <summary>
		///		Private backing variable for Broccoli
		/// </summary>
		private bool _broccoli;
		/// <summary>
		///		Should the Entree include Broccoli
		/// </summary>
		public bool Broccoli
		{
			get => _broccoli;
			set
			{
				if (_broccoli != value)
				{
					_broccoli = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Broccoli"));
				}
			}
		}

		/// <summary>
		/// private backing variable for Mushrooms
		/// </summary>
		private bool _mushrooms;
		/// <summary>
		///		Should the Entree include Mushrooms
		/// </summary>
		public bool Mushrooms
		{
			get => _mushrooms;
			set
			{
				if (_mushrooms != value)
				{
					_mushrooms = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Mushrooms"));
				}
			}
		}

		/// <summary>
		/// private backing variable for Tomato
		/// </summary>
		private bool _tomato;
		/// <summary>
		///		Should the Entree includ Tomato
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
		/// private backing variable for Cheddar
		/// </summary>
		private bool _cheddar;
		/// <summary>
		///		Should the Entree includ Cheddar
		/// </summary>
		public bool Cheddar
		{
			get => _cheddar;
			set
			{
				if (_cheddar != value)
				{
					_cheddar = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Cheddar"));
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
				if (!Broccoli) instructions.Add("Hold broccoli");
				if (!Mushrooms) instructions.Add("Hold mushrooms");
				if (!Tomato) instructions.Add("Hold tomato");
				if (!Cheddar) instructions.Add("Hold cheddar");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public GardenOrcOmelette()
		{
			_name = "Garden Orc Omelette";
			_description = "Vegetarian. Two egg omelette packed with a mix of broccoli, mushrooms, and tomatoes. Topped with cheddar cheese.";
			EntreeValues.SetDefaults(this);
		}
	}
}
