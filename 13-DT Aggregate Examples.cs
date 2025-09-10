using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Dabase_Connectivity
{
    internal class Class1
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

            Console.WriteLine("\t Employees List");
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

            int RowCount = 0;
            string Query1 = "Country = 'Jordan'";
            DataRow[] ResultRows;

            ResultRows = dtEmployee.Select(Query1);

            Console.WriteLine("\n\n\t Employees List Only from Jordan");
            foreach (DataRow row in ResultRows)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {4}\t",
                    row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            RowCount = ResultRows.Count();
            TotalSalaries = Convert.ToDouble(dtEmployee.Compute("SUM(Salary)", Query1));
            AvgSalaries = Convert.ToDouble(dtEmployee.Compute("AVG(Salary)", Query1));
            MinSalaries = Convert.ToDouble(dtEmployee.Compute("MIN(Salary)", Query1));
            MaxlSalaries = Convert.ToDouble(dtEmployee.Compute("MAX(Salary)", Query1));

            Console.WriteLine();
            Console.WriteLine("Total Employees = " + RowCount);
            Console.WriteLine("Total Salaries = " + TotalSalaries);
            Console.WriteLine("Average Salary = " + AvgSalaries);
            Console.WriteLine("Minimun Salary = " + MinSalaries);
            Console.WriteLine("Maximum Salary = " + MaxlSalaries);


            string Query2 = "Country = 'Jordan' OR Country = 'Ethiopia'";
            ResultRows = dtEmployee.Select(Query2);

            Console.WriteLine("\n\n\t Employees List Only from Jordan and Ethiopia");
            foreach (DataRow row in ResultRows)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {4}\t",
                    row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            RowCount = ResultRows.Count();
            TotalSalaries = Convert.ToDouble(dtEmployee.Compute("SUM(Salary)", Query2));
            AvgSalaries = Convert.ToDouble(dtEmployee.Compute("AVG(Salary)", Query2));
            MinSalaries = Convert.ToDouble(dtEmployee.Compute("MIN(Salary)", Query2));
            MaxlSalaries = Convert.ToDouble(dtEmployee.Compute("MAX(Salary)", Query2));

            Console.WriteLine();
            Console.WriteLine("Total Employees = " + RowCount);
            Console.WriteLine("Total Salaries = " + TotalSalaries);
            Console.WriteLine("Average Salary = " + AvgSalaries);
            Console.WriteLine("Minimun Salary = " + MinSalaries);
            Console.WriteLine("Maximum Salary = " + MaxlSalaries);

            string Query3 = "ID = 1";
            ResultRows = dtEmployee.Select(Query3);

            Console.WriteLine("\n\n\t Employees List Only ID = 1");
            foreach (DataRow row in ResultRows)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {4}\t",
                    row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            RowCount = ResultRows.Count();
            TotalSalaries = Convert.ToDouble(dtEmployee.Compute("SUM(Salary)", Query3));
            AvgSalaries = Convert.ToDouble(dtEmployee.Compute("AVG(Salary)", Query3));
            MinSalaries = Convert.ToDouble(dtEmployee.Compute("MIN(Salary)", Query3));
            MaxlSalaries = Convert.ToDouble(dtEmployee.Compute("MAX(Salary)", Query3));

            Console.WriteLine();
            Console.WriteLine("Total Employees = " + RowCount);
            Console.WriteLine("Total Salaries = " + TotalSalaries);
            Console.WriteLine("Average Salary = " + AvgSalaries);
            Console.WriteLine("Minimun Salary = " + MinSalaries);
            Console.WriteLine("Maximum Salary = " + MaxlSalaries);

            Console.ReadKey();
        }
    }
}
