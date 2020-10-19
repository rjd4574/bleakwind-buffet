/*- CashReg.cs								Created: 16OCT20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Last Modified 18OCT20
 *	A Cash Representation of all notes and coins in CashRegister drawer
 */

using RoundRegister;
using System.ComponentModel;

namespace PointOfSale.Transaction
{
	/// <summary>
	/// Class defining the cash in the register
	/// </summary>
	public class CashReg : Cash
	{
		// View model of coins in the register
		#region Coins

		/// <summary>
		///		view model of the pennies in the cash drawr
		/// </summary>
		public override int Pennies
		{
			get => CashDrawer.Pennies;
			set
			{
				CashDrawer.Pennies = value;
				OnCashChanged("Pennies");
			}
		}

		/// <summary>
		///		view model of the Nickels in the cash drawr
		/// </summary>
		public int Nickels
		{
			get => CashDrawer.Nickels;
			set
			{
				CashDrawer.Nickels = value;
				OnCashChanged("Nickels");
			}
		}

		/// <summary>
		///		view model of the Dimes in the cash drawr
		/// </summary>
		public int Dimes
		{
			get => CashDrawer.Dimes;
			set
			{
				CashDrawer.Dimes = value;
				OnCashChanged("Dimes");
			}
		}

		/// <summary>
		///		view model of the Quarters in the cash drawr
		/// </summary>
		public int Quarters
		{
			get => CashDrawer.Quarters;
			set
			{
				CashDrawer.Quarters = value;
				OnCashChanged("Quarters");
			}
		}

		/// <summary>
		///		view model of the HalfDollars in the cash drawr
		/// </summary>
		public int HalfDollars
		{
			get => CashDrawer.HalfDollars;
			set
			{
				CashDrawer.HalfDollars = value;
				OnCashChanged("HalfDollars");
			}
		}

		/// <summary>
		///		view model of the Dollars in the cash drawr
		/// </summary>
		public int Dollars
		{
			get => CashDrawer.Dollars;
			set
			{
				CashDrawer.Dollars = value;
				OnCashChanged("Dollars");
			}
		}
		#endregion

		// View model of bills in the register
		#region Bills

		/// <summary>
		///		view model of the Ones in the cash drawr
		/// </summary>
		public int Ones
		{
			get => CashDrawer.Ones;
			set
			{
				CashDrawer.Ones = value;
				OnCashChanged("Ones");
			}
		}

		/// <summary>
		///		view model of the Twos in the cash drawr
		/// </summary>
		public int Twos
		{
			get => CashDrawer.Twos;
			set
			{
				CashDrawer.Twos = value;
				OnCashChanged("Twos");
			}
		}

		/// <summary>
		///		view model of the Fives in the cash drawr
		/// </summary>
		public int Fives
		{
			get => CashDrawer.Fives;
			set
			{
				CashDrawer.Fives = value;
				OnCashChanged("Fives");
			}
		}

		/// <summary>
		///		view model of the Tens in the cash drawr
		/// </summary>
		public int Tens
		{
			get => CashDrawer.Tens;
			set
			{
				CashDrawer.Tens = value;
				OnCashChanged("Tens");
			}
		}

		/// <summary>
		///		view model of the Twenties in the cash drawr
		/// </summary>
		public int Twenties
		{
			get => CashDrawer.Twenties;
			set
			{
				CashDrawer.Twenties = value;
				OnCashChanged("Twenties");
			}
		}

		/// <summary>
		///		view model of the Fifties in the cash drawr
		/// </summary>
		public int Fifties
		{
			get => CashDrawer.Fifties;
			set
			{
				CashDrawer.Fifties = value;
				OnCashChanged("Fifties");
			}
		}

		/// <summary>
		///		view model of the Hundreds in the cash drawr
		/// </summary>
		public int Hundreds
		{
			get => CashDrawer.Hundreds;
			set
			{
				CashDrawer.Hundreds = value;
				OnCashChanged("Hundreds");
			}
		}
		#endregion


		/// <summary>
		/// Total amount of money in the drawer
		/// </summary>
		public override double Total => CashDrawer.Total;

		/// <summary>
		/// OPens the drawer
		/// </summary>
		public void OpenDrawer()
		{
			CashDrawer.OpenDrawer();
		}

		/// <summary>
		/// Resets the Cash in the drawer
		/// </summary>
		public void ResetDrawer()
		{
			CashDrawer.ResetDrawer();
		}
	}
}
