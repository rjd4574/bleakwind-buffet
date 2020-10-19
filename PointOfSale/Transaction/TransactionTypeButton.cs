/*- TransactionTypeButton.cs				Created: 18OCT20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Last Modified 18OCT20
 *	Simple Toggle button that can also hold a userControl type
 */

using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PointOfSale.Transaction
{
	/// <summary>
	/// Toggle button with a user control reference
	/// </summary>
	public class TransactionTypeButton : ToggleButton
	{
		/// <summary>
		///		Represents a cash/credit/debit payment control
		/// </summary>
		public UserControl PaymentType { get; set; }
	}
}
