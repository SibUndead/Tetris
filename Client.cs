using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Tetris
{
    class Client
    {
        Tetris myTetris;
        Tetris oponentTetris;

        TcpClient client;

        public Client(IPAddress ip, int port, Tetris myTetris, Tetris oponentTetris)
        {
            this.myTetris = myTetris;
            this.oponentTetris = oponentTetris;
            //Пробуем установить соединение с сервером
            try
            {
                client = new TcpClient();
                client.Connect(new IPEndPoint(ip, port));
                run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        //Обмен данными с сервером
        void run()
        {
            Thread th = new Thread(delegate ()
            {
                while (true)
                {
                    Tetris temp;
                    Tetris.LoadBinary(out temp, client.GetStream());
                    oponentTetris.Clone(temp);
                    Tetris.SaveBinary(myTetris, client.GetStream());
                }
            });
            th.IsBackground = true;
            th.Start();
        }
    }
}
