using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classrooms.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }
        public DateTime PostTime { get; set; }
        public string PosterId { get; set; }

        public Course Course { get; set; }
        public string CourseId { get; set; }

    }
}
