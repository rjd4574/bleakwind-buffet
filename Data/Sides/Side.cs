/*- Side.cs								Created: 09SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 01Oct20
 *	Defines the common proprerties of a side
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
	/// <summary>
	///		A base class representing the common properties of a side
	/// </summary>
	public abstract class Side : IOrderItem, INotifyPropertyChanged
	{
		/// <summary>
		///		Allows side's to be notified when one of their properties has been changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///		Protected backing variable for the name of the side
		/// </summary>
		protected string _name;

		/// <summary>
		/// The name of the side
		/// </summary>
		public string Name => _name;

		/// <summary>
		///		Private backing variable for the Size of the side
		/// </summary>
		private Size _size;
		/// <summary>
		///		What size is the side
		/// </summary>
		public Size Size
		{
			get => _size;
			set
			{   // Only set the size if the value is valid!
				if (!(Enum.IsDefined(typeof(Size), value)))
					throw new NotImplementedException("Size is Not Defined");
				if (_size != value)
				{
					double price = Price;
					uint calories = Calories;
					_size = value;
					OnPropertyChanged(new PropertyChangedEventArgs("Size"));
					// Determine if the price/calories have changed with the size
					if (price != Price)
						OnPropertyChanged(new PropertyChangedEventArgs("Price"));
					if (calories != Calories)
						OnPropertyChanged(new PropertyChangedEventArgs("Calories"));
				}
			}
		}

		/// <summary>
		///		Gets the price of the side based on its size
		/// </summary>
		public double Price => SideValues.Price(this);

		/// <summary>
		///		Gets the calories of the side based on its size
		/// </summary>
		public uint Calories => SideValues.Calories(this);

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the side. The base will return an empty set
		///		of instructions. If the child has special Instruction options
		///		it should override this method
		/// </summary>
		public virtual List<string> SpecialInstructions => new List<string>();

		/// <summary>
		///		Allow children of the drink class to invoke propertychaned events
		/// </summary>
		/// <param name="e">The property that was changed in an inherted class</param>
		protected void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}

		/// <summary>
		///		All sides must be able to represent themselves using a valid ToString. 
		///		Base ToString will include the size and name of the side. If the child
		///		requires further description it should override this method.
		/// </summary>
		/// <returns>A string representation of the side</returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} {_name}";
		}
	}
}
