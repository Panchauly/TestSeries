using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSeries.Models;
using TestSeries.Models.ViewModel;

namespace TestSeries.Controllers
{
    public class InstituteController : Controller
    {
        static ApplicationDbContext _context;
        static string userId;

        public InstituteController()
        {
            _context = new ApplicationDbContext();
          //  userId = User.Identity.GetUserId();
        }

        // GET: Institute
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            ViewBag.CityId = new SelectList(_context.City,"CityId","CityName");
            ViewBag.StateId = new SelectList(_context.State, "StateId", "StateName");
            return View();
        }

        [HttpPost]
        public new ActionResult Profile(InstituteProfile model)
        {
            ViewBag.CityId = new SelectList(_context.City, "CityId", "CityName");
            ViewBag.StateId = new SelectList(_context.State, "StateId", "StateName");
            model.InstituteId = userId;

            return View(model);
        }

        public ActionResult AddBranch()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult AddBranch(Branch model)
        {
            return View(model);
        }

        public ActionResult AddLevel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLevel(Level model)
        {
            return View(model);
        }

        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject model)
        {
            return View(model);
        }


        public ActionResult AddChapter()
        {
            ViewBag.SubjectId = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            return View();
        }

        [HttpPost]
        public ActionResult AddChapter(Chapter model)
        {
            ViewBag.SubjectId = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            return View(model);
        }


        public ActionResult AddQuestion()
        {
            ViewBag.Branch = new SelectList(_context.Branch, "BranchId", "BranchName");
            ViewBag.Level  = new SelectList(_context.Subject, "LevelId", "LevelName");
            ViewBag.Subject = new SelectList(_context.Level, "SubjectId", "SubjectName");
            ViewBag.Chapter = new SelectList(_context.Chapter, "ChapterId", "ChapterName");
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(QuestionViewModel model)
        {
            ViewBag.Branch = new SelectList(_context.Branch, "BranchId", "BranchName");
            ViewBag.Level = new SelectList(_context.Subject, "LevelId", "LevelName");
            ViewBag.Subject = new SelectList(_context.Level, "SubjectId", "SubjectName");
            ViewBag.Chapter = new SelectList(_context.Chapter, "ChapterId", "ChapterName");
            return View(model);
        }


    }
}