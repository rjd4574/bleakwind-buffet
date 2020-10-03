/*- SmokehouseSkeleton.cs				Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 01OCT20
 *	Defines the Entree Smokehouse Skeleton (Breakfast combo)
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		Describes the smokehouse skeleton class
	/// </summary>
	public class SmokehouseSkeleton : Entree
	{
		/// <summary>
		/// private backing variable for SausageLink
		/// </summary>
		private bool _sausageLink;
		/// <summary>
		///		Should the Entree include Sausage Links
		/// </summary>
		public bool SausageLink
		{
			get => _sausageLink;
			set
			{
				if (_sausageLink != value)
				{
					_sausageLink = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("SausageLink"));
				}
			}
		}

		/// <summary>
		/// private backing variable for Egg
		/// </summary>
		private bool _egg;
		/// <summary>
		///		Should the Entree include Eggs
		/// </summary>
		public bool Egg
		{
			get => _egg;
			set
			{
				if (_egg != value)
				{
					_egg = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Egg"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for HashBrowns
		/// </summary>
		private bool _hashBrowns;
		/// <summary>
		///		Should the Entree includ hash browns
		/// </summary>
		public bool HashBrowns
		{
			get => _hashBrowns;
			set
			{
				if (_hashBrowns != value)
				{
					_hashBrowns = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("HashBrowns"));
				}
			}
		}

		/// <summary>
		///		Private backing variable for Pancake
		/// </summary>
		private bool _pancake;
		/// <summary>
		///		Should the Entree includ pancakes
		/// </summary>
		public bool Pancake
		{
			get => _pancake;
			set
			{
				if (_pancake != value)
				{
					_pancake = value;
					base.OnPropertyChange(new PropertyChangedEventArgs("Pancake"));
				}
			}
		}

		/// <summary>
		///		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree
		/// </summary>
		/// </summary>
		public override List<string> SpecialInstructions
		{
			get
			{
				List<string> instructions = new List<string>();
				if (!SausageLink) instructions.Add("Hold sausage");
				if (!Egg) instructions.Add("Hold eggs");
				if (!HashBrowns) instructions.Add("Hold hash browns");
				if (!Pancake) instructions.Add("Hold pancakes");
				return instructions;
			}
		}

		/// <summary>
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public SmokehouseSkeleton()
		{
			_name = "Smokehouse Skeleton";
			EntreeValues.SetDefaults(this);
		}
	}
}
