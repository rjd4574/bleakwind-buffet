/*- Entree.cs							Created: 09SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 01OCT20
 *	Defines the common proprerties of an Entree
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
	/// <summary>
	///		A base class representing the common properties of an Entree
	/// </summary>
	public abstract class Entree : IOrderItem, INotifyPropertyChanged
	{
		/// <summary>
		///		Allows all Entree's to be informed of a property change
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///		Protected backing variable for the name of the Entree
		/// </summary>
		protected string _name;

		/// <summary>
		/// The name of the Entree
		/// </summary>
		public string Name => _name;

		/// <summary>
		///		Gets the price of the Entree
		/// </summary>
		public double Price => EntreeValues.Price(this);

		/// <summary>
		///		Gets the calories of the Entree
		/// </summary>
		public uint Calories => EntreeValues.Calories(this);

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Entree. The base will return an empty set
		///		of instructions. If the child has special Instruction options
		///		it should override this method
		/// </summary>
		public virtual List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		Allow children of the entree class to invoke propertychaned events
		/// </summary>
		/// <param name="e">The property that was changed in an inherted class</param>
		protected void OnPropertyChange(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}

		/// <summary>
		///		All Entrees must be able to represent themselves using a valid ToString 
		///		The base class will return just the name of the Entree. Any child requiring 
		///		a different description should override this method.
		/// </summary>
		/// <returns>A string representation of the Entree</returns>
		public override string ToString()
		{
			return _name;
		}
	}
}
