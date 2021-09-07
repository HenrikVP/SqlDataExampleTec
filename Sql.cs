using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataExampleTec
{
    class Sql
    {
        const string connectionString =
            "Data Source =.; " +
            "Initial Catalog = SqlDataDB; " +
            "Integrated Security = True";

        public int? Insert(Person person)
        {
            // Prepare a proper parameterized query 
            string sql = "INSERT INTO person ([name], dob) OUTPUT INSERTED.id VALUES(@name,@dob) ";

            // Create the connection (and be sure to dispose it at the end)
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection to the database. 
                    // This is the first critical step in the process.
                    // If we cannot reach the db then we have connectivity problems
                    cnn.Open();

                    // Prepare the command to be executed on the db
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Create and set the parameters values 
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = person.Name;
                        cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = person.Dob;

                        var id = cmd.ExecuteScalar();
                        return (int?)id;
                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.Message);
                    return null;
                }
            }

        }

        internal List<Person> Select(string search)
        {
            List<Person> personList = new List<Person>();
            string sql = $"SELECT * FROM person WHERE [name] like '%{search}%'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}");
                        personList.Add(new Person()
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Dob = (DateTime)reader[2]
                        });

                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.Message);
                    return null;
                }
            }
            return personList;
        }

        internal List<Person> Select(DateTime dateTime)
        {
            List<Person> personList = new List<Person>();
            string sql = $"SELECT * FROM person WHERE dob = @dob";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = dateTime;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}");
                        personList.Add(new Person()
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Dob = (DateTime)reader[2]
                        });

                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.GetType() +"\n"+ ex.Message);
                    return null;
                }
            }
            return personList;
        }
    }
}
