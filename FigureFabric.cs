﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    //"Фабрика" фигур
    class FigureFabric
    {
        static Random rnd = new Random();
        public static int type;
        public enum FiguresEnum 
        {
            AngleDOWN,
            AngleUP,
            CurveLEFT,
            CurveRIGHT,
            Line,
            Square,
            TShaped
        }
        //Создать фигруру
        public static Figure MakeFigure(Tetris tetris, FiguresEnum figure)
        {
            switch(figure)
            {
                case FiguresEnum.AngleDOWN: return new Figures.AngleDOWN(tetris);
                case FiguresEnum.AngleUP: return new Figures.AngleUP(tetris);
                case FiguresEnum.CurveLEFT: return new Figures.CurveLEFT(tetris);
                case FiguresEnum.CurveRIGHT: return new Figures.CurveRIGHT(tetris);
                case FiguresEnum.Line: return new Figures.Line(tetris);
                case FiguresEnum.Square: return new Figures.Square(tetris);
                case FiguresEnum.TShaped: return new Figures.TShaped(tetris);
            }
            return null;
        }
        //Создать случайную фигуру
        public static Figure MakeRandomFigure(Tetris tetris)
        {
            Array arr = Enum.GetValues(typeof(FiguresEnum));
            type = rnd.Next(0, arr.Length);
            return MakeFigure(tetris, (FiguresEnum)arr.GetValue(type));
        }
    }
}
