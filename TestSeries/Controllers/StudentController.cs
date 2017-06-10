using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSeries.Models;

namespace TestSeries.Controllers
{
    public class StudentController : Controller
    {
        private static ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            ViewBag.CityId = new SelectList(_context.City,"CityId","CityName");
            return View();
        }

        [HttpPost]
        public new ActionResult Profile(StudentProfile model)
        {
            return View(model);
        }

        public ActionResult Exam()
        {
            return View();
        }

    }
}