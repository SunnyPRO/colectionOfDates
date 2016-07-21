using PAD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        static void Main(string[] args)
        {
            {
                while (true)
                {
                    Console.WriteLine("->Read all nodes or only one? (all/one/par): ");
                    string chr = Console.ReadLine();
                    if (chr == "all")
                        allNodes();
                    if (chr == "one")
                    {
                        Console.WriteLine("->Number of node: ");
                        int nr = Convert.ToInt32(Console.ReadLine());
                        singleNode(nr);
                    }
                    if(chr == "par")
                    {
                        Console.WriteLine("->Offset: ");
                        int offset = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("->Limit: ");
                        int limit = Convert.ToInt32(Console.ReadLine());
                        partialNode(offset,limit);
                    }

                }
            }
        }

        static void allNodes()
        {
            List<Employee> listEmployee = new List<Employee>();
            ClientTools tool = new ClientTools();

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8000");
            request.Method = "GET";
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                Console.WriteLine(response.StatusCode + "200 \n"
                                   + response.Method + " " + response.ResponseUri + response.ProtocolVersion
                                   + "\n" + response.Headers + test + "\n\n");

            }

            listEmployee = tool.Deserialize(test);
            listEmployee.ToString();

            
        }

        static void singleNode(int nr)
        {
            List<Employee> listEmployee = new List<Employee>();
            ClientTools tool = new ClientTools();

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8000/?id=" + nr);
            request.Method = "GET";
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                Console.WriteLine( response.StatusCode + "200 \n"
                                   + response.Method + " " + response.ResponseUri + response.ProtocolVersion 
                                   + "\n" + response.Headers + test + "\n\n");
            }

            listEmployee.ToString();
        }

        static void partialNode(int offset,int limit)
        {
            List<Employee> listEmployee = new List<Employee>();
            ClientTools tool = new ClientTools();

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8000/" + "?offset=" + offset
                + "&limit=" + limit);
            request.Method = "GET";
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                Console.WriteLine(response.StatusCode + "200 \n"
                   + response.Method + " " + response.ResponseUri + response.ProtocolVersion
                   + "\n" + response.Headers + test + "\n\n");
            }

            listEmployee = tool.Deserialize(test);
            listEmployee.ToString();
        }
    }
}
