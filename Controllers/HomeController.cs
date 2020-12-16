using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Academia.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly AcademiaWebContext _Context;

        public HomeController(ILogger<HomeController> logger, AcademiaWebContext context)
        {
            _logger = logger;
            _Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            var student = _Context.Students.Include(p=>p.ParentStudents).ThenInclude(p=>p.Parent).ToList();
            return View(student);
        }

        public IActionResult studentbyid(int id)
        {
            var student = _Context.Students.Include(p => p.ParentStudents).ThenInclude(p => p.Parent).FirstOrDefault(p=>p.Id==id);
            return View(student);
        }

        public IActionResult Privacy(string s, int i)
        {
            //some kind of logic to process s and i
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
