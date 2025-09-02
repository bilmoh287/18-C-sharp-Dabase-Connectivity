using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace C__Dabase_Connectivity
{
    internal class Program8
    {
        static string ConnectionString = "Server=localhost\\SQL22;Database=ContactsDB;Trusted_Connection=True;";

        static void UpdateContact(int ContactID, stContact ContactInfo)
        {
            bool IsFind = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"UPDATE [dbo].[Contacts]
                       SET [FirstName] = @FirstName,
                          [LastName] = @LastName,
                          [Email] = @Email,
                          [Phone] = @Phone,
                          [Address] = @Address,
                          [CountryID] = @CountryID
                       WHERE ContactID = @ContactID";


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FirstName", ContactInfo.FirstName);
            command.Parameters.AddWithValue("@LastName", ContactInfo.LastName);
            command.Parameters.AddWithValue("@Email", ContactInfo.Email);
            command.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
            command.Parameters.AddWithValue("@Address", ContactInfo.Address);
            command.Parameters.AddWithValue("@CountryID", ContactInfo.CountryID);
            command.Parameters.AddWithValue("@ContactID", ContactID);


            try
            {
                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    Console.WriteLine("Record Updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to Update the Record!");
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

            contactInfo.FirstName = "Jemila";
            contactInfo.LastName = "Abdellah";
            contactInfo.Email = "Jem@gmail";
            contactInfo.Phone = "09047281";
            contactInfo.Address = "101 AddisAbaba ";
            contactInfo.CountryID = 3;

            UpdateContact(6, contactInfo);

            Console.ReadKey();
        }
    }
}
