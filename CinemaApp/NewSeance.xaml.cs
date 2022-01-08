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
using CinemaLibrary.Entity;
using CinemaLibrary;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для NewSeance.xaml
    /// </summary>
    public partial class NewSeance : Page
    {
        private SeanceCreator seance;
        public NewSeance(SeanceCreator seanceCreator)
        {
            seance = seanceCreator;
            InitializeComponent();
            foreach (var g in Genre.GetGenres())
            {
                var checkbox = new CheckBox
                {
                    Content = g,
                    FontSize = 22
                };
                checkbox.Checked += GenreChecked;
                checkbox.Unchecked += GenreUnchecked;
                Genres.Children.Add(checkbox);
            }
        }
        private List<string> ActiveGenres = new List<string>();
        private void GenreChecked(object sender, RoutedEventArgs e) 
        {
            if (ActiveGenres.Contains(((CheckBox)sender).Content.ToString())) return;
            ActiveGenres.Add(((CheckBox)sender).Content.ToString());
        }
        private void GenreUnchecked(object sender, RoutedEventArgs e)
        {
            if (ActiveGenres.Contains(((CheckBox)sender).Content.ToString())) 
            ActiveGenres.Remove(((CheckBox)sender).Content.ToString());
        }
        private void toSeancesButton_Click(object sender, RoutedEventArgs e)
        {
            var film = createFilm();
            seance.PageControl(film);
        }

        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
            createFilm();
            string message = "Фильм успешно добавлен";
            MessageBox.Show(message);
        }
        private Film createFilm() 
        {
            Film film;
            List<Genre> tmpgenres = new List<Genre>();

            foreach (var i in ActiveGenres)
            {
                tmpgenres.Add(Genre.GetGenreByTitle(i));
            }
            string tmpstring = FilmRestrictionComboBox.Text;


            film = new Film
            {
                Name = FilmNameTextBox.Text,
                Duration = Convert.ToInt32(FilmDurationTextBox.Text),
                Restriction = int.Parse(tmpstring.Substring(0,tmpstring.Length-1)),
                Description = FilmDescriptionTextBox.Text,
                Genre = tmpgenres,
                DateStart = (DateTime)FilmStartDatePicker.SelectedDate, 
                DateFinish = (DateTime)FilmFinishDatePicker.SelectedDate
            };
            Film.Add(film);
            return film;
        }
    }
}
