using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Security.Cryptography;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace AdminTabloNetCore.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthForm.xaml
    /// </summary>
    public partial class AuthForm : Window
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private async void clSign(object sender, RoutedEventArgs e)
        {
            string pwd = String.Empty;
            if (spPasNoVisible.Visibility == Visibility.Visible) { pwd = pbPas.Password; }
            else { pwd = tbPas.Text; }
            using (var md5Hash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(pwd);
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                var hash = BitConverter.ToString(hashBytes);
                var user = Models.context.GetContext().Users.FirstOrDefault(p => p.PasHash == hash);
                try
                {
                    using (var http = new HttpClient())
                    {
                        var repsonse = await http.PostAsync("http://infotab.okeit.edu/infotabloserver/api/adminpanel/auth", hash, new JsonMediaTypeFormatter());
                        var result = repsonse.Content.ReadAsStringAsync().Result;
                        if (result == "Данные корректны")
                        {
                            MessageBox.Show("Добро пожаловать в панель администратора, .", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            new MainWindow().Show();
                            Close();
                        }
                        else { MessageBox.Show("Проверьте корректность введенных данных."); }
                    }
                }
                catch
                {
                    MessageBox.Show("Отсутствует подключение к серверу.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void pbPas_PasswordChanged(object sender, RoutedEventArgs e)
        {
            tbPas.Text = pbPas.Password;
        }


        private void clVisibleCollapsePassword(object sender, RoutedEventArgs e)
        {
            if (spPasNoVisible.Visibility == Visibility.Visible)
            {
                tbPas.Text = pbPas.Password;

                spPasNoVisible.Visibility = Visibility.Collapsed;
                spPasVisible.Visibility = Visibility.Visible;
            }
            else
            {
                spPasVisible.Visibility = Visibility.Collapsed;
                spPasNoVisible.Visibility = Visibility.Visible;
                pbPas.Password = tbPas.Text;
            }
        }
    }
}
