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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminTabloNetCore.DialogHosts
{
    /// <summary>
    /// Логика взаимодействия для DirectionControl.xaml
    /// </summary>
    public partial class DirectionControl : UserControl
    {
        AdditionalLessonsModels.AddSheduleAdditionalLessonModel addModel { get; set; }

        public DirectionControl(AdditionalLessonsModels.AddSheduleAdditionalLessonModel add)
        {
            InitializeComponent();
            addModel = add;
            DataContext = addModel;
            cbDays.ItemsSource = addModel.values;
        }
    }
}
