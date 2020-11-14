/*- Combo.cs							Created: 10OCT20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 10OCT20
 *	Defines a combo meal. Includes one Entree, Drink, and Side.
 *	All values are total (combined from all three items) along
 *	with a discount.
 */

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;

namespace BleakwindBuffet.Data
{
	/// <summary>
	/// Class representing a combo meal
	/// </summary>
	public class Combo : IOrderItem, INotifyPropertyChanged
	{
		/// <summary>
		///		Allows the combo meal to be notified when one of its meal's
		///		properties has changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///  Private backing variable for the name of the combo
		/// </summary>
		private string _name = "Combo";
		/// <summary>
		///		The name of the combo
		/// </summary>
		public string Name => _name;

		/// <summary>
		/// private backing variable for the description of the combo;
		/// </summary>
		private string _description = "Combo";
		/// <summary>
		/// the description of the combo
		/// </summary>
		public string Description => _description;

		/// <summary>
		///		Discount when ordering a complete combo
		/// </summary>
		public double Discount => 1.00;

		/// <summary>
		/// the price of the combo to include a discount if it is complete
		/// </summary>
		public double Price
		{
			get
			{
				double price = 0;
				if (_hasEntree) price += Entree.Price;
				if (_hasDrink) price += Drink.Price;
				if (_hasSide) price += Side.Price;
				if(IsComplete) price -= Discount;
				return price;
			}
		}

		/// <summary>
		/// the total amount of calories in the entire combo 
		/// </summary>
		public uint Calories
		{
			get
			{
				uint cal = 0;
				if (_hasEntree) cal += Entree.Calories;
				if (_hasDrink) cal += Drink.Calories;
				if (_hasSide) cal += Side.Calories;
				return cal;
			}
		}

		/// <summary>
		///		Returns a list of all items in the combo as well as their special
		///		instructions.
		/// </summary>
		public List<string> SpecialInstructions
		{
			get
			{
				List<string> list = new List<string>();
				if (_hasEntree) list.AddRange(GetInstructions(Entree));
				if (_hasDrink) list.AddRange(GetInstructions(Drink));
				if (_hasSide) list.AddRange(GetInstructions(Side));		
				return list;
			}
		}

		/// <summary>
		///	private backing varible for the Entree.
		/// </summary>
		private Entree _entree = null;
		/// <summary>
		///		The entree for this combo
		/// </summary>
		public Entree Entree
		{
			get => _entree;
			set => Add(value);
		}
		/// <summary>
		/// Indicates whether an Entree has been aded to the combo
		/// </summary>
		private bool _hasEntree => Entree != null;

		/// <summary>
		/// Private backing variable for the drink
		/// </summary>
		private Drink _drink = null;
		/// <summary>
		///	The Drink for this combo
		/// </summary>
		public Drink Drink
		{
			get => _drink;
			set => Add(value);
		}
		/// <summary>
		/// Indicates whether the Drink a been added to the combo
		/// </summary>
		private bool _hasDrink => Drink != null;

		/// <summary>
		/// private backing variable for the side
		/// </summary>
		private Side _side = null;
		/// <summary>
		/// The side for this combo
		/// </summary>
		public Side Side
		{
			get => _side;
			set => Add(value);
		}
		/// <summary>
		/// Indicates whether a Side has been added to the combo
		/// </summary>
		private bool _hasSide => Side != null;

		/// <summary>
		///		Indicates whether the Combo is complete and eligible
		///		for the discount.
		/// </summary>
		public bool IsComplete => (_hasEntree && _hasDrink && _hasSide);

		public List<IOrderItem> EntreeList;
		public List<IOrderItem> DrinkList;
		public List<IOrderItem> SideList;

		public Combo() { LoadItemList(); }
		public Combo(Entree entree, Drink drink, Side side) : this()
		{
			Add(entree);
			Add(drink);
			Add(side);
		}

		/// <summary>
		///		Add the new IOrder Item to the combo. Notify all properties of this change.
		///		If we are replacing a previous item, unassign the previous event listener.
		/// </summary>
		/// <param name="item"></param>
		public void Add(IOrderItem item)
		{
			item.PropertyChanged += IOrderItemChangedListener;
			if( item is Entree entree )
			{
				if (_hasEntree) Entree.PropertyChanged -= IOrderItemChangedListener;
				_entree = entree;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entree"));
			}
			else if (item is Drink drink )
			{
				if (_hasDrink) Drink.PropertyChanged -= IOrderItemChangedListener;
				_drink = drink;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Drink"));
			}
			else if (item is Side side )
			{
				if (_hasSide) Side.PropertyChanged -= IOrderItemChangedListener;
				_side = side;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Side"));
			}
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("String"));
		}

		private void IOrderItemChangedListener(Object sender, PropertyChangedEventArgs e)
		{
			switch( e.PropertyName )
			{
				case "Price":
					PropertyChanged?.Invoke(this, e);
					break;
				case "Calories":
					PropertyChanged?.Invoke(this, e);
					break;
				case "Size":
					break;
				default:
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
					break;
			}
		}

		private List<string> GetInstructions(IOrderItem item)
		{
			List<string> list = new List<String>();
			list.Add($"=>{item.ToString()}");
			foreach (string instruction in item.SpecialInstructions)
				list.Add($"\t-->{instruction}");
			return list;
		}

		/// <summary>
		/// Satisfies IOrderItem Requirement
		/// </summary>
		public string String => ToString();

		public override string ToString()
		{
			return $"{((IsComplete) ? "" : "(Incomplete) ")}Combo Meal";
		}



		private void LoadItemList()
		{
			EntreeList = (List<IOrderItem>)Menu.EntreeItems();
			DrinkList = (List<IOrderItem>)Menu.DrinkItems();
			SideList = (List<IOrderItem>)Menu.SideItems();
		}
	}
}
