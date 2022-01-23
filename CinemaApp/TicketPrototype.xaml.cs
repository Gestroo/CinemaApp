using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
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
        public TicketPrototype(Personal personal, Seance seance,Client client, int row, int number)
        {
            InitializeComponent();
            _personal = personal;
            _seance = seance;
            _row = row;
            _number = number;
            _client = client;
            ShowTicket();
        }
        private Client _client;
        private Personal _personal;
        private Seance _seance;
        private int _row;
        private int _number;

        public List<Human> people = new List<Human>();
        
        private void ShowTicket()
        {
            string info = null;
            people.Add(_personal);
            if (_client != null)
            people.Add(_client);
            FilmInfoTextBlock.Text = $"{_seance.Film.Name} {_seance.Date} {_seance.Time}";
            HallInfoTextBlock.Text = $"{_seance.CinemaHall.HallName} Ряд: {_row} Место: {_number} ";
            foreach (var p in people)
                info += p.GetFullName() + Environment.NewLine;
            HumanInfoTextBlock.Text = info;
        }

    }
}
