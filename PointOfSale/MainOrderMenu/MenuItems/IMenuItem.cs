using BleakwindBuffet.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale
{
	interface IMenuItem
	{
		IOrderItem Order { get; }
	}
}
