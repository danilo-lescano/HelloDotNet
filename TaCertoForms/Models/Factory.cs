using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using TaCertoForms.Models;

namespace TaCertoForms.Models{
    public class Factory{
        private string query;
        protected string Query{
            set{
                query = value;
            }
        }

        protected List<Object> QueryExecute(){
            //Execute the Query statement
            return new List<Object>();
        }

        private void teste(){
            string connectionString = "x";
            //
            // In a using statement, acquire the SqlConnection as a resource.
            //
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //
                // Open the SqlConnection.
                //
                con.Open();
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand("SELECT TOP 2 * FROM Dogs1", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                            reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }
            }
        }
    }
}