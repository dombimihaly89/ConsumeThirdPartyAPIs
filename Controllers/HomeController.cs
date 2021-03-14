using ConsumeThirdPartyAPIs.Services;
using ConsumeThirdPartyAPIs.Exceptions;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Collections.Generic;

namespace ConsumeThirdPartyAPIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHolidaysApiService _holidaysApiService;

        public HomeController(IHolidaysApiService holidaysApiService)
        {
            _holidaysApiService = holidaysApiService;
        }

        [HttpGet("{year}/{countryCode}")]
        public IActionResult GetHolidays(int year, string countryCode)
        {
            var result = new List<HolidayModel>();
            try 
            {
                result = _holidaysApiService.GetHolidays(year, countryCode).GetAwaiter().GetResult();
            }
            catch(ServiceException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
            }
            catch(Exception)
            {
                return  new StatusCodeResult(500);
            }

            return Ok(result);
        }

    }
}