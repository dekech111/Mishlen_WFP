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
    /// Логика взаимодействия для WindowEditClient.xaml
    /// </summary>
    public partial class WindowEditClient : Window
    {
        private int idClient = PageClients.GetIdClient();
        public WindowEditClient()
        {
            InitializeComponent();
            var clientObj = ConnectHelper.entObj.ClientFromOrganization.SingleOrDefault(x => x.ID_Client == idClient);

            txbSurname.Text = clientObj.Surname;
            txbName.Text = clientObj.Firstname;
            txbMiddlename.Text = clientObj.Middlename;
            txbPhone.Text = clientObj.Phone;
            txbEmail.Text = clientObj.Email;

            cmbOrg.SelectedItem = ConnectHelper.entObj.Organization.SingleOrDefault(x => x.ID_Organization == clientObj.id_Organization);

            cmbOrg.SelectedValuePath = "ID_Organization";
            cmbOrg.DisplayMemberPath = "Name";
            cmbOrg.ItemsSource = ConnectHelper.entObj.Organization.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txbSurname.Text.Length < 1 && txbName.Text.Length < 1 && txbMiddlename.Text.Length < 1 && txbEmail.Text.Length < 1 && txbPhone.Text.Length < 1 && cmbOrg.SelectedValue == null)
                MessageBox.Show("Данные не могут быть пустыми", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbSurname.Text.Length < 1)
                MessageBox.Show("Заполните Фамилию", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbName.Text.Length < 1)
                MessageBox.Show("Заполните Имя", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbMiddlename.Text.Length < 1)
                MessageBox.Show("Заполните Отчетство", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbEmail.Text.Length < 1 )
                MessageBox.Show("Заполните Email", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (txbPhone.Text.Length < 1 )
                MessageBox.Show("Заполните Номер телефона", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (cmbOrg.SelectedValue == null)
                MessageBox.Show("Выберите организацию", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (ConnectHelper.entObj.ClientFromOrganization.Where(x => x.Surname == txbSurname.Text && x.Firstname == txbName.Text && x.Middlename == txbMiddlename.Text &&
                x.Phone == txbPhone.Text && x.Email == txbEmail.Text && x.id_Organization == (int)cmbOrg.SelectedValue).Count() > 0)
                MessageBox.Show("Такой пользователь уже есть!", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                try
                {
                    ClientFromOrganization clientFromOrganization = ConnectHelper.entObj.ClientFromOrganization.SingleOrDefault(x => x.ID_Client == idClient);
                    clientFromOrganization.Surname = txbSurname.Text;
                    clientFromOrganization.Firstname = txbName.Text;
                    clientFromOrganization.Middlename = txbMiddlename.Text;
                    clientFromOrganization.Phone = txbPhone.Text;
                    clientFromOrganization.Email = txbEmail.Text;
                    clientFromOrganization.id_Organization = (int)cmbOrg.SelectedValue;
                    ConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }
    }
}
