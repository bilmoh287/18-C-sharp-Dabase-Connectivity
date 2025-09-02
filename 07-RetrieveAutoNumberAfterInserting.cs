using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace C__Dabase_Connectivity
{
    internal class Program7
    {
        static string ConnectionString = "Server=localhost\\SQL22;Database=ContactsDB;Trusted_Connection=True;";

        static void InserIntoDatabaseAndGetID(stContact ContactInfo)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"
                            INSERT INTO [dbo].[Contacts]
                                ([FirstName], [LastName], [Email], [Phone], [Address], [CountryID])
                            VALUES
                                (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
                                SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", ContactInfo.FirstName);
            command.Parameters.AddWithValue("@LastName", ContactInfo.LastName);
            command.Parameters.AddWithValue("@Email", ContactInfo.Email);
            command.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
            command.Parameters.AddWithValue("@Address", ContactInfo.Address);
            command.Parameters.AddWithValue("@CountryID", ContactInfo.CountryID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    Console.WriteLine($"Newly Inserted ID : {InsertedID}");
                }
                else
                {
                    Console.WriteLine("Record Insertion Failed!");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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

            contactInfo.FirstName = "Bilal";
            contactInfo.LastName = "Mohammed";
            contactInfo.Email = "bilmoh@gmail";
            contactInfo.Phone = "0922221";
            contactInfo.Address = "101 AddisAbaba ";
            contactInfo.CountryID = 3;

            InserIntoDatabaseAndGetID(contactInfo);

            Console.ReadKey();
        }
    }
}
