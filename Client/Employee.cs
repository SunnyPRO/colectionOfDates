using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAD
{
    [Serializable()]
    public class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string departament { get; set; }
        public int salary { get; set; }

        public override String ToString()
        {
            return "Employee{" +
                    "firstName='" + firstName + '\'' +
                    ", lastName='" + lastName + '\'' +
                    ", department='" + departament + '\'' +
                    ", salary=" + salary +
                    '}';
        }
    }
}
