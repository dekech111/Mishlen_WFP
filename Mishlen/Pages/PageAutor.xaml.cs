using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Mishlen.dataFiles;

namespace Mishlen.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAutor.xaml
    /// </summary>
    public partial class PageAutor : Page
    {
        bool passShow = false;
        public PageAutor()
        {
            InitializeComponent();            
        }

        private void pbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txbPass.Text = pbPass.Password;
        }

        private void btneyes_Click(object sender, RoutedEventArgs e)
        {
            if (!passShow)
            {
                pbPass.Visibility = Visibility.Collapsed;
                txbPass.Visibility = Visibility.Visible;
                passShow = true;
            }
            else
            {
                pbPass.Visibility = Visibility.Visible;
                txbPass.Visibility = Visibility.Collapsed;
                passShow = false;
            }
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (pbPass.Password == "1111" || txbPass.Text == "1111")
            {
                FrameApp.frmObj.Navigate(new PageMain());
            }
            else
                MessageBox.Show("Не правильный пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
