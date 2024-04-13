using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Mishlen.dataFiles;
using Mishlen.Pages.EditInfo;

namespace Mishlen.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        MainWindow Form = Application.Current.Windows[0] as MainWindow;
        private static Product product;
        private static int idProduct;
        public PageMain()
        {
            InitializeComponent();
            Form.spMenu.Visibility = Visibility.Visible;
            Form.ButtonSettings.Visibility = Visibility.Visible;

            cmbFilt.Items.Add("Товар от 1 до 20 шт");
            cmbFilt.Items.Add("Товар от 20 до 50 шт");
            cmbFilt.Items.Add("Товар от 50 до 100 шт");
            cmbFilt.Items.Add("Товар от 100 шт");
            cmbFilt.Items.Add("Показать все");

            cmbSort.SelectedValuePath = "ID_ProductType";
            cmbSort.DisplayMemberPath = "Name";
            cmbSort.ItemsSource = ConnectHelper.entObj.ProductType.ToList();

            lbProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text != "Поиск товара")
                lbProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductType.Name.Contains(txbSearch.Text) || x.Category.Contains(txbSearch.Text) ||
                x.Name.Contains(txbSearch.Text) || x.Price.ToString().Contains(txbSearch.Text)).ToList();
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
            if(txbSearch.Text.Length <1 && txbSearch.IsFocused == false)
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
                cmbFilt.SelectedIndex = -1;
                cmbSort.SelectedIndex = -1;
            }
        }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilt.SelectedIndex == 0)
                lbProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.CountInStrock > 0 && x.CountInStrock < 20).ToList();
            else if (cmbFilt.SelectedIndex == 1)
                lbProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.CountInStrock > 20 && x.CountInStrock < 50).ToList();
            else if (cmbFilt.SelectedIndex == 2)
                lbProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.CountInStrock > 50 && x.CountInStrock < 100).ToList();
            else if(cmbFilt.SelectedIndex == 3)
                lbProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.CountInStrock > 100).ToList();
            else
            {
                lbProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
                cmbSort.SelectedIndex = -1;
                txbSearch.Text = "Поиск товара";
                txbSearch.Opacity = 0.9;
                cmbFilt.SelectedIndex = -1;
            }
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbSort.SelectedIndex != -1)
            lbProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.id_ProductType == (int)cmbSort.SelectedValue).ToList();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            product = lbProduct.SelectedItem as Product;
            if (product == null)
                MessageBox.Show("Выберите товар", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                ConnectHelper.entObj.Product.Remove(product);
                ConnectHelper.entObj.SaveChanges();
                lbProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            product = lbProduct.SelectedItem as Product;
            if (product == null)
                MessageBox.Show("Выберите товар", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                idProduct = product.ID_Product;
                WindowEditProduct  windowEditProduct = new WindowEditProduct();
                windowEditProduct.ShowDialog();
                lbProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
            }
        }

        public static int GetIdProduct()
        {
            return idProduct;
        }
    }
}
