using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tetris
{
    [Serializable]
    public class Tetris
    {
        int sizeX=14;
        int sizeY=18;
        int score = 0;
        int[,] screen; //размер экрана
        Figure movingFigure = null;

        //Получить/Установить размер поля по х
        public int SizeX
        {
            get
            {
                return sizeX;
            }
            set
            {
                if(value>0 && value <20)
                    sizeX = value;
                else
                    sizeX = 16;
            }

        }

        //Получить/Установить размер поля по у
        public int SizeY
        {
            get
            {
                return sizeY;
            }
            set
            {
                if (value > 0 && value < 30)
                    sizeY = value;
                else
                    sizeX = 18;
            }
        }
        //Получить/Установить кол-во очков
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (value >= 0)
                    score = value;
            }
        }
        //Получить или передать поле как одномерный массив
        public int[] Screen
        {
            get
            {
                int[] temp = new int[sizeX * sizeY + 2];
                int i = 0;
                foreach(var t in screen)
                {
                    temp[i++] = t;
                }
                return temp;
            }
            set
            {
                screen = new int[sizeX, sizeY];
                for(int i=0; i<sizeX*sizeY; i++)
                {
                    screen[i/sizeY,i%sizeY]= value[i];
                }
            }
        }

        //Задем/Принимаем двигающуюся фигру в виде строки
        public string TypeMovingFigure
        {
            get
            {
                return movingFigure.GetType().ToString();
            }
            set
            {
                
                movingFigure=(Figure)Activator.CreateInstance(Type.GetType(value,false,true));
            }
        }

        //Здаём/Получаем двигающуюся фигру как одномерный массив
        public int[] MovingFigure
        {
            get
            {
                return movingFigure.Arr;
            }
            set
            {
                movingFigure.Arr = value;
               // movingFigure.SetTetris(this);
            }
        }

        //Конструктор по умолчанию
        public Tetris()
        {
            screen = new int[sizeX, sizeY];
        }

        //Конструктор с параметрами
        public Tetris(int sizeX=16, int sizeY=18)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            screen = new int[sizeX, sizeY];
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    screen[j, i] = 0;
        }

        //Получить значение точки на поле
        public int getPoint(int x, int y)
        {
            if (x < 0 || x >= sizeX || y < 0 || y >= sizeY)
                return -1;
            return screen[x, y];
        }
        
        //Генерация новой фигуры с помощью "фабрики фигур"
        public void generateFigure()
        {     
            movingFigure = FigureFabric.MakeRandomFigure(this);
        }

        //Удаление линии и подсчёт очков
        public void deleteline()
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
                    score += (((i * (-1)) + sizeY) * 100);

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

        //Проверка на конец игры
        public bool Endgame()
        {
            for (int j = 0; j < SizeX; j++)
            {
                if (screen[j, 0] == 1)
                    return true;
            }
            return false;
        }

        //Перенести движущуюся фигуру на видимый экран
        public void PasteFigureOnScreen(int[,] screen)
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

        //Инвертирование видимого экрана по оси у
        public int GetPointInvShowingScreen(int x, int y)
        {
            int[,] showingInvScreen = (int[,])screen.Clone();
            PasteFigureOnScreen(showingInvScreen);
            return showingInvScreen[x, sizeY - 1 - y];
        }

        //Функция инвертирования для вращения фигуры
        private int Invert(int m)
        {
            int n = ((m * (-1)) + 3);
            return n;
        }

        //Проверка возможности размещения фигуры
        private bool Valnewpos(int x, int y) 
        {
            int i, j;
            if (x < 0)
                movingFigure.IsMoving = false;
            else
            {
                for (i = 0; i < Figure.sizeMap && movingFigure.IsMoving == true; i++)
                {
                    for (j = 0; j < Figure.sizeMap && movingFigure.IsMoving == true; j++)
                    {
                        if (movingFigure.getPointMap(j, i) == 1)
                        {
                            if ((j + x >= SizeX) || (i + y >= SizeY))
                            {
                                movingFigure.IsMoving = false;
                            }
                            if (getPoint(j + x, i + y) == 1)
                            {
                                movingFigure.IsMoving = false;
                            }
                        }
                    }
                }
            }
            return movingFigure.IsMoving;
        }

        //Поворот движущейся фигуры
        public void Rotate()
        {
            int[,] _map = new int[4, 4];
            int i, j, sx = 4, sy = 4;

            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                {
                    _map[j, i] = movingFigure.getPointMap(j, i);
                    if (movingFigure.getPointMap(j, i) == 1)
                    {
                        if (i < sx)
                            sx = i;
                        if (Invert(j) < sy)
                            sy = Invert(j);
                    }
                    movingFigure.setPointMap(j, i, 0);
                }

            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                    if (_map[Invert(i), j] == 1)
                        movingFigure.setPointMap(j - sx, i - sy, 1);

            if (!Valnewpos(movingFigure.X, movingFigure.Y))
                for (i = 0; i < 4; i++)
                    for (j = 0; j < 4; j++)
                        movingFigure.setPointMap(j, i, _map[j, i]);
            movingFigure.IsMoving = true;
        }

        //Шаг вниз
        public void StepDown()
        {
            if (Valnewpos(movingFigure.X, movingFigure.Y+1))
                movingFigure.Y++;
        }

        //Падение вниз
        public void MoveDown()
        {
            while (Valnewpos(movingFigure.X, movingFigure.Y))
            {
                StepDown();
            }
        }

        //Щаг влево
        public void MoveLeft()
        {
            if (!Valnewpos(movingFigure.X - 1, movingFigure.Y))
                movingFigure.IsMoving = true;
            else
                movingFigure.X--;
        }

        //Шаг вправо
        public void MoveRight()
        {
            if (!Valnewpos(movingFigure.X + 1, movingFigure.Y))
                movingFigure.IsMoving = true;
            else
                movingFigure.X++;
        }

        //public void ShowScreen() //показать экран
        //{
        //    int[,] showingScreen = (int[,])screen.Clone();
        //    PasteFigureOnScreen(showingScreen);
        //    Console.Clear();
        //    for (int i = 0; i < sizeY; i++)
        //    {
        //        for (int j = 0; j < sizeX; j++)
        //        {
        //            Console.Write("{0}", showingScreen[j, i]);
        //        }    
        //        Console.WriteLine();
        //    }
        //}

        //Получить фигруру как объект класса
        public Figure GetFigure()
        {
            return movingFigure;
        }

        //Что происходит за один "шаг" на поле
        public void Step()
        {
            StepDown();
            if (movingFigure.IsMoving==false)
            {
                PasteFigureOnScreen(screen);
                if (!Endgame())
                {
                    deleteline();
                    generateFigure();
                }
            }
        }

        //Копирование тетриса
        public void Clone(Tetris tetris)
        {
            this.movingFigure = tetris.movingFigure;
            this.screen = tetris.screen;
            this.sizeX = tetris.sizeX;
            this.sizeY = tetris.sizeY;
        }

        //Сохранение сериализуемых данных в поток
        public static void SaveBinary(Tetris tetris, Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, tetris);
        }

        //Чтение сериализуемых данных из потока
        public static void LoadBinary(out Tetris tetris, Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            tetris = (Tetris)formatter.Deserialize(stream);
        }

        //public static void Save(string fileName, Tetris tetris)
        //{
        //    FileInfo fi = new FileInfo(fileName);
        //    using (FileStream fs = fi.Create())
        //    {
        //        XmlSerializer xs = new XmlSerializer(typeof(Tetris));
        //        xs.Serialize(fs, tetris);
        //        fs.Close();
        //    }
        //}
        //public static void Load(string fileName, out Tetris tetris)
        //{
        //    FileInfo fi = new FileInfo(fileName);
        //    using (FileStream fs = fi.Open(FileMode.Open))
        //    {
        //        XmlSerializer xs = new XmlSerializer(typeof(Tetris));
        //        tetris = (Tetris)xs.Deserialize(fs);
        //    }
        //}
    }
}
