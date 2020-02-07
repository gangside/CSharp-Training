using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace EchoServer
{
    class Program
    {
        static void Main(string[] args) {
            //if (args.Length < 1) {
            //    //Process
            //    Console.WriteLine("사용법 : {0} <BindIP>", Process.GetCurrentProcess().ProcessName);
            //    return;
            //}

            string bindIp = "127.0.0.1";
            const int bindPort = 5425;
            TcpListener server = null;

            try {
                //IPEndPoint는 IP통신에 필요한 IP주소의 출입구를 나타내는 클래스입니다. (IP, Port에 대한 정보가 들어가있어요)
                IPEndPoint localAdress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);

                server = new TcpListener(localAdress);
                server.Start(); //IP와 포트를 입력하고나서 서버를 만들고 실행하게 된다.
                Console.WriteLine("에코 서버가 시작됐습니다");

                while (true) {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("클라이언트 접속 : {0}", ((IPEndPoint)client.Client.RemoteEndPoint).ToString());

                    NetworkStream stream = client.GetStream();

                    int length;
                    string data = null;
                    byte[] bytes = new byte[256];

                    //클라이언트의 스트림에서 바이트형식으로 문자열을 받아 인코딩한 후, 다시 바이트로 변환하여 클라이언트에게 송신한다.
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) {
                        data = Encoding.Default.GetString(bytes, 0, length);

                        Console.WriteLine(String.Format("수신: {0}", data));
       
                        byte[] msg = Encoding.Default.GetBytes(Console.ReadLine());
                        int msgLength = msg.Length;
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("송신:[" + Encoding.Default.GetString(msg, 0, msgLength) + "]를 송신했습니다");
                    }

                    stream.Close();
                    client.Close();
                }
            }
            catch (SocketException e) {
                Console.WriteLine(e.Message);               
            }
            finally {
                server.Stop();
            }

            Console.WriteLine("에코 서버 종료");
        }
    }
}
