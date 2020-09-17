using Classrooms.Data;
using Classrooms.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

//public class CourseRepository : ICourseRepository
public class CourseRepository : Repository<Course>, ICourseRepository
{
    private readonly SchoolContext _context;
    public CourseRepository(SchoolContext context) :base(context)
    {
        _context = context;
    }

    public string GetInstructorId(string courseId)
    {
        var course = _context.Courses.Find(courseId);
        return course.InstructorId;
    }

    // returns a list of every person enrolled in the course
    //public IEnumerable<string> GetMemberNames(string courseId)
    public IEnumerable<string> GetMemberIds(string courseId)
    {
        //var enrollments = _context.Enrollments.Where(e => e.CourseID == courseId).Select(enrollment => enrollment.PersonID);

        IEnumerable<string> query = (from u in _context.Users
                                         join e in _context.Enrollments on u.Id equals e.PersonID
                                         select e.PersonID).ToList();
                      //select new { u.UserName }).ToList();
        //select new List<string> { u.UserName };
        //      Dim customerList =
        //        From cust In db.Customers
        //        Where cust.CompanyName.StartsWith("L")
        //Select New CustomerInfo With {.CompanyName = cust.CompanyName,
        //                              .ContactName = cust.ContactName}

        //      DataGridView1.DataSource = customerList



        //List<Point> lp = lpf.ConvertAll(
        //    new Converter<PointF, Point>(PointFToPoint));


        //foreach (var pid in enrollments)
        //{
        //    peopleInCourse.Add(_context.Users.Find(pid).UserName);
        //}
        //return peopleInCourse;
        return query;
    }

    // get a list of the courses a person is enrolled in
    public IEnumerable<Enrollment> GetCourses(string userId)
    {
        List<Enrollment> totalCourses = _context.Enrollments.Where(e => e.PersonID == userId).ToList();

        return totalCourses;
    }
}