using CinemaLibrary.Entity;
using System.Windows;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для TicketPrototype.xaml
    /// </summary>
    public partial class TicketPrototype : Window
    {
        public TicketPrototype(Personal personal, Seance seance, int row, int number)
        {
            InitializeComponent();
            _personal = personal;
            _seance = seance;
            _row = row;
            _number = number;
            ShowTicket();
        }

        private Personal _personal;
        private Seance _seance;
        private int _row;
        private int _number;


        private void ShowTicket()
        {
            FilmInfoTextBlock.Text = $"{_seance.Film.Name} {_seance.Date} {_seance.Time}";
            HallInfoTextBlock.Text = $"{_seance.CinemaHall.HallName} Ряд: {_row} Место: {_number} ";
            CashierInfoTextBlock.Text = _personal.GetFullName();
        }

    }
}
