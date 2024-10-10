using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem
{
    internal class OnPremisCourse : Course
    {
        public string Schedule;
        public int ClassroomCapacity;

        public OnPremisCourse(int CourseId, string Title,string Duration,decimal Price, string schedule, int classroomCapacity):base (CourseId, Title, Duration, Price)
        {
            Schedule = schedule;
            ClassroomCapacity = classroomCapacity;
        }

        public override string DisplayCourseInfo()
        {
            return base.DisplayCourseInfo() +$"ClassroomCapacity {ClassroomCapacity} Schedule{Schedule} ";
        }
    }
}
