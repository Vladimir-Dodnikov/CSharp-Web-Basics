using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpDemo_Client_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string newLine = "\r\n";

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                using NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[100000];
                int lenght = stream.Read(buffer, 0, buffer.Length);

                string requestString = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

                Console.WriteLine(requestString);


                string  html  = $"<h1>Welcome to Custom Server {DateTime.Now}</h1>" +
                        $"<form action=/tweet method=post><input name=username /><input name=password />" +
                        $"<input type=submit /></form>";


                string response = "HTTP/1.1 200 OK" + newLine +
                        "Server: CustomServer 2020" + newLine +
                        // "Location: https://www.google.com" + newLine +
                        "Content-Type: text/html; charset=utf-8" + newLine +
                        // "Content-Disposition: attachment; filename=vlado.txt" + newLine +
                        "Content-Lenght: " + html.Length + newLine +
                        newLine +
                        html + newLine;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes);

                Console.WriteLine(new string('=', 25));
            }
        }

        public static async Task ReadData()
        {
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            // var html = await httpClient.GetStringAsync(url);
            // Console.WriteLine(html);
        }
    }
}
