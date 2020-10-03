/*- OrderButton.cs						Created: 26SEP20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Last Modified: 02OCT20
 *	Extends the functionality of a ToggleButton to contain
 *	A single IOrderItem
 */

using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using BleakwindBuffet.Data;

namespace PointOfSale
{
	/// <summary>
	/// Toggle Button with added feature
	/// </summary>
	public class OrderButton : Button
	{
		/// <summary>
		///		Reference to a IOrderItem it represents
		/// </summary>
		public IOrderItem MenuItem { get; set; }
	}
}
