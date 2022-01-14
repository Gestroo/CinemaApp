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
using CinemaLibrary;
using CinemaLibrary.Entity;

namespace CinemaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Personal personal)
        {

            InitializeComponent();
            WindowState = WindowState.Maximized;
            DgInsert();
            LoadGenres();
            LoadHalls();
            LoadName(personal);
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateP.SelectedDate == Convert.ToDateTime("29/11/21"))
            { }
        }

        public void LoadHalls() 
        {
            
            hallsComboBox.ItemsSource = CinemaHall.GetHalls(); 
        }
        public void LoadName(Personal personal) 
        {
            NameTextBlock.FontSize = 20;
            NameTextBlock.Text = personal.FullName;
        }
        public void DgInsert()
        {
            dgSeances.ItemsSource = Seance.GetSeances();
        }

        public void LoadGenres() 
        {
            var genres = Genre.GetGenres();
            genresComboBox.ItemsSource = genres;
        }
        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Выйти из учетной записи?",
                "Выход",
                MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                Authorization authorization = new Authorization();
                authorization.Show();
                this.Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;

        }
    }
}