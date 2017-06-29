using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Tetris
{
    [Serializable]
    public abstract class Figure
    {
        public const int sizeMap = 4;
        int x, y;
        protected int[,] map = new int[sizeMap, sizeMap]; //фигура
        bool isMoving = true;

        //Получить/Установить координату х
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value >= 0)
                    x = value;
            }
        }
        
        //Получить/Установить координату у
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

        //Получить или установить значение поля, указывающего на движение фигуры
        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
            set
            {
                isMoving = value;
            }
        }

        //Получить или передать фигуру в виде одномерного массива
        public int[] Map
        {
            get
            {
                int[] temp = new int[sizeMap * sizeMap];
                int i = 0;
                foreach(var t in map)
                {
                    temp[i++] = t;
                }
                return temp;
            }
            set
            {
                map = new int[sizeMap, sizeMap];
                for (int i = 0; i < sizeMap * sizeMap; i++)
                {
                    map[i / sizeMap, i % sizeMap] = value[i];
                }
            }
        }

        //Получить координаты точки
        public int getPointMap(int x, int y)
        {
            if (x < 0 || x >= sizeMap || y < 0 || y >= sizeMap)
                return -1;
            return map[x, y];
        }

        //Присвоить точке значение
        public void setPointMap(int x, int y, int val)
        {
            map[x, y]=val;
        }

        //Создаём массив для передачи
        public int[] Arr
        {
            get
            {
                // добавить индификатор типа
                int[] temp = new int[sizeMap * sizeMap+3];
                int i = 0;
                temp[i++] = x;
                temp[i++] = y;
                temp[i++] = Convert.ToInt32(isMoving);
                foreach (var t in map)
                {
                    temp[i++] = t;
                }
                return temp;
            }
            set
            {
                int i = 0;
                x = value[i++];
                y = value[i++];
                isMoving = (value[i++] == 1);
                map = new int[sizeMap, sizeMap];
                for (int j = 0; j < sizeMap * sizeMap; j++,i++)
                {
                    map[j / sizeMap, j % sizeMap] = value[j];
                }
            }
        }

        //Метод, необходимый для сериализации 
        //public void SetTetris(Tetris tetris)
        //{
        //}

        //Конструктор по умолчанию
        public Figure()
        {
        }

        //Устанавливаем координаты фигуры
        public Figure(Tetris tetris)
        {
            this.x = tetris.SizeX / 2 -1;
            this.y = 0;
        }

        //Получаем массив-карту фигруы
        public int[,] GetMap()
        {
            return map;
        }

    }
}
