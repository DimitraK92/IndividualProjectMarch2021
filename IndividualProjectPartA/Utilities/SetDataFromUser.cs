using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProjPartA.Entities;

namespace IndividualProjPartA.Utilities
{
    class SetDataFromUser
    {
        public static void SetData()
        {
            Console.Clear();
            Console.WriteLine("\r\nCreate the students");
            SetStudents();
            PrintStudents();

            Console.Clear();
            Console.WriteLine("\r\nCreate the trainers");
            SetTrainers();
            PrintTrainers();

            Console.Clear();
            Console.WriteLine("\r\nCreate the courses");
            SetCourses();
            PrintCourses();

            Console.Clear();
            Console.WriteLine("\r\nCreate the assignments");
            SetAssignments();
            PrintAssignments();
        }

        public static void SetStudents()
        {
            Console.WriteLine("\nIf you want students to be added to a list automatically for you enter the number of students you want to be created.\nOtherwise press any other key to add students manually.");
            int number;
            var isValidNumber = int.TryParse(Console.ReadLine(), out number) && number > 0;
            if (isValidNumber)
            {
                for (int i = 0; i < number; i++) { new Student(); };
            }
            else
            {
                bool addMore = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nPlease enter the info of the students you want to add to the list.");
                    //first name
                    var firstName = GetFromKeyboard.GetStringFromKeyboard("first name");
                    //last name
                    var lastName = GetFromKeyboard.GetStringFromKeyboard("last name");
                    //date of birth
                    var dateOfBirth = GetFromKeyboard.GetDateFromKeyboard("date of birth");
                    //tuition fees
                    decimal tuitionFees = GetFromKeyboard.GetDecimalFromKeyboard("tuition fees");
                    //create student
                    new Student(firstName, lastName, dateOfBirth, tuitionFees);

                    Console.WriteLine("\n\nDo you want to add another student? Enter Y for yes.\nOtherwise, press any other key  to see your list.");
                    var answer = Console.ReadLine();
                    if (answer.ToUpper() == "Y") { addMore = true; }
                    else { addMore = false; }
                }
                while (addMore);
            }
        }
        public static void PrintStudents()
        {
            Console.WriteLine($"{Student.Students.Count} students were created. Here is the list:");
            int count = 0;
            foreach (var student in Student.Students)
            {
                count++;
                Console.WriteLine($"{count} - {student}");
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public static void SetTrainers()
        {
            Console.WriteLine("\nIf you want trainers to be added to a list automatically for you enter the number of students you want to be created.\nOtherwise just press enter to add trainers manually.");
            int number;
            var isValidNumber = int.TryParse(Console.ReadLine(), out number) && number > 0;
            if (isValidNumber)
            {
                for (int i = 0; i < number; i++) { new Trainer(); }
            }
            else
            {
                bool addMore = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nPlease enter the info of the trainers you want to add to the list.");
                    //first name
                    var firstName = GetFromKeyboard.GetStringFromKeyboard("first name");
                    //last name
                    var lastName = GetFromKeyboard.GetStringFromKeyboard("last name");
                    //subject
                    var subject = GetFromKeyboard.GetStringFromKeyboard("subject");

                    new Trainer(firstName, lastName, subject);

                    Console.WriteLine("\n\nDo you want to add another trainer? Enter Y for yes.\nOtherwise, press any other key to see your list.");
                    var answer = Console.ReadLine();
                    if (answer.ToUpper() == "Y") { addMore = true; }
                    else { addMore = false; }
                }
                while (addMore);
            }
        }
        public static void PrintTrainers()
        {
            Console.WriteLine($"{Trainer.Trainers.Count} trainers were created. Here is the list:");
            int count = 0;
            foreach (var trainer in Trainer.Trainers)
            {
                count++;
                Console.WriteLine($"{count} - {trainer}");
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public static void SetCourses()
        {
            Console.WriteLine("\nIf you want courses to be added to a list automatically for you enter the number of courses you want to be created.\nOtherwise press any other key to add courses manually.");
            int number;
            var isValidNumber = int.TryParse(Console.ReadLine(), out number) && number > 0;
            if (isValidNumber)
            {
                for (int i = 0; i < number; i++) { new Course(); }
            }
            else
            {
                bool addMore = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nPlease enter the info of the courses you want to add to the list.");
                    //title
                    var title = GetFromKeyboard.GetStringFromKeyboard("title");
                    //stream
                    var stream = GetFromKeyboard.GetStringFromKeyboard("stream");
                    //type
                    var type = GetFromKeyboard.GetStringFromKeyboard("type");
                    //start_date
                    var start_date = GetFromKeyboard.GetDateFromKeyboard("start date");
                    //end_date;
                    var end_date = GetFromKeyboard.GetDateFromKeyboard("end date;");
                    //create course
                    new Course(title, stream, type, start_date, end_date);

                    Console.WriteLine("\n\nDo you want to add another course? Enter Y for yes.\nOtherwise, press any other key to see your list.");
                    var answer = Console.ReadLine();
                    if (answer.ToUpper() == "Y") { addMore = true; }
                    else { addMore = false; }
                }
                while (addMore);
            }
        }
        public static void PrintCourses()
        {
            Console.WriteLine($"{Course.Courses.Count} courses with assignments were created. Here is the list:");
            int count = 0;
            foreach (var course in Course.Courses)
            {
                count++;
                Console.WriteLine($"{count} - {course}");
                Console.WriteLine($"{course.CourseAssignments.Count} course assignments were created. Here is the list:");
                foreach (var assignment in course.CourseAssignments)
                {
                    Console.WriteLine($"- {assignment}");
                }
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public static void SetAssignments()
        {
            Console.WriteLine("\nIf you want assignments to be added to a list automatically for you enter the number of assignments you want to be created.\nOtherwise press any other key to add assignments manually.");
            int number;
            var isValidNumber = int.TryParse(Console.ReadLine(), out number) && number > 0;
            if (isValidNumber)
            {
                var coursesCounter = 0;
                //create an assignment with it's date inside the boundaries of a course
                for (int i = 0; i < number; i++)
                {
                    // if there are are less courses than assignments start from the first course again
                    if (coursesCounter >= Course.Courses.Count) { coursesCounter = 0; }
                    var selectedCourse = Course.Courses[coursesCounter];
                    new Assignment(selectedCourse.Start_date, selectedCourse.End_date);
                    coursesCounter++;
                }
            }
            else
            {
                bool addMore = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nPlease enter the info of the assignments you want to add to the list.");
                    //title
                    var title = GetFromKeyboard.GetStringFromKeyboard("title");
                    //description
                    var description = GetFromKeyboard.GetStringFromKeyboard("description");
                    //SubDateTime
                    var subDateTime = GetFromKeyboard.GetDateFromKeyboard("submission date");
                    //oralMark
                    var oralMark = GetFromKeyboard.GetFloatFromKeyboard("oral mark");
                    //totalMark
                    var totalMark = GetFromKeyboard.GetFloatFromKeyboard("total mark");
                    //create assignment
                    new Assignment(title, description, subDateTime, oralMark, totalMark);

                    Console.WriteLine("\n\nDo you want to add another assignment? Enter Y for yes.\nOtherwise, press any other key to see your list.");
                    var answer = Console.ReadLine();
                    if (answer.ToUpper() == "Y") { addMore = true; }
                    else { addMore = false; }
                }
                while (addMore);
            }
        }
        public static void PrintAssignments()
        {
            Console.WriteLine($"\nHere is the list of assignments:\n");
            int count = 0;
            foreach (var assign in Assignment.Assignments)
            {
                count++;
                Console.WriteLine($"{count} - {assign}");
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public static void SetStudentsPerCourse()
        {
            //clear all previous data in case this option was selected again before
            foreach (var course in Course.Courses)
            {
                course.CourseStudents = new List<Student>();
            }

            Console.Clear();
            Console.WriteLine($"\nIf you want students to be added to the courses automatically for you please enter the letter A.\nOtherwise, press any other key to go on with the data setting.");
            var userInput = Console.ReadLine();
            if (userInput.ToUpper() == "A")
            {
                foreach (var course in Course.Courses)
                {
                    course.CourseStudents = Student.GetRandomStudents();
                }
            }
            else
            {
                Console.Clear();
                foreach (var course in Course.Courses)
                {
                    Console.WriteLine($"\nIf you want students to be added to the course {course.Title} automatically for you please enter the number of students you want to be added " +
                        $"or enter 0 for not adding students to this course.\nOtherwise press any other key to add students manually.");
                    int number;
                    var isValidNumber = int.TryParse(Console.ReadLine(), out number);
                    if (isValidNumber)
                    {
                        if (number == 0) { continue; }
                        else if (number > 0)
                        {
                            course.CourseStudents = Student.GetRandomStudents(number);
                        }
                    }
                    else
                    {
                        Console.WriteLine("These are your students.\r\nSelect students by entering the student's number.");
                        Console.WriteLine("");
                        PrintStudents();
                        bool addMore = false;
                        do
                        {
                            Console.Write($"\r\nStudent's number:");
                            bool isValid = false;
                            int studentNum;
                            do
                            {
                                isValid = int.TryParse(Console.ReadLine(), out studentNum);
                                if (isValid)
                                {
                                    if (studentNum <= 0 || studentNum > Student.Students.Count) { isValid = false; }
                                }
                                var doesStudentExist = false;
                                if (isValid)
                                {
                                    doesStudentExist = course.CourseStudents.Contains(Student.Students[studentNum - 1]);
                                    if (doesStudentExist) { isValid = false; }
                                }
                                if (!isValid)
                                {
                                    if (doesStudentExist)
                                    {
                                        Console.WriteLine("This student has already been added to this course.");
                                    }
                                    Console.Write($"Please enter a valid number:");
                                }

                            } while (!isValid);

                            course.CourseStudents.Add(Student.Students[studentNum - 1]);
                            if (Student.Students.Count == course.CourseStudents.Count) { Console.WriteLine("You have added all the available students to the course."); break; }
                            Console.WriteLine("\nDo you want to add another student? Enter Y for yes.\nOtherwise, press any other key.");
                            var answer = Console.ReadLine();
                            if (answer.ToUpper() == "Y") { addMore = true; }
                            else { addMore = false; }
                        }
                        while (addMore);
                    }

                }

            }



        }

        public static void SetTrainersPerCourse()
        {
            //clear all previous data in case this option was selected again before
            foreach (var course in Course.Courses)
            {
                course.CourseTrainers = new List<Trainer>();
            }

            Console.Clear();
            Console.WriteLine($"\nIf you want trainers to be added to the courses automatically for you please enter the letter A.\nOtherwise, press any other key to go on with the data setting.");
            var userInput = Console.ReadLine();
            if (userInput.ToUpper() == "A")
            {
                foreach (var course in Course.Courses)
                {
                    course.CourseTrainers = Trainer.GetRandomTrainers();
                }
            }
            else
            {
                Console.Clear();
                foreach (var course in Course.Courses)
                {
                    Console.WriteLine($"\nIf you want trainers to be added to the course {course.Title} automatically for you please enter the number of trainers you want to be added or enter 0 for not adding trainers to this course." +
                        $"\nOtherwise just press any other key to add trainers manually.");
                    int number;
                    var isValidNumber = int.TryParse(Console.ReadLine(), out number);
                    if (isValidNumber)
                    {
                        if (number == 0) { continue; }
                        else if (number > 0)
                        {
                            course.CourseTrainers = Trainer.GetRandomTrainers(number);
                            foreach (var trainer in course.CourseTrainers) { trainer.TrainerCourses.Add(course); }
                        }
                    }
                    else
                    {
                        Console.WriteLine("These are your trainers.\r\nSelect trainers by entering the trainer's number.");
                        Console.WriteLine("");
                        PrintTrainers();
                        bool addMore = false;
                        do
                        {
                            Console.Write($"\r\nTrainer's number:");
                            bool isValid = false;
                            int trainerNum;
                            do
                            {
                                isValid = int.TryParse(Console.ReadLine(), out trainerNum);
                                if (isValid)
                                {
                                    if (trainerNum <= 0 || trainerNum > Trainer.Trainers.Count) { isValid = false; }
                                }
                                var doesTrainerExist = false;
                                if (isValid)
                                {
                                    doesTrainerExist = course.CourseTrainers.Contains(Trainer.Trainers[trainerNum - 1]);
                                    if (doesTrainerExist) { isValid = false; }
                                }
                                if (!isValid)
                                {
                                    if (doesTrainerExist)
                                    {
                                        Console.WriteLine("This trainer has already been added to this course.");
                                    }
                                    Console.Write($"Please enter a valid number:");
                                }

                            } while (!isValid);

                            course.CourseTrainers.Add(Trainer.Trainers[trainerNum - 1]);
                            if (Trainer.Trainers.Count == course.CourseTrainers.Count) { Console.WriteLine("You have added all the available trainers to the course."); break; }
                            Console.WriteLine("\nDo you want to add another trainer? Enter Y for yes.\nOtherwise, press any other key.");
                            var answer = Console.ReadLine();
                            if (answer.ToUpper() == "Y") { addMore = true; }
                            else { addMore = false; }
                        }
                        while (addMore);
                    }
                }
            }

        }

        public static void SetAssignmentsPerCourse()
        {
            //clear all previous data in case this option was selected again before
            foreach (var course in Course.Courses)
            {
                course.CourseAssignments = new List<Assignment>();
            }

            Console.Clear();
            Console.WriteLine($"\nIf you want assignments to be added to the courses automatically for you please enter the letter A.\nOtherwise, press any other key to go on with the data setting.");
            var userInput = Console.ReadLine();
            if (userInput.ToUpper() == "A")
            {
                foreach (var assignment in Assignment.Assignments)
                {
                    foreach (var course in Course.Courses.OrderBy(x => RandomFunctions.Rnd.Next()))
                    {
                        if (assignment.SubDateTime >= course.Start_date && assignment.SubDateTime <= course.End_date)
                        {
                            course.CourseAssignments.Add(assignment);
                            //if added in one course then it should not be added to more courses
                            //an assignment cannot belong to many courses
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There are no assignments for this course");
                        }
                    }

                }
            }
            else
            {
                Console.Clear();
                foreach (var course in Course.Courses)
                {

                    //check that there is an assignment within the course's date range
                    List<Assignment> validAssignments = new List<Assignment>();
                    foreach (var assignment in Assignment.Assignments)
                    {
                        if (assignment.SubDateTime >= course.Start_date && assignment.SubDateTime <= course.End_date)
                        {
                            validAssignments.Add(assignment);
                        }
                    }
                    if (validAssignments.Count == 0)
                    {
                        Console.WriteLine("There are no assignments within the date-range of the specific course");
                        continue;
                    }

                    //check that there is an assignment that has not already been used for another course
                    List<Assignment> validAndNotUsedAssignments = new List<Assignment>();
                    foreach (var assignment in validAssignments)
                    {
                        var isUsed = false;
                        foreach (var c in Course.Courses)
                        {
                            if (c.CourseAssignments.Contains(assignment)) { isUsed = true; }
                        }
                        if (!isUsed) { validAndNotUsedAssignments.Add(assignment); }
                    }
                    if (validAndNotUsedAssignments.Count == 0)
                    {
                        Console.WriteLine("There are no assignments for this course that are not already used in another course");
                        continue;
                    }

                    Console.WriteLine($"\nIf you want assignments to be added to the course {course.Title} ({course.Start_date} - {course.End_date}) automatically for you please enter the number of assignments you want to be added or enter 0 for not adding assignments to this course." +
                        $"\nOtherwise just press any other key to add assignments manually.");
                    int number;
                    var isValidNumber = int.TryParse(Console.ReadLine(), out number);
                    if (isValidNumber)
                    {
                        if (number == 0) { continue; }
                        else if (number > 0)
                        {
                            if (number > validAndNotUsedAssignments.Count)
                            {
                                Console.WriteLine("You asked for more assignments to be added in the course than the ones that exist and are in a valid date range and not already used." +
                                    "All the available assignments found were added.");
                                course.CourseAssignments = validAndNotUsedAssignments;
                                continue;
                            }

                            for (int i = 0; i < number; i++)
                            {
                                course.CourseAssignments.Add(validAndNotUsedAssignments[i]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("These are your assignments.\r\nSelect assignments by entering the assignment's number.");
                        int count = 0;
                        foreach (var assign in validAndNotUsedAssignments)
                        {
                            count++;
                            Console.WriteLine($"{count} - {assign}");
                        }
                        Console.WriteLine("");
                        bool addMore = false;
                        do
                        {
                            Console.Write($"\r\nAssignment's number:");
                            bool isValid = false;
                            int assignmentNum;
                            do
                            {
                                isValid = int.TryParse(Console.ReadLine(), out assignmentNum);
                                if (isValid)
                                {
                                    if (assignmentNum <= 0 || assignmentNum > validAndNotUsedAssignments.Count) { isValid = false; }
                                }
                                var doesAssignmentExist = false;
                                if (isValid)
                                {
                                    doesAssignmentExist = course.CourseAssignments.Contains(validAndNotUsedAssignments[assignmentNum - 1]);
                                    if (doesAssignmentExist) { isValid = false; }
                                }
                                if (!isValid)
                                {
                                    if (doesAssignmentExist)
                                    {
                                        Console.WriteLine("This assignment has already been added to this course.");
                                    }
                                    Console.Write($"Please enter a valid number:");
                                }

                            } while (!isValid);

                            course.CourseAssignments.Add(validAndNotUsedAssignments[assignmentNum - 1]);
                            if (validAndNotUsedAssignments.Count == course.CourseAssignments.Count) { Console.WriteLine("You have added all the available assignments to the course."); break; }
                            Console.WriteLine("\nDo you want to add another assignment? Enter Y for yes.\nOtherwise, press any other key.");
                            var answer = Console.ReadLine();
                            if (answer.ToUpper() == "Y") { addMore = true; }
                            else { addMore = false; }
                        }
                        while (addMore);
                    }

                }
            }

        }

        public static void SetAssignmentsPerStudent()
        {
            //clear all previous data in case this option was selected again before
            foreach (var student in Student.Students)
            {
                student.StudentAssignments = new List<Assignment>();
            }

            Console.Clear();
            Console.WriteLine($"\nIf you want assignments to be matched with students automatically for you please enter the letter A.\nOtherwise, press any other key to go on with the data setting.");
            var userInput = Console.ReadLine();
            if (userInput.ToUpper() == "A")
            {
                foreach (var student in Student.Students)
                {
                    student.StudentAssignments = student.GetRandomStudentAssignments();
                }
            }
            else
            {
                foreach (var student in Student.Students)
                {
                    Console.WriteLine($"\nIf you want assignments to be added to the student {student.FirstName} {student.LastName} automatically for you please enter the number of assignments you want to be added " +
                        $"or enter 0 for not adding assignments to this student\nOtherwise just press any other key to add assignments manually.");
                    int number;
                    var isValidNumber = int.TryParse(Console.ReadLine(), out number);
                    if (isValidNumber)
                    {
                        if (number == 0) { continue; }
                        else if (number > 0)
                        {
                            student.StudentAssignments = student.GetRandomStudentAssignments(number);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"According to the courses that student {student.FirstName} {student.LastName} attends, these are the titles of the available assignments per course:");
                        int count = 0;
                        var allAvailableStudentAssignments = student.GetallAvailableAssignments();
                        if (allAvailableStudentAssignments.Count == 0)
                        {
                            Console.WriteLine("There are no available assignments for this student.");
                            continue;
                        }
                        foreach (var assignment in allAvailableStudentAssignments)
                        {
                            count++;
                            Console.WriteLine($"{count} - {assignment.Title}");

                        }
                        Console.WriteLine("\r\n Please select the assignments you want to match with the student by entering the assignment's number");
                        bool addMore = false;
                        do
                        {
                            Console.Write($"\r\nAssignments's number:");
                            bool isValid = false;
                            int assignmentNum;
                            do
                            {
                                isValid = int.TryParse(Console.ReadLine(), out assignmentNum);
                                if (isValid)
                                {
                                    if (assignmentNum < 0 || assignmentNum > allAvailableStudentAssignments.Count) { isValid = false; }
                                }
                                var hasAssignmentAlreadyBeenAdded = false;
                                if (isValid && assignmentNum != 0)
                                {
                                    hasAssignmentAlreadyBeenAdded = student.StudentAssignments.Contains(allAvailableStudentAssignments[assignmentNum - 1]);
                                    if (hasAssignmentAlreadyBeenAdded)
                                    {
                                        Console.WriteLine("This assignment has already been added.");
                                        isValid = false;
                                    }
                                }
                                if (assignmentNum == 0) { break; }
                                if (!isValid)
                                {
                                    Console.Write($"Please enter a valid number:");
                                }

                            } while (!isValid);
                            if (assignmentNum == 0) { break; }
                            if (assignmentNum != 0) { student.StudentAssignments.Add(allAvailableStudentAssignments[assignmentNum - 1]); }
                            if (allAvailableStudentAssignments.Count == student.StudentAssignments.Count) { Console.WriteLine("You have added all the available assignments to the student's assignment list."); break; }
                            Console.WriteLine("\nDo you want to add another assignment? Enter Y for yes.\nOtherwise, press any other key.");
                            var answer = Console.ReadLine();
                            if (answer.ToUpper() == "Y") { addMore = true; }
                            else { addMore = false; }
                        } while (addMore);
                    }

                }
            }

        }

        public static void PrintStudentsWhoNeedToSubmitAssignmentsAtSpecificDate()
        {
            Console.Clear();
            var date = GetFromKeyboard.GetDateFromKeyboard("a date to see the students who need to submit their assignments on the same calendar week");

            var currentCulture = CultureInfo.CurrentCulture;
            var weekNumber = currentCulture.Calendar.GetWeekOfYear(
                date,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);

            bool isAnyAssignment = false;
            foreach (var student in Student.Students)
            {
                foreach (var assignment in student.StudentAssignments)
                {
                    var assignmentWeekNumber = currentCulture.Calendar.GetWeekOfYear(
                        assignment.SubDateTime,
                        CalendarWeekRule.FirstDay,
                        DayOfWeek.Monday);
                    if (assignmentWeekNumber==weekNumber && assignment.SubDateTime.Year==date.Year)
                    {
                        isAnyAssignment = true;
                        Console.WriteLine($"Student {student} has to submit the assignment {assignment.Title} on {assignment.SubDateTime}.");
                    }
                }
            }
            if (!isAnyAssignment) { Console.WriteLine("No student needs to submit assignment on this calendar week."); }

            Console.ReadKey();
        }

    }

}

