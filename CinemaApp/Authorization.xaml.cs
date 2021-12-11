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

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }


        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SeanceCreatorButton_Click(object sender, RoutedEventArgs e)
        {
            SeanceCreator seanceCreator = new SeanceCreator();
            seanceCreator.Show();
            this.Close();
        }

        private void HallCheckButton_Click(object sender, RoutedEventArgs e)
        {
            Hall1 hall = new Hall1();
            hall.Show();
            this.Close();
        }
    }
}
