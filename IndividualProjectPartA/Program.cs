using IndividualProjPartA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjPartA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\nHello and wellcome to the 'Build a Private School from scratch!' console application.\r\nThis app provides a simple structure for setting and demonstrating " +
                "your school data via the console.\r\nYou will be asked to fill the entities of Students, Trainers, Courses and Assignment first and after that, to match each student, trainer " +
                "and assignment with a specific course (one or more).\r\nThe application allows you to keep courses without necessarily having to add students in it.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();

            // set students, trainers, courses, assignments
            SetDataFromUser.SetData();

            bool showMenu = true;
            // show available options until user chooses to exit the program
            while (showMenu)
            {
                showMenu = ProjectMenu.Menu();
            }
        }
    }
}
