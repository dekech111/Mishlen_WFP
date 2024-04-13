using Mishlen.dataFiles;
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
using System.Windows.Shapes;

namespace Mishlen.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowAddInfo.xaml
    /// </summary>
    public partial class WindowAddInfo : Window
    {
        public WindowAddInfo()
        {
            InitializeComponent();

            cmbOrg.SelectedValuePath = "ID_Organization";
            cmbOrg.DisplayMemberPath = "Name";
            cmbOrg.ItemsSource = ConnectHelper.entObj.Organization.ToList();

            cmbProductType.SelectedValuePath = "ID_ProductType";
            cmbProductType.DisplayMemberPath = "Name";
            cmbProductType.ItemsSource = ConnectHelper.entObj.ProductType.ToList();

            cmbProduct.SelectedValuePath = "ID_Product";
            cmbProduct.DisplayMemberPath = "Name";
            cmbProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();

            cmbClient.SelectedValuePath = "ID_Client";
            cmbClient.DisplayMemberPath = "FIO";
            cmbClient.ItemsSource = ConnectHelper.entObj.ClientFromOrganization.ToList();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (txbName.Text.Length < 1 && txbCategory.Text.Length < 1 && txbCountInStrock.Text.Length < 1 && txbPrice.Text.Length < 1 && cmbProductType.SelectedValue == null)
                MessageBox.Show("Данные не могут быть пустыми", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbName.Text.Length < 1)
                MessageBox.Show("Заполните Наименование", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbCategory.Text.Length < 1)
                MessageBox.Show("Заполните Категорию", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbCountInStrock.Text.Length < 1)
                MessageBox.Show("Заполните кол-во", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbPrice.Text.Length < 1)
                MessageBox.Show("Заполните Цену", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (cmbProductType.SelectedValue == null)
                MessageBox.Show("Выберите тип", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (ConnectHelper.entObj.Product.Where(x => x.Name == txbName.Text && x.Category == txbCategory.Text && x.CountInStrock.ToString() == txbCategory.Text &&
            x.Price.ToString() == txbPrice.Text).Count() > 0)
                MessageBox.Show("Такой товар уже есть!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                try
                {
                    Product product = new Product()
                    {
                        Name = txbName.Text,
                        Category = txbCategory.Text,
                        Price = int.Parse(txbPrice.Text),
                        CountInStrock = int.Parse(txbCountInStrock.Text),
                        id_ProductType = (int)cmbProductType.SelectedValue
                    };
                    ConnectHelper.entObj.Product.Add(product);
                    ConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            if (txbSurname.Text.Length < 1 && txbFirstname.Text.Length < 1 && txbMiddlename.Text.Length < 1 && txbEmail.Text.Length < 1 && txbPhone.Text.Length < 1 && cmbOrg.SelectedValue == null)
                MessageBox.Show("Данные не могут быть пустыми", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbSurname.Text.Length < 1)
                MessageBox.Show("Заполните Фамилию", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbFirstname.Text.Length < 1)
                MessageBox.Show("Заполните Имя", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbMiddlename.Text.Length < 1)
                MessageBox.Show("Заполните Отчетство", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbEmail.Text.Length < 1)
                MessageBox.Show("Заполните Email", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbPhone.Text.Length < 1)
                MessageBox.Show("Заполните Номер телефона", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (cmbOrg.SelectedValue == null)
                MessageBox.Show("Выберите организацию", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (ConnectHelper.entObj.ClientFromOrganization.Where(x => x.Surname == txbSurname.Text && x.Firstname == txbFirstname.Text && x.Middlename == txbMiddlename.Text &&
                x.Phone == txbPhone.Text && x.Email == txbEmail.Text && x.id_Organization == (int)cmbOrg.SelectedValue).Count() > 0)
                MessageBox.Show("Такой пользователь уже есть!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                try
                {
                    ClientFromOrganization clientFromOrganization = new ClientFromOrganization()
                    {
                        Surname = txbSurname.Text,
                        Firstname = txbName.Text,
                        Middlename = txbMiddlename.Text,
                        Phone = txbPhone.Text,
                        Email = txbEmail.Text,
                        id_Organization = (int)cmbOrg.SelectedValue
                    };
                    ConnectHelper.entObj.ClientFromOrganization.Add(clientFromOrganization);
                    ConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (cmbClient.SelectedValue == null && cmbProduct.SelectedValue == null && txbCountOrder.Text.Length < 1)
                MessageBox.Show("Данные не могут быть пустыми", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (cmbClient.SelectedValue == null)
                MessageBox.Show("Выберите клиента", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (cmbProduct.SelectedValue == null)
                MessageBox.Show("Выберите товар", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbCountOrder.Text.Length < 1)
                MessageBox.Show("Заполните количество", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (ConnectHelper.entObj.Order.Where(x => x.id_Client == (int)cmbClient.SelectedValue && x.id_Product == (int)cmbProduct.SelectedValue &&
             x.CountOrder.ToString() == txbCountOrder.Text && x.SumOrder.ToString() == txbSumOrder.Text).Count() > 1)
                MessageBox.Show("Такой заказ уже есть!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                try
                {
                    Order order = new Order()
                    {
                        id_Client = (int)cmbClient.SelectedValue,
                        id_Product = (int)cmbProduct.SelectedValue,
                        CountOrder = Convert.ToInt32(txbCountOrder.Text),
                        SumOrder = Convert.ToInt32(txbSumOrder.Text),
                        DateOrder = DateTime.Now
                    };
                    ConnectHelper.entObj.Order.Add(order);


                    Product product = ConnectHelper.entObj.Product.Where(x => x.ID_Product == (int)cmbProduct.SelectedValue).SingleOrDefault();
                    product.CountInStrock = product.CountInStrock - int.Parse(txbCountOrder.Text);

                    ConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }

        }

        private void txbCountOrder_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbProduct.SelectedValue == null)
                txbWarning.Text = "Выберите товар!";
            else
            {
                var product = ConnectHelper.entObj.Product.SingleOrDefault(x => x.ID_Product == (int)cmbProduct.SelectedValue);

                if (txbCountOrder.Text.Length > 0 && product.CountInStrock < int.Parse(txbCountOrder.Text))
                {
                    txbSumOrder.Text = null;
                    txbWarning.Text = "Такого количества товара нет на складе!";
                    btnAddOrder.IsEnabled = false;
                }
                else if (txbCountOrder.Text.Length > 0)
                {
                    txbSumOrder.Text = (int.Parse(txbCountOrder.Text) * product.Price).ToString();
                    txbWarning.Text = " рублей";
                    btnAddOrder.IsEnabled = true;
                }
                else
                    txbSumOrder.Text = null;
            }
        }

        private void txbCountOrder_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !Char.IsDigit(e.Text, 30))
                e.Handled = true;
        }

        private void cmbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = ConnectHelper.entObj.Product.SingleOrDefault(x => x.ID_Product == (int)cmbProduct.SelectedValue);

            if (product.CountInStrock == 0)
            {
                txbWarning.Text = "Данный товар закончился!";
                btnAddOrder.IsEnabled=false;
            }
            else
            {
                btnAddOrder.IsEnabled = true;
                txbWarning.Text = " Рублей";
            }
        }
    }
}
