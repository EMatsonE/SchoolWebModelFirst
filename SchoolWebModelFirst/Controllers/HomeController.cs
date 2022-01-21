using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolWebModelFirst.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebModelFirst.Controllers
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
            List<Student> result = null;
            using (SchoolContext context = new SchoolContext())
            {
                result = context.Students.ToList();
            }

                return View(result);
        }

        public IActionResult SaveStudent(Student student)
        {
            using (SchoolContext context = new SchoolContext())
            {
                context.Add(student);
                context.SaveChanges();
            }

            return Redirect("/");
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
