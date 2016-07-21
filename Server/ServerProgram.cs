using PAD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Server;
using System.Web;

namespace Lab5Pad
{
    class Program
    { 

        static void Main(string[] args)
        {

            List<Employee> listEmployeeAux = new List<Employee>();

            List<Employee> listEmployee = new List<Employee>();

            string url = "http://localhost";
            string port = "8000";
            string prefix = String.Format("{0}:{1}/", url, port);

            ServerTools tool = new ServerTools();

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(prefix);

            listener.Start();

            Console.WriteLine("Listening: {0}", prefix);


            while (true)
            {
                //Ожидание входящего запроса
                HttpListenerContext context = listener.GetContext();

                //Объект запроса
                HttpListenerRequest request = context.Request;

                //Объект ответа
                HttpListenerResponse response = context.Response;

                //Создаем ответ
                string requestBody;
                Stream inputStream = request.InputStream;
                Encoding encoding = request.ContentEncoding;
                StreamReader reader = new StreamReader(inputStream, encoding);
                requestBody = reader.ReadToEnd();

                if (request.HttpMethod.ToString().Equals("PUT"))
                {
                    listEmployeeAux = tool.Deserialize(requestBody);//Deserializam lista primita
                    listEmployee.AddRange(listEmployeeAux); //Adaugam ce primim la lista finala

                    Console.WriteLine("->There is {0} request: \n{1}" + requestBody,
                        request.HttpMethod, request.Headers);

                    foreach (var item in listEmployeeAux)
                    {
                        Console.Write("\n" + item.firstName + "\n");
                        Console.Write(item.lastName + "\n");
                        Console.Write(item.departament + "\n");
                        Console.Write(item.salary + "\n\n");

                    }
                }


                if (request.HttpMethod.ToString().Equals("GET"))
                {
                    string id = "";
                    string offset = "";
                    string limit = "";
                    Employee employee;

                    id = HttpUtility.ParseQueryString(request.Url.Query).Get("id");//scoate parametrul ID , daca este
                    offset = HttpUtility.ParseQueryString(request.Url.Query).Get("offset");//scoate parametrul offset , daca este
                    limit = HttpUtility.ParseQueryString(request.Url.Query).Get("limit");//scoate parametrul limit , daca este

                    if ((id == null || id == "") && (offset == null || offset == "") && (limit == null || limit == ""))//Daca se cere toata lista
                    {
                        response.StatusCode = (int)HttpStatusCode.OK;
                        var str = tool.Serelize(listEmployee);
                        response.AddHeader("Content-Type", "text/xml");
                        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(str);

                        //Возвращаем ответ
                        using (Stream stream = response.OutputStream)
                        {
                            stream.Write(bytes, 0, bytes.Length);
                        }
                        Console.WriteLine("->There is {0} request: \n{1}" + requestBody,
                                          request.HttpMethod, request.Headers);
                    }

                    if ((id != "") && (offset == null || offset == "") && (limit == null || limit == ""))//Daca se cere numai un singur Employee
                    {
                        decimal value;
                        if (Decimal.TryParse(id, out value))
                        {
                            employee = listEmployee.ElementAt(Convert.ToInt32(id));
                            List<Employee> listEmployeeFinal = new List<Employee>();
                            listEmployeeFinal.Add(employee);

                            response.StatusCode = (int)HttpStatusCode.OK;
                            var str = tool.Serelize(listEmployeeFinal);
                            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(str);

                            //Возвращаем ответ
                            using (Stream stream = response.OutputStream)
                            {
                                stream.Write(bytes, 0, bytes.Length);
                            }

                            Console.WriteLine("->There is {0} request: \nURI:{1} " + requestBody,
                                                request.HttpMethod, request.Url);
                        }
                    }

                    if ((id == "" || id == null) && (offset != "") && (limit != ""))//Daca se cere un interval
                    {
                        decimal value;
                        if (Decimal.TryParse(offset, out value))
                        {
                            Console.Write("Offset = " + offset + " , Limit = " + limit + "\n");
                            List<Employee> finalList = new List<Employee>();

                            for (int i = Convert.ToInt32(offset); i < Convert.ToInt32(limit) + Convert.ToInt32(offset); i++)
                            {
                                finalList.Add(listEmployee.ElementAt(i));
                            }

                            response.StatusCode = (int)HttpStatusCode.OK;
                            var str = tool.Serelize(finalList);
                            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(str);

                            //Возвращаем ответ
                            using (Stream stream = response.OutputStream)
                            {
                                stream.Write(bytes, 0, bytes.Length);
                            }

                            Console.WriteLine("->There is {0} request: \n{1} " + requestBody,
                                               request.HttpMethod, request.Headers);
                        }
                    }
                }
            }
        }
    }
}
