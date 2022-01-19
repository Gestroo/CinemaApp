using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static CinemaApp.MainWindow;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Window
    {
        public AddReservation(Seance seance, GetBooking booking)
        {
            InitializeComponent();
            _seance = seance;
            notify = booking;
        }

        private event GetBooking notify;
        private Seance _seance;
        private Client client;
        private List<Reservation> reserves = new List<Reservation>();
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastNameTextBox.Text == "" || FirstNameTextBox.Text == "" || PhoneNumberTextBox.Text == "" || !BirthDatePicker.SelectedDate.HasValue)
            {
                string message = $"Пожалуйста, заполните все поля";
                MessageBox.Show(message);
                return;
            }
            if (BirthDatePicker.SelectedDate.Value > DateTime.Now)
            {
                string message = $"Некорректная дата рождения";
                MessageBox.Show(message);
                return;
            }
            if (Math.Abs((BirthDatePicker.SelectedDate.Value - DateTime.Now).TotalDays) < _seance.Film.Restriction * 365)
            {
                string message = $"Возрастное ограничение не пройдено";
                MessageBox.Show(message);
                return;
            }


            if (Client.FindClient(LastNameTextBox.Text, FirstNameTextBox.Text, MiddleNameTextBox.Text, PhoneNumberTextBox.Text, DateTime.Parse(BirthDatePicker.Text)) == null)
            {
                AddClient();
            }
            else client = Client.FindClient(LastNameTextBox.Text, FirstNameTextBox.Text, MiddleNameTextBox.Text, PhoneNumberTextBox.Text, DateTime.Parse(BirthDatePicker.Text));
            Booking booking = new Booking
            {
                Client = client,
                DateTime = DateTime.Now,
                Reservations = reserves
            };
            Booking.Add(booking);
            notify.Invoke(booking);
            this.Close();
        }
        private void AddClient()
        {
            client = new Client
            {
                LastName = LastNameTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                MiddleName = MiddleNameTextBox.Text,
                BirthDate = (DateTime)BirthDatePicker.SelectedDate,
                PhoneNumber = PhoneNumberTextBox.Text,
            };
            Client.Add(client);
        }

        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneNumberTextBox.Text = PhoneNumberTextBox.Text.Replace(" ", "");
            PhoneNumberTextBox.SelectionStart = PhoneNumberTextBox.Text.Length;
        }

        private void PhoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            string t = PhoneNumberTextBox.Text;

            if (t.Length == 0)
            {
                PhoneNumberTextBox.Text = "+7";
                PhoneNumberTextBox.SelectionStart = PhoneNumberTextBox.Text.Length; //коретка в конец строки
            }
            if (t.Length >= 12)
            {
                e.Handled = true; // отклоняем ввод
            }
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true; // отклоняем ввод
            }

        }


    }
}
