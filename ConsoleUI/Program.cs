using ConsoleUI.Models;
using ConsoleUI.WithGenerics;
using ConsoleUI.WithoutGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> ages = new List<int>();

            //ages.Add(23);

            Console.ReadLine();

            DemonstrateTextFileStorage();

            Console.WriteLine( );
            Console.WriteLine("Press enter to shut down");
            Console.ReadLine();
        }

        private static void DemonstrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();
            string peopleFile = @"D:\temp\people.csv";
            string logFile = @"D:\temp\logs.csv";

            PopulateLists(people, logs);

            GenericTextFileEditor.SaveToTextFile<Person>(people,peopleFile);

            GenericTextFileEditor.SaveToTextFile(logs,logFile);


            var newPeople = GenericTextFileEditor.LoadFromTextFile<Person>(peopleFile);

            foreach (var p in newPeople)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} (IsAlive = {p.IsAlive})");
            }

            var newLogs = GenericTextFileEditor.LoadFromTextFile<LogEntry>(logFile);

            foreach (var log in newLogs)
            {
                Console.WriteLine($"{log.ErrorCode} {log.Message} at {log.TimeOfEvent.ToShortDateString()}");
            }


            //====================================================================//

            //Non-Generics

            //OriginalTextFileProcessor.SaveLogs(logs, logFile);

            //var newLogs = OriginalTextFileProcessor.LoadLogs(logFile);

            //foreach (var log in newLogs)
            //{
            //    Console.WriteLine($"{log.ErrorCode} {log.Message} at {log.TimeOfEvent.ToShortDateString()}");
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
            people.Add(new Person { FirstName = "Tim", LastName = "Barton" });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm" });
            people.Add(new Person { FirstName = "Greg", LastName = "Olsen" });

            logs.Add(new LogEntry { Message = "All good", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "I am too awesome", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "I was tired", ErrorCode = 2222 });
        }
    }
}
