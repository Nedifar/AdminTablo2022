using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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
using static System.Net.WebRequestMethods;

namespace AdminTabloNetCore.Models
{
    /// <summary>
    /// Логика взаимодействия для AddAdminsToShedule.xaml
    /// </summary>
    public partial class AddAdminsToShedule : Window
    {
        Models.MonthYear year;

        public AddAdminsToShedule(Models.MonthYear abs)
        {
            InitializeComponent();
            year = abs;
            loadCB();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            var selectedSupervisior = cbAdmins.SelectedItem as Models.SupervisorShedule;
            year.SupervisorShedules.Add(selectedSupervisior);
            context.GetContext().SaveChanges();
            Close();
        }

        private void clNoneList(object sender, RoutedEventArgs e)
        {
            AddAdmin addAdmin = new AddAdmin(null);
            addAdmin.Show();
            addAdmin.IsVisibleChanged += AddAdmin_IsVisibleChanged;
        }

        private void AddAdmin_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            loadCB();
        }

        private void loadCB()
        {
            var items = new List<SupervisorShedule>();

            try
            {
                var supervisiors = context.GetContext().SupervisorShedules.ToList();
                foreach (var item in supervisiors)
                {
                    if (year.SupervisorShedules.Contains(item))
                    {

                    }
                    else
                    {
                        items.Add(item);
                    }
                }
                cbAdmins.ItemsSource = items;
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
        }
    }
}
