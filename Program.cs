using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Tetris Tetris = new Tetris(16, 18);
            Tetris.generateFigure();
            while (true)
            {
                Tetris.Step();
                if (!Tetris.Endgame())
                    break;
                Tetris.ShowScreen();
                Thread.Sleep(500);
            }
        }
    }
}
