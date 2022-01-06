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
            newseance = new NewSeance(this);
            InitializeComponent();
            WindowState = WindowState.Maximized;
            LoadName(personal);
        }
        private Page newseance;
        private Page seancecontrol = new SeanceControl();
        private void NewSeanceButton_Click(object sender, RoutedEventArgs e)
        {
            NewSeanceButton.Background = Brushes.Gray;
            SeanceControlButton.Background = Brushes.Purple;
            NewSeanceButton.BorderBrush = Brushes.Black;
            SeanceControlButton.BorderBrush = Brushes.Purple;
            seanceCreator.Navigate(newseance);

        }
        public void LoadName(Personal personal)
        {
            NameTextBlock.FontSize = 20;
            NameTextBlock.Text = personal.FullName;
        }
        public void PageControl() 
        {
            NewSeanceButton.Background = Brushes.Purple;
            SeanceControlButton.Background = Brushes.Gray;
            NewSeanceButton.BorderBrush = Brushes.Purple;
            SeanceControlButton.BorderBrush = Brushes.Black;
            seanceCreator.Navigate(seancecontrol);
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
