using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPEchoServerValuta
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("192.168.191.33");
            // opsætning af tcplistener på port 7777
            TcpListener serverSocket = new TcpListener(ip, 7777);
            // starter at lytte til klient anmodninger
            serverSocket.Start();
            //Socket connectionSocket = serverSocket.AcceptSocket();
            Console.WriteLine("Server activated");

            do
            {
                Task.Run(() =>
                {
                    //Venter på connection før den aktiverer
                    TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine("Server activated & Connected");
                    //kalder metoden DoClient
                    DoClient(connectionSocket);

                });

            } while (true);
        }

        public static void DoClient(TcpClient socket)
        {
            Stream ns = socket.GetStream();
            // Stream ns = new NetworkStream(connectionSocket);
            // aflæse 
            StreamReader sr = new StreamReader(ns);
            // skrive
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {
                Console.WriteLine("Client: " + message);

                string[] array = message.Split(" ");
                if (array[0] == "D")
                {
                    answer = "Dansk krone til Svensk krone konvertering: " + Valuta2.ValutaCalc.TilSvenskeKroner(double.Parse(array[1]));
                }

                else if (array[0] == "S")
                {
                    answer = answer = "Svensk krone til Dansk krone konvertering: " + Valuta2.ValutaCalc.TilDanskeKroner(double.Parse(array[1]));
                }
                else
                {
                    // Den sender metoden tilbage
                    answer = "For Dansk Krone konvertering start with 'D', And for Svensk Krone kovertering start with 'S'";
                }
                sw.WriteLine(answer);
                message = sr.ReadLine();

            }

            ns.Close();
            socket.Close();
        }
    }
}
