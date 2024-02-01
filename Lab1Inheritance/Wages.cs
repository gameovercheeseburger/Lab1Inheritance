using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Inheritance
{
    class Wage : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public Wage() { }

        public Wage(string id, string name, long sin, double hourlyRate, double hoursWorked) : base(id, name, sin)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return base.ToString() + $", Hourly Rate={HourlyRate}, Hours Worked={HoursWorked}";
        }
    }
}
