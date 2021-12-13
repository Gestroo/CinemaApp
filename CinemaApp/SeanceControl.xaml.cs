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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaLibrary;
using CinemaLibrary.Entity;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для SeanceControl.xaml
    /// </summary>
    public partial class SeanceControl : Page
    {
        public SeanceControl()
        {
            InitializeComponent();
            GetFilmNameComboBox();
        }
        public void GetFilmNameComboBox()
        {
            var filmName = Film.GetFilmName();
            filmName.Add("Выберите фильм");
            chooseFilmComboBox.ItemsSource = filmName;
        }

        private void chooseFilmComboBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (chooseFilmComboBox.Text == "Выберите фильм") chooseFilmComboBox.Text = "";
        }

        private void ComboBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (chooseHallComboBox.Text == "Выберите зал") chooseHallComboBox.Text = "";
        }
    }
}
