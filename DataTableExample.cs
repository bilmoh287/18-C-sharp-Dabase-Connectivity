using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Dabase_Connectivity
{
    internal class DataTableExample
    {
        static void main(string[] args)
        {
            DataTable dtEmployee = new DataTable();
            dtEmployee.TableName = "EmployeesDataTable";

            dtEmployee.Columns.Add("ID", typeof(int));
            dtEmployee.Columns.Add("Name", typeof(string));
            dtEmployee.Columns.Add("Country", typeof(string));
            dtEmployee.Columns.Add("Salary", typeof(Double));
            dtEmployee.Columns.Add("Date", typeof(DateTime));

            dtEmployee.Rows.Add(1, "Bilal", "Ethiopia", 500, DateTime.Now);
            dtEmployee.Rows.Add(2, "Mohammed", "Jordan", 17000, DateTime.Now);
            dtEmployee.Rows.Add(3, "Jones", "United Statates", 1300, DateTime.Now);
            dtEmployee.Rows.Add(4, "Aliya", "Egypt", 2900, DateTime.Now);
            dtEmployee.Rows.Add(5, "Kalid", "Yemen", 1500, DateTime.Now);

            foreach (DataRow row in dtEmployee.Rows)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {0}\t",
                    row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            Console.ReadKey();
        }
    }
}
