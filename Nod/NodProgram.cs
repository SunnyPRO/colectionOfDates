using PAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodT;

namespace Nod
{
    class NodProgram
    {
        static void Main(string[] args)
        {
            {
                NodTools tool = new NodTools();
                Employee employee = new Employee();

                while (true)
                {
                    Console.WriteLine("Introduceti numarul nodului: ");//Cerem numarul nodului
                    int nr = Convert.ToInt32(Console.ReadLine());//Citim nr nodului

                    List<Employee> listEmployee = new List<Employee>();
                    listEmployee = tool.PopulateList(nr);//Se populeaza lista in dependenta de ce nod santem


                    var str = tool.Serelize(listEmployee); //Trimitem lista noastra prin PUT la dataWereHouse


                    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(str);
                    Uri uri = new Uri("http://localhost:8000");

                    using (var client = new System.Net.WebClient())
                        {
                            client.UploadDataAsync(uri, "PUT", bytes);
                        }

                }
            }
        }
    }
}


