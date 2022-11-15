using AdminTabloNetCore.AdditionalLessonsModels;
using MaterialDesignThemes.Wpf;
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

        public AdditionalLessonsModels.Lesson CurrentLesson { get; set; }

        public AdditionalLessonsPage()
        {
            InitializeComponent();

            lvSheduleAdditionalLessons.ItemsSource = SheduleAdditionalLessons;
        }

        private async void clEditDirection(object sender, RoutedEventArgs e)
        {
            var selectedObj = (sender as Button).DataContext as SheduleAdditionalLesson;

            AddSheduleAdditionalLessonModel editAdditional = new()
            {
                name = selectedObj.name,
                durationLesson = selectedObj.durationLesson
            };

            foreach(var item in selectedObj.DayWeeks)
            {
                editAdditional.values.Where(p => p.name == item.name).FirstOrDefault().Checked = true;
            }
            
            var view = new DialogHosts.DirectionControl(editAdditional)
            {

            };
            var result = await DialogHost.Show(view, "RootDialog", null, null);
            if (result as bool? == true)
            {
                selectedObj.name = editAdditional.name;
                selectedObj.durationLesson = editAdditional.durationLesson;

                foreach (var item in editAdditional.values)
                {
                    if (item.Checked && selectedObj.DayWeeks.Where(p => p.name == item.name).Count() == 0)
                    {
                        var findedDayWeek = Models.context.GetContext().DayWeeks.Where(p => p.name == item.name).FirstOrDefault();
                        selectedObj.DayWeeks.Add(findedDayWeek);

                        foreach(var itemTime in selectedObj.Times)
                        {
                            Models.context.GetContext().Lessons.Add(new Lesson { DayWeek = findedDayWeek , Time = itemTime});
                        }
                    }
                    else if(!item.Checked && selectedObj.DayWeeks.Where(p => p.name == item.name).Count() == 1)
                    {
                        selectedObj.DayWeeks.Remove(Models.context.GetContext().DayWeeks.Where(p => p.name == item.name).FirstOrDefault());
                    }
                }
                SaveAndApplyChanges();
            }
        }

        private async void clDeleteDirection(object sender, RoutedEventArgs e)
        {
            var deleteObj = (sender as Button).DataContext as AdditionalLessonsModels.SheduleAdditionalLesson;
            var view = new DialogHosts.ConfirmWindow("Вы дейвствительно хотите удалить выбранное направление?")
            {

            };
            var result = await DialogHost.Show(view, "RootDialog", null, null);
            if (result as bool? == true)
            {
                Models.context.GetContext().SheduleAdditionalLessons.Remove(deleteObj);
                SaveAndApplyChanges();
            }
        }

        private async void clEditTime(object sender, RoutedEventArgs e)
        {
            var selectedTime = (sender as MenuItem).DataContext as AdditionalLessonsModels.Time;
            var view = new DialogHosts.TimeControl()
            {
                DataContext = selectedTime
            };
            var result = await DialogHost.Show(view, "RootDialog", null, null);
            if (result as bool? == true)
            {
                SaveAndApplyChanges();
            }
        }

        private async void clDeleteTime(object sender, RoutedEventArgs e)
        {
            var deleteObj = (sender as MenuItem).DataContext as AdditionalLessonsModels.Time;
            var view = new DialogHosts.ConfirmWindow("Вы дейвствительно хотите удалить выбранное время?")
            {

            };
            var result = await DialogHost.Show(view, "RootDialog", null, null);
            if (result as bool? == true)
            {
                Models.context.GetContext().Times.Remove(deleteObj);
                SaveAndApplyChanges();
            }
        }

        private async void clAddLesson(object sender, RoutedEventArgs e)
        {
            var selectedLesson = (sender as MenuItem).DataContext as AdditionalLessonsModels.Lesson;
            var view = new DialogHosts.LessonControl()
            {
                DataContext = selectedLesson
            };
            var result = await DialogHost.Show(view, "RootDialog", null, null);
            if (result as bool? == true)
            {
                SaveAndApplyChanges();
            }
        }

        private async void clDeleteLesson(object sender, RoutedEventArgs e)
        {
            var selectedLesson = (sender as MenuItem).DataContext as AdditionalLessonsModels.Lesson;
            var view = new DialogHosts.ConfirmWindow("Вы дейвствительно хотите удалить выбранное занятие?")
            {

            };
            var result = await DialogHost.Show(view, "RootDialog", null, null);
            if (result as bool? == true)
            {
                selectedLesson.groupName = null;
                selectedLesson.teacherName = null;
                SaveAndApplyChanges();
            }
        }

        private async void clAddDirection(object sender, RoutedEventArgs e)
        {
            AddSheduleAdditionalLessonModel newAdditional = new();
            newAdditional.values = new(){
                new DayChecked { name = "Понедельник", Checked = true },
            new DayChecked { name = "Вторник", Checked = true },
            new DayChecked { name = "Среда", Checked = true },
            new DayChecked { name = "Четверг", Checked = true },
            new DayChecked { name = "Пятница", Checked = true },
            new DayChecked { name = "Суббота", Checked = false },
            new DayChecked { name = "Воскресенье", Checked = false }};
            var view = new DialogHosts.DirectionControl(newAdditional)
            {

            };
            var result = await DialogHost.Show(view, "RootDialog", null, null);
            if (result as bool? == true)
            {
                var selectedAdditional = new AdditionalLessonsModels.SheduleAdditionalLesson()
                {
                    name = newAdditional.name,
                    durationLesson = newAdditional.durationLesson
                };

                foreach (var item in newAdditional.values)
                {
                    if (item.Checked)
                        selectedAdditional.DayWeeks.Add(Models.context.GetContext().DayWeeks.Where(p => p.name == item.name).FirstOrDefault());
                }

                Models.context.GetContext().SheduleAdditionalLessons.Add(selectedAdditional);
                SaveAndApplyChanges();
            }
        }

        private void SaveAndApplyChanges()
        {
            Models.context.GetContext().SaveChanges();
            SheduleAdditionalLessons = new(Models.context.GetContext().SheduleAdditionalLessons.ToList());
            lvSheduleAdditionalLessons.ItemsSource = SheduleAdditionalLessons;
        }

        private async void clAddTime(object sender, RoutedEventArgs e)
        {
            var selectedAdditional = (sender as Button).DataContext as AdditionalLessonsModels.SheduleAdditionalLesson;
            var newTime = new AdditionalLessonsModels.Time();
            var view = new DialogHosts.TimeControl()
            {
                DataContext = newTime
            };
            var result = await DialogHost.Show(view, "RootDialog", null, null);
            if (result as bool? == true)
            {
                selectedAdditional.Times.Add(newTime);
                foreach (var itemTime in selectedAdditional.DayWeeks)
                {
                    Models.context.GetContext().Lessons.Add(new Lesson { DayWeek = itemTime, Time = newTime });
                }
                SaveAndApplyChanges();
            }
        }
    }
}
