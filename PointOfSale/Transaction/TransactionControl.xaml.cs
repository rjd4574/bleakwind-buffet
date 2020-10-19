/*- TransactionControl.cs					Created: 17OCT20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Last Modified 18OCT20
 *	Controls the transaction of the order. There are three possible
 *	user forms that can pay: cash, debit, credit
 */


using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using BleakwindBuffet.Data;

namespace PointOfSale.Transaction
{
	/// <summary>
	/// Interaction logic for TransactionControl.xaml
	/// </summary>
	public partial class TransactionControl : UserControl, INotifyPropertyChanged
	{
		/// <summary>
		/// NOtifies when the transaction has completed/cancelled
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// the current order being paid for.
		/// </summary>
		private Order _curOrder;
		/// <summary>
		/// View model archatecture
		/// </summary>
		private RoundRegisterViewModel _vm;

		/// <summary>
		/// cash control form
		/// </summary>
		private CashPaymentControl _cash;
		/// <summary>
		/// Credit control form
		/// </summary>
		private CardPaymentControl _credit;
		/// <summary>
		/// Debit control form
		/// </summary>
		private CardPaymentControl _debit;

		/// <summary>
		/// The top of this screen will have three transactionTypeButtons
		/// Each button represents a different payment method (cash,credit,debit)
		/// this button represents the active one.
		/// </summary>
		private TransactionTypeButton _curPayment;

		/// <summary>
		/// Constructor initializes components with proper datacontext and sets default
		/// settings.
		/// </summary>
		/// <param name="order">The order that is being paid for</param>
		public TransactionControl(Order order)
		{
			InitializeComponent();
			_curOrder = order;
			_vm = new RoundRegisterViewModel() { TotalSale = _curOrder.Total };
			_cash = new CashPaymentControl() { DataContext = _vm };
			_credit = new CardPaymentControl() { DataContext = _vm };
			_debit = new CardPaymentControl() { DataContext = _vm };

			SetButtons();
			
		}

		/// <summary>
		/// helper method for the constructor. Sets the defaults for the transaction
		/// </summary>
		private void SetButtons()
		{
			// set the three options
			uxCashButton.PaymentType = _cash;
			uxCreditButton.PaymentType = _credit;
			uxDebitButton.PaymentType = _debit;

			// set cash as default
			_curPayment = uxCashButton;
			_curPayment.PaymentType = _cash;
			uxTransactionBorder.Child = _curPayment.PaymentType;
			
			// disable selected button
			_curPayment.IsChecked = true;
			_curPayment.IsEnabled = false;

			// attache event listener from buttons
			_cash.PropertyChanged += OnTransactionUpdate;
			_credit.PropertyChanged += OnTransactionUpdate;
			_debit.PropertyChanged += OnTransactionUpdate;
		}

		/// <summary>
		///  One of the payment controls have been updated to either cancel or complete their order
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTransactionUpdate(object sender, PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case "Cancel":
					TransactionCancelButton();
					break;
				case "Complete":
					TransactionCompleteButton();
					break;
				default: break;
			}
		}

		/// <summary>
		/// One of the three TransactionTypeButtons have been pressed. Correctly toggle
		/// the screen and enable/check the correct boxes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTogglePayment(object sender, RoutedEventArgs e )
		{
			if (sender is TransactionTypeButton butt)
			{
				if (butt != _curPayment)
				{
					_curPayment.IsEnabled = true;
					_curPayment.IsChecked = false;
					_curPayment = butt;
					_curPayment.IsEnabled = false;
					uxTransactionBorder.Child = _curPayment.PaymentType;
				}
			}
		}

		/// <summary>
		/// Echo the cancel property change
		/// </summary>
		private void TransactionCancelButton()
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TransactionCancel"));
		}

		/// <summary>
		/// The customer has successfully completed the transaction. Print an accurate reciept
		/// and then send up the completed notification
		/// </summary>
		private void TransactionCompleteButton()
		{
			// Order Number/Date/Time
			_vm.PrintLine($"Order Number: {_curOrder.TicketNumber}");
			_vm.PrintLine($"{DateTime.Now.ToString("dd-MMM-yy HH:mm:ss")}");
			_vm.PrintLine("");
			
			// Get all the items in the order and print them out with their:
			// Price/Name/SpecialInstructions
			foreach(IOrderItem item in _curOrder)
			{
				_vm.PrintLine (String.Format("${0:00.00} -- {1}", item.Price, item.ToString()));
				foreach (string instruction in item.SpecialInstructions)
					_vm.PrintLine ($"     {instruction}");
			}

			//Print price total summary
			_vm.PrintLine("");
			_vm.PrintLine(String.Format("${0:00.00} -- Subtotal", _curOrder.Subtotal));
			_vm.PrintLine(String.Format("${0:00.00} -- Tax", _curOrder.Tax));
			_vm.PrintLine("-------------------");
			_vm.PrintLine(String.Format("${0:00.00} -- Total", _curOrder.Total));

			// print payment summary
			if( _curPayment.PaymentType == _cash)
			{
				_vm.PrintLine(string.Format("${0:00.00} -- Cash Payment",_vm.AmountPaid.Total));
				_vm.PrintLine("-------------------");
				_vm.PrintLine(string.Format("${0:00.00} -- Change Returned",_vm.ChangeOwed));

			}
			else if (_curPayment.PaymentType == _credit )
				_vm.PrintLine(string.Format("${0:00.00} -- Credit Payment", _vm.TotalSale));
			else
				_vm.PrintLine(string.Format("${0:00.00} -- Debit Payment", _vm.TotalSale));


			// send transaction complete notification
			_vm.CutReciept();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TransactionComplete"));
		}
	}
}
