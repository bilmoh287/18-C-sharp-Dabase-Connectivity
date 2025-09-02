using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace C__Dabase_Connectivity
{
    internal class Program4
    {
        static string ConnectionString = "Server=localhost\\SQL22;Database=ContactsDB;Trusted_Connection=True;";

        static string GetFirstName(int ID)
        {
            string FirstName = "";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = "SELECT FirstName FROM Contacts WHERE ContactID = @ContactID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("ContactID", ID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    FirstName = result.ToString();
                }
                else
                {
                    FirstName = "";
                }

                connection.Close();
            }

            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return FirstName;

        }

        static void main(string[] args)
        {
            Console.WriteLine(GetFirstName(1));
            Console.ReadKey();
        }
    }
}
