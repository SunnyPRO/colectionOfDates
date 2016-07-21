using PAD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace NodT
{
    public class NodTools
    {

        public string Serelize(List<Employee> employee)//Serializarea unei liste de employees
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(employee.GetType());
            string xml = "";
            using (var sw = new StringWriter())
            {
                using (var xw = XmlWriter.Create(sw))
                {
                    x.Serialize(sw, employee);
                }
                xml = sw.ToString();
            }
            return xml;
        }

        public List<Employee> PopulateList(int port)//Se populeaza listele initiale din noduri
        {
            List<Employee> listEmployees = new List<Employee>();

            if (port == 1)
            {

                Employee employe = new Employee();
                employe.firstName = "Ion";
                employe.lastName = "Ostafi";
                employe.departament = "Nodul1";
                employe.salary = 1500;

                listEmployees.Add(employe);
            }

            if (port == 2)
            {

                Employee employe = new Employee();
                employe.firstName = "Alexandru";
                employe.lastName = "Sonic";
                employe.departament = "Nodul2";
                employe.salary = 500;

                listEmployees.Add(employe);
            }
            if (port == 3)
            {

                Employee employe = new Employee();
                employe.firstName = "Adrian";
                employe.lastName = "Cobilas";
                employe.departament = "Nodul3";
                employe.salary = 800;

                listEmployees.Add(employe);

            }
            if (port == 4)
            {
                Employee employe = new Employee();
                employe.firstName = "Gheorghe";
                employe.lastName = "Gavrilas";
                employe.departament = "Nodul4";
                employe.salary = 700;

                listEmployees.Add(employe);
            }
            if (port == 5)
            {
                Employee employe = new Employee();
                employe.firstName = "Marian";
                employe.lastName = "Buga";
                employe.departament = "Nodul5";
                employe.salary = 700;
            }
            if (port == 6)
            {
                Employee employe = new Employee();
                employe.firstName = "Andrei";
                employe.lastName = "Vacaruc";
                employe.departament = "Nodul6";
                employe.salary = 600;
            }

            return listEmployees;
        }
    }
}
