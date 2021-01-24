using GenericsConsole.Models;
using GenericsConsole.WithGenerics;
using GenericsConsole.WithoutGenerics;
using System;
using System.Collections.Generic;

namespace GenericsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DemonstrateTextFileStorage();

            Console.WriteLine("Hello World!");
        }

        private static void DemonstrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = @"C:\Users\Dan\Projects\general-practice-dotnet\GeneralPractice\GenericsFiles\people.csv";
            string logFile = @"C:\Users\Dan\Projects\general-practice-dotnet\GeneralPractice\GenericsFiles\logs.csv";

            PopulateLists(people, logs);

            /* New way of doing things - with generics */

            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);
            foreach (var p in newPeople)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} (IsAlive = {p.IsAlive})");
            }

            var newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);
            foreach (var log in newLogs)
            {
                Console.WriteLine($"{log.ErrorCode}: {log.Message} at {log.TimeOfEvent.ToShortTimeString()}");
            }


            /* Old way of doing things - non-generics */

            //OriginalTextFileProcessor.SaveLogs(logs, logFile);
            //var newLogs = OriginalTextFileProcessor.LoadLogs(logFile);
            //foreach (var log in newLogs)
            //{
            //    Console.WriteLine($"{log.ErrorCode}: {log.Message} at {log.TimeOfEvent.ToShortTimeString()}");
            //}

            //OriginalTextFileProcessor.SavePeople(people, peopleFile);
            //var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);
            //foreach (var p in newPeople)
            //{
            //    Console.WriteLine($"{p.FirstName} {p.LastName} (IsAlive = {p.IsAlive})");
            //}
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm", IsAlive = false });
            people.Add(new Person { FirstName = "John", LastName = "Smith" });

            logs.Add(new LogEntry { Message = "Something happened", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "Awesome", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "Something else", ErrorCode = 2222 });
        }
    }
}
