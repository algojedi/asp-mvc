using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public string CourseID { get; set; }
        public string PersonID { get; set; }

        public Course Course { get; set; }
        //public Person Person { get; set; }

    }
}
