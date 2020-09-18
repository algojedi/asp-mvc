using Classrooms.Data;
using Classrooms.Models;
using System.Collections.Generic;
using System.Linq;

//public class CourseRepository : ICourseRepository
public class CourseRepository : Repository<Course>, ICourseRepository
{
    private readonly SchoolContext _context;

    public CourseRepository(SchoolContext context) : base(context)
    {
        _context = context;
    }

    public string GetInstructorId(string courseId)
    {
        var course = _context.Courses.Find(courseId);
        return course.InstructorId;
    }

    // returns a list of every person enrolled in the course
    public IEnumerable<string> GetMemberIds(string courseId)
    {
        //var enrollments = _context.Enrollments.Where(e => e.CourseID == courseId).Select(enrollment => enrollment.PersonID);

        IEnumerable<string> query = (from u in _context.Users
                                     join e in _context.Enrollments on u.Id equals e.PersonID
                                     where e.CourseID == courseId
                                     select e.PersonID).ToList();
               return query;
    }

    // get a list of the courses a person is enrolled in
    public IEnumerable<Enrollment> GetCourses(string userId)
    {
        List<Enrollment> totalCourses = _context.Enrollments.Where(e => e.PersonID == userId).ToList();

        return totalCourses;
    }
}