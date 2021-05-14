using IndividualProjPartA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProjPartA.Entities
{
    class Assignment
    {
        public static List<Assignment> Assignments = new List<Assignment>();

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubDateTime { get; set; }
        public float OralMark { get; set; }
        public float TotalMark { get; set; }

        public Assignment(string title, string description, DateTime subDadeTime, float oralMark, float totalMark)
        {
            Title = title;
            Description = description;
            SubDateTime = subDadeTime;
            OralMark = oralMark;
            TotalMark = totalMark;

            Assignments.Add(this);
        }
        public Assignment(DateTime start_date, DateTime end_date)
        {
            Title = RandomFunctions.GenerateRandomString(2, 20);
            Description = RandomFunctions.GenerateRandomString(3, 100);
            SubDateTime = RandomFunctions.GenerateRandomDate(start_date, end_date, true);
            OralMark = RandomFunctions.GenerateRandomFloat(0, 100);
            TotalMark = RandomFunctions.GenerateRandomFloat(OralMark, 100);

            Assignments.Add(this);
        }
        public static List<Assignment> GetRandomAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();

            int amount = RandomFunctions.Rnd.Next(1, Assignments.Count);
            foreach (var assignment in Assignments.OrderBy(x => RandomFunctions.Rnd.Next()).Take(amount))
            {
                assignments.Add(assignment);
            }
            return assignments;
        }
        public static List<Assignment> GetRandomAssignments(int amount)
        {
            List<Assignment> assignments = new List<Assignment>();
            if (amount > Assignments.Count)
            {
                amount = Assignments.Count;
                Console.WriteLine($"There are only {Assignments.Count} available, so all of them will be added to the course.");
            }
            foreach (var assignment in Assignments.OrderBy(x => RandomFunctions.Rnd.Next()).Take(amount))
            {
                assignments.Add(assignment);
            }
            return assignments;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Description: {Description}, Submission date: {SubDateTime.ToString("dd/MM/yyyy")}, Oral mark: {OralMark}, Total mark: {TotalMark}";
        }
    }
}

