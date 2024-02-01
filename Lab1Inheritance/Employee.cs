using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Inheritance
{
    class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long Sin { get; set; }

        public Employee() { }

        public Employee(string id, string name, long sin)
        {
            Id = id;
            Name = name;
            Sin = sin;
        }

        public override string ToString()
        {
            return $"Employee: ID={Id}, Name={Name}, SIN={Sin}";
        }
    }
}
