using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet =true)] // this tells the framework that when instantiating this class, this particular property should receive info from the request (SearchTerm)
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet(string searchTerm)
        {
            
            // OnGet responds to an HTTP GET Request
            // config now allows you access to things from appsettings.json
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
