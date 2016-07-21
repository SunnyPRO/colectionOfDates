using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDistribuite
{
    class JsonParser
    {
        public static List<Employee> ParseString(string data)
        {
            string collection = data.Replace("][", ",");
            List<Employee> employees=new List<Employee>();
            employees.AddRange(JsonConvert.DeserializeObject<List<Employee>>(collection));
            return employees;
        }
    }
}
