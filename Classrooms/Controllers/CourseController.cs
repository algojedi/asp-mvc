using Classrooms.Data;
using Classrooms.Models;
using Classrooms.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Classrooms.Controllers
{
    public class CourseController : Controller
    {
        //private SchoolContext _context;
        private IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;

        public CourseController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            //_context = c;
            _unitOfWork = unitOfWork;
            _userManager = userManager;

        }

        public async Task<ViewResult> CourseDetail(string id)
        {
            string instructorId;
            IEnumerable<string> participants;

            instructorId = _unitOfWork.Courses.GetInstructorId(id);
            participants = _unitOfWork.Courses.GetMemberIds(id);

            List<string> usernames = new List<string>();
            ApplicationUser user;
            
            foreach (string p in participants) {
                user = await _userManager.FindByIdAsync(p);
                usernames.Add(user.UserName);
            }
            var model = new CourseDetailViewModel
            {
                CourseTitle = id,
                InstructorId = instructorId,
                Participants = usernames
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //    [HttpPost]
        //    public IActionResult Create(CreateCourseViewModel model)
        //    {
        //        Console.WriteLine("entering create course post controller and user id is: " + model.id);
        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        if (ModelState.IsValid)
        //        {

        //            var course = new Course { CourseId = model.Title, InstructorId = userId, CourseName = model.Title };
        //            var enrollment = new Enrollment { CourseID = model.Title, PersonID = userId };
        //            _context.Courses.Add(course);
        //            _context.Enrollments.Add(enrollment);
        //            _context.SaveChanges();

        //        }



    }
}
