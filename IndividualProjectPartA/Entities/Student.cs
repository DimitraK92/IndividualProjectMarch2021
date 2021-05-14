using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProjPartA.Utilities;

namespace IndividualProjPartA.Entities
{
    class Student
    {
        public static List<Student> Students = new List<Student>();
        public List<Assignment> StudentAssignments = new List<Assignment>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal TuitionFees { get; set; }
        public Student(string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TuitionFees = tuitionFees;

            Students.Add(this);
        }
        public Student()
        {
            FirstName = RandomFunctions.GenerateRandomString(3, 15);
            LastName = RandomFunctions.GenerateRandomString(3, 30);
            DateOfBirth = RandomFunctions.GenerateRandomDate(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(-18), false);
            TuitionFees = RandomFunctions.GenerateRandomDecimal(0, 5000);

            Students.Add(this);
        }

        public static void PrintAssignmentsPerStudent()
        {
            Console.Clear();
            Console.WriteLine("\n\nThese are the lists of the assignments per student.");
            foreach (var student in Students)
            {
                if (student.StudentAssignments.Count == 0) { Console.WriteLine($"The student {student.FirstName} {student.LastName} has no assignments."); }
                else
                {
                    Console.WriteLine($"\n{student.FirstName} {student.LastName}'s assignments:");
                    foreach (var assignment in student.StudentAssignments)
                    {
                        Console.WriteLine(assignment);
                    }
                }
            }
            Console.ReadLine();
        }
        public static void PrintStudentsThatHaveMoreThanOneCourse()
        {
            Console.Clear();
            Console.WriteLine("\nThese are the students that have more than one course.");

            bool atLeastOne = false;
            foreach (var student in Students)
            {
                int c = 0;
                foreach(var course in Course.Courses)
                {
                    if (course.CourseStudents.Contains(student)) { c++; }
                    if (c > 1)
                    {
                        atLeastOne = true;
                        Console.WriteLine(student);
                        break;
                    }
                }
            }
            if (!atLeastOne)
            {
                Console.WriteLine("\nThere are no students that have more than one course.");
            }
            Console.ReadLine();
        }

        public static List<Student> GetRandomStudents()
        {
            List<Student> students = new List<Student>();
            int amount = RandomFunctions.Rnd.Next(1, Students.Count);
            foreach (var student in Students.OrderBy(x => RandomFunctions.Rnd.Next()).Take(amount))
            {
                students.Add(student);
            }
            return students;
        }
        public static List<Student> GetRandomStudents(int amount)
        {
            List<Student> students = new List<Student>();
            if (amount > Students.Count)
            {
                amount = Students.Count;
                Console.WriteLine($"There are only {Students.Count} available, so all of them will be added to the course.");
            }
            foreach (var student in Students.OrderBy(x => RandomFunctions.Rnd.Next()).Take(amount))
            {
                students.Add(student);
            }
            return students;
        }
        public List<Assignment> GetallAvailableAssignments()
        {
            var allAvailableStudentAssignments = new List<Assignment>();
            foreach (var course in Course.Courses)
            {
                if (course.CourseStudents.Contains(this))
                {
                    allAvailableStudentAssignments.AddRange(course.CourseAssignments);
                }
            }
            return allAvailableStudentAssignments;
        }

        public List<Assignment> GetRandomStudentAssignments(int amount = 0)
        {
            var allAvailableStudentAssignments = GetallAvailableAssignments();
            if (allAvailableStudentAssignments.Count == 0) { return allAvailableStudentAssignments; }

            var assignments = new List<Assignment>();
            if (amount == 0) { amount = RandomFunctions.Rnd.Next(1, allAvailableStudentAssignments.Count); }
            else if (amount > allAvailableStudentAssignments.Count)
            {
                amount = allAvailableStudentAssignments.Count;
                Console.WriteLine("You have asked for more assignments than there are available. All availaible ones will be added.");
            }
            foreach (var assignment in allAvailableStudentAssignments.OrderBy(x => RandomFunctions.Rnd.Next()).Take(amount))
            {
                assignments.Add(assignment);
            }

            return assignments;
        }
        public override string ToString()
        {
            return $"First name: {FirstName}, Last name: {LastName}, Date of birth: {DateOfBirth.ToString("dd/MM/yyyy")}, Tuition fees: {TuitionFees}.";
        }

    }
}
