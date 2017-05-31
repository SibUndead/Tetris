using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        public const int sizeMap = 4;
        int x, y;
        protected int[,] map = new int[sizeMap, sizeMap]; //фигура
        bool isMoving = true;
        Tetris tetris;
        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 0)
                    y = value;
            }
        }

        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
        }

        public Figure(Tetris tetris)
        {
            this.tetris = tetris;
            this.x = tetris.SizeX / 2 -1;
            this.y = 0;
        }
        public int[,] GetMap()
        {
            return map;
        }
        private int Invert(int m)   //функция инвертирования чисел от 0 к 3
        {
            int n = ((m * (-1)) + 3);
            return n;
        }
        private bool Valnewpos() //проверка возможности размещения фигуры
        {
            int i, j;
            if (x < 0)
                isMoving = false;
            else
            {
                for (i = 0; i < sizeMap && isMoving==true; i++)
                {
                    for (j = 0; j < sizeMap && isMoving == true; j++)
                    {
                        if (map[j, i] == 1)
                        {
                            if ((j + x >= tetris.SizeX) || (i + y >= tetris.SizeY))
                            {
                                isMoving = false;
                            }
                            if (tetris.getPoint(j + x, i + y) == 1)
                            {
                                isMoving = false;
                            }
                        }
                    }
                }
            }
            return isMoving;
        }
        public void Rotate()
        {
            int[,] _map = new int[4, 4];
            int i, j, sx = 4, sy = 4;

            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                {
                    _map[j, i] = map[j, i];
                    if (map[j, i] == 1)
                    {
                        if (i < sx)
                            sx = i;
                        if (Invert(j) < sy)
                            sy = Invert(j);
                    }
                    map[j, i] = 0;
                }

            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                    if (_map[Invert(i), j] == 1)
                        map[j - sx, i - sy] = 1;

            if (!Valnewpos())
                for (i = 0; i < 4; i++)
                    for (j = 0; j < 4; j++)
                        map[j, i] = _map[j, i];
        }

        public void StepDown()
        {
            y++;
            if (!Valnewpos())
                y--;
        }

        public void MoveDown()
        {
            while(Valnewpos())
            {
                StepDown();
            }
        }
        public void MoveLeft()
        {
            x--;
            if(!Valnewpos())
            {
                x++;
                isMoving = true;
            }
        }
        public void MoveRight()
        {
            x++;
            if (!Valnewpos())
            {
                x--;
                isMoving = true;
            }
        }

    }
}
