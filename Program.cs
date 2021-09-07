using System;

namespace SqlDataExampleTec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Sql sql = new Sql();
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
