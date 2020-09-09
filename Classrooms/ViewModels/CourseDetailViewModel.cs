using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms.ViewModels
{
    public class CourseDetailViewModel
    {
        [Required]
        public string CourseTitle { get; set; }
        public string InstructorId { get; set; }

        public List<string> Participants { get; set; }

    }
}
