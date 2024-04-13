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
using Mishlen.dataFiles;

namespace Mishlen.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOrders.xaml
    /// </summary>
    public partial class PageOrders : Page
    {
        public PageOrders()
        {
            InitializeComponent();

            dpDateStart.DisplayDateStart = Convert.ToDateTime("01.01.2000");
            dpDateStart.DisplayDateEnd = DateTime.Now;
            lbOrders.ItemsSource = ConnectHelper.entObj.Order.ToList();
        }

        private void dpDateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dpDateEnd.IsEnabled = true;
            dpDateEnd.DisplayDateStart = dpDateStart.SelectedDate;

            lbOrders.ItemsSource = ConnectHelper.entObj.Order.Where(x => x.DateOrder >= dpDateStart.SelectedDate).ToList();
        }

        private void dpDateEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lbOrders.ItemsSource = ConnectHelper.entObj.Order.Where(x => x.DateOrder >= dpDateStart.SelectedDate && x.DateOrder <= dpDateEnd.SelectedDate).ToList();
        }
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text != "Поиск товара")
                lbOrders.ItemsSource = ConnectHelper.entObj.Order.Where(x => x.ID_Order.ToString().Contains(txbSearch.Text) || x.Product.Name.Contains(txbSearch.Text) ||
                x.ClientFromOrganization.FIO.Contains(txbSearch.Text) || x.CountOrder.ToString().Contains(txbSearch.Text) || x.SumOrder.ToString().Contains(txbSearch.Text)).ToList();
        }

        private void txbSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txbSearch.Text == "Поиск товара")
            {
                txbSearch.Text = null;
                txbSearch.Opacity = 100;
            }

            if (txbSearch.IsFocused == true)
            {
                txbSearch.Text = null;
                txbSearch.Opacity = 100;
            }
        }

        private void txbSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txbSearch.Text.Length < 1 && txbSearch.IsFocused == false)
            {
                txbSearch.Text = "Поиск товара";
                txbSearch.Opacity = 0.9;
            }
        }

        private void txbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txbSearch.Text = "Поиск товара";
            txbSearch.Opacity = 0.9;
        }

        private void txbSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txbSearch.Text = null;
            txbSearch.Opacity = 100;
        }

        private void txbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txbSearch.Text == "Поиск товара")
            {
                txbSearch.Text = null;
                txbSearch.Opacity = 100;
            }

            if (txbSearch.Text != null && txbSearch.Text != "Поиск товара")
            {
                dpDateStart.SelectedDate = null;
                dpDateEnd.SelectedDate= null;
            }
        }
    }
}
