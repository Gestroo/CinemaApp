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
    /// Логика взаимодействия для TicketPrototype.xaml
    /// </summary>
    public partial class TicketPrototype : Window
    {
        public TicketPrototype(Personal personal, Seance seance, int row,int number)
        {
            InitializeComponent();
            _personal = personal;
            _seance  = seance;
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
            CashierInfoTextBlock.Text = $"Кассир: {_personal.FullName} ";
        }

    }
}
