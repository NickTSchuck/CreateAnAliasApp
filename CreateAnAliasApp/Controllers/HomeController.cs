using CreateAnAliasApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CreateAnAliasBLL;
using Newtonsoft.Json;

namespace CreateAnAliasApp.Controllers
{
    public class HomeController : Controller
    {       
        private readonly ILogger<HomeController> _logger;
        private readonly ICreateAnAliasBLL _createAnAliasBLL;

        public HomeController(ILogger<HomeController> logger, ICreateAnAliasBLL bll)
        {
            _logger = logger;
            _createAnAliasBLL = bll;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult APICredit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetNewIdentity()
        {
            Dictionary<string, string> results = _createAnAliasBLL.getNewAlias() as Dictionary<string, string>;

            Alias newAlias = new Alias();
            newAlias.FirstName  = results.GetValueOrDefault("FirstName");
            newAlias.LastName  = results.GetValueOrDefault("LastName");
            newAlias.Gender  = results.GetValueOrDefault("Gender");
            newAlias.City  = results.GetValueOrDefault("City");
            newAlias.State  = results.GetValueOrDefault("State");
            newAlias.Country  = results.GetValueOrDefault("Country");
            newAlias.imgURL  = results.GetValueOrDefault("ImageURL");

            return Json(JsonConvert.SerializeObject(newAlias));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
