/*- CurrencyControl.cs						Created: 18OCT20
 * Author: Ryan Dentremont					CIS 400 MWF @ 1330
 *											Last Modified 18OCT20
 *	Allows the incrementing or decrementing of a bill or coin.
 *	It can support any bill or coin assuming dependencies are properly
 *	bound in the xaml
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PointOfSale.Transaction
{
	/// <summary>
	/// Interaction logic for CurrencyControl.xaml
	/// </summary>
	public partial class CurrencyControl : UserControl
	{
		#region Value Property
		/// <summary>
		/// Dependency property for the value of the incrementer (how many notes)
		/// </summary>
		public static DependencyProperty ValueProperty =
			DependencyProperty.Register("Value", typeof(int), typeof(CurrencyControl),
				new FrameworkPropertyMetadata(0,
					FrameworkPropertyMetadataOptions.AffectsRender |
					FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		/// <summary>
		/// Property for the value of the incrementer (how many notes)
		/// </summary>
		public int Value
		{
			get => (int)(GetValue(ValueProperty));
			set => SetValue(ValueProperty, value);
		}

		#endregion

		#region Denomination Property
		/// <summary>
		/// Dependency property for the denomination of the note/coin
		/// </summary>
		public static DependencyProperty DenominationProperty =
			DependencyProperty.Register("Denomination", typeof(string), typeof(CurrencyControl),
				new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.AffectsMeasure,
												SetNoteColor));
		/// <summary>
		/// Property for the denomination of the note/coin
		/// </summary>
		public string Denomination
		{
			get => (string)(GetValue(DenominationProperty));
			set => SetValue(DenominationProperty, value);
		}
		#endregion

		#region Change Property

		/// <summary>
		/// dependency property for the amount of change to be returned to the customer
		/// of this particular note/coin
		/// </summary>
		public static DependencyProperty ChangeProperty =
			DependencyProperty.Register("Change", typeof(int), typeof(CurrencyControl));
		/// <summary>
		/// property for the amount of cahnge to be returned to the customer of this specific
		/// bill/coin
		/// </summary>
		public int Change
		{
			get => (int)GetValue(ChangeProperty);
			set => SetValue(ChangeProperty, value);
		}
		#endregion

		#region Notes Proeprty

		/// <summary>
		/// Dependency property for the amount of this type of note/coin that are remaining
		/// in the cash regiester
		/// </summary>
		public static DependencyProperty NotesRemainingProperty =
			DependencyProperty.Register("NotesRemaining", typeof(int), typeof(CurrencyControl));

		/// <summary>
		/// property for how many notes/coins of this type remaining in the register
		/// </summary>
		public int NotesRemaining
		{
			get => (int)GetValue(NotesRemainingProperty);
			set => SetValue(NotesRemainingProperty, value);
		}
		#endregion


		/// <summary>
		/// Constructor, initializes components
		/// </summary>
		public CurrencyControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Called when the + or - button is called, thus incrementing/decrementing how many
		/// of this note/coin the customer has given us
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IncrementClick(object sender, RoutedEventArgs e)
		{
			if (sender is MinusButton && Value > 0)
				Value--;
			else if (sender is PlusButton)
				Value++;
		}

		/// <summary>
		/// Called as part of the Denomination property, sets a orange color if its a coin,
		/// or keeps it green for a note.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		static void SetNoteColor(object sender, DependencyPropertyChangedEventArgs e)
		{
			if( sender is CurrencyControl currency )
			{
				if( currency.Denomination.Contains("c"))
					currency.uxAmount.Background = Brushes.Orange;
			}
		}
	}
}
