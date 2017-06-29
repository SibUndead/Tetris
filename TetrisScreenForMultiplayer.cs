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


namespace Tetris
{
    //Поле для двух игроков
    public partial class TetrisScreenForMultiplayer : Form
    {
        bool gameOn=false;
        Tetris myTetris;
        Tetris opponentTetris;
        public TetrisScreenForMultiplayer(Tetris myTetris, Tetris opponentTetris)
        {
            this.myTetris = myTetris;
            this.opponentTetris = opponentTetris;
            InitializeComponent();
            tetViewMultipayer.InitializeContexts();
            
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
                    myTetris.generateFigure();
                    while (gameOn)
                    {
                        lock (myTetris)
                        {
                            gameOn = !myTetris.Endgame();
                            myTetris.Step();
                            Thread.Sleep(200);
                        }
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
            Glu.gluOrtho2D(0.0, tetViewMultipayer.Width, 0.0, tetViewMultipayer.Height);
            // теперь необходимо корректно настроить 2D ортогональную проекцию 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            timerrender.Start();
        }

        //Вывод изображения средствами OpenGL
        private void Draw()
        {

            // очищаем буфер цвета

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            
            DrawTetris(myTetris,true);
            DrawTetris(opponentTetris,false);
            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();

            // обновляем изображение в элементе 
            tetViewMultipayer.Invalidate();
        }
        private void DrawTetris(Tetris tetris, bool my)
        {
            double a = 1, b = 0.6, c = 0;
            int X0 = my ? 0 : 450;
            if(X0!=0)
            {
                a = 0;
                b = 1;
                c = 0.3;
            }

            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3d(0, 1, 1);
            Gl.glVertex2d(X0+7, 7);
            Gl.glVertex2d(X0 + 438, 7);
            Gl.glVertex2d(X0 + 438, 558);
            Gl.glVertex2d(X0 + 7, 558);
            Gl.glEnd();

            for (int i = 0; i < tetris.SizeY; i++)
            {
                for (int j = 0; j < tetris.SizeX; j++)
                {
                    if (tetris.GetPointInvShowingScreen(j, i) == 1)
                    {
                        Gl.glColor3d(a, b, c);
                        Gl.glBegin(Gl.GL_QUADS);
                        // устанавливаем параметр цвета, основанный на параметрах a b c 
                        // рисуем вершину в координатах 5,5 
                        Gl.glVertex2d(X0 + 15.0 + (j * 30.0), 15.0 + (i * 30.0));
                        // устанавливаем параметр цвета, основанный на параметрах с a b 
                        Gl.glColor3d(a, b, c);
                        // рисуем вершину в координатах 25,5 
                        Gl.glVertex2d(X0 + 40.0 + (j * 30.0), 15.0 + (i * 30.0));
                        // устанавливаем параметр цвета, основанный на параметрах b c a 
                        Gl.glColor3d(a, 1, 1);
                        // рисуем вершину в координатах 25,5 
                        Gl.glVertex2d(X0 + 40.0 + (j * 30.0), 40.0 + (i * 30.0));
                        // устанавливаем параметр цвета, основанный на параметрах b c a 
                        Gl.glColor3d(a, b, c);
                        // рисуем вершину в координатах 25,5 
                        Gl.glVertex2d(X0 + 15.0 + (j * 30.0), 40.0 + (i * 30.0));
                        // завершаем режим рисования примитивов 
                        Gl.glEnd();
                    }
                }
            }
        }

        //Обновление счёта
        private void ScoreUpdate()
        {
            scoreLineMy.Text = "Ваш Счёт:" + myTetris.Score.ToString();
            scoreLineMy.Refresh();
            scoreLineOpponent.Text = "Счёт Оппонента:" + opponentTetris.Score.ToString();
            scoreLineOpponent.Refresh();
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
            lock (myTetris)
            {
                if (e.KeyCode == Keys.Left)
                {
                    myTetris.MoveLeft();
                }
                else if (e.KeyCode == Keys.Right)
                {
                    myTetris.MoveRight();
                }
                else if (e.KeyCode == Keys.Space)
                {
                    myTetris.Rotate();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    myTetris.MoveDown();
                }
                Draw();
            }
        }
    }
}
