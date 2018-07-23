using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular5WebApiCore.Service.Locations;
using Microsoft.AspNetCore.Mvc;

namespace Angular5WebApiCore.WebAPI.Areas.MasterData.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    public class LocationController : Controller
    {
        private readonly ICountryService countryService;

        public LocationController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public async Task<IActionResult> GetCountries()
        {
            return Ok(await countryService.GetAllAsync());
        }
    }
}