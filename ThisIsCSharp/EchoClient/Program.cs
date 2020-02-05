using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args) {
            if(args.Length < 4) {
                Console.WriteLine("사용법: {0} <Bind IP> <Server IP> <Message>", Process.GetCurrentProcess().ProcessName);
                return;
            }

            string bindIp = args[0];
            int bindPort = Convert.ToInt32(args[1]);
            string serverIp = args[2];
            const int serverPort = 5425;
            string message = args[3];

            try {
                IPEndPoint clientAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                Console.WriteLine("클라이언트: {0}, 서버: {1}", clientAddress.ToString(), serverAddress.ToString());

                //클라이언트는 서버와 통신된 어떤 하나의 공간으로 이해해도 될것같은데
                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress);

                byte[] data = System.Text.Encoding.Default.GetBytes(message);

                //클라이언트의 흐름(전기같은)에 data를 흘려보낸다. 현재 클라이언트는 서버와 연결된 상태니까,
                //서버로 자연스래 흘러가고 서버의 포트가 열려있고 전기를 받을 준비가 되어있다면 받아가겠지.
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("송신: {0}", message);

                //이제 서버에서 수신도 받아봐야지
                data = new byte[256];
                string responseData = "";
                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.Default.GetString(data, 0, bytes);
                Console.WriteLine("수신: {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch (SocketException e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("에코 클라이언트 종료");
        }
    }
}
