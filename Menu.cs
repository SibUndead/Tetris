using System;
using System.Net;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Tetris
{
    public partial class Menu : Form
    {
        // https://github.com/karneev/RVS-PS/blob/master/Agent/Agent/MVC/Model/SQLiteDriver.cs
        string dbFileName;
        SQLiteConnection Conn;
        SQLiteCommand Cmd;

        public Menu()
        {
            dbFileName = "TetResults.sqlite";
            Conn = new SQLiteConnection();
            Cmd = new SQLiteCommand();
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            CreateDataBase();
        }

        private void CreateDataBase()
        {
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName);

            try
            {
                Conn = new SQLiteConnection(string.Format("Data Source={0};", dbFileName));
                Conn.Open();
                Cmd.Connection = Conn;

                Cmd.CommandText = "CREATE TABLE IF NOT EXISTS Results (id INTEGER PRIMARY KEY AUTOINCREMENT, result INTEGER)";
                Cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            Conn.Close();
        }

        //Начать одиночную игру
        private void Game_Click(object sender, EventArgs e)
        {
            Tetris tetris = new Tetris();
            TetrisScreen ts = new TetrisScreen(tetris);
            this.Visible = false;
            ts.ShowDialog();
            this.Visible = true;
            Application.Restart();
        }
    
        //Выход из игры
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Подключиться к серверу
        private void multiplayerButton_Click(object sender, EventArgs e)
        {
            Tetris myTetris = new Tetris();
            Tetris opponentTetris = new Tetris();
            TetrisScreenForMultiplayer tsfm = new TetrisScreenForMultiplayer(myTetris, opponentTetris);
            string ip = Convert.ToString(ipAdressTextBox.Text);
            int port = Convert.ToInt32(portTextBox.Text);

            Client client = new Client(IPAddress.Parse(ip), port, myTetris, opponentTetris);

            this.Visible = false;
            tsfm.Text = "Client";
            tsfm.ShowDialog();
            this.Visible = true;
            Application.Restart();
        }

        //Создать сервер
        private void createServerButton_Click(object sender, EventArgs e)
        {
            Tetris myTetris = new Tetris();
            Tetris opponentTetris = new Tetris();
            TetrisScreenForMultiplayer tsfm = new TetrisScreenForMultiplayer(myTetris, opponentTetris);
            string ip = Convert.ToString(ipAdressTextBox.Text);
            int port = Convert.ToInt32(portTextBox.Text);

           Server server = new Server(IPAddress.Parse(ip),port, myTetris, opponentTetris);

            this.Visible = false;
            tsfm.Text = "Server";
            tsfm.ShowDialog();
            this.Visible = true;
            Application.Restart();
        }

        private void resultsTabButton_Click(object sender, EventArgs e)
        {
            Results results = new Results();
            this.Visible = false;
            results.ShowDialog();
            this.Visible = true;
        }
    }
}
