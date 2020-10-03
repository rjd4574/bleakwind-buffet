/*- PhillyPoacher.cs					Created: 26AUG20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 01OCT20
 *	Defines the Entree Thugs T-Bone (T-Bone)
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{

	/// <summary>
	/// Describes the thugs T-Bone class
	/// </summary>
	public class ThugsTBone : Entree
	{
		/// <summary>
		///		Constructor, this is where the default values of this Entreer will be set.
		/// </summary>
		public ThugsTBone()
		{
			_name = "Thugs T-Bone";
			EntreeValues.SetDefaults(this);
		}
	}
}
