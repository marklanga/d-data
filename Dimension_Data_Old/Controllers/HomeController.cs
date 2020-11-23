using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dimension_Data.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Dimension_Data.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //string connString = "Server=den1.mysql5.gear.host;Port=3306;User=test321;Password=password.123;Database=test321";
            string connString = "Server=localhost;Port=3306;User=root;Password=admin.123;Database=dimension_data";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand("SP_Test", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
