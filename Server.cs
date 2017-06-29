using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Tetris
{
    class Server
    {
        TcpListener server;
        Tetris myTetris;
        Tetris oponentTetris;

        TcpClient client;
        public Server(IPAddress ip,  int port, Tetris myTetris, Tetris oponentTetris)
        {
            this.myTetris = myTetris;
            this.oponentTetris = oponentTetris;
            //Запускаем сервер
            server = new TcpListener(ip, port);
            run();
        }
        //Запуск и сервера и обмен данными с клиентом
        public void run()
        {
            server.Start();
            client=server.AcceptTcpClient();
            Thread th = new Thread(delegate ()
              {
                  try
                  {
                      while (true)
                      {
                          Tetris.SaveBinary(myTetris, client.GetStream());
                          Tetris temp;
                          Tetris.LoadBinary(out temp, client.GetStream());
                          oponentTetris.Clone(temp);
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.ToString(), "Error");
                  }
        });
            th.IsBackground = true;
            th.Start();
        }
    }
}
