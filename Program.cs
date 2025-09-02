using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace C__Dabase_Connectivity
{
    internal class Program
    {
        static string ConnectionString = "Server=localhost\\SQL22;Database=ContactsDB;Trusted_Connection=True;";

        static void DeleteContact(string ContactIDs)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"DELETE FROM Contacts
                     WHERE ContactID IN (
                         SELECT value 
                         FROM STRING_SPLIT(@ContactIDs, ',')
                     )";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactIDs", ContactIDs);


            try
            {
                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    Console.WriteLine("Record Deleted successfully.");
                }
                else
                {
                    Console.WriteLine("IDs Not Found");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        
        }

        static void Main(string[] args)
        {

            DeleteContact("13, 14");
           
            Console.ReadKey();
        }
    }
}
