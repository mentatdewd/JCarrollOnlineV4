using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using AutoMapper;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace JCarrollOnline.Controllers
{
    [Route("api/[controller]")]
    public class RSSController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public RSSController(IMapper mapper, 
            UserManager<ApplicationUser> userManager,
            ILogger<MicropostController> logger){
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("theMariners")]
        public async Task<IActionResult> TheMariners()
        {
            string apiResponse;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://www.mlb.com/mariners/feeds/news/rss.xml"))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response : ");
                    Console.WriteLine(apiResponse);
                }
            }
            return Ok(apiResponse);
        }
    }
}