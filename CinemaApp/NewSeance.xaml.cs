using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            if (film == null) return;
            seance.PageControl(film);
        }

        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
            createFilm();

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

            if (FilmNameTextBox.Text == "" || FilmDurationTextBox.Text == "" || FilmStartDatePicker.Text == "" || FilmFinishDatePicker.Text == "" || tmpstring == "")
            {
                string messageAlarm = $"Заполните все поля";
                MessageBox.Show(messageAlarm);
                return null;
            }
            if ((DateTime)FilmStartDatePicker.SelectedDate < DateTime.Now.Date)
            {
                string messageAlarm = $"Дата старта должна быть больше сегодняшней";
                MessageBox.Show(messageAlarm);
                return null;
            }

            if ((DateTime)FilmStartDatePicker.SelectedDate > (DateTime)FilmFinishDatePicker.SelectedDate)
            {
                string messageAlarm = $"Некорректные даты";
                MessageBox.Show(messageAlarm);
                return null;
            }
            try
            {
                int test = Convert.ToInt32(FilmDurationTextBox.Text);
            }
            catch (System.FormatException)
            {
                string messageAlarm = $"Введите корректную длительность фильма";
                MessageBox.Show(messageAlarm);
                return null;
            }


            film = new Film
            {
                Name = FilmNameTextBox.Text,
                Duration = Convert.ToInt32(FilmDurationTextBox.Text),
                Restriction = int.Parse(tmpstring.Substring(0, tmpstring.Length - 1)),
                Description = FilmDescriptionTextBox.Text,
                Genre = tmpgenres,
                DateStart = (DateTime)FilmStartDatePicker.SelectedDate,
                DateFinish = (DateTime)FilmFinishDatePicker.SelectedDate
            };
            Film.Add(film);
            string message = "Фильм успешно добавлен";
            MessageBox.Show(message);
            return film;
        }
    }
}
