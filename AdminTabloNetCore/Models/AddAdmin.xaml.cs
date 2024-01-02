using Microsoft.EntityFrameworkCore;
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

namespace AdminTabloNetCore.Models
{
  /// <summary>
  /// Логика взаимодействия для AddAdmin.xaml
  /// </summary>
  public partial class AddAdmin : Window
  {
    SupervisorShedule supervisor = new SupervisorShedule();
    public AddAdmin(SupervisorShedule supervisorShedule)
    {
      InitializeComponent();
      if (supervisorShedule != null)
      {
        tb.Text = "Редактирование дежурного администратора";
        supervisor = supervisorShedule;
      }
      DataContext = supervisor;
    }

    private void clSave(object sender, RoutedEventArgs e)
    {
      if (!String.IsNullOrWhiteSpace(tbName.Text) && !String.IsNullOrWhiteSpace(tbPosition.Text))
      {
        if (supervisor.idSupervisorShedule == 0)
          context.GetContext().SupervisorShedules.Add(supervisor);
        else
        {
          context.GetContext().Entry(supervisor).State = EntityState.Modified;
        }
        context.GetContext().SaveChanges(); //здесь на сервер

        MessageBox.Show("Информация об администраторе успешно сохранена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        Close();
      }
      else
        MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
  }
}
