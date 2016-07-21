using PAD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Client
{
    public class ClientTools
    {

        public List<Employee> Deserialize(string value)//Dezserializarea unei liste de employees
        {
            List<Employee> obiect = new List<Employee>();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(obiect.GetType());
            using (TextReader reader = new StringReader(value))
            {
                obiect = (List<Employee>)x.Deserialize(reader);
            }

            return obiect;
        }

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
            return listEmployees;
        }
    }
}
