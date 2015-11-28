using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Nethack.Server
{
    public class NetworkIOServer
    {
        string localIP = "?";

        public NetworkIOServer()
        {
            
            IPHostEntry host;
            //string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
        }
        

        public static void Main()
        {


            Thread Serverrr = new Thread(() =>
            {
                NetworkIOServer serv = new NetworkIOServer();
                serv.Run();
            });

            Thread Clienttt = new Thread(() =>
            {
                NetworkIOServer cli = new NetworkIOServer();
                cli.Client();
            });

            Serverrr.Start();
            Clienttt.Start();

        }

               
        private void Run()
        {
            Console.Title = "Server";
            TcpListener tcpListener = null;

            //Tworzymy nowy obiekt TcpListener i rozpoczyna
            //oczekiwanie ne sygnał na porcie 65000

            
            Console.WriteLine("IP Twojego komputer: " + localIP);

            IPAddress localAddr = IPAddress.Parse(localIP);
            tcpListener = new TcpListener(localAddr, 13000);
 
            tcpListener.Start();


            //Oczekuje na sygnał do czasu przesłania plikiu
            for (; ; )
            {
                //Kiedy klijent się połączy, serwer przyjmuje połącznie i zwraca
                //nowe gniazdo o nazwie socketForClient, a obiekt TcpLitener
                //kontynuuje oczekiwanie na sygnał

                    Socket socketForClient = tcpListener.AcceptSocket();
                    Console.WriteLine("Klient> podłaczył się..");

                    //Wysyłanie pliku
                    SendFileToClient(socketForClient);

                    Console.WriteLine("Zerwanie połączenia");

                    //Zakończenie połączenia
                    socketForClient.Close();
                    Console.WriteLine("Koniec...");
                    Console.ReadKey();
                    break;


            }
        }

        //Metoda pomocnicza do wysyłania pliku
        private void SendFileToClient(Socket socketForClient)
        {
            //Tworzy się NetworkStream, a następnie tworzy dla niego obiekt StreamWriter

            NetworkStream networkStream = new NetworkStream(socketForClient);
            StreamWriter streamWriter = new StreamWriter(networkStream);

            //Tworzymy StreamReader dla pliku
           // StreamReader streamReader = new StreamReader(@"D:\Ola\C#\Interesujace-obiekty\Nethack\SerwerWysylaPlik.txt");

            string theString;

            //Przechodzi przez plik i wysyła wiersz po wierszu

            do
            {
                theString = Console.ReadLine();

                if (theString != null)
                {
                   // Console.WriteLine("Wysyłanie : {0}", theString);
                    streamWriter.WriteLine(theString);
                    streamWriter.Flush();
                }
            }
            while (theString != "");

            //Operacje porzadkujące
            //streamReader.Close();
            networkStream.Close();
            streamWriter.Close();
        }

        //Client
        public void Client()
        {
            Console.Title = "Client";
            String strServer = "";
            // Tworzenie obiektu TcpCliect do komunikacji z serwerem
            TcpClient socketForServer = null;
            Ping ping = new Ping();
            while (socketForServer == null)
            {
                for (int i = 2; i < 256; i++)
                {
                    if (socketForServer != null)
                        break;
                    try
                    {
                        strServer = "192.168.1." + i.ToString();
                        if (strServer == localIP) continue;
                        PingReply pingresult = ping.Send(strServer, 100);
                        if (pingresult.Status.ToString() == "Success")
                        {
                            Console.WriteLine("Serwer> Połączenie z adresem {0}:13000....", strServer);
                            socketForServer = new TcpClient(strServer, 13000);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Serwer> Połączenie nieudane.", strServer);
                    }
                }
            }
            Console.WriteLine("Serwer> Połączenie udane.", strServer);
            //Tworzy się NetworkStream i StreamReader
            NetworkStream networkStream = socketForServer.GetStream();
            StreamReader streamReader = new StreamReader(networkStream);

            try
            {
                string OutPutString;

                //Odczytywanie dane z serwera i wyświetlanie

                do
                {
                    OutPutString = streamReader.ReadLine();

                    if (OutPutString != null)
                    {
                        Console.WriteLine(OutPutString);
                    }
                }
                while (OutPutString != null);
            }
            catch
            {
                Console.WriteLine("Nie udało się");
            }

            networkStream.Close();

        }
    }
}
