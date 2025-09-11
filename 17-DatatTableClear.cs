.using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Dabase_Connectivity
{
    internal class DataTableClear
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
            dtEmployee.Rows.Add(4, "Aliya", "Jordan", 2900, DateTime.Now);
            dtEmployee.Rows.Add(5, "Kalid", "Yemen", 1500, DateTime.Now);

            int EmployeeCount = 0;
            double TotalSalaries = 0;
            double AvgSalaries = 0;
            double MinSalaries = 0;
            double MaxlSalaries = 0;

            EmployeeCount = dtEmployee.Rows.Count;
            TotalSalaries = Convert.ToDouble(dtEmployee.Compute("SUM(Salary)", string.Empty));
            AvgSalaries = Convert.ToDouble(dtEmployee.Compute("AVG(Salary)", string.Empty));
            MinSalaries = Convert.ToDouble(dtEmployee.Compute("MIN(Salary)", string.Empty));
            MaxlSalaries = Convert.ToDouble(dtEmployee.Compute("MAX(Salary)", string.Empty));

            Console.WriteLine("\n\t Employees List\n");
            foreach (DataRow row in dtEmployee.Rows)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {4}\t",
                    row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            Console.WriteLine();
            Console.WriteLine("Total Employees = " + EmployeeCount);
            Console.WriteLine("Total Salaries = " + TotalSalaries);
            Console.WriteLine("Average Salary = " + AvgSalaries);
            Console.WriteLine("Minimun Salary = " + MinSalaries);
            Console.WriteLine("Maximum Salary = " + MaxlSalaries);

            //Clearing DataTable
            dtEmployee.Clear();

            //To Make changes made in DataTable also in DB
            //dtEmployee.AcceptChanges();

            Console.WriteLine("\n\t Employees List after Clearing DataTable");
            foreach (DataRow row in dtEmployee.Rows)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {4}\t",
                    row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);

            }

            Console.WriteLine("Empty");

            Console.ReadKey();
        }
    }
}
