using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Tetris
{
    public partial class Results : Form
    {
        string dbFileName;
        SQLiteConnection Conn;
        SQLiteCommand Cmd;

        public Results()
        {
            dbFileName = "TetResults.sqlite";
            Conn = new SQLiteConnection();
            Cmd = new SQLiteCommand();
            InitializeComponent();

        }

        private void Results_Load(object sender, EventArgs e)
        {
            ReadDataBase();
        }

        private void ReadDataBase()
        {
            try
            {
                Conn = new SQLiteConnection(string.Format("Data Source={0};", dbFileName));
                Conn.Open();
                Cmd.Connection = Conn;
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            DataTable dTable = new DataTable();
            string sqlQuery;

            if (Conn.State != ConnectionState.Open)
            {
                return;
            }

            try
            {
                sqlQuery = "SELECT * FROM Results ORDER BY Result";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Conn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    resultsViewer.Rows.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++)
                        resultsViewer.Rows.Add(dTable.Rows[i].ItemArray);
                }
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            Conn.Close();
        }
    }
}
