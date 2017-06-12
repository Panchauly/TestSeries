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
        static string userId="";

        public InstituteController()
        {
            _context = new ApplicationDbContext();
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }

        // GET: Institute
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            ViewBag.CityId = new SelectList(_context.City, "CityId", "CityName");
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
            _context.Branch.Add(model);
            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", "Institute");
            }
            return View(model);
        }

        public ActionResult AddLevel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLevel(Level model)
        {
            _context.Level.Add(model);
            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", "Institute");
            }
            return View(model);
        }

        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject model)
        {
            _context.Subject.Add(model);
            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", "Institute");
            }
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
            _context.Chapter.Add(model);
            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", "Institute");
            }
            ViewBag.SubjectId = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            return View(model);
        }


        public ActionResult AddQuestion()
        {
            ViewBag.Branch = new SelectList(_context.Branch, "BranchId", "BranchName");
            ViewBag.Level = new SelectList(_context.Level, "LevelId", "LevelName");
            ViewBag.Subject = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            ViewBag.Chapter = new SelectList(_context.Chapter, "ChapterId", "ChapterName");
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(QuestionViewModel model)
        {
            ViewBag.Branch = new SelectList(_context.Branch, "BranchId", "BranchName");
            ViewBag.Level = new SelectList(_context.Level, "LevelId", "LevelName");
            ViewBag.Subject = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            ViewBag.Chapter = new SelectList(_context.Chapter, "ChapterId", "ChapterName");
            var que = new Question();
            que.QuestionBody = model.QuestionBody;
            que.UploadedBy = userId;
            que.RightAnswer = model.RightAnswer;
            que.A = model.A;
            que.B = model.B;
            que.C = model.C;
            que.D = model.D;
            que.UploadedOn = DateTime.Now;
            Pattern pattern = _context.Patterns.FirstOrDefault(p => p.Level == model.Level && p.Subject == model.Subject && p.Branch == model.Branch && p.Chapter == model.Chapter);
            if (pattern == null)
            {
                pattern = new Pattern();
                pattern.Branch = model.Branch;
                pattern.Chapter = model.Chapter;
                pattern.Level = model.Level;
                pattern.Subject = model.Subject;
                _context.Patterns.Add(pattern);
                _context.SaveChanges();
            }
            que.PatternId = pattern.PatternId;
            que.AnyImage = false;
            que.DificultyLevel = 0;
            que.QuestionImage = 0;
            if (!que.AnyImage)
                que.QuestionImage = 2;
            _context.Question.Add(que);
            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", "Institute");
            }
            return View(model);
        }


    }
}