using IndividualProjPartA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjPartA.Entities
{
    class Course
    {
        public static List<Course> Courses = new List<Course>();

        public List<Student> CourseStudents = new List<Student>();
        public List<Trainer> CourseTrainers = new List<Trainer>();
        public List<Assignment> CourseAssignments = new List<Assignment>();

        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }

        public Course(string title, string stream, string type, DateTime start_date, DateTime end_date)
        {
            Title = title;
            Stream = stream;
            Type = type;
            Start_date = start_date;
            End_date = end_date;

            Courses.Add(this);
        }
        public Course()
        {
            Title = RandomFunctions.GenerateRandomString(2, 30);
            Stream = RandomFunctions.GenerateRandomString(2, 30);
            Type = RandomFunctions.GenerateRandomString(2, 20);
            Start_date = RandomFunctions.GenerateRandomDate(new DateTime(2020, 10, 1), new DateTime(2021, 3, 1), true);
            End_date = RandomFunctions.GenerateRandomDate(Start_date.AddDays(30), Start_date.AddDays(365), true);

            Courses.Add(this);
        }

        static public void PrintStudentsPerCourse()
        {
            Console.Clear();
            Console.WriteLine("\nThese are the lists of the students per course.");
            foreach (var course in Courses)
            {
                Console.WriteLine($"\nThis is the list of course {course.Title} students.");
                if (course.CourseStudents.Count == 0) { Console.WriteLine("There are no students in this course"); }
                foreach (var student in course.CourseStudents)
                {
                    Console.WriteLine(student);
                }
            }
            Console.ReadLine();
        }
        static public void PrintTrainersPerCourse()
        {
            Console.Clear();
            Console.WriteLine("\nThese are the lists of the trainers per course.");
            foreach (var course in Courses)
            {
                Console.WriteLine($"\nThis is the list of course {course.Title} trainers.");
                foreach (var trainer in course.CourseTrainers)
                {
                    Console.WriteLine(trainer);
                }
            }
            Console.ReadLine();
        }
        static public void PrintAssignmentsPerCourse()
        {
            Console.Clear();
            Console.WriteLine("\nThese are the lists of the assignments per course.");
            foreach (var course in Courses)
            {
                if (course.CourseAssignments.Count == 0) { Console.WriteLine($"\r\nCourse {course.Title} has no assignments."); }
                else
                {
                    Console.WriteLine($"\nThis is the list of course {course.Title} assignments.");
                    foreach (var assignment in course.CourseAssignments)
                    {
                        Console.WriteLine(assignment);

                    }
                }
            }
            Console.ReadLine();
        }


        public override string ToString()
        {
            return $"Title: {Title}, Stream: {Stream}, Type {Type}, Start date: {Start_date.ToString("dd/MM/yyyy")}, End date: {End_date.ToString("dd/MM/yyyy")}";
        }
    }
}

