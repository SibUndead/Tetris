using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut; 
using Tao.Platform.Windows;
using System.Data.SQLite;
using System.IO;

namespace Tetris
{
    //Создаём экран игры
    public partial class TetrisScreen : Form
    {
        bool gameOn = false;
        Tetris tetris;
        string dbFileName;
        SQLiteConnection Conn;
        SQLiteCommand Cmd;


        public TetrisScreen(Tetris tetris)
        {
            this.tetris = tetris;
            Conn = new SQLiteConnection();
            Cmd = new SQLiteCommand();
            dbFileName = "TetResults.sqlite";
            InitializeComponent();
            TetView.InitializeContexts();
        }

        public void AddElementDataBase(int score)
        {

            try
            {
                Conn = new SQLiteConnection(string.Format("Data Source={0};", dbFileName));
                Conn.Open();
                Cmd.Connection = Conn;

                Cmd.CommandText = "INSERT INTO Results ('result') values ('"+score+"')";
                Cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            Conn.Close();
        }

        //Загрузка формы
        private void Screen_Load(object sender, EventArgs e)
        {
            Init();
            if (gameOn == false)
            {
                gameOn = true;
                Thread th = new Thread(delegate ()
                {

                    tetris.generateFigure();
                    while (gameOn)
                    {
                        lock (tetris)
                        {
                            gameOn = !tetris.Endgame();
                            tetris.Step();
                            Thread.Sleep(300);
                        }
                    }
                    DialogResult result = MessageBox.Show("Ваш счёт: " + tetris.Score.ToString(), "Игра окончена");
                    if (result == DialogResult.OK)
                    {
                        //AddElementDataBase(tetris.Score);
                        this.Invoke(new MethodInvoker(Close));
                    }
                });
                th.IsBackground = true;
                th.Start();
            }
        }

        //Иницализация необходимых библиотек
        void Init()
        {
            // инициализация библиотеки GLUT
            Glut.glutInit();
            // инициализация режима окна 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Glut.glutDisplayFunc(Draw);
            //Glut.glutKeyboardFunc(SKeyboard);

            // устанавливаем цвет очистки окна 
            Gl.glClearColor(0, 0, 0, 1);
            // устанавливаем порт вывода, основываясь на размерах элемента управления 
            //   Gl.glViewport(0, 0, TetView.Width, TetView.Height);
            // устанавливаем проекционную матрицу 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очищаем ее 
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, TetView.Width, 0.0, TetView.Height);
            // теперь необходимо корректно настроить 2D ортогональную проекцию 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            timerrender.Start();
        }
        //Вывод изображения средствами OpenGL
        private void Draw()
        {

            double a = 1, b = 0.6, c = 0;
            // очищаем буфер цвета

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3d(0, 1, 1);
            Gl.glVertex2d(7, 7);
            Gl.glVertex2d(438, 7);
            Gl.glVertex2d(438, 558);
            Gl.glVertex2d(7, 558);
            Gl.glEnd();

            for (int i = 0; i < tetris.SizeY; i++)
                for (int j = 0; j < tetris.SizeX; j++)
                {
                    if (tetris.GetPointInvShowingScreen(j, i) == 1)
                    {
                        Gl.glColor3d(a, b, c);
                        Gl.glBegin(Gl.GL_QUADS);
                        // устанавливаем параметр цвета, основанный на параметрах a b c 
                        // рисуем вершину в координатах 5,5 
                        Gl.glVertex2d(15.0 + (j * 30.0), 15.0 + (i * 30.0));
                        // устанавливаем параметр цвета, основанный на параметрах с a b 
                        Gl.glColor3d(a, b, c);
                        // рисуем вершину в координатах 25,5 
                        Gl.glVertex2d(40.0 + (j * 30.0), 15.0 + (i * 30.0));
                        // устанавливаем параметр цвета, основанный на параметрах b c a 
                        Gl.glColor3d(a, 1, 1);
                        // рисуем вершину в координатах 25,5 
                        Gl.glVertex2d(40.0 + (j * 30.0), 40.0 + (i * 30.0));
                        // устанавливаем параметр цвета, основанный на параметрах b c a 
                        Gl.glColor3d(a, b, c);
                        // рисуем вершину в координатах 25,5 
                        Gl.glVertex2d(15.0 + (j * 30.0), 40.0 + (i * 30.0));
                        // завершаем режим рисования примитивов 
                        Gl.glEnd();
                    }
                }
            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();

            // обновляем изображение в элементе 
            TetView.Invalidate();
        }

        //Добавление нового элемента в БД
        public void AddElementInResults(int result)
        {

        }

        //Обновление счёта
        private void ScoreUpdate()
        {
            scoreLine.Text = "Счёт:" + tetris.Score.ToString();
            scoreLine.Refresh();
        }
        //Таймер
        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
            ScoreUpdate();
        }
        //Клавиши управления
        private void TetrisScreen_KeyUp(object sender, KeyEventArgs e)
        {
            lock (tetris)
            {
                if (e.KeyCode == Keys.Left)
                {
                    tetris.MoveLeft();
                }
                else if (e.KeyCode == Keys.Right)
                {
                    tetris.MoveRight();
                }
                else if (e.KeyCode == Keys.Space)
                {
                    tetris.Rotate();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    tetris.MoveDown();
                }
                Draw();
            }
        }
    }
}
