﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataExampleTec
{
    class Sql
    {
        void Insert()
        {
            // Prepare a proper parameterized query 
            string sql = "insert into Main ([Firt Name], [Last Name]) values(@first,@last)";

            // Create the connection (and be sure to dispose it at the end)
            using (SqlConnection cnn = new SqlConnection(connetionString))
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
                        cmd.Parameters.Add("@first", SqlDbType.NVarChar).Value = textbox2.text;
                        cmd.Parameters.Add("@last", SqlDbType.NVarChar).Value = textbox3.text;

                        // Let's ask the db to execute the query
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Row inserted!!" + );
                        else
                            // Well this should never really happen
                            MessageBox.Show("No row inserted");

                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }

        }
    }


}
