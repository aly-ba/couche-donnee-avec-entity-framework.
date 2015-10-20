using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using ASPNET5Samurai.DataModel;
using ASPNET5Samurai.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET5Samurai.Controllers.Controllers
{

 
    public class HomeController : Controller
    {
        private readonly SamuraiContext _context;
        public HomeController(SamuraiContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            var samurais = _context.Samurais.ToList();
            return View(samurais);
        }
        public IActionResult Insert(string name)
        {
            _context.Add(new Samurai { Name = name });
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}
