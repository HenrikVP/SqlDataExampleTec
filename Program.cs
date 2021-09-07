using System;
using System.Collections.Generic;

namespace SqlDataExampleTec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Sql sql = new Sql();
            //InsertMethod(sql);
            Console.Write("Search for:");
            string search = Console.ReadLine();
            //List<Person> persons = sql.Select(search);
            List<Person> persons = sql.Select(new DateTime(1809, 2, 12));

            if (persons != null && persons.Count > 0)
            foreach (var person in persons)
            {
                Console.WriteLine(person.Name);
            }
            else Console.WriteLine("Nothing found.");

        }

        private static void InsertMethod(Sql sql)
        {
            Person person = new Person();
            person.Name = "Abraham Lincoln";
            person.Dob = new DateTime(1809, 2, 12);
            int? id = sql.Insert(person);
            if (id != null)
                Console.WriteLine($"{person.Name} (born {person.Dob}) have gotten id : {id}");
            else Console.WriteLine("Something went horribly wrong!");
        }
    }
}
