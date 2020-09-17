
using Classrooms.Models;
using System.Collections.Generic;

    public interface ICourseRepository : IRepository<Course>
    {
        string GetInstructorId(string courseId);

    IEnumerable<Enrollment> GetCourses(string userId);
    public IEnumerable<string> GetMemberIds(string courseId);
    }