using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classrooms.Data;
using Classrooms.Models;
using Classrooms.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Classrooms.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        //private SchoolContext context;
        private IUnitOfWork _unitOfWork;


        //public ProfileController(SchoolContext ctx, IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> usermgr, SignInManager<ApplicationUser> sim)
        public ProfileController(IUnitOfWork uow, IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> usermgr, SignInManager<ApplicationUser> sim)
        {
            httpContextAccessor = _httpContextAccessor;
            userManager = usermgr;
            signInManager = sim;
            //context = ctx;
            _unitOfWork = uow;
        }
        public IActionResult Index()
        {
            //string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            //string userId = httpContextAccessor.HttpContext.User.

            var userId = userManager.GetUserId(User);
            //Console.WriteLine("the user id for the profile page is.." + userId);

            //List<Enrollment> enrollments = context.Enrollments
            //                .Where(e => e.PersonID == userId).ToList();


            //foreach (Enrollment e in enrollments)
            //{
            //    Console.WriteLine("the course " + User.Identity.Name + " is enrolled in is: " + e.CourseID);
            //}
            //Console.WriteLine(User.Identity.Name + " has the following course: " + enrollments);

            List<Enrollment> enrollments = _unitOfWork.Courses.GetCourses(userId).ToList();

            var model = new ProfileViewModel
            {
                Name = userName,
                Id = userId,
                Enrollments = enrollments

            };
            return View(model);
        }
    }
}
