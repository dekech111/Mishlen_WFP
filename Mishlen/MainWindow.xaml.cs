using Mishlen.dataFiles;
using Mishlen.Pages;
using System.Windows;


namespace Mishlen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            spMenu.Visibility = Visibility.Collapsed;
            ButtonSettings.Visibility = Visibility.Collapsed;
            ConnectHelper.entObj = new MichelinEntities();
            FrameApp.frmObj = FrmMain;
            FrameApp.frmObj.Navigate(new PageAutor());
        }

        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageOrders());
        }

        private void ButtonClients_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageClients());
        }

        private void ButtonProducts_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageMain());
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            WindowAddInfo windowAddInfo = new WindowAddInfo();
            windowAddInfo.ShowDialog();

        }
    }
}
