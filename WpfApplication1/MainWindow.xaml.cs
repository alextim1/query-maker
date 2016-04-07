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
using Npgsql;
using System.Data;

namespace WpfApplication1
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NpgsqlConnection conn;// = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=Alextim1_shimmy;Database=videoSaloon;");
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new NpgsqlConnection(textBox.Text);
                conn.Open();
            }

            catch (Exception exc)
            {
                label.Content = exc.Message;
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Close();
            }
            catch (Exception exc)
            {
                label.Content = exc.Message;
            }
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(textBox.Text, conn);
                NpgsqlDataAdapter ad = new NpgsqlDataAdapter(cmd);
                //DataSet ds = new DataSet("query_result");
                DataTable dt = new DataTable();
                //ds.Tables.Add("query_result");
                //ad.Fill(ds);
                ad.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }

            catch (Exception exc)
            {
                label.Content = exc.Message;
            }
            

        }
    }
}
