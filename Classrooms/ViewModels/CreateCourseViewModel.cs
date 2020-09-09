using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms.ViewModels
{
    public class CreateCourseViewModel
    {

    [Required]
    public string Title { get; set; }
    public string id { get; set; }

    }
}
