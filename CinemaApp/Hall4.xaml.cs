using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static CinemaApp.MainWindow;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для Hall4.xaml
    /// </summary>
    public partial class Hall4 : Window
    {
        public Hall4(Seance seance, Personal personal)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            _personal = personal;
            _seance = seance;
            LoadData();
            LoadSeatsInfo();
            notify += GetBookingEvent;
        }

        public event GetBooking notify;
        private Booking booking { get; set; }
        private Personal _personal;
        private Seance _seance;
        private Button lastCheckedButton;
        private List<Button> checkedButtons = new List<Button>();

        private void LoadSeatsInfo()
        {
            foreach (var s in SeatsGrid.Children)
            {
                if (!(s is Button)) continue;
                var tmp = s as Button;
                var name = tmp.Name;
                int number;
                int row = int.Parse(name.Substring(1, 1));
                if (name.Length == 11)
                    number = int.Parse(name.Substring(3, 2));
                else number = int.Parse(name.Substring(3, 1));

                if (_seance.BoughtSeats.Contains(HallSeat.FindSeat(row, number)))
                {
                    tmp.Background = Brushes.IndianRed;
                }
                if (_seance.ReservedSeats.Contains(HallSeat.FindSeat(row, number)))
                {
                    tmp.Background = Brushes.Aquamarine;
                }

            }


        }

        private void GetBookingEvent(Booking booking)
        {
            this.booking = booking;
        }

        public void LoadData()
        {
            SeanceInfoTextBlock.Text = $"{_seance.Film.Name}, {_seance.Date} {_seance.Time}";
        }
        private void SeatButton_Click(object sender, RoutedEventArgs e)
        {

            var tmp_button = (Button)sender;
            if (checkedButtons.Contains(tmp_button))
            {

                checkedButtons.Remove(tmp_button);
                var name = tmp_button.Name;
                int number;
                int row = int.Parse(name.Substring(1, 1));
                if (name.Length == 11)
                    number = int.Parse(name.Substring(3, 2));
                else number = int.Parse(name.Substring(3, 1));
                if (_seance.BoughtSeats.Contains(HallSeat.FindSeat(row, number)))
                {
                    tmp_button.Background = Brushes.IndianRed; return;
                }
                if (_seance.ReservedSeats.Contains(HallSeat.FindSeat(row, number)))
                {
                    tmp_button.Background = Brushes.Aquamarine; return;
                }
                tmp_button.Background = Brushes.White;
                if (checkedButtons.Count == 0)
                    lastCheckedButton = null;
                else lastCheckedButton = checkedButtons[checkedButtons.Count - 1];
            }
            else
            {
                var name = tmp_button.Name;
                int number;
                int row = int.Parse(name.Substring(1, 1));
                if (name.Length == 11)
                    number = int.Parse(name.Substring(3, 2));
                else number = int.Parse(name.Substring(3, 1));
                if (_seance.BoughtSeats.Contains(HallSeat.FindSeat(row, number)))
                {
                    string message = "Это место уже куплено";
                    MessageBox.Show(message);
                    return;
                }
                checkedButtons.Add(tmp_button);
                tmp_button.Background = Brushes.Gray;
                lastCheckedButton = tmp_button;
            }

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var b in checkedButtons)

            {
                var name = b.Name;
                int number;
                int row = int.Parse(name.Substring(1, 1));
                if (name.Length == 11)
                    number = int.Parse(name.Substring(3, 2));
                else number = int.Parse(name.Substring(3, 1));

                if (_seance.ReservedSeats.Contains(HallSeat.FindSeat(row, number)))
                {
                    MessageBoxResult result = MessageBox.Show(
         "Вы уверены что хотите очистить бронь?",
         "Сохранить",
         MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        b.Background = Brushes.White;
                    }
                }
                b.Background = Brushes.White;


            }
            lastCheckedButton = null;
            LoadSeatsInfo();
            checkedButtons.Clear();
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            string message = null;
            {
                foreach (var b in checkedButtons)

                {
                    var name = b.Name;
                    int number;
                    int row = int.Parse(name.Substring(1, 1));
                    if (name.Length == 11)
                        number = int.Parse(name.Substring(3, 2));
                    else number = int.Parse(name.Substring(3, 1));

                    if (_seance.ReservedSeats.Contains(HallSeat.FindSeat(row, number)))
                    {
                        message += $"{Environment.NewLine} Ряд : {row} Место : {number} Бронь :{Client.FindClientByTicket(_seance, row, number).GetFIO()}";
                    }
                }
                if (_seance.ReservedSeats.Count != 0)
                {
                    MessageBoxResult result = MessageBox.Show(
           $"Присутстcвует бронь: {message}",
           "Сохранить",
           MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.Cancel) return;
                }



                foreach (var b in checkedButtons)

                {
                    var name = b.Name;
                    int number;
                    int row = int.Parse(name.Substring(1, 1));
                    if (name.Length == 11)
                        number = int.Parse(name.Substring(3, 2));
                    else number = int.Parse(name.Substring(3, 1));

                    {

                        _seance.BoughtSeats.Add(HallSeat.FindSeat(row, number));
                        _seance.Save();

                        if (Ticket.FindTicket(_seance, row, number) == null)
                        {
                            Ticket ticket = new Ticket
                            {
                                Seance = _seance,
                                Row = HallRow.GetHallRowByNumber(row),
                                Seat = HallSeat.FindSeat(row, number),
                                TotalPrice = 250,
                                Personal = _personal
                            };
                            Ticket.Add(ticket);
                        }

                        b.Background = Brushes.IndianRed;
                    }
                }
                checkedButtons.Clear();
            }

        }
        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkedButtons.Count == 0) return;

            var reservation = new AddReservation(_seance, notify);
            reservation.ShowDialog();
            if (booking == null) return;
            foreach (var b in checkedButtons)
            {
                var name = b.Name;
                int number;
                int row = int.Parse(name.Substring(1, 1));
                if (name.Length == 11)
                    number = int.Parse(name.Substring(3, 2));
                else number = int.Parse(name.Substring(3, 1));

                Ticket ticket;
                if (Ticket.FindTicket(_seance, row, number) == null)
                {
                    ticket = new Ticket
                    {
                        Seance = _seance,
                        Row = HallRow.GetHallRowByNumber(row),
                        Seat = HallSeat.FindSeat(row, number),
                        TotalPrice = 250,
                        Personal = _personal
                    };
                    Ticket.Add(ticket);
                }
                else { ticket = Ticket.FindTicket(_seance, row, number); }

                Reservation _reservation = new Reservation
                {
                    Ticket = ticket,
                };
                Reservation.Add(_reservation);

                booking.Reservations.Add(_reservation);

                if (!_seance.ReservedSeats.Contains(HallSeat.FindSeat(row, number)))
                    _seance.ReservedSeats.Add(HallSeat.FindSeat(row, number));
                b.Background = Brushes.Aquamarine;
            }
            _seance.Save();
            checkedButtons.Clear();
        }

        private void TicketPrototypeButton_Click(object sender, RoutedEventArgs e)
        {
            if (lastCheckedButton == null)
            {
                string message = "Нет выбранного билета";
                MessageBox.Show(message);
                return;
            }

            var name = lastCheckedButton.Name;
            int number;
            int row = int.Parse(name.Substring(1, 1));
            if (name.Length == 11)
                number = int.Parse(name.Substring(3, 2));
            else number = int.Parse(name.Substring(3, 1));
            TicketPrototype ticketPrototype = new TicketPrototype(_personal, _seance, row, number);
            ticketPrototype.Show();

        }
    }
}
