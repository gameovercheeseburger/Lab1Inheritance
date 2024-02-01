using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Inheritance
{
    class Salaried : Employee
    {
        public double Salary { get; set; }

        public Salaried() { }

        public Salaried(string id, string name, long sin, double salary) : base(id, name, sin)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $", Salary={Salary}";
        }
    }
}
