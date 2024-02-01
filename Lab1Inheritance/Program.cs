using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = ReadEmployeesFromFile("C:\\Users\\pjurg\\source\\repos\\Lab1Inheritance\\Lab1Inheritance\\employees.txt");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine($"Average weekly pay for all employees: {CalculateAverageWeeklyPay(employees):C}");
            Console.WriteLine($"Highest weekly pay for wage employees: {GetHighestWeeklyPayForWageEmployee(employees):C}");
            Console.WriteLine($"Lowest salary for salaried employees: {GetLowestSalaryForSalariedEmployee(employees):C}");
            DisplayEmployeePercentageByCategory(employees);
        }

        static List<Employee> ReadEmployeesFromFile(string filename)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        string id = data[0];
                        string name = data[1];
                        long sin = long.Parse(data[2]);
                        if (id.StartsWith("0") || id.StartsWith("1") || id.StartsWith("2") || id.StartsWith("3") || id.StartsWith("4"))
                        {
                            double salary = double.Parse(data[3]);
                            employees.Add(new Salaried(id, name, sin, salary));
                        }
                        else if (id.StartsWith("5") || id.StartsWith("6") || id.StartsWith("7"))
                        {
                            double hourlyRate = double.Parse(data[3]);
                            double hoursWorked = double.Parse(data[4]);
                            employees.Add(new Wage(id, name, sin, hourlyRate, hoursWorked));
                        }
                        else if (id.StartsWith("8") || id.StartsWith("9"))
                        {
                            double hourlyRate = double.Parse(data[3]);
                            double hoursWorked = double.Parse(data[4]);
                            employees.Add(new PartTime(id, name, sin, hourlyRate, hoursWorked));
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return employees;
        }

        static double CalculateAverageWeeklyPay(List<Employee> employees)
        {
            double totalPay = 0;
            foreach (var emp in employees)
            {
                if (emp is Salaried)
                {
                    totalPay += ((Salaried)emp).Salary;
                }
                else if (emp is Wage)
                {
                    Wage wageEmp = (Wage)emp;
                    totalPay += wageEmp.HourlyRate * Math.Min(wageEmp.HoursWorked, 40)
                                + wageEmp.HourlyRate * Math.Max(0, wageEmp.HoursWorked - 40) * 1.5;
                }
                else if (emp is PartTime)
                {
                    PartTime partTimeEmp = (PartTime)emp;
                    totalPay += partTimeEmp.HourlyRate * partTimeEmp.HoursWorked;
                }
            }
            return totalPay / employees.Count;
        }

        static double GetHighestWeeklyPayForWageEmployee(List<Employee> employees)
        {
            double highestPay = 0;
            string employeeName = "";
            foreach (var emp in employees)
            {
                if (emp is Wage)
                {
                    Wage wageEmp = (Wage)emp;
                    double weeklyPay = wageEmp.HourlyRate * Math.Min(wageEmp.HoursWorked, 40)
                                        + wageEmp.HourlyRate * Math.Max(0, wageEmp.HoursWorked - 40) * 1.5;
                    if (weeklyPay > highestPay)
                    {
                        highestPay = weeklyPay;
                        employeeName = emp.Name;
                    }
                }
            }
            Console.WriteLine($"Employee with highest weekly pay: {employeeName}");
            return highestPay;
        }

        static double GetLowestSalaryForSalariedEmployee(List<Employee> employees)
        {
            double lowestSalary = double.MaxValue;
            string employeeName = "";
            foreach (var emp in employees)
            {
                if (emp is Salaried)
                {
                    Salaried salariedEmp = (Salaried)emp;
                    if (salariedEmp.Salary < lowestSalary)
                    {
                        lowestSalary = salariedEmp.Salary;
                        employeeName = emp.Name;
                    }
                }
            }
            Console.WriteLine($"Employee with lowest salary: {employeeName}");
            return lowestSalary;
        }

        static void DisplayEmployeePercentageByCategory(List<Employee> employees)
        {
            int totalEmployees = employees.Count;
            int salariedCount = 0;
            int wageCount = 0;
            int partTimeCount = 0;
            foreach (var emp in employees)
            {
                if (emp is Salaried)
                {
                    salariedCount++;
                }
                else if (emp is Wage)
                {
                    wageCount++;
                }
                else if (emp is PartTime)
                {
                    partTimeCount++;
                }
            }
            Console.WriteLine($"Percentage of salaried employees: {(double)salariedCount / totalEmployees * 100}%");
            Console.WriteLine($"Percentage of wage employees: {(double)wageCount / totalEmployees * 100}%");
            Console.WriteLine($"Percentage of part-time employees: {(double)partTimeCount / totalEmployees * 100}%");
        }
    }
}




