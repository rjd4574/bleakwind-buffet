/*- CardPaymentControl.cs					Created: 17OCT20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Last Modified 18OCT20
 *	Control interface allowing a user to use a card to pay for the total
 *	amount of the transaction
 */

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using RoundRegister;
namespace PointOfSale.Transaction
{
	/// <summary>
	/// Interaction logic for CardPaymentControl.xaml
	/// </summary>
	public partial class CardPaymentControl : UserControl, INotifyPropertyChanged
	{
		/// <summary>
		/// property event handler, used to notify of a canceled or 
		/// completed transaction
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		public string CardType { get; set; }

		/// <summary>
		/// Constructor, initializes the components. 
		/// </summary>
		public CardPaymentControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Called when the cancel transaction button is pressed. 
		/// sends notification of the cancel request
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void TransactionCancelButton(object sender, RoutedEventArgs e)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cancel"));
		}

		/// <summary>
		/// Called when the customer is attempting to use their card to pay for the meal
		/// A completed notification is sent if it is succesful, otherwise the 
		/// transaction result is printed as an error
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void TransactionCompleteButton(object sender, RoutedEventArgs e)
		{
			if (DataContext is RoundRegisterViewModel vm)
			{
				CardTransactionResult result = vm.RunCard;
				if (result == CardTransactionResult.Approved)
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Complete"));
				else
					uxCardDeclined.Text = result.ToString();
			}
		}
	}
}
