using Microsoft.AspNet.Identity;
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
        static string userId;

        public StudentController()
        {
            _context = new ApplicationDbContext();
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
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
            var student = _context.StudentProfile.FirstOrDefault(s => s.StudentId == userId);
            var batch = _context.Batch.FirstOrDefault(b => b.BatchId == student.Batch);
            var exam = _context.Exam.FirstOrDefault(e => e.InstituteId == batch.Institute);
            var questions = _context.Question.Where(q=>q.PatternId==exam.Pattern && q.UploadedBy==exam.InstituteId).ToList();
            ViewBag.Index = 0;
            var question = questions[0];
            return View(question);
        }

        [HttpPost]
        public ActionResult Exam(Question model, string Command, FormCollection form)
        {

            switch(Command)
            {
                case "Next":

                    break;
                case "Prev":
                    break;
                case "Submit":
                    break;
            }

            return View(model);
        }



       

    }
}