﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new Menu());
            //Tetris.generateFigure();
            //while (true)
            //{
            //    Tetris.Step();
            //    if (!Tetris.Endgame())
            //        break;
            //    Tetris.ShowScreen();
            //Thread.Sleep(500);
            //}
        }
    }
}
