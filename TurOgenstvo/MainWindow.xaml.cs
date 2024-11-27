using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TurOgenstvo.model;

namespace TurOgenstvo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Тур> тур = new List<Тур>();

        public MainWindow()
        {
            InitializeComponent();
            LoadTurs();
        }
        public void LoadTurs()
        {
            MyDbContext db = new MyDbContext();

            using (SqlConnection connection = new SqlConnection(db.connectionString))
            using (SqlCommand command = new SqlCommand(@"
            SELECT t.Номер, t.Наименование, t.Цена, STRING_AGG(tt.Тип_Тура, ', ') AS Типы
            FROM Тур t
            JOIN Тур_Тип_Тура ttt ON t.Номер = ttt.Номер_Тура
            JOIN Тип_Тура tt ON ttt.Номер_Тип_Тура = tt.Номер
            GROUP BY t.Номер, t.Наименование, t.Цена
            ", connection)) 
            {
                connection.Open();
                //List<Тур> тур = new List<Тур>();
                тур.Clear();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        тур.Add(new Тур
                        {
                            Номер = reader.GetInt32(0),
                            Наименование = reader.GetString(1),
                            Цена = reader.GetInt32(2),
                            Типы = reader.GetString(3) // Считываем строку с объединёнными типами
                        });
                    }
                    //ldd.Items.Clear();
                    //ldd.ItemsSource = тур;

                   
                }
            }
            UpdateList();
        }

        private void UpdateList(List<Тур> filteredTurs = null)
        {
            if (ldd != null)
            {
                // Если filteredTurs не равен null, используем его, иначе используем список туров
                ldd.ItemsSource = filteredTurs ?? тур ?? new List<Тур>(); // Если туры тоже null, используем пустой список
            }
        }


        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedValue = selectedItem.Content.ToString();

                switch (selectedValue)
                {
                    case "Номер":
                        тур = тур.OrderBy(t => t.Номер).ToList();
                        break;
                    case "Название":
                        тур = тур.OrderBy(t => t.Наименование).ToList();
                        break;
                    case "Цена":
                        тур = тур.OrderBy(t => t.Цена).ToList();
                        break;
                }
                UpdateList();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            var filteredTurs = тур.Where(t => t.Наименование.ToLower().Contains(searchText) || t.Номер.ToString().Contains(searchText)).ToList();
            UpdateList(filteredTurs);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (ldd.SelectedItem is Тур id)
            {
                DeleteProduct(id.Номер);
                LoadTurs();
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }
        public void DeleteProduct(int Номер)
        {
            MyDbContext db = new MyDbContext();

            using (SqlConnection connection = new SqlConnection(db.connectionString))
            using (SqlCommand command = new SqlCommand("delete from Тур where Номер=@Номер", connection))
            {
                command.Parameters.AddWithValue("@Номер", Номер);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        //public void LoadTurs()
        //{
        //    MyDbContext db = new MyDbContext();



        //    using (SqlConnection connection = new SqlConnection(db.connectionString))
        //    using (SqlCommand command = new SqlCommand("Select Номер,Наименование , Цена from Тур ", connection))
        //    {
        //        connection.Open();
        //        List<Тур> тур = new List<Тур>();

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                тур.Add(new Тур
        //                {
        //                    Номер = reader.GetInt32(0),
        //                    Наименование = reader.GetString(1),
        //                    Цена = reader.GetInt32(2),

        //                    //ОтельID = reader.GetInt32(4),
        //                });
        //            }
        //            //ldd.ItemsSource = null;
        //            ldd.Items.Clear();

        //            ldd.ItemsSource = тур;
        //        }
        //    }
    }

}

