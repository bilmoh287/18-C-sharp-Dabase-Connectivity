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

        static bool FindContactByContactID(int ID, ref stContact ContactInfo)
        {
            bool IsFind = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue(ContactID, ID)
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

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
