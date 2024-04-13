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
using Mishlen.dataFiles;

namespace Mishlen.Pages.EditInfo
{
    /// <summary>
    /// Логика взаимодействия для WindowEditProduct.xaml
    /// </summary>
    public partial class WindowEditProduct : Window
    {
        private int productId = PageMain.GetIdProduct();
        public WindowEditProduct()
        {
            InitializeComponent();
            var product = ConnectHelper.entObj.Product.SingleOrDefault(x => x.ID_Product == productId);

            txbName.Text = product.Name;
            txbCategory.Text = product.Category;
            txbCountInStrock.Text = product.CountInStrock.ToString();
            txbPrice.Text = product.Price.ToString();


            cmbProductType.SelectedItem = ConnectHelper.entObj.ProductType.SingleOrDefault(x => x.ID_ProductType == product.id_ProductType);
            cmbProductType.SelectedValuePath = "ID_ProductType";
            cmbProductType.DisplayMemberPath = "Name";
            cmbProductType.ItemsSource = ConnectHelper.entObj.ProductType.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txbName.Text.Length < 1 && txbCategory.Text.Length < 1 && txbCountInStrock.Text.Length < 1 && txbPrice.Text.Length < 1 && cmbProductType.SelectedValue == null)
                MessageBox.Show("Данные не могут быть пустыми", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if(txbName.Text.Length < 1)
                MessageBox.Show("Заполните Наименование", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbCategory.Text.Length < 1 )
                MessageBox.Show("Заполните Категорию", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbCountInStrock.Text.Length < 1 )
                MessageBox.Show("Заполните кол-во", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbPrice.Text.Length < 1)
                MessageBox.Show("Заполните Цену", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if(cmbProductType.SelectedValue == null)
                MessageBox.Show("Выберите тип", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (ConnectHelper.entObj.Product.Where(x => x.Name == txbName.Text && x.Category == txbCategory.Text && x.CountInStrock.ToString() == txbCategory.Text &&
            x.Price.ToString() == txbPrice.Text).Count() > 0)
                MessageBox.Show("Такой товар уже есть!", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                try
                {
                    Product product = ConnectHelper.entObj.Product.SingleOrDefault(x => x.ID_Product == productId);
                    product.Name = txbName.Text;
                    product.Category = txbCategory.Text;
                    product.Price = int.Parse(txbPrice.Text);
                    product.CountInStrock = int.Parse(txbCountInStrock.Text);
                    product.id_ProductType = (int)cmbProductType.SelectedValue;
                    ConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }
    }
}
