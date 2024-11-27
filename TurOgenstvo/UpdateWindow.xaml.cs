using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace TurOgenstvo
{
    /// <summary>
    /// Логика взаимодействия для UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string название = nametxt.Text;
            string цена = pricetxt.Text;
            string описание = opistxt.Text;

            AddProduct(название, цена, описание);
        }


        public void AddProduct(string название, string цена, string описание)
        {
            MyDbContext db = new MyDbContext();

            using (SqlConnection connection = new SqlConnection(db.connectionString))
            using (SqlCommand command = new SqlCommand("insert into Товары(Название,Цена,Описание)values(@Название,@Цена,@Описание)", connection))
            {
                command.Parameters.AddWithValue("@Название", название);
                command.Parameters.AddWithValue("@Цена", цена);
                command.Parameters.AddWithValue("@Описание", описание);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

