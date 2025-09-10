using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace C__Dabase_Connectivity
{
    internal class Program9
    {
        static string ConnectionString = "Server=localhost\\SQL22;Database=ContactsDB;Trusted_Connection=True;";

        static void DeleteContact(int ContactID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"Delete Contacts Where ContactName = @ContactID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue(@"ContactID", ContactID);

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
                    Console.WriteLine("Failed to Delete the Record!");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        static void ain(string[] args)
        {

            DeleteContact(9);

            Console.ReadKey();
        }
    }
}
