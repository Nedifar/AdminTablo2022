using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminTabloNetCore
{
    /// <summary>
    /// Логика взаимодействия для AdditionalLessonsPage.xaml
    /// </summary>
    public partial class AdditionalLessonsPage : UserControl
    {
        public ObservableCollection<AdditionalLessonsModels.SheduleAdditionalLesson> SheduleAdditionalLessons { get; set; } = new(Models.context.GetContext().SheduleAdditionalLessons.ToList());

        public AdditionalLessonsPage()
        {
            InitializeComponent();

            lvSheduleAdditionalLessons.ItemsSource = SheduleAdditionalLessons;
        }
    }
}
