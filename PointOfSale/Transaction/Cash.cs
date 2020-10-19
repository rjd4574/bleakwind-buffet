/*- Cash.cs									Created: 16OCT20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Last Modified 18OCT20
 *	Defines a group or collection of money by keeping track of how many
 *	bills of each type there are
 */

using System;
using System.ComponentModel;

namespace PointOfSale.Transaction
{
	/// <summary>
	/// Class defining a collection of money
	/// </summary>
	public class Cash : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		// Number of each of coins in this Cash 
		#region Coins

		protected int _pennies;
		/// <summary>
		///		Number of Pennies contained in this cash
		/// </summary>
		public virtual int Pennies
		{
			get => _pennies;
			set
			{
				_pennies = value;
				OnCashChanged("Pennies");
			}
		}

		protected int _nickels;
		/// <summary>
		///		Number of Nickels contained in this cash
		/// </summary>
		public virtual int Nickels
		{
			get => _nickels;
			set
			{
				_nickels = value;
				OnCashChanged("Nickels");
			}
		}

		protected int _dimes;
		/// <summary>
		///		Number of Dimes contained in this cash
		/// </summary>
		public virtual int Dimes
		{
			get => _dimes;
			set
			{
				_dimes = value;
				OnCashChanged("Dimes");
			}
		}

		protected int _quarters;
		/// <summary>
		///		Number of Quarters contained in this cash
		/// </summary>
		public virtual int Quarters
		{
			get => _quarters;
			set
			{
				_quarters = value;
				OnCashChanged("Quarters");
			}
		}

		protected int _halfDollars;
		/// <summary>
		///Number of HalfDollars contained in this cash
		/// </summary>
		public virtual int HalfDollars
		{
			get => _halfDollars;
			set
			{
				_halfDollars = value;
				OnCashChanged("HalfDollars");
			}
		}

		protected int _dollars;
		/// <summary>
		///	Number of Dollars contained in this cash
		/// </summary>
		public virtual int Dollars
		{
			get => _dollars;
			set
			{
				_dollars = value;
				OnCashChanged("Dollars");
			}
		}
		#endregion

		// Number of each of the bills in this Cash
		#region Bills

		protected int _ones;
		/// <summary>
		///	Number of Ones contained in this cash
		/// </summary>
		public virtual int Ones
		{
			get => _ones;
			set
			{
				_ones = value;
				OnCashChanged("Ones");
			}
		}

		protected int _twos;
		/// <summary>
		///	Number of Twos contained in this cash
		/// </summary>
		public virtual int Twos
		{
			get => _twos;
			set
			{
				_twos = value;
				OnCashChanged("Twos");
			}
		}

		protected int _fives;
		/// <summary>
		///	Number of Fives contained in this cash
		/// </summary>
		public virtual int Fives
		{
			get => _fives;
			set
			{
				_fives = value;
				OnCashChanged("Fives");
			}
		}

		protected int _tens;
		/// <summary>
		///	Number of Tens contained in this cash
		/// </summary>
		public virtual int Tens
		{
			get => _tens;
			set
			{
				_tens = value;
				OnCashChanged("Tens");
			}
		}

		protected int _twenties;
		/// <summary>
		///	Number of Twenties contained in this cash
		/// </summary>
		public virtual int Twenties
		{
			get => _twenties;
			set
			{
				_twenties = value;
				OnCashChanged("Twenties");
			}
		}

		protected int _fifties;
		/// <summary>
		///		Number of fifties contained in this cash
		/// </summary>
		public virtual int Fifties
		{
			get => _fifties;
			set
			{
				_fifties = value;
				OnCashChanged("Fifties");
			}
		}

		protected int _hundreds;
		/// <summary>
		///		Number of Hundreds contained in this cash
		/// </summary>
		public virtual int Hundreds
		{
			get => _hundreds;
			set
			{
				_hundreds = value;
				OnCashChanged("Hundreds");
			}
		}
		#endregion

		/// <summary>
		/// Gets the total value of the cash
		/// </summary>
		public virtual double Total => GetTotalCash();

		/// <summary>
		/// "locking" variable that avoids notification properties when
		/// the program is altering several cash properties at once
		/// </summary>
		private bool _makingChange = false;

		/// <summary>
		/// Computes the total value of all the cash based on how many
		/// notes/coins there are
		/// </summary>
		/// <returns>The total value of this Cash</returns>
		public double GetTotalCash()
		{
			double total = 0.0;
			total += Pennies*.01;
			total += Nickels*.05;
			total += Dimes*.10;
			total += Quarters*.25;
			total += HalfDollars*.50;
			total += Dollars*1.00;
			total += Ones*1.00;
			total += Twos*2.00;
			total += Fives*5.00;
			total += Tens * 10.00;
			total += Twenties*20.00;
			total += Fifties*50.00;
			total += Hundreds*100.00;

			return total;
		}

		/// <summary>
		/// Called when one of the notes/coins values are changed.
		/// </summary>
		/// <param name="property"></param>
		public void OnCashChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

			if (!_makingChange)
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
		}

		/// <summary>
		///		Sets the value of this cash to the provided parameter.
		///		It will attempt to use the least amount of bills as possible
		///		but will only use bills that are available in the cashReg
		/// </summary>
		/// <param name="change">Value of cash to match</param>
		/// <param name="reg">CashDrawer with amount of bills available</param>
		public void MakeExactChange(double change, CashReg reg)
		{
			_makingChange = true;
			// convert the amount from Dollars to Cents
			int amount = (int)(change*100);	

			Hundreds =		UseMaxBills(reg.Hundreds, 10000,ref amount);
			Fifties =		UseMaxBills(reg.Fifties,  5000, ref amount);
			Twenties =		UseMaxBills(reg.Twenties, 2000, ref amount);
			Tens =			UseMaxBills(reg.Tens,	  1000, ref amount);
			Fives =			UseMaxBills(reg.Fives,	   500, ref amount);
			Twos =			UseMaxBills(reg.Twos,	   200, ref amount);
			Ones =			UseMaxBills(reg.Ones,	   100, ref amount);
			Dollars =		UseMaxBills(reg.Dollars,   100, ref amount);
			HalfDollars =	UseMaxBills(reg.HalfDollars,50, ref amount);
			Quarters =		UseMaxBills(reg.Quarters,   25, ref amount);
			Dimes =			UseMaxBills(reg.Dimes,		10, ref amount);
			Nickels =		UseMaxBills(reg.Nickels,	 5, ref amount);
			Pennies =		UseMaxBills(reg.Pennies,	 1, ref amount);

			_makingChange = false;
			if (amount != 0)
				throw new NotImplementedException("Register doesn't have enough cash!");
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
		}

		/// <summary>
		///		Helper method to set value of total cash on hand
		///  Uses  Maximum Sized Bills to match the value of money requested
		/// </summary>
		/// <param name="onHand"> how many notes/coins of this type are on hand</param>
		/// <param name="value"> the value of this note/bill (in cents)</param>
		/// <param name="amount">the amount of money we are trying to match (in cents) </param>
		/// <returns></returns>
		public int UseMaxBills(int onHand, int value, ref int amount )
		{
			int numBills = amount / value;
			if (numBills > onHand)
				numBills = onHand;

			amount -= numBills * value;

			return numBills;
		}
	}
}
