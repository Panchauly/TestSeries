using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestSeries.Models;
using TestSeries.Models.ViewModel;

namespace TestSeries.Controllers
{
    public class InstituteController : Controller
    {
        static ApplicationDbContext _context;
        static string userId = "";
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public InstituteController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _context = new ApplicationDbContext();
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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
            _context.Question.Add(que);
            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", "Institute");
            }
            return View(model);
        }

        public ActionResult AddExam()
        {
            ViewBag.Branch = new SelectList(_context.Branch, "BranchId", "BranchName");
            ViewBag.Level = new SelectList(_context.Level, "LevelId", "LevelName");
            ViewBag.Subject = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            ViewBag.Chapter = new SelectList(_context.Chapter, "ChapterId", "ChapterName");
            return View();
        }

        [HttpPost]
        public ActionResult AddExam(Exam model, FormCollection form)
        {
            ViewBag.Branch = new SelectList(_context.Branch, "BranchId", "BranchName");
            ViewBag.Level = new SelectList(_context.Level, "LevelId", "LevelName");
            ViewBag.Subject = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            ViewBag.Chapter = new SelectList(_context.Chapter, "ChapterId", "ChapterName");
            var Branch = Convert.ToInt32(form["Branch"] as string);
            var Level = Convert.ToInt32(form["Level"] as string);
            var Subject = Convert.ToInt32(form["Subject"] as string);
            var Chapter = Convert.ToInt32(form["Chapter"] as string);
            Pattern pattern = _context.Patterns.FirstOrDefault(p => p.Level == Level && p.Subject == Subject && p.Branch == Branch && p.Chapter == Chapter);
            model.Pattern = pattern.PatternId;
            _context.Exam.Add(model);
            if (_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index", "Institute");
            }
            return View(model);
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(StudentViewModel model, FormCollection form)
        {
            if (ModelState.IsValid)
            {

                ApplicationDbContext _context = new ApplicationDbContext();
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.Phone };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Student");
                    var batch = _context.Batch.FirstOrDefault(b=>b.Institute == userId);
                    if (batch != null)
                    {
                        if (batch.EnrolledSeates < batch.AllotedSeats)
                        {
                            StudentProfile student = new StudentProfile();
                            student.StudentId = user.Id;
                            student.FirstName = model.FirstName;
                            student.LastName = model.LastName;
                            student.DOB = model.DOB;
                            student.Gender = form["Gender"] as string;
                            student.Batch = batch.BatchId;
                            student.IsActive = true;
                            _context.StudentProfile.Add(student);
                            if (_context.SaveChanges() > 0)
                            {
                                batch.EnrolledSeates = batch.EnrolledSeates + 1;
                                _context.SaveChanges();
                                return RedirectToAction("Index", "Institute");
                            }
                        }
                    }
                }
            }
            return View(model);
        }


    }
}