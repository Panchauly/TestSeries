using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;
using TestSeries.Models;

namespace TestSeries.Controllers
{
    public class AdminController : Controller
    {
        public ApplicationDbContext _context;
        public ApplicationUser _applicationUser;


        public AdminController()
        {
            _context = new ApplicationDbContext();
            _applicationUser = new ApplicationUser();


        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Roles()
        {
            var roleStore = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var model = roleStore.Roles.ToList();
            return View(model);
        }


        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(IdentityRole model)
        {
            var roleStore = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            roleStore.Create(model);
            return RedirectToAction("Roles", "Admin");
        }
    }
}