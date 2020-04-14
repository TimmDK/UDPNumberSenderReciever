using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPNumberReciever
{
    class UDPNumberRecieverBroad
    {
        static void Main(string[] args)
        {
            //Create UDP client for reading incoming data
            UdpClient udpReciever = new UdpClient(7000);

            //BROADCASTING RECIEVER
            //This EndPoint will allow to read the datagrams sent from any ip-source on port 7000
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 7000);

            //Blocks until a message is recieved on this socket from a remote host 
            Console.WriteLine("Server is blocked");
            try
            {   
                while (true)
                {
                    Byte[] recieveBytes = udpReciever.Receive(ref remoteEndPoint);
                    //The server is now activated

                    string recievedData = Encoding.ASCII.GetString(recieveBytes);

                    Console.WriteLine("Sender: " + recievedData.ToString());
                    Console.WriteLine("This message was sent from " +
                                      remoteEndPoint.Address.ToString() +
                                      " on their port number " +
                                      remoteEndPoint.Port.ToString());
                    Thread.Sleep(1000);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
