using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CinemaLibrary.Entity;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для SeanceCreator.xaml
    /// </summary>
    public partial class SeanceCreator : Window
    {
        public SeanceCreator(Personal personal)
        {

            InitializeComponent();
            WindowState = WindowState.Maximized;
            LoadName(personal);
        }

        
        private void NewSeanceButton_Click(object sender, RoutedEventArgs e)
        {
            NewSeanceButton.Background = Brushes.Gray;
            SeanceControlButton.Background = Brushes.Purple;
            NewSeanceButton.BorderBrush = Brushes.Black;
            SeanceControlButton.BorderBrush = Brushes.Purple;
            seanceCreator.Navigate(new NewSeance(this));

        }
        public void LoadName(Personal personal)
        {
            NameTextBlock.FontSize = 20;
            NameTextBlock.Text = personal.GetFIO();
        }
        public void PageControl() 
        {
            NewSeanceButton.Background = Brushes.Purple;
            SeanceControlButton.Background = Brushes.Gray;
            NewSeanceButton.BorderBrush = Brushes.Purple;
            SeanceControlButton.BorderBrush = Brushes.Black;
            seanceCreator.Navigate(new SeanceControl());
        }
        public void PageControl(Film film)
        {
            NewSeanceButton.Background = Brushes.Purple;
            SeanceControlButton.Background = Brushes.Gray;
            NewSeanceButton.BorderBrush = Brushes.Purple;
            SeanceControlButton.BorderBrush = Brushes.Black;
            seanceCreator.Navigate(new SeanceControl(film));
        }
        private void SeanceControlButton_Click(object sender, RoutedEventArgs e)
        {
            PageControl();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
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
    }
}
