using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyMVC.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace ProyMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager=userManager;
        }

        public IActionResult Index()
        {   
            if(User.Identity.IsAuthenticated)
            {
                ViewBag.usuario=User.Identity.Name;
            }
            else{
                ViewBag.usuario="usuario no autenticado";
            }
            
            return View();
        }
        [Authorize]
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
