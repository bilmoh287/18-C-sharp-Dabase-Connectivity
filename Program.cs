using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

namespace C__Dabase_Connectivity
{
    internal class Program
    {
        static string ConnectionString = "Server=localhost\\SQL22;Database=ContactsDB;Trusted_Connection=True;";

        static void PrintContact()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "SELECT * FROM Contacts";

            SqlCommand command = new SqlCommand(query, connection); 

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {

                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LasttName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];

                    Console.WriteLine($"ContactID :  {ContactID}");
                    Console.WriteLine($"FirstName :  {FirstName}");
                    Console.WriteLine($"LastName  :  {LasttName}");
                    Console.WriteLine($"Email     :  {Email}");
                    Console.WriteLine($"Phone     :  {Phone}");
                    Console.WriteLine($"Address   :  {Address}");
                    Console.WriteLine($"CountryID :  {CountryID}");
                    Console.WriteLine();

                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void Main(string[] args)
        {
            PrintContact();
            Console.ReadKey();
        }
    }
}
