using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using myaspnetcore_mvc_app.Models;

namespace myaspnetcore_mvc_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            this.config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //read the connection string from appettings.json
            string connstring = this.config.GetConnectionString("MyDbConnection");
            ViewBag.ConnectionString = connstring;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
