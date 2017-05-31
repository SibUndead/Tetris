using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tetris
{
    class Tetris
    {
        int sizeX;
        int sizeY;
        int[,] screen; //размер экрана
        Figure movingFigure = null;

        public int SizeX
        {
            get
            {
                return sizeX;
            }
        }
        public int SizeY
        {
            get
            {
                return sizeY;
            }
        }

        public Tetris(int sizeX=16, int sizeY=18)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            screen = new int[sizeX, sizeY];
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    screen[j, i] = 0;
        }

        public int getPoint(int x, int y)
        {
            if (x < 0 || x >= sizeX || y < 0 || y >= sizeY)
                return -1;
            return screen[x, y];
        }
        
        public void generateFigure()
        {     
            movingFigure = FigureFabric.MakeRandomFigure(this);
        }

        public void deleteline() //удалить линию
        {
            int i, j, k;
            bool isLine;

            for (i = SizeY-1; i >= 0; i--)
            {
                isLine = true;
                for (j = 0, isLine = true; j < SizeX; j++)
                {
                    if (screen[j, i] == 0)
                        isLine = false;
                }
                if (isLine == true)
                {
                    for (k = i; k > 0; k--)
                    {
                        for (j = 0; j < SizeX; j++)
                        {
                            screen[j, k] = screen[j, k - 1];
                        }
                    }
                    i++;
                }
            }
        }

        public bool Endgame() //проверка на конец игры
        {
            for (int j = 0; j < SizeX; j++)
            {
                if (screen[j, 0] == 1)
                    return false;
            }
            return true;
        }

        private void PasteFigureOnScreen(int[,] screen)
        {
            if(movingFigure!=null)
            {
                for (int i = 0; i < Figure.sizeMap; i++)
                {
                    for (int j = 0; j < Figure.sizeMap; j++)
                    {
                        if(movingFigure.Y + i>=0 && movingFigure.Y + i<sizeY &&
                           movingFigure.X + j >= 0 && movingFigure.X + j < sizeX)
                            screen[movingFigure.X + j, movingFigure.Y + i] |= movingFigure.GetMap()[j,i];
                    }
                }
            }
        }

        public void ShowScreen() //показать экран
        {
            int[,] showingScreen = (int[,])screen.Clone();
            PasteFigureOnScreen(showingScreen);
            Console.Clear();
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    Console.Write("{0}", showingScreen[j, i]);
                }    
                Console.WriteLine();
            }
        }

        public void KeyDown()
        {
        }

        public void Step()
        {
            movingFigure.StepDown();
            if(movingFigure.IsMoving==false)
            {
                PasteFigureOnScreen(screen);
                deleteline();
                generateFigure();
            }
        }
    }
}
