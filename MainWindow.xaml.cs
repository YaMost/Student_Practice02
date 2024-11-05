using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;
using static System.NullReferenceException;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace MiningMinerals
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=MiningDB.db;";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
            string sqlQuery = "SELECT * FROM Minerals";

            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                sqlConnection.Open();
                string cmd = sqlQuery; 
                SQLiteCommand createCommand = new SQLiteCommand(cmd, sqlConnection);
                createCommand.ExecuteNonQuery();
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable(); 
                dataAdp.Fill(dt);
    
                DataGridMinerals.ItemsSource = dt.DefaultView;  
                sqlConnection.Close();
            }
        }


        private void RadioBtnMinerals_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM Minerals";

            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                sqlConnection.Open();
                string cmd = sqlQuery;
                SQLiteCommand createCommand = new SQLiteCommand(cmd, sqlConnection);
                createCommand.ExecuteNonQuery();
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                DataGridMinerals.ItemsSource = dt.DefaultView;
                sqlConnection.Close();
            }
        }

        private void RadioBtnTransit_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM Transit";

            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                sqlConnection.Open();
                string cmd = sqlQuery;
                SQLiteCommand createCommand = new SQLiteCommand(cmd, sqlConnection);
                createCommand.ExecuteNonQuery();
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                DataGridMinerals.ItemsSource = dt.DefaultView;
                sqlConnection.Close();
            }
        }

        private void RadioBtnMining_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM Mining";

            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                sqlConnection.Open();
                string cmd = sqlQuery;
                SQLiteCommand createCommand = new SQLiteCommand(cmd, sqlConnection);
                createCommand.ExecuteNonQuery();
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                DataGridMinerals.ItemsSource = dt.DefaultView;
                sqlConnection.Close();
            }
        }

        private void Query1_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT \"Название месторождения\",\"Запасы\",\"Годовая добыча\"\r\nFROM Mining\r\nWHERE \"Годовая добыча\" * 1.1* 1.1* 1.1* 1.1* 1.1 >= \"Запасы\";";
            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                sqlConnection.Open();
                string cmd = sqlQuery;
                SQLiteCommand createCommand = new SQLiteCommand(cmd, sqlConnection);
                createCommand.ExecuteNonQuery();
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                DataGridMinerals.ItemsSource = dt.DefaultView;
                sqlConnection.Close();
            }
        }

        private void Query2_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT DISTINCT Minerals.\"Полезное ископаемое\"\r\nFROM Minerals, Mining\r\nWHERE \"Годовая добыча\" < COALESCE(\"Годовая потребность\", 0);";
            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                sqlConnection.Open();
                string cmd = sqlQuery;
                SQLiteCommand createCommand = new SQLiteCommand(cmd, sqlConnection);
                createCommand.ExecuteNonQuery();
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                DataGridMinerals.ItemsSource = dt.DefaultView;
                sqlConnection.Close();
            }
        }

        private void Query3_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT DISTINCT \"Название месторождения\", \"Полезное ископаемое\" , abs((\"Годовая добыча\"*\"Цена за единицу\") - (\"Годовая добыча\" * \"Себестоимость за единицу\")) AS \"Прибыль\"  \r\nFROM Mining\r\nWHERE \"Название месторождения\" = 'Эльдорадо';";
            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                sqlConnection.Open();
                string cmd = sqlQuery;
                SQLiteCommand createCommand = new SQLiteCommand(cmd, sqlConnection);
                createCommand.ExecuteNonQuery();
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                DataGridMinerals.ItemsSource = dt.DefaultView;
                sqlConnection.Close();
            }
        }

        private void Query4_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT DISTINCT \"Тип\", \"Название месторождения\" , \"Способ разработки\", Mining.\"Полезное ископаемое\"  FROM Mining, Minerals\r\nWHERE  \"Способ разработки\" = 'Открытый' AND \"Тип\"='Твёрдое топливо';";
            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                sqlConnection.Open();
                string cmd = sqlQuery;
                SQLiteCommand createCommand = new SQLiteCommand(cmd, sqlConnection);
                createCommand.ExecuteNonQuery();
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                DataGridMinerals.ItemsSource = dt.DefaultView;
                sqlConnection.Close();
            }
        }
    }
    
}
