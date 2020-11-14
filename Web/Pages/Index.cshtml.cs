/*- Index.cshtml.cs						Created: 05NOV20
 * Author: Ryan Dentremont				CIS 400 MWF @ 1330
 *										Updated: 06NOV20
 *	Code-behind for behavior of the Index (main menu) of the 
 *	bleakwind buffet html web page
*/

using System.Collections.Generic;
using System.Linq;
using BleakwindBuffet.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

/// <summary>
///  Bleakwind buffet main menu code behind
/// </summary>
namespace Web.Pages
{
	public class IndexModel : PageModel
	{
		
		public Dictionary<string, IEnumerable<IOrderItem>> SearchTypes { get; set; }

		/// <summary>
		/// Filters the menu items by name
		/// </summary>
		public string SearchTerms { get; set; }

		/// <summary>
		///  search filter by the min desired calories
		/// </summary>
		public float? CaloriesMin { get; set; }
		/// <summary>
		/// Search filter by the max desired calories
		/// </summary>
		///
		public float? CaloriesMax { get; set; }

		/// <summary>
		/// search filter by the min desired price
		/// </summary>
		public float? PriceMin { get; set; }
		/// <summary>
		/// search filter by the max desired price
		/// </summary>
		public float? PriceMax { get; set; }


		/// <summary>
		/// Search update for bleakwind menu items
		/// </summary>
		public void OnGet()
		{
			SearchTypes = new Dictionary<string, IEnumerable<IOrderItem>>();

			// get search criterea
			SearchTerms = Request.Query["SearchTerms"];

			//Get order selection type (entree/drink/side)
			foreach (string type in Request.Query["TypeCheck"])
				SearchTypes[type] = Menu.Partial(type);

			// No selection, get them all
			if (SearchTypes.Count <= 0 )
			{
				foreach (string type in Menu.Types)
					SearchTypes[type] = Menu.Partial(type);
			}

			// filter by search criteria (check IOrderItem Name & Description)
			if (SearchTerms != null)
			{
				// iterate over entree/drink/side menu items
				for (int type = 0; type < SearchTypes.Count; type++)
				{
					// current menu type
					var category = SearchTypes.ElementAt(type);
					// all search terms that are seperated by a space
					var AllSearches = SearchTerms.Split(' ').ToList();

					// update the key value pair of this type(entree/drink/side)
					SearchTypes[category.Key] = SearchTypes[category.Key].Where
					// update the current list of items in this section of the menu
					(order => AllSearches.Any(search => 
							// try to match the OrderItem tostring
							order.ToString().ToLower().Contains(search.ToLower())		||
							// or try to match the description
							order.Description.ToLower().Contains(search.ToLower())		));

				}
			}

			// filter by calories
			try { CaloriesMin = float.Parse(Request.Query["CaloriesMin"]); } catch { }
			try { CaloriesMax = float.Parse(Request.Query["CaloriesMax"]); } catch { }
			// if no bounds, keep everything
			if( !(CaloriesMin == null && CaloriesMax == null) )
			{
				// iterate through all of the displaying menu categories
				for( int type = 0; type<SearchTypes.Count; type++)
				{
					// get the current key from the loop iterator
					var category = SearchTypes.ElementAt(type);

					// No lower bound --> Make sure all items are less than max
					if (CaloriesMin == null)
						SearchTypes[category.Key] = SearchTypes[category.Key].Where
							(order => order.Calories <= CaloriesMax);

					// no uppoer boud --> make sure all items are greater than min
					else if (CaloriesMax == null)
						SearchTypes[category.Key] = SearchTypes[category.Key].Where
							(order => order.Calories >= CaloriesMin);

					// both bounds --> ensure all items are in between min and max.
					else
						SearchTypes[category.Key] = SearchTypes[category.Key].Where
							(order => order.Calories >= CaloriesMin && order.Calories <= CaloriesMax);
				}
			
				
			}

			// filter by Price
			try { PriceMin = float.Parse(Request.Query["PriceMin"]); } catch { }
			try { PriceMax = float.Parse(Request.Query["PriceMax"]); } catch { }
			// if no bounds, keep everything
			if (!(PriceMin == null && PriceMax == null))
			{
				// iterate through all of the displaying menu categories
				for (int type = 0; type < SearchTypes.Count; type++)
				{
					// get the current key from the loop iterator
					var category = SearchTypes.ElementAt(type);

					// No lower bound --> Make sure all items are less than max
					if (PriceMin == null)
						SearchTypes[category.Key] = SearchTypes[category.Key].Where
							(order => order.Price <= PriceMax);

					// no uppoer boud --> make sure all items are greater than min
					else if (PriceMax == null)
						SearchTypes[category.Key] = SearchTypes[category.Key].Where
							(order => order.Price >= PriceMin);

					// both bounds --> ensure all items are in between min and max.
					else
						SearchTypes[category.Key] = SearchTypes[category.Key].Where
							(order => order.Price >= PriceMin && order.Price <= PriceMax);
				}


			}


		}



		// auto-populated
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		
	}
}
