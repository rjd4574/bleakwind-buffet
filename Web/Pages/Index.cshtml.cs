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
				SearchTypes.Add(type, Menu.Search(type, SearchTerms));
			// No selection, get them all
			if (SearchTypes.Count <= 0 )
			{
				foreach(string type in Menu.Types)				
					SearchTypes.Add(type, Menu.Search(type, SearchTerms));
			}
			// filter by calories
			try { CaloriesMin = float.Parse(Request.Query["CaloriesMin"]); } catch { }
			try { CaloriesMax = float.Parse(Request.Query["CaloriesMax"]); } catch { }
			for(int type = 0; type<SearchTypes.Count;type++)
			{
				var category = SearchTypes.ElementAt(type);
				SearchTypes[category.Key] = Menu.FilterByCalories(category.Value, CaloriesMin, CaloriesMax);
			}
			// filter by Price
			try { PriceMin = float.Parse(Request.Query["PriceMin"]); } catch { }
			try { PriceMax = float.Parse(Request.Query["PriceMax"]); } catch { }
			for (int type = 0; type < SearchTypes.Count; type++)
			{
				var category = SearchTypes.ElementAt(type);
				SearchTypes[category.Key] = Menu.FilterByPrice(category.Value, PriceMin, PriceMax);
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
