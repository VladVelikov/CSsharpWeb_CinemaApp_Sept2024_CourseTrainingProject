using System.Diagnostics;        // system
using Microsoft.AspNetCore.Mvc;  // third party
using CinemaApp.Web.ViewModels;  // internal

namespace CinemaApp.Web.Controllers
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
            /// two ways of transmitting data from controller to view
            /// 1. ViewBag or ViewData use
            /// 2. Pass VewModel to the View - in the brackets   =>>  return View( "The view model" )

            ViewBag.Title = "HomePage";
            ViewBag.Message = "Welcome to the Cinema Web App!";
            return View();
        }

       
    }
}
