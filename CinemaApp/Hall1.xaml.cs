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
    /// Логика взаимодействия для Hall1.xaml
    /// </summary>
    public partial class Hall1 : Window
    {
        public Hall1(Seance seance, Personal personal)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            _personal = personal;
            _seance = seance;
            LoadData();
            LoadSeatsInfo();
            notify += GetBookingEvent;
        }
        public delegate void GetBooking(Booking booking);
        public event GetBooking notify;
       private Booking booking { get; set; }
        private Personal _personal;
        private Seance _seance;
        private Button lastCheckedButton;
        private Brush lastBrushes;
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
            /*     if (lastCheckedButton !=null)
                     ClearLastSeat(lastCheckedButton);
                 var tmp_button = (Button)sender;
                     lastBrushes = tmp_button.Background;
                     tmp_button.Background = Brushes.Gray;
                 lastCheckedButton = tmp_button;*/
            var tmp_button = (Button)sender;
            if (checkedButtons.Contains(tmp_button))
            {
                checkedButtons.Remove(tmp_button);
                tmp_button.Background = Brushes.White;
            }
            else 
            {
                checkedButtons.Add(tmp_button);
                tmp_button.Background = Brushes.Gray;
            }
                
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (lastCheckedButton != null && lastBrushes != Brushes.IndianRed)
            {
                lastCheckedButton.Background = Brushes.White;
                lastBrushes = lastCheckedButton.Background;
            }
            else if (lastBrushes == Brushes.IndianRed)
            {
                string message = "Нельзя удалить купленное место";
                MessageBox.Show(message);
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            string message = null;
            {
                foreach (var b in checkedButtons)

                {
                    var tmp_button = b as Button;
                    var name = b.Name;
                    int number;
                    int row = int.Parse(name.Substring(1, 1));
                    if (name.Length == 11)
                        number = int.Parse(name.Substring(3, 2));
                    else number = int.Parse(name.Substring(3, 1));

                    if (_seance.ReservedSeats.Contains(HallSeat.FindSeat(row, number)))
                    {

                        message += $"Ряд : {row} Место : {number} Бронь : ";
               
                    }
                    MessageBoxResult result = MessageBox.Show(
         "Сохранить изменения?",
         "Сохранить",
         MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
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
                    checkedButtons.Clear();
                }
            }

        }
        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {


            foreach (var b in checkedButtons)

            {
                var name = b.Name;
                int number;
                int row = int.Parse(name.Substring(1, 1));
                if (name.Length == 11)
                    number = int.Parse(name.Substring(3, 2));
                else number = int.Parse(name.Substring(3, 1));

                if (_seance.BoughtSeats.Contains(HallSeat.FindSeat(row, number)))
                {
                    string messageAlarm = $"Нельзя забронировать купленное место";
                    MessageBox.Show(messageAlarm);
                    return;
                }

                _seance.ReservedSeats.Add(HallSeat.FindSeat(row, number));
                _seance.Save();
                b.Background = Brushes.Aquamarine;


            }
            var reservation = new AddReservation(_seance, notify);
            reservation.ShowDialog();

            foreach (var b in checkedButtons)

            {
                var tmp_button = b as Button;
                var name = b.Name;
                int number;
                int row = int.Parse(name.Substring(1, 1));
                if (name.Length == 11)
                    number = int.Parse(name.Substring(3, 2));
                else number = int.Parse(name.Substring(3, 1));

                Ticket ticket = new Ticket
                {
                    Seance = _seance,
                    Row = HallRow.GetHallRowByNumber(row),
                    Seat = HallSeat.FindSeat(row, number),
                    TotalPrice = 250,
                    Personal = _personal
                };
                Ticket.Add(ticket);

                Reservation _reservation = new Reservation
                {
                    Ticket = ticket,
                };
                Reservation.Add(_reservation);

                booking.Reservations.Add(_reservation);

            }
            booking.Save();
        }

        private void TicketPrototypeButton_Click(object sender, RoutedEventArgs e)
        {
            if (lastCheckedButton != null)
            {
                var name = lastCheckedButton.Name;
            int number;
            int row = int.Parse(name.Substring(1, 1));
            if (name.Length == 11)
                number = int.Parse(name.Substring(3, 2));
            else number = int.Parse(name.Substring(3, 1));
                TicketPrototype ticketPrototype = new TicketPrototype(_personal,_seance,row,number);
                ticketPrototype.Show();
            }      
        }
    }
}
