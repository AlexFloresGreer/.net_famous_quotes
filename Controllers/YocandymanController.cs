using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DapperApp.Models;
using DapperApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DapperApp.Controllers
{
    public class YocandymanController : Controller
    {
        private readonly UserRepository userRepository;

          public YocandymanController() {
            userRepository = new UserRepository();
        }

// ____________________Display main page________________________________
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Console.WriteLine("hitting index");

            return View("Index");
        }
// ____________________Process user and quote________________________________

        [HttpPost]
        [Route("new")]
        public IActionResult New(User newUser)
        {
            Console.WriteLine("adding user first");
            userRepository.Add(newUser);
            Console.WriteLine("adding user");

            return RedirectToAction("Quotes");
        }
// ____________________Display user and quote________________________________
        
        [HttpGet]
        [Route("Quotes")]
        public IActionResult Quotes()
        {
            Console.WriteLine("display quotes");

            return View("Quotes", userRepository.FindAll());
        }





    }
}
