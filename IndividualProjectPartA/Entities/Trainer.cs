using IndividualProjPartA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjPartA.Entities
{
    class Trainer
    {
        public static List<Trainer> Trainers = new List<Trainer>();

        public List<Course> TrainerCourses = new List<Course>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Trainer(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;

            Trainers.Add(this);
        }
        public Trainer()
        {
            FirstName = RandomFunctions.GenerateRandomString(3, 15);
            LastName = RandomFunctions.GenerateRandomString(3, 30);
            Subject = RandomFunctions.GenerateRandomString(2, 30);

            Trainers.Add(this);
        }
        public Trainer(string firstName)
        {
            FirstName = firstName;
        }
        public static List<Trainer> GetRandomTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();

            int amount = RandomFunctions.Rnd.Next(1, Trainers.Count);
            foreach (var trainer in Trainers.OrderBy(x => RandomFunctions.Rnd.Next()).Take(amount))
            {
                trainers.Add(trainer);
            }
            return trainers;
        }
        public static List<Trainer> GetRandomTrainers(int amount)
        {
            List<Trainer> trainers = new List<Trainer>();
            if (amount > Trainers.Count)
            {
                amount = Trainers.Count;
                Console.WriteLine($"There are only {Trainers.Count} available, so all of them will be added to the course.");
            }
            foreach (var trainer in Trainers.OrderBy(x => RandomFunctions.Rnd.Next()).Take(amount))
            {
                trainers.Add(trainer);
            }
            return trainers;
        }
        public override string ToString()
        {
            return $"First name: {FirstName}, Last name: {LastName}, Subject: {Subject}";
        }
    }
}
