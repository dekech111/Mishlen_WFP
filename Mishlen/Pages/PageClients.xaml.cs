using Mishlen.dataFiles;
using Mishlen.Pages.EditInfo;
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

namespace Mishlen.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageClients.xaml
    /// </summary>
    public partial class PageClients : Page
    {
        private static ClientFromOrganization client;
        private static int idClient;
        public PageClients()
        {
            InitializeComponent();
            cmbSort.SelectedValuePath = "ID_Organization";
            cmbSort.DisplayMemberPath = "Name";
            cmbSort.ItemsSource = ConnectHelper.entObj.Organization.ToList();

            lbClients.ItemsSource = ConnectHelper.entObj.ClientFromOrganization.ToList();
        }
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text != "Поиск клиента")
                lbClients.ItemsSource = ConnectHelper.entObj.ClientFromOrganization.Where(x => x.Organization.Name.Contains(txbSearch.Text) || x.FIO.Contains(txbSearch.Text) ||
                x.Phone.Contains(txbSearch.Text) || x.Email.ToString().Contains(txbSearch.Text)).ToList();
        }

        private void txbSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txbSearch.Text == "Поиск клиента")
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
                txbSearch.Text = "Поиск клиента";
                txbSearch.Opacity = 0.9;
            }
        }

        private void txbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txbSearch.Text = "Поиск клиента";
            txbSearch.Opacity = 0.9;
        }

        private void txbSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txbSearch.Text = null;
            txbSearch.Opacity = 100;
        }

        private void txbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txbSearch.Text == "Поиск клиента")
            {
                txbSearch.Text = null;
                txbSearch.Opacity = 100;
            }

            if (txbSearch.Text != null && txbSearch.Text != "Поиск клиента")
            {
                cmbSort.SelectedIndex = -1;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            client = lbClients.SelectedItem as ClientFromOrganization;
            if (client == null) MessageBox.Show("Запись не выбрана!", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                ConnectHelper.entObj.ClientFromOrganization.Remove(client);
                ConnectHelper.entObj.SaveChanges();
                lbClients.ItemsSource = ConnectHelper.entObj.ClientFromOrganization.ToList();
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
             client = lbClients.SelectedItem as ClientFromOrganization;
            if (client == null) MessageBox.Show("Запись не выбрана!", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                idClient = client.ID_Client;
                WindowEditClient windowEditClient = new WindowEditClient();
                windowEditClient.ShowDialog();
                lbClients.ItemsSource = ConnectHelper.entObj.ClientFromOrganization.ToList();
            }
        }
        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbSort.SelectedIndex != -1)
            lbClients.ItemsSource = ConnectHelper.entObj.ClientFromOrganization.Where(x => x.id_Organization == (int)cmbSort.SelectedValue).ToList();
        }

        private void btnViewAll_Click(object sender, RoutedEventArgs e)
        {
            lbClients.ItemsSource = ConnectHelper.entObj.ClientFromOrganization.ToList();
            txbSearch.Text = "Поиск клиента";
            txbSearch.Opacity = 0.9;
            cmbSort.SelectedIndex = -1;

        }
        public static int GetIdClient()
        {
            return idClient;
        }

    }
}
