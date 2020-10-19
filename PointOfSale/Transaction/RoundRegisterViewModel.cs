/*- RoundRegisterViewModel.cs				Created: 18OCT20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Last Modified 18OCT20
 *	Allows comunication between transaction controls forms and the cash
 *	register. It also hols all intermediate logic and parameters.
 */


using RoundRegister;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Xml.Schema;

namespace PointOfSale.Transaction
{
	/// <summary>
	/// view model for the cash register and transaction details
	/// </summary>
	public class RoundRegisterViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// PRoperty changed event handler notifies of any
		/// changes in the cash totals.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// connection to the static cashdrawer with the added functionality
		/// from the custom Cash Object
		/// </summary>
		public CashReg Register = new CashReg();
		/// <summary>
		/// The cash paid from the customer
		/// </summary>
		public Cash Paid = new Cash();
		/// <summary>
		///  the change from the register due back to the customer
		/// </summary>
		public Cash Change = new Cash();

		/// <summary>
		/// property access to Register
		/// </summary>
		public CashReg CashDrawer => Register;
		/// <summary>
		/// propertyaccess to Paid
		/// </summary>
		public Cash AmountPaid => Paid;
		/// <summary>
		/// property access to Change
		/// </summary>
		public Cash ChangeDue => Change;

		/// <summary>
		/// Total amount owed from this sale
		/// </summary>
		public double TotalSale { get; set; }
		/// <summary>
		/// How much is currently (changes as the customer payment is processed)
		/// </summary>
		public double ChangeOwed
		{
			get
			{
				double owed = Paid.Total - TotalSale;
				if (owed < 0)
					return 0;
				return owed;
			}
		}
		/// <summary>
		/// how much money is owed to the customer (changes as the custmoer payment is processed)
		/// </summary>
		public double AmountDue
		{
			get
			{
				double due = TotalSale - Paid.Total;
				if (due < 0)
					return 0;
				return due;
			}

		}

		/// <summary>
		/// Runs the sale through the custmoer's card
		/// </summary>
		public CardTransactionResult RunCard => CardReader.RunCard(TotalSale);

		/// <summary>
		/// bool representing whether the transaction has been fully paid
		/// </summary>
		public bool IsPaid => AmountDue <= 0;

		/// <summary>
		/// Constructor, handles the property changed events
		/// </summary>
		public RoundRegisterViewModel()
		{
			Paid.PropertyChanged += OnCustomerPayment;
			Change.PropertyChanged += OnChangeReturned;
		}

		/// <summary>
		/// sends string to the receipt printer, and ensures it will fit
		/// properly (under 40 chars)
		/// </summary>
		/// <param name="line">line to print to the reciept</param>
		public void PrintLine(string line)
		{
			while(line.Length > 40)
			{
				RecieptPrinter.PrintLine(line.Substring(0, 40));
				line = line.Substring(40);
			}
			RecieptPrinter.PrintLine(line);
		}

		/// <summary>
		/// Cuts the reciept
		/// </summary>
		public void CutReciept()
		{
			RecieptPrinter.CutTape();
		}

		/// <summary>
		/// Called when the customer pays any note or coin. All totals are re-calculated
		///  and the required properties are notified of their change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnCustomerPayment(object sender, PropertyChangedEventArgs e)
		{
			Change.MakeExactChange(ChangeOwed, CashDrawer);
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ChangeOwed"));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPaid"));
		}

		/// <summary>
		/// Any events that need to happen when change given to customer is changed
		/// can go here, currently no implementation
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnChangeReturned(object sender, PropertyChangedEventArgs e)
		{

		}

		/// <summary>
		///		finalizes the cash transaction. The drawer is opened, and the money from the 
		///		customer is put into the drawer and the change due is taken out.
		/// </summary>
		public void MakeCashPayment()
		{
			CashDrawer.OpenDrawer();

			Register.Pennies += Paid.Pennies;
			Register.Pennies -= Change.Pennies;

			Register.Nickels += Paid.Nickels;
			Register.Nickels -= Change.Nickels;

			Register.Dimes += Paid.Dimes;
			Register.Dimes -= Change.Dimes;

			Register.Quarters += Paid.Quarters;
			Register.Quarters -= Change.Quarters;

			Register.HalfDollars += Paid.HalfDollars;
			Register.HalfDollars -= Change.HalfDollars;

			Register.Dollars += Paid.Dollars;
			Register.Dollars -= Change.Dollars;

			Register.Ones += Paid.Ones;
			Register.Ones -= Change.Ones;

			Register.Twos += Paid.Twos;
			Register.Twos -= Change.Twos;

			Register.Fives += Paid.Fives;
			Register.Fives -= Change.Fives;

			Register.Tens += Paid.Tens;
			Register.Tens -= Change.Tens;

			Register.Twenties += Paid.Twenties;
			Register.Twenties -= Change.Twenties;

			Register.Fifties += Paid.Fifties;
			Register.Fifties -= Change.Fifties;

			Register.Hundreds += Paid.Hundreds;
			Register.Hundreds -= Change.Hundreds;


		}
	}
}
