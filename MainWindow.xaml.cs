using Api_Yandex_True.Classes;
using Api_Yandex_True.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Api_Yandex_True
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataResponce responce;
        public MainWindow()
        {
            InitializeComponent();
            Iint();
        }
        public async void Iint()
        {
            responce = await GetWeather.Get(58.01261f, 56.25439f);
            foreach (Forecast forecast in responce.forecasts)
                Days.Items.Add(forecast.date.ToString("dd.MM.yyyy"));
            Create(0);
        }
        public void Create(int idForrecast)
        {
            parent.Children.Clear();
            foreach (Hour hour in responce.forecasts[idForrecast].hours)
            {
                parent.Children.Add(new Elements.Item(hour));
            }
        }

        private void SelectDay(object sender, SelectionChangedEventArgs e)
        {
            Create(Days.SelectedIndex);
        }

        private void UpdateWeather(object sender, RoutedEventArgs e)
        {
            Iint();
        }
    }
}
