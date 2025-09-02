using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace C__Dabase_Connectivity
{
    internal class Program3
    {
        static string ConnectionString = "Server=localhost\\SQL22;Database=ContactsDB;Trusted_Connection=True;";

        static void PrintAllNamesStartWith(string StartWith)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE @StartWith + '%'";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@StartWith", StartWith);

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

        static void PrintAllNamesEndtWith(string EndWith)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @EndtWith ";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@EndtWith", EndWith);

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

        static void PrintAllNamesThatContains(string Contsins)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @Contains + '%'";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Contains", Contsins);

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
            Console.WriteLine("----------Start With 'J' \n");
            PrintAllNamesStartWith("Jo");

            Console.WriteLine("----------End With 'Jh' \n");
            PrintAllNamesEndtWith("n");

            Console.WriteLine("----------Print All that conatins 'ae' \n");
            PrintAllNamesThatContains("ae");
        }
    }
}
