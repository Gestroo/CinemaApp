using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CinemaApp
{
    /// <summary>
    /// Класс, добавляющий сеансы в базу данных
    /// </summary>
    public partial class SeanceControl : Page
    {
        public SeanceControl()
        {
            InitializeComponent();
            GetFilmNameComboBox();
            chooseHallComboBox.ItemsSource = CinemaHall.GetHalls();
        }

        public SeanceControl(Film film)
        {
            InitializeComponent();
            GetFilmNameComboBox();
            chooseHallComboBox.ItemsSource = CinemaHall.GetHalls();
            chooseFilmComboBox.SelectedItem = film;
        }

        public void GetFilmNameComboBox()
        {
            var filmName = Film.GetFilms();
            chooseFilmComboBox.ItemsSource = filmName;
        }


        /// <summary>
        /// Добавление сеансов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveSeancesButton_Click(object sender, RoutedEventArgs e)
        {
            if (chooseFilmComboBox.SelectedItem == null || chooseHallComboBox.SelectedItem == null)
            {
                string message = $"Заполните все поля";
                MessageBox.Show(message);
                return;
            }
            if (SeanceDateCalendar.SelectedDate == null)
            {
                SeanceDateCalendar.SelectedDate = SeanceDateCalendar.DisplayDate;
            }
            if (ActiveTimes.Count == 0)
            {
                string message = $"Вы не выбрали ни одного времени";
                MessageBox.Show(message);
                return;
            }

            var hall = chooseHallComboBox.SelectedItem as CinemaHall;
            var film = chooseFilmComboBox.SelectedItem as Film;
            var filmstart = film.DateStart;
            var filmfinish = film.DateFinish;
            Seance seance;

            for (int i = 0; i < hallTimes.Count - 1; i++)
            {
                if ((DateTime.Parse(hallTimes[i + 1]) - DateTime.Parse(hallTimes[i])).TotalMinutes < film.Duration)
                {
                    string message = $"Фильм не помещается между сеансами {SeanceDateCalendar.SelectedDate.Value.Date.Add(DateTime.Parse(hallTimes[i]).TimeOfDay)} и {SeanceDateCalendar.SelectedDate.Value.Date.Add(DateTime.Parse(hallTimes[i + 1]).TimeOfDay)}";
                    MessageBox.Show(message);
                    return;
                }
            }

            foreach (var t in ActiveTimes)
            {
                if (SeanceDateCalendar.SelectedDate.Value.Date > filmfinish || SeanceDateCalendar.SelectedDate.Value.Date < filmstart)
                {
                    string message = $"Некорректная дата сеанса {SeanceDateCalendar.SelectedDate.Value.Date.Add(DateTime.Parse(t).TimeOfDay)}";
                    MessageBox.Show(message);
                    return;
                }
                if (Seance.GetSeance(SeanceDateCalendar.SelectedDate.Value.Date.Add(DateTime.Parse(t).TimeOfDay), chooseHallComboBox.SelectedItem as CinemaHall) != null)
                {
                    string message = $"Сеанс {SeanceDateCalendar.SelectedDate.Value.Date.Add(DateTime.Parse(t).TimeOfDay)} {hall.HallName} уже существует";
                    MessageBox.Show(message);
                    return;
                }
            }
            MessageBoxResult result = MessageBox.Show(
           "Сохранить изменения?",
           "Сохранить",
           MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                foreach (var t in ActiveTimes)
                {

                    seance = new Seance
                    {
                        CinemaHall = chooseHallComboBox.SelectedItem as CinemaHall,
                        Film = chooseFilmComboBox.SelectedItem as Film,
                        SeanceDate = SeanceDateCalendar.SelectedDate.Value.Date.Add(DateTime.Parse(t).TimeOfDay),
                        Cost = 250
                    };
                    Seance.Add(seance);
                }
                string message = $"Сеансы успешно добавлены";
                MessageBox.Show(message);
                ActiveTimes.Clear();
            }
        }
        public List<string> hallTimes = new List<string>();

        /// <summary>
        /// Переключение между залами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseHallComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((e.AddedItems[0] as CinemaHall).HallName)

            {
                case "Зал 1":
                    hallTimes.Clear();
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    for (int i = 1; i < 8; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = Time.GetTimeByID(i).SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                        hallTimes.Add(Time.GetTimeByID(i).SeanceTime.ToString("t"));
                    }
                    break;


                case "Зал 2":
                    hallTimes.Clear();
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    for (int i = 8; i < 14; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = Time.GetTimeByID(i).SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                        hallTimes.Add(Time.GetTimeByID(i).SeanceTime.ToString("t"));
                    }
                    break;

                case "Зал 3":
                    hallTimes.Clear();
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    var solocheckbox = new CheckBox
                    {
                        Content = Time.GetTimeByID(1).SeanceTime.ToString("t"),
                        FontSize = 22
                    };
                    solocheckbox.Checked += TimeChecked;
                    solocheckbox.Unchecked += TimeUnchecked;
                    SeanceTime.Children.Add(solocheckbox);
                    hallTimes.Add(Time.GetTimeByID(1).SeanceTime.ToString("t"));

                    solocheckbox = new CheckBox
                    {
                        Content = Time.GetTimeByID(9).SeanceTime.ToString("t"),
                        FontSize = 22
                    };
                    solocheckbox.Checked += TimeChecked;
                    solocheckbox.Unchecked += TimeUnchecked;
                    SeanceTime.Children.Add(solocheckbox);
                    hallTimes.Add(Time.GetTimeByID(9).SeanceTime.ToString("t"));
                    for (int i = 14; i < 19; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = Time.GetTimeByID(i).SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                        hallTimes.Add(Time.GetTimeByID(i).SeanceTime.ToString("t"));
                    }
                    break;
                case "Зал 4":
                    hallTimes.Clear();
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    for (int i = 19; i < 22; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = Time.GetTimeByID(i).SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                        hallTimes.Add(Time.GetTimeByID(i).SeanceTime.ToString("t"));
                    }
                    for (int i = 11; i < 13; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = Time.GetTimeByID(i).SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                        hallTimes.Add(Time.GetTimeByID(i).SeanceTime.ToString("t"));
                    }
                    solocheckbox = new CheckBox
                    {
                        Content = Time.GetTimeByID(22).SeanceTime.ToString("t"),
                        FontSize = 22
                    };
                    solocheckbox.Checked += TimeChecked;
                    solocheckbox.Unchecked += TimeUnchecked;
                    SeanceTime.Children.Add(solocheckbox);
                    hallTimes.Add(Time.GetTimeByID(22).SeanceTime.ToString("t"));
                    break;

                case "Зал 5":
                    hallTimes.Clear();
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    for (int i = 23; i < 30; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = Time.GetTimeByID(i).SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                        hallTimes.Add(Time.GetTimeByID(i).SeanceTime.ToString("t"));
                    }
                    break;
            }
        }

        private List<string> ActiveTimes = new List<string>();
        private void TimeChecked(object sender, RoutedEventArgs e)
        {
            if (ActiveTimes.Contains(((CheckBox)sender).Content.ToString())) return;
            ActiveTimes.Add(((CheckBox)sender).Content.ToString());
        }
        private void TimeUnchecked(object sender, RoutedEventArgs e)
        {
            if (ActiveTimes.Contains(((CheckBox)sender).Content.ToString()))
                ActiveTimes.Remove(((CheckBox)sender).Content.ToString());
        }
    }
}
