using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPNumberSender
{
    class UDPNumberSenderBroad
    {
        static void Main(string[] args)
        {
            int number = 0;

            //makes remote endpoint broadcast. Must have UdpCliet(0) to do so.
            UdpClient udpServer = new UdpClient(0);
            udpServer.EnableBroadcast = true;
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, 7000);

            Console.Write("Press any key to start broadcast");
            string name = Console.ReadLine();

            while (true)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(name + " send the number " + number + " hello");
                try
                {
                    udpServer.Send(sendBytes, sendBytes.Length, remoteEndPoint);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                number++;
                Console.WriteLine(" " + number);
                
                Thread.Sleep(1000);
            }
        }
    }
}
