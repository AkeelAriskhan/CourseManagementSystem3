using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem
{
    internal class CourseManager
    {
        public List<Course> Courses=new List<Course>();

        public  void CreateCourse(string Title,string Duration, decimal Price)
        {
            var newcoursre= new Course(Courses.Count+1, Title, Duration, Price);
            Courses.Add(newcoursre);
            Console.WriteLine("Course Added ");
        }
        public void ReadCourses() 
        {
            if (Courses.Count > 0)
            {
                foreach (var course in Courses) 
                {
                 Console.WriteLine(course);
                    
                }
            }
            else {
                Console.WriteLine("Courses not found");
            
            }
        }
        public void UpdateCourse(int CourseId, string Title, string Duration, decimal Price)
        {
           var selectcoursre= Courses.Find(x=>x.CourseId==CourseId);
            if (selectcoursre != null)
            {
                selectcoursre.Duration = Duration;
                selectcoursre.Price = Price;
                selectcoursre.Title = Title;
                Console.WriteLine("coursre updated");

            }
            else { 
              Console.WriteLine($"course not found");
            }
        }
        public void DeleteCourse(int CourseId) 
        {
            var selectcoursre = Courses.Find(x => x.CourseId == CourseId);
            if (selectcoursre != null)
            {
                Courses.Remove(selectcoursre);
                Console.WriteLine("course remove succsefully");

            }
            else
            {
                Console.WriteLine($"course not found");
            }
        }
        public decimal ValidateCoursePrice()
        {
            decimal price=0;
            while (true) 
            {
                Console.Write("Enter  a course price");
                var newprice=decimal.Parse(Console.ReadLine());
                if (newprice > 0)
                {

                    price = newprice;
                    break;
                }
                else {
                 
                    Console.WriteLine("invalid price ");
                
                }
            }
            return price;
        }

    }
}
