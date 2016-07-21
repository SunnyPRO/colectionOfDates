using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discovery;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace ColectiiDistribuite
{
    class ClientProgram
    {
 
        static void Main(string[] args)
        {
            UdpSimple server = new UdpSimple();
            Thread.Sleep(1000);
            server.Start();
            string message = "-> Get connection number";
            server.Send(message);
            Console.WriteLine("-> Request sent");
            server.Stop();
            BrokerService broker = new BrokerService(32321);
            Task t = Task.Factory.StartNew(async () =>
            {
                int time = 6;
                while (time > 0)
                {
                    message = await broker.AsyncRead();
                    Console.WriteLine("-> Received: " + message);
                    time--;
                }
                Thread.Sleep(150);
                string m = "get data";
                broker.Protocol = "tcp";
                await broker.AsyncWrite(m);
                string rawData = await broker.AsyncRead();
                List<Employee> employees = JsonParser.ParseString(rawData);

                Console.WriteLine("-> Starting to validate XML");
                string xmlMessage = "";
                employees.ForEach(x => 
                {
                    xmlMessage = Employee.Deserialize(x);
                });
                Console.WriteLine("\n-> Order list by salary");

                employees = employees.OrderBy(x => x.Salary).ToList();
                employees.ForEach(x=>Console.WriteLine(x));
            });
            t.Wait();
            Console.ReadKey();

        }

    }
}
