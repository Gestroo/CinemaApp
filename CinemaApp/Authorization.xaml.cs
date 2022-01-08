using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CinemaLibrary;
using CinemaLibrary.Entity;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            new ApplicationContext(ApplicationContext.GetDb());
            InitializeComponent();
            AddSeats();
            AddHalls();
        }


        private void AddSeats()
        {
            CinemaHall hall1 = new CinemaHall
            {
                HallName = "Зал 1"
            };
            for (int i = 1; i < 11; i++)
            {
                new HallSeat()
                {
                    SeatNumber = i
                };

            }
        }
        private void AddHalls() 
        {

        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var personal = Personal.GetPersonal(LoginTextBox.Text.Trim(), GetHash(PasswordBox.Password.Trim()));

            if (personal != null)
            {
                if (personal.Role.ID == 1)
                {
                    SeanceCreator window = new SeanceCreator(personal);
                    window.Show();
                    this.Close();
                }
                else if (personal.Role.ID == 2)
                {
                    MainWindow window = new MainWindow(personal);
                    window.Show();
                    this.Close();
                }
            }
        }


            private string GetHash(string input)
            {
                var data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (var i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
                return sBuilder.ToString();
            }
        }
    } 

