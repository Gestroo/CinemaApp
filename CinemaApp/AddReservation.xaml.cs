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
using static CinemaApp.Hall1;

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
        private List<Reservation> reserves;
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastNameTextBox.Text == "" || FirstNameTextBox.Text == "" || PhoneNumberTextBox.Text == "" || BirthDatePicker.Text == "")
            {
                string message = $"Пожалуйста, заполните все поля";
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
        }
    }
}
