using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
//using System.Oboolt;

namespace Nethack.Server
{
    public class NetworkIOServer
    {
        public static void Main(){
            NetworkIOServer app = new NetworkIOServer();
            app.Run();
        }
        private void Run(){
            //Tworzymy nowy obiekt TcpListener i rozpoczyna
            //oczekiwanie ne sygnał na porcie 65000

            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(localAddr, 65000);
            tcpListener.Start();

            //Oczekuje na sygnał do czasu przesłania plikiu
            for (; ; )
            {
                //Kiedy klijent się połączy, serwer przyjmuje połącznie i zwraca
                //nowe gniazdo o nazwie socketForClient, a obiekt TcpLitener
                //kontynuuje oczekiwanie na sygnał

                Socket socketForClient = tcpListener.AcceptSocket();
                Console.WriteLine("Jesteś w grze :)");

                //Wysyłanie pliku
                SendFileToClient(socketForClient);

                Console.WriteLine("Zerwanie połączenia");

                //Zakończenie połączenia
                socketForClient.Close();
                Console.WriteLine("Koniec...");
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
            StreamReader streamReader = new StreamReader(@"D:\Ola\C#\Interesujace-obiekty\Nethack\SerwerWysylaPlik.txt");

            string theString;

            //Przechodzi przez plik i wysyła wiersz po wierszu

            do
            {
                theString = streamReader.ReadLine();

                if (theString != null)
                {
                    Console.WriteLine("Wysyłanie : {0}", theString);
                    streamWriter.WriteLine(theString);
                    streamWriter.Flush();
                }
            }
            while (theString != null);

            //Operacje porzadkujące
            streamReader.Close();
            networkStream.Close();
            streamWriter.Close();
        }
    }
}
