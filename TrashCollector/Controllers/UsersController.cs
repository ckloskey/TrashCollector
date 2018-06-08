using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext db;
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public UsersController()
        {
            db = new ApplicationDbContext();
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
        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }

                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();
        }
        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var user = new ApplicationUser { UserName = model.UserName, UserRole = "Employee", FirstName = model.FirstName, LastName = model.LastName, Email = "employee@gmail.com" };
            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                try
                {
                    await UserManager.AddToRoleAsync(user.Id, "Employee");

                    Employee employee = new Employee();
                    employee.UserId = user.Id;
                    employee.Login = user.UserName;
                    employee.FirstName = user.FirstName;
                    employee.LastName = user.LastName;
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Users");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                
            }
            return View("Index", "Users");
        }
    }
}