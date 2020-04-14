using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPNumberReciever
{
    class UDPNumberReciever
    {
        static void MainX(string[] args)
        {
            //Create UDP client for reading incoming data
            UdpClient udpReciever = new UdpClient(9999);

            //Creates an IPEndPoint to record the ip adress and port number of the sender
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteIpEndPoint = new IPEndPoint(ip, 9999);
            //endpoint allows us to read datagrams sent from another source

            try
            {
                //Blocks until a message is recieved on this socket from a remote host 
                Console.WriteLine("Server is blocked");

                while (true)
                {
                    Byte[] recieveBytes = udpReciever.Receive(ref remoteIpEndPoint);
                    //The server is now activated

                    string recievedData = Encoding.ASCII.GetString(recieveBytes);
                    string[] data = recievedData.Split(' ');
                    string clientName = data[0];
                    string message = data[1] + " " + data[2];

                    Console.WriteLine(recievedData);
                    Console.WriteLine("Recieved from: " + clientName.ToString() + " " + message.ToString());

                    string sendData = "Server: " + recievedData.ToUpper();
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(sendData);

                    udpReciever.Send(sendBytes, sendBytes.Length, remoteIpEndPoint);

                    Console.WriteLine("This message was sent from " +
                                      remoteIpEndPoint.Address.ToString() +
                                      " on their port number " +
                                      remoteIpEndPoint.Port.ToString());
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
