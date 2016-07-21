using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace ColectiiDistribuite
{
    [XmlRoot(ElementName = "Employee")]
    public class Employee {
        [XmlElement(ElementName = "FirstName")]
        public String FirstName{ get; set; }
        [XmlElement(ElementName = "LastName")]
        public String LastName{ get; set; }
        [XmlElement(ElementName = "Department")]
        public String Department{ get; set; }
        [XmlElement(ElementName = "Salary")]
        public Double Salary { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }

        public Employee(String firstName, String lastName, String departament, Double salary) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Department = departament;
            this.Salary = salary;
        }

        public Employee() {
        }
    
        public override String ToString() {
            return "Employee{" +
                    "firstName='" + FirstName + '\'' +
                    ", lastName='" + LastName + '\'' +
                    ", department='" + Department + '\'' +
                    ", salary=" + Salary +
                    '}';
        }

        public static string Deserialize<T>(T value)
        {
            Console.WriteLine(" ================= \n");
            Console.WriteLine("-> ModelClass : " + value);
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();

            string message;
            MemoryStream stream = new MemoryStream();
            
                xmlserializer.Serialize(stream, value);
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                message = sr.ReadToEnd();
            Console.WriteLine("-> XML : " + message);
            if (xmlserializer.CanDeserialize(new XmlTextReader(new StringReader(message))))
                    Console.WriteLine("-> XMLSchema: Is Valid");
                else Console.WriteLine("-> XMLSchema: Is Not valid");
                return message;
            
        }
    }

    public class Employees
    {

        public List<Employee> data { get; set; }
    }



}
