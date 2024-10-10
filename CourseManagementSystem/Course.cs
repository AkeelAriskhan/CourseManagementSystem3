using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem
{
    internal class Course
    {
        public  int CourseId { get; set; }
        public string Title { get; set; }

        public string Duration { get; set; }

        public decimal Price { get; set; }
    }
}
