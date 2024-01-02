using AdminTabloNetCore.AdditionalLessonsModels;
using AdminTabloNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace AdminTabloNetCore
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Models.MonthYear abs;
    Models.TimeShedule selectedShedule = new Models.TimeShedule();
    public ObservableCollection<Models.DayPartHeader> DayPartHeaders { get; set; }
    public ObservableCollection<Models.Para> typesInterval { get; set; } = new ObservableCollection<Models.Para>();

    public MainWindow()
    {
      InitializeComponent();
      dgAdmins.ItemsSource = Models.context.GetContext().SupervisorShedules.ToList();
      DayPartHeaders = new ObservableCollection<Models.DayPartHeader>(Models.context.GetContext().DayPartHeaders.OrderBy(p => p.beginTime.Hour).ToList());
      lvNamesHeader.ItemsSource = DayPartHeaders;
      foreach (var item in Models.context.GetContext().TypeIntervals.ToList())
      {
        typesInterval.Add(new Models.Para { TypeInterval = item });
      }
      lvTypes.ItemsSource = typesInterval;
      cbCHKR.ItemsSource = new string[] { "Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
      cbCHKR.SelectedIndex = Models.context.GetContext().SpecialDayWeekNames.FirstOrDefault().dayWeek;
      DayPartHeaders.Add(new Models.DayPartHeader());
      loadAdminsDates();
      loadDataGrid();
      try
      {
        deleteOldLabels();
      }
      catch { MessageBox.Show("Проверьте подлкючение."); this.Close(); }
      cbShedule.ItemsSource = new string[] { "Основное", "ЧКР", "Особый" };
      dgAcc.ItemsSource = Models.context.GetContext().Announcements
          .OrderByDescending(p => p.Priority)
          .ThenByDescending(p => p.idAnnouncement)
          .ToList();

      gridAdditionalLessons.Children.Add(new AdditionalLessonsPage());
      gridScreenSaver.Children.Add(new Pages.ScreenSaverSettingsPage());
    }

    private void dpPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {
      if (dpPicker.SelectedDate == null)
      { return; }
      string lsls = dpPicker.SelectedDate.Value.ToShortDateString();
      var newDateShedule = new Models.TimeShedule()
      {
        Name = dpPicker.SelectedDate.Value.ToString("dd.MM.yyyy")
      };
      foreach (var item in Models.context.GetContext().TimeShedules.FirstOrDefault(p => p.Name == "Основной").Paras?.OrderBy(p => p.numberInList))
      {
        newDateShedule.Paras.Add(new Models.Para(item));
      }
      Fill(Models.context.GetContext().TimeShedules.FirstOrDefault(p => p.Name == lsls) ?? newDateShedule);
    }

    private void cbShedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (cbShedule.SelectedIndex == 1)
      {
        dpPicker.Visibility = Visibility.Collapsed;
        Fill(Models.context.GetContext().TimeShedules.FirstOrDefault(p => p.Name == "ЧКР") ?? new Models.TimeShedule() { Name = "ЧКР" });
      }
      else if (cbShedule.SelectedIndex == 2)
      {
        dpPicker.Visibility = Visibility.Visible;
        dpPicker.SelectedDate = null;
        Fill(new Models.TimeShedule());
      }
      else
      {
        dpPicker.Visibility = Visibility.Collapsed;
        Fill(Models.context.GetContext().TimeShedules.FirstOrDefault(p => p.Name == "Основной") ?? new Models.TimeShedule() { Name = "Основной" });
      }
    }

    void Fill(Models.TimeShedule shedule)
    {
      selectedShedule = shedule;
      selectedShedule.Paras = new ObservableCollection<Models.Para>(selectedShedule.Paras?.OrderBy(p => p.numberInList));
      lvMainSheduleTime.ItemsSource = selectedShedule.Paras;
    }

    private void clSave(object sender, RoutedEventArgs e)
    {
      try
      {
        int paraCounet = 1;
        int eventCounter = 1;
        int peremenaCounter = 1;
        for (int i = 0; i < selectedShedule.Paras.Count; i++)
        {
          var item = selectedShedule.Paras[i];
          item.numberInterval = (item.TypeInterval.name) switch
          {
            "Пара" => paraCounet++,
            "Перемена" => peremenaCounter++,
            "Событие" => eventCounter++,
            _ => 0
          };

          item.numberInList = i;
        }
        for (int i = 0; i < selectedShedule.Paras.Count() - 1; i++)
        {
          if (selectedShedule.Paras[i].end.TimeOfDay != selectedShedule.Paras[i + 1].begin.TimeOfDay)
          {
            MessageBox.Show("Существует пустой промежуток времени.");
            return;
          }
        }

        for (int i = 0; i < selectedShedule.Paras.Count(); i++)
        {
          if (selectedShedule.Paras[i].idPara == 0)
          {
            Models.context.GetContext().Paras.Add(new Models.Para()
            {
              begin = selectedShedule.Paras[i].begin,
              end = selectedShedule.Paras[i].end,
              guid = selectedShedule.Paras[i].guid,
              Name = selectedShedule.Paras[i].Name,
              idTypeInterval = selectedShedule.Paras[i].TypeInterval.idInterval,
              numberInList = selectedShedule.Paras[i].numberInList,
              numberInterval = selectedShedule.Paras[i].numberInterval,
              idTimeShedule = selectedShedule.idTimeShedule
            });
          }
          else
          {
            context.GetContext().Entry(selectedShedule.Paras[i]).State = EntityState.Modified;
            Models.context.GetContext().SaveChanges();
          }
        }

        if (selectedShedule.idTimeShedule == 0)
          Models.context.GetContext().TimeShedules.Add(selectedShedule);
        Models.context.GetContext().SaveChanges();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Пожалуйста, проверьте данные на корректность.");
      }
    }

    private async void checkActive(object sender, RoutedEventArgs e)
    {
      var mod = (sender as CheckBox).DataContext as Models.Announcement;
      var model = Models.context.GetContext().Announcements.FirstOrDefault(p => p.idAnnouncement == mod.idAnnouncement);
      model.isActive = (sender as CheckBox).IsChecked.Value;
      Models.context.GetContext().SaveChanges();
      await SendUpdateInfo("http://192.168.147.58:86/infotabloserver/api/lastdance/update");
    }

    private void clAdd(object sender, RoutedEventArgs e)
    {
      var form = new AddForm(null);
      form.Show();
      form.IsVisibleChanged += Form_IsVisibleChanged;
    }

    private async void Form_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      dgAcc.ItemsSource = Models.context.GetContext().Announcements.OrderByDescending(p => p.Priority).ThenByDescending(p => p.idAnnouncement).ToList();
      using (var http = new HttpClient())
      {
        Models.context.GetContext().SaveChanges();
        await SendUpdateInfo("http://192.168.147.58:86/infotabloserver/api/lastdance/update");
        MessageBox.Show("Сохранение выполнено успешно.");
        Thread.Sleep(3000);
        await SendUpdateInfo("http://192.168.147.58:86/infotabloserver/api/lastdance/update");
      }
    }

    private void clEdit(object sender, RoutedEventArgs e)
    {
      var bing = (sender as Button).DataContext as Models.Announcement;
      var form = new AddForm(bing);
      form.Show();
      form.IsVisibleChanged += Form_IsVisibleChanged;
    }

    private void deleteOldLabels()
    {
      var list = Models.context.GetContext().Announcements.Where(p => p.dateClosed != null && p.dateClosed < DateTime.Now.AddDays(-7)).ToList();
      Models.context.GetContext().RemoveRange(list);
      Models.context.GetContext().SaveChanges();
    }

    void loadAdminsDates()
    {
      cbYear.ItemsSource = new string[] {
                DateTime.Now.AddYears(-1).ToString("yyyy"),
                DateTime.Now.ToString("yyyy"),
                DateTime.Now.AddYears(1).ToString("yyyy")
            };

      cbMonths.ItemsSource = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12);
      cbYear.SelectedItem = DateTime.Now.ToString("yyyy");
      cbMonths.SelectedItem = DateTime.Now.ToString("MMMM").ToLower();
    }

    void loadDataGrid()
    {
      dg.Columns.Clear();
      int year = int.Parse(cbYear.SelectedItem.ToString());
      int month = cbMonths.SelectedIndex + 1;
      dg.Columns.Add(new DataGridTextColumn
      {
        IsReadOnly = false,
        Header = "",
        Binding = new Binding("NameSupervisor")
      });
      dg.Columns.Add(new DataGridTextColumn
      {
        Header = "Должность",
        Binding = new Binding($"position")
      });
      for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
      {
        CheckBox checkBox = new CheckBox();
        Style style = new Style() { };
        style = (Style)Resources["kk"];
        dg.Columns.Add(new DataGridCheckBoxColumn
        {
          Header = $"{i}",
          Binding = new Binding($"dd.d{i}")
          {
            Mode = BindingMode.TwoWay
          },
          CellStyle = (Style)Resources["kk"]
        });
      }
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
      //var mooo = dg.SelectedItem as Models.DatesSupervisior;
      //Models.context.GetContext().SaveChanges();
    }

    private void df(object sender, DataGridRowEditEndingEventArgs e)
    {
      // Models.context.GetContext().SaveChanges();

    }

    private void save(object sender, RoutedEventArgs e)
    {
      Models.context.GetContext().SaveChanges();
    }

    private void chang(object sender, SelectionChangedEventArgs e)
    {
      abs = null;
      if (cbMonths.SelectedIndex == -1)
        return;
      try
      {
        int year = Convert.ToInt32(cbYear.SelectedItem);
        int month = cbMonths.SelectedIndex + 1;
        Models.DefaultClass.date = new DateTime(year, month, 1);
        loadDataGrid();
        abs = Models.context.GetContext().MonthYear.FirstOrDefault(p => p.date == Models.DefaultClass.date);
        if (abs == null)
        {
          var item = new Models.MonthYear { date = Models.DefaultClass.date };
          Models.context.GetContext().MonthYear.Add(item);
          Models.context.GetContext().SaveChanges();
          abs = Models.context.GetContext().MonthYear.FirstOrDefault(p => p.date == Models.DefaultClass.date);
        }
        ObservableCollection<Models.SupervisorShedule> supervisorShedules = new ObservableCollection<Models.SupervisorShedule>();
        foreach (var item in abs.SupervisorShedules.ToList())
        {
          supervisorShedules.Add(item);
        }
        dg.ItemsSource = supervisorShedules;
      }
      catch { }
    }

    private void clAddAdmin(object sender, RoutedEventArgs e)
    {
      Models.AddAdminsToShedule addAdminsTo = new Models.AddAdminsToShedule(abs);
      addAdminsTo.Show();
      addAdminsTo.IsVisibleChanged += AddAdminsTo_IsVisibleChanged;
    }

    private void AddAdminsTo_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      chang(null, null);
    }

    private void clEditAdmin(object sender, RoutedEventArgs e)
    {
      var send = (sender as Button).DataContext as Models.SupervisorShedule;
      Models.AddAdmin add = new Models.AddAdmin(send);
      add.Show();
      add.IsVisibleChanged += Add_IsVisibleChanged;
    }

    private void Add_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      dgAdmins.ItemsSource = Models.context.GetContext().SupervisorShedules.ToList();
    }

    private void clDeleteAdmin(object sender, RoutedEventArgs e)
    {
      if (dgAdmins.SelectedItems.Count == 1)
      {
        Models.context.GetContext().SupervisorShedules.Remove(dgAdmins.SelectedItem as Models.SupervisorShedule);
        Models.context.GetContext().SaveChanges();
        dgAdmins.ItemsSource = Models.context.GetContext().SupervisorShedules.ToList();
        MessageBox.Show("Успешно удалено!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
      }
    }

    private void clAddAdmins(object sender, RoutedEventArgs e)
    {
      Models.AddAdmin add = new Models.AddAdmin(null);
      add.Show();
      add.IsVisibleChanged += Add_IsVisibleChanged;
    }

    private async void clDeleteAnnounc(object sender, RoutedEventArgs e)
    {
      if (dgAcc.SelectedItems.Count == 1)
      {
        Models.context.GetContext().Announcements.Remove(dgAcc.SelectedItem as Models.Announcement);
        Models.context.GetContext().SaveChanges();
        dgAcc.ItemsSource = Models.context.GetContext().Announcements.OrderByDescending(p => p.Priority).ThenByDescending(p => p.idAnnouncement).ToList();
        await SendUpdateInfo("http://192.168.147.58:86/infotabloserver/api/lastdance/update");
      }
      else
        MessageBox.Show("Пожалуйста, выберите объявление для удаления.");
    }

    private async Task SendUpdateInfo(string url)
    {
      try
      {
        var http = new HttpClient();
        var response = await http.GetAsync(url);
        response.EnsureSuccessStatusCode();
      }
      catch { }
    }

    private void clSaveDayPartHeaders(object sender, RoutedEventArgs e)
    {
      if (!(DayPartHeaders.Last().Header == null
          && DayPartHeaders.Last().beginTime == new DateTime()
          && DayPartHeaders.Last().endTime == new DateTime()))
      {
        Models.context.GetContext().DayPartHeaders.Add(DayPartHeaders.Last());
        DayPartHeaders.Add(new Models.DayPartHeader());
      }
      foreach (var header in DayPartHeaders)
      {
        if (header.Header != null)
        {
          context.GetContext().Entry(header).State = EntityState.Modified;
          Models.context.GetContext().SaveChanges();
        }
      }
      Models.context.GetContext().SaveChanges();
    }

    private void clDeleteHeaderPartDat(object sender, RoutedEventArgs e)
    {
      var obj = (sender as Button).DataContext as Models.DayPartHeader;
      var resultMessageBox = MessageBox.Show("Предупреждение", "Вы дейстивтельно хотите совершить удаление?", MessageBoxButton.OKCancel);
      if (resultMessageBox == MessageBoxResult.OK)
      {
        Models.context.GetContext().DayPartHeaders.Remove(obj);
        DayPartHeaders.Remove(obj);
      }
    }

    private void cbCHKR_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      Models.context.GetContext().SpecialDayWeekNames.FirstOrDefault().dayWeek = (sender as ComboBox).SelectedIndex;
    }

    private void clDeletePara(object sender, RoutedEventArgs e)
    {
      var obj = (sender as Button).DataContext as Models.Para;
      var resultMessageBox = MessageBox.Show("Предупреждение", "Вы дейстивтельно хотите совершить удаление?", MessageBoxButton.OKCancel);
      if (resultMessageBox == MessageBoxResult.OK)
      {
        if (obj.idPara != 0)
        {
          Models.context.GetContext().Paras.Remove(obj);
          Models.context.GetContext().Paras.Remove(obj);
        }
        selectedShedule.Paras.Remove(obj);
      }
    }
  }
}
