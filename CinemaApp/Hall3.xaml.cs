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

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для Hall3.xaml
    /// </summary>
    public partial class Hall3 : Window
    {
        public Hall3()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private Button lastCheckedButton;
        private Brush lastBrushes;
        private void SeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (lastCheckedButton != null)
                ClearLastSeat(lastCheckedButton);
            var tmp_button = (Button)sender;
            lastBrushes = tmp_button.Background;
            tmp_button.Background = Brushes.Gray;
            lastCheckedButton = tmp_button;

        }

        private void ClearLastSeat(Button btn)
        {
            if (lastBrushes == Brushes.IndianRed)
                btn.Background = Brushes.IndianRed;
            if (lastBrushes == Brushes.Aquamarine)
                btn.Background = Brushes.Aquamarine;
            if (lastCheckedButton.Background != Brushes.IndianRed && lastCheckedButton.Background != Brushes.Aquamarine)
                btn.Background = Brushes.White;

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
            if (lastCheckedButton != null)
            {
                lastCheckedButton.Background = Brushes.IndianRed;
                lastBrushes = lastCheckedButton.Background;
            }
        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            if (lastCheckedButton != null && lastBrushes != Brushes.IndianRed)
            {
                lastCheckedButton.Background = Brushes.Aquamarine;
                lastBrushes = lastCheckedButton.Background;
            }
            else if (lastBrushes == Brushes.IndianRed)
            {
                string message = "Нельзя забронировать купленное место";
                MessageBox.Show(message);
            }
        }
    }
}
