using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Classrooms.Models
{
    public class Course
    {

        [Required]
        public string CourseId { get; set; }

        [Required]
        public string InstructorId { get; set; }

        [Required]
        public string CourseName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}
