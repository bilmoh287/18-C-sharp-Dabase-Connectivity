using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace C__Dabase_Connectivity
{
    internal class Program5
    {
        static string ConnectionString = "Server=localhost\\SQL22;Database=ContactsDB;Trusted_Connection=True;";

        static bool FindContactByContactID(int ID, ref stContact ContactInfo)
        {
            bool IsFind = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFind = true;

                    ContactInfo.ID = (int)reader["ContactID"];
                    ContactInfo.FirstName = (string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryID = (int)reader["CountryID"];
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return IsFind;
        }

        public struct stContact
        {
            public int ID { set; get; }
            public string FirstName { set; get; }
            public string LastName { set; get; }
            public string Email { set; get; }
            public string Phone { set; get; }
            public string Address { set; get; }
            public int CountryID { set; get; }

        }

        static void main(string[] args)
        {
            stContact contactInfo = new stContact();

            if (FindContactByContactID(11, ref contactInfo))
            {
                Console.WriteLine(contactInfo.ID);
                Console.WriteLine(contactInfo.FirstName);
                Console.WriteLine(contactInfo.LastName);
                Console.WriteLine(contactInfo.Email);
                Console.WriteLine(contactInfo.Phone);
                Console.WriteLine(contactInfo.Address);
                Console.WriteLine(contactInfo.CountryID);
            }
            else
            {
                Console.WriteLine("Contact Not FOund :-(");
            }

            Console.ReadKey();
        }
    }
}
