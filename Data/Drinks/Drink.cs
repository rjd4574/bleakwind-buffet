/*- Drink.cs							Created: 09SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Defines the common proprerties of a Drink
 */

using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
	/// <summary>
	///		A base class representing the common properties of a Drink
	/// </summary>
	public abstract class Drink : IOrderItem, INotifyPropertyChanged
	{
		/// <summary>
		///		Allows all drinks to be notified of a change
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///		Protected backing variable for the name of the drink
		/// </summary>
		protected string _name;
		/// <summary>
		/// The name of the drink
		/// </summary>
		public string Name => _name;

		/// <summary>
		/// protected backing variable for the discription of the drink
		/// </summary>
		protected string _description;
		/// <summary>
		/// Description of the drink
		/// </summary>
		public string Description => _description;

		/// <summary>
		///		Private backing variable for the Size of the drink
		/// </summary>
		private Size _size;

		/// <summary>
		///		What size is the drink
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
					if( price != Price )
						OnPropertyChanged(new PropertyChangedEventArgs("Price"));
					if( calories != Calories )
						OnPropertyChanged(new PropertyChangedEventArgs("Calories"));
				}
			}
		}

		/// <summary>
		///		Gets the price of the Drink based on its size
		/// </summary>
		public double Price => DrinkValues.Price(this);

		/// <summary>
		///		Gets the calories of the Drink based on its size
		/// </summary>
		public uint Calories => DrinkValues.Calories(this);

		/// <summary>
		///		Create a list of special instructions to be followed
		///		when making the Drink. The base will return an empty set
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
			switch(e.PropertyName)
			{
				case "Price": break;
				case "Calories": break;
				case "Size":
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("String"));
					break;
				case "Decaf":
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("String"));
					break;
				case "Flavor":
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("String"));
					break;
				default: 
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
					break;
			}
		}

		/// <summary>
		/// Property that can be notified when the ToString has changed
		/// </summary>
		public string String => ToString();

		/// <summary>
		///		All Drinks must be able to represent themselves using a valid ToString. 
		///		Base ToString will include the size and name of the drink. If the child
		///		requires further description it should override this method.
		/// </summary>
		/// <returns>A string representation of the drink</returns>
		public override string ToString()
		{
			return $"{EnumExt.Print(Size)} {_name}";
		}
	}
}
