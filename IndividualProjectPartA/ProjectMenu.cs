using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProjPartA.Entities;
using IndividualProjPartA.Utilities;

namespace IndividualProjPartA
{
    class ProjectMenu
    {
        public static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:"); ;
            Console.WriteLine("\r\n--- SET OPTIONS");
            Console.WriteLine("\r\n1. Set students per course");
            Console.WriteLine("\r\n2. Set trainers per course");
            Console.WriteLine("\r\n3. Set assignments per course");
            Console.WriteLine("\r\n4. Set assignments per student");
            Console.WriteLine("\r\n--- SHOW OPTIONS");
            Console.WriteLine("\r\n5. Show students per course");
            Console.WriteLine("\r\n6. Show trainers per course");
            Console.WriteLine("\r\n7. Show assignments per course");
            Console.WriteLine("\r\n8. Show assignments per student");
            Console.WriteLine("\r\n9. Show students that have more than one courses");
            Console.WriteLine("\r\n10. Show students that have to submit assignment within a specific week");
            Console.WriteLine("\r\n--- EXIT");
            Console.WriteLine("\r\nX. Exit program");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    SetDataFromUser.SetStudentsPerCourse();
                    return true;
                case "2":
                    SetDataFromUser.SetTrainersPerCourse();
                    return true;
                case "3":
                    SetDataFromUser.SetAssignmentsPerCourse();
                    return true;
                case "4":
                    SetDataFromUser.SetAssignmentsPerStudent();
                    return true;
                case "5":
                    Course.PrintStudentsPerCourse();
                    return true;
                case "6":
                    Course.PrintTrainersPerCourse();
                    return true;
                case "7":
                    Course.PrintAssignmentsPerCourse();
                    return true;
                case "8":
                    Student.PrintAssignmentsPerStudent();
                    return true;
                case "9":
                    Student.PrintStudentsThatHaveMoreThanOneCourse();
                    return true;
                case "10":
                    SetDataFromUser.PrintStudentsWhoNeedToSubmitAssignmentsAtSpecificDate();
                    return true;
                case "x":
                case "X":
                    return false;
                default:
                    return true;
            }
        }
    }
}
