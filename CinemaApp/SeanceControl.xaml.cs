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

        private void chooseFilmComboBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (chooseFilmComboBox.Text == "Выберите фильм") chooseFilmComboBox.Text = "";
        }

        private void ComboBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (chooseHallComboBox.Text == "Выберите зал") chooseHallComboBox.Text = "";
        }

        private void saveSeancesButton_Click(object sender, RoutedEventArgs e)
        {
            Seance seance;
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
                        SeanceDate = SeanceDateCalendar.SelectedDate.Value.Date.Add(DateTime.Parse(t).TimeOfDay)
                    };
                    Seance.Add(seance);
                    
                }
                ActiveTimes.Clear();
            }
        }

        private void chooseHallComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((e.AddedItems[0] as CinemaHall).HallName) 
            
            {
                case "Зал 1" :
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    for (int i = 0; i < 7; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = ApplicationContext.tmptimes[i].SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                    }
                    break;

                case "Зал 2":
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    for (int i = 7; i < 13; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = ApplicationContext.tmptimes[i].SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                    }
                    break;

                case "Зал 3":
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    var solocheckbox = new CheckBox
                    {
                        Content = ApplicationContext.tmptimes[0].SeanceTime.ToString("t"),
                        FontSize = 22
                    };
                    SeanceTime.Children.Add(solocheckbox);

                    solocheckbox = new CheckBox
                    {
                        Content = ApplicationContext.tmptimes[8].SeanceTime.ToString("t"),
                        FontSize = 22
                    };
                    SeanceTime.Children.Add(solocheckbox);
                    for (int i = 13; i < 18; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = ApplicationContext.tmptimes[i].SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                    }
                    break;
                case "Зал 4":
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    for (int i = 18; i < 21; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = ApplicationContext.tmptimes[i].SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                    }
                    for (int i = 10; i < 12; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = ApplicationContext.tmptimes[i].SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                        checkbox.Checked += TimeChecked;
                        checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
                    }
                    solocheckbox = new CheckBox
                    {
                        Content = ApplicationContext.tmptimes[21].SeanceTime.ToString("t"),
                        FontSize = 22
                    };
                    SeanceTime.Children.Add(solocheckbox);
                    break;

                case "Зал 5":
                    ActiveTimes.Clear();
                    SeanceTime.Children.Clear();
                    for (int i = 22; i < 29; i++)
                    {
                        var checkbox = new CheckBox
                        {
                            Content = ApplicationContext.tmptimes[i].SeanceTime.ToString("t"),
                            FontSize = 22
                        };
                         checkbox.Checked += TimeChecked;
                         checkbox.Unchecked += TimeUnchecked;
                        SeanceTime.Children.Add(checkbox);
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
