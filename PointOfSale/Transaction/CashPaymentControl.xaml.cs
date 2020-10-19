/*- CashPaymentControl.cs					Created: 17OCT20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Last Modified 18OCT20
 *	Creates a control interace allowing the user to tell the computer
 *	what type of Cash the customer has provided, how many bills are in the
 *	drawer, and what the proper return change (if any) should be
 */

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace PointOfSale.Transaction
{
	/// <summary>
	/// Interaction logic for CashPaymentControl.xaml
	/// </summary>
	public partial class CashPaymentControl : UserControl, INotifyPropertyChanged
	{
		/// <summary>
		/// Notifies when the cash transaction has been competed or cancelled
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Constructor initializes the components
		/// </summary>
		public CashPaymentControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Called when the cancel button is pressed. It sends cancel notification
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void TransactionCancelButton(object sender, RoutedEventArgs e)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cancel"));
		}

		/// <summary>
		///		Called when the complete button is pressed. Databinding doesn't
		///		allow the button to be enabled when the customer still owes money,
		///		but it is double checked here regardless. This button will only activate 
		///		after a customer who has paid has paid the total amount
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void TransactionCompleteButton(object sender, RoutedEventArgs e)
		{
			if (DataContext is RoundRegisterViewModel vm)
			{
				if (vm.AmountDue <= 0)
				{
					// Opens drawer and exchanges money
					vm.MakeCashPayment();
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Complete"));
				}
			}
		}
	}
}
