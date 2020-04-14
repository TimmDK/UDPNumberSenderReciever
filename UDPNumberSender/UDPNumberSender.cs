using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPNumberSender
{
    class UDPNumberSender
    {
        static void MainX(string[] args)
        {
            int number = 0;

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            UdpClient udpClient = new UdpClient("127.0.0.1", 9999);

            IPEndPoint remoteEndPoint = new IPEndPoint(ip, 9999);

            Console.Write("What is your name?:");
            string name = Console.ReadLine();

            while (true)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(name + " send the number " + number + " hello");

                udpClient.Send(sendBytes, sendBytes.Length);
                Byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                //Client activated 

                string receivedData = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine(receivedData);
                number++;

                Thread.Sleep(1000);
            }
        }
    }
}
