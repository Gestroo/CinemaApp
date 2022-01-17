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
             _personal = personal;
            UpdateData();
            LoadGenres();
            LoadHalls();
            LoadName(personal);
        }
        private Personal _personal;
        public void UpdateData() 
        {
            List<Seance> seances = Seance.GetSeances();
            if (ActiveSeancesCheckBox.IsChecked == true)
            {
                seances = seances.Where(s =>s.SeanceDate >= DateTime.Now).ToList();      
            }
            if (PastSeancesCheckBox.IsChecked == true)
            {
                seances = seances.Where(s => s.SeanceDate < DateTime.Now).ToList();
            }
            if (SearchFilmByTitleTextBox.Text != "")
            {
                seances = seances.Where(s => s.Film.Name.ToLower().Contains(SearchFilmByTitleTextBox.Text.ToLower())).ToList();
            }
            if (SearchDatePicker.Text != "") 
            {
                seances = seances.Where(s => s.Date == SearchDatePicker.Text).ToList();
            }
            if (genresComboBox.SelectedItem != null) 
            {
            seances = seances.Where(s=>s.Film.Genres.ToLower().Contains(genresComboBox.SelectedItem.ToString().ToLower())).ToList();
            }
            if (RestrictionComboBox.SelectedItem != null)
            {
                seances = seances.Where(s => s.Film.Restriction.ToString() == RestrictionComboBox.Text).ToList();
            }
            if (hallsComboBox.SelectedItem != null)
            {
                seances = seances.Where(s => s.CinemaHall.HallName== hallsComboBox.Text).ToList();
            }
            SeancesDataGrid.ItemsSource = seances;
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void Row_DoubleClick(object sender,MouseButtonEventArgs e)
        {
            var personal = _personal as Personal;
            var seance = (sender as DataGridRow).Item as Seance;
            if (seance == null) return;
            switch (seance.CinemaHall.HallNumber) 
            
            {
                case 1:
                    var hall1 = new Hall1(seance, _personal);
                    hall1.Show();
                    break;
                case 2: var hall2 = new Hall2(seance, _personal);
                    hall2.Show();
                    break;
                case 3: var hall3 = new Hall3(seance, _personal);
                    hall3.Show();
                    break;
                case 4: var hall4 = new Hall4(seance, _personal);
                    hall4.Show();
                    break;
                case 5: var hall5 = new Hall5(seance, _personal);
                    hall5.Show();
                    break;
            }

                
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

        private void SearchFilmTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();

        }

        private void genresComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

      
        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            SearchFilmByTitleTextBox.Clear();
            SearchDatePicker.Text ="";
            genresComboBox.Text = null;
            RestrictionComboBox.Text = null;
            hallsComboBox.Text = null;
            UpdateData();
        }

        private void hallsComboBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            UpdateData();

        }

        private void RestrictionComboBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            UpdateData();
        }

        
        private void ActiveSeancesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PastSeancesCheckBox.IsChecked = false;
            UpdateData();
        }

        private void PastSeancesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ActiveSeancesCheckBox.IsChecked = false;
            UpdateData();
        }



        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }


    }
}