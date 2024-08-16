using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestAdo.Models;
using TestAdo.Entities;
using System.Runtime.Intrinsics.Arm;

namespace TestAdo.Controllers
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
            //DatabaseProcess dp = new DatabaseProcess();
            //User user = new()
            //{
            //    Firstname="fateme",
            //    Lastname="ashrafi",
            //    Mobile="0917"
            //};
            //dp.AddUser(user);
            return View();
        }

        public IActionResult Privacy()
        {
            DatabaseProcess dp = new DatabaseProcess();
            dp.GetWithId();
            //for update
            //User user = new()
            //{
            //    Firstname = "pouyan",
            //    Lastname = "Nazari",
            //    Mobile = "0913123456"
            //};
            //dp.UpdateUser(user);



            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
