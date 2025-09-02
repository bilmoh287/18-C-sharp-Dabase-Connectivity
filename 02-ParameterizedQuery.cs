using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace C__Dabase_Connectivity
{
    internal class Program2
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

                while (reader.Read())
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

        static void PrintAllConatcsWithFirstName(string Firstname)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName = @FirstName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", Firstname);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
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

        static void PrintAllConatcsWithFirstNameAndCountryID(string Firstname, int CountryId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName = @FirstName AND CountryID = @CountryID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", Firstname);
            command.Parameters.AddWithValue("@CountryID", CountryId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
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

        static void main(string[] args)
        {
            //PrintContact();
            //PrintAllConatcsWithFirstName("Jane");
            PrintAllConatcsWithFirstNameAndCountryID("Jane", 1);
            Console.ReadKey();
        }
    }
}
