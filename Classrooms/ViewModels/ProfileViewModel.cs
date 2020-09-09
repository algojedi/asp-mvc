using Classrooms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms.ViewModels
{
    public class ProfileViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Id { get; set; }
        public List<Enrollment> Enrollments { get; set; }

    }
}
