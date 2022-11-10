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

namespace AdminTabloNetCore
{
    /// <summary>
    /// Логика взаимодействия для AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        Models.Announcement announcement = new Models.Announcement();
        public AddForm(Models.Announcement selannouncement)
        {
            InitializeComponent();
            cbPriority.ItemsSource = new string[] { "Обычное", "Важное" };
            if (selannouncement != null)
            {
                announcement = selannouncement;
                dpDate.SelectedDate = announcement.dateClosed;
                tpTime.SelectedTime = announcement.dateClosed;
                dpDateBegin.SelectedDate = announcement.dateAdded;
                tpDateBegin.SelectedTime = announcement.dateAdded;
                radios.Visibility = Visibility.Collapsed;
                rbDate.IsChecked = true;
                cbPriority.SelectedIndex = int.Parse(announcement.Priority);
                cbToTop.Visibility = Visibility.Visible;
            }
            DataContext = announcement;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            announcement.Priority = cbPriority.SelectedIndex.ToString();
            if (announcement.idAnnouncement != 0)
            {
                if (dpDateBegin.SelectedDate.HasValue)
                {
                    announcement.dateAdded = dpDateBegin.SelectedDate.Value;
                    if (tpDateBegin.SelectedTime.HasValue)
                        announcement.dateAdded=announcement.dateAdded.AddMinutes(tpDateBegin.SelectedTime.Value.Minute).AddHours(tpDateBegin.SelectedTime.Value.Hour);
                }
                if (cbToTop.IsChecked == true)
                    announcement.dateAdded = DateTime.Now;
                announcement.dateClosed = dpDate.SelectedDate;
                try
                {

                    if (tpTime.SelectedTime != null || spPeriod.Visibility == Visibility.Visible)
                        announcement.dateClosed = rbPeriod.IsChecked.Value == true ? announcement.dateClosed.Value.AddHours(int.Parse(tbPeriod.Text)) : dpDate.SelectedDate.Value.AddMinutes(tpTime.SelectedTime.Value.Minute).AddHours(tpTime.SelectedTime.Value.Hour);
                }
                catch { MessageBox.Show(@"Если вы хотите создать бессрочное объвление, то выберите пункт ""До даты"" и оставьте поля пустыми или выберите корректный период жизни объявления. "); return; }
                //if (announcement.dateClosed != null)
                //    announcement.dateClosed.Value.AddMinutes(tpTime.SelectedTime.Value.Minute).AddHours(tpTime.SelectedTime.Value.Hour);
            }
            else
            {
                if (dpDateBegin.SelectedDate.HasValue)
                {
                    announcement.dateAdded = dpDateBegin.SelectedDate.Value;
                    if (tpDateBegin.SelectedTime.HasValue)
                        announcement.dateAdded = announcement.dateAdded.AddMinutes(tpDateBegin.SelectedTime.Value.Minute).AddHours(tpDateBegin.SelectedTime.Value.Hour);
                }
                else
                    announcement.dateAdded = DateTime.Now;
                try
                {
                    if (tpTime.SelectedTime != null || spPeriod.Visibility == Visibility.Visible)
                        announcement.dateClosed = rbPeriod.IsChecked.Value == true ? announcement.dateAdded.AddHours(int.Parse(tbPeriod.Text)) : dpDate.SelectedDate.Value.AddMinutes(tpTime.SelectedTime.Value.Minute).AddHours(tpTime.SelectedTime.Value.Hour);
                    announcement.isActive = true;
                }
                catch { MessageBox.Show(@"Если вы хотите создать бессрочное объвление, то выберите пункт ""До даты"" и оставьте поля пустыми или выберите корректный период жизни объявления. "); return; }
                Models.context.GetContext().Announcements.Add(announcement);
            }
            Models.context.GetContext().SaveChanges();
            Close();
        }
    }
}
