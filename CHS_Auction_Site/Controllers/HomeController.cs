using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CHS_Auction_Site.Models;

using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CHS_Auction_Site.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration configuration;

        //public HomeController(IConfiguration config)
        //{
            //this.configuration = config;
        //}

        public IActionResult Index()
        {
            //string connectionstring = configuration.GetConnectionString("AuctionDatabase");

            //SqlConnection connection = new SqlConnection(connectionstring);

            //connection.Open();
            //SqlCommand com = new SqlCommand("Select count(*) from Admins", connection);
            //var ha = (int)com.ExecuteScalar();
            //ViewData["Total"] = ha;
            //connection.Close();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            ViewData["Message"] = "Check In";

            return View();
        }

        public IActionResult Payments()
        {
            ViewData["Message"] = "Payment";

            return View();
        }

        public IActionResult NewItem()
        {
            ViewData["Message"] = "NewItem";

            return View();
        }

        public IActionResult Event()
        {
            ViewData["Message"] = "Event";

            return View();
        }

        public IActionResult EventItems()
        {
            ViewData["Message"] = "Event Items";

            return View();
        }

		public IActionResult CheckIn()
        {
            ViewData["Message"] = "Check In";

            return View();
		}
        public IActionResult Invoice()
        {
            return View();
        }

        public IActionResult TicketSales()
        {
            return View();
        }

        public IActionResult ItemLog()
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
