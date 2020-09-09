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
        private SchoolContext context;

        public CourseController(SchoolContext c)
        {
            context = c;
        }

        public IActionResult CourseDetail(string id)
        {

            string instructorId = context.Courses
                .Where(c => c.CourseId == id).FirstOrDefault().InstructorId;

            var parts = (from e in context.Enrollments
                         where e.CourseID == id
                         select e.PersonID).ToList();

            List<string> namedParts = new List<string>();
            foreach (var part in parts)
            {
                namedParts.Add(context.Users.Find(part).UserName);

            }

            var model = new CourseDetailViewModel
            {
                CourseTitle = id,
                InstructorId = instructorId,
                Participants = namedParts
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCourseViewModel model)
        {
            Console.WriteLine("entering create course post controller and user id is: " + model.id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {

                var course = new Course { CourseId = model.Title, InstructorId = userId, CourseName = model.Title };
                var enrollment = new Enrollment { CourseID = model.Title, PersonID = userId };
                context.Courses.Add(course);
                context.Enrollments.Add(enrollment);
                context.SaveChanges();

            }

            // get the enrollements for the user to pass to the profile view model

            List<Enrollment> enrollments = context.Enrollments
                            .Where(e => e.PersonID == userId).ToList();



            var profileModel = new ProfileViewModel
            {
                Id = userId,
                Name = User.Identity.Name,
                Enrollments = enrollments
            };

            return View("Views/Profile/Index.cshtml", profileModel);
        }
    }

}

