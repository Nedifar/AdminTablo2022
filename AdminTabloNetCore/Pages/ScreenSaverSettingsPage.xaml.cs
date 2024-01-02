using AdminTabloNetCore.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace AdminTabloNetCore.Pages
{
    public partial class ScreenSaverSettingsPage : UserControl
    {
        private readonly string baseAddress = "http://192.168.147.58:86/infotabloserver/";
        public string backPlayerSource { get; set; }
        private List<SpecialBackgroundPhoto> _specialPhotoes;

        public ScreenSaverSettingsPage()
        {
            InitializeComponent();
            DataContext = this;
            cbBackgroundType.ItemsSource = new string[] { "Основное", "Особое" };
            FirstDataLoad();
            cbBackgroundType.SelectedIndex = 0;
        }

        private void FirstDataLoad()
        {
            context.RestartContext();
            var todayBack = context.GetContext().SpecialBackgroundPhotos.
                ToList()
                .FirstOrDefault(p => p.targetDate.HasValue
                && dpBack.SelectedDate.HasValue
                && p.targetDate.Value.ToShortDateString() == dpBack.SelectedDate.Value.ToShortDateString());
            string url = baseAddress + (todayBack == null
                ? context.GetContext().SpecialBackgroundPhotos.FirstOrDefault(p => p.targetDate == null).fileName
                : todayBack.fileName);
            cbBackgroundType.SelectedIndex = todayBack == null
                ? 0
                : 1;
            meBackPlayer.Source = null;
            meBackPlayer.Source = new Uri(url);
            meBackPlayer.Play();
        }

        private void TypeChanged(object sender, SelectionChangedEventArgs e)
        {
            dpBack.Visibility = cbBackgroundType.SelectedIndex == 0
                ? Visibility.Collapsed
                : Visibility.Visible;
            if (cbBackgroundType.SelectedIndex == 0)
            {
                dpBack.SelectedDate = null;
                meBackPlayer.Source = new Uri(baseAddress + context.GetContext().SpecialBackgroundPhotos.FirstOrDefault(p => p.targetDate == null).fileName);
            }
            else
            {
                dpBack.SelectedDate = DateTime.Now;
            }
        }

        private async void ClSelectMediaFile(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new();
                fileDialog.Filter = "Media files (*.jpeg;*.jpg;*.png;*.mp4)|*.jpeg;*.jpg;*.png;*.mp4";
                if (fileDialog.ShowDialog() == true)
                {
                    using var form = new MultipartFormDataContent();
                    using var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(fileDialog.FileName));
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    form.Add(fileContent, "uploadFile", System.IO.Path.GetFileName(fileDialog.FileName));
                    if (cbBackgroundType.SelectedIndex == 0)
                        form.Add(new StringContent("Main"), "typeUpload");
                    else
                    {
                        form.Add(new StringContent("Other"), "typeUpload");
                        form.Add(new StringContent(dpBack.SelectedDate.Value.ToShortDateString()), "dateTarget");
                    }
                    using (var http = new HttpClient())
                    {
                        var response = await http.PostAsync(baseAddress + "tabloapi/upload", form);
                        response.EnsureSuccessStatusCode();
                    }
                    FirstDataLoad();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка подлкючения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ScreenSizeChanged(object sender, SizeChangedEventArgs e)
        {
            meBackPlayer.Height = (sender as UserControl).ActualHeight - 180;
        }

        private void CurrentDateChanged(object sender, SelectionChangedEventArgs e)
        {
            context.RestartContext();
            var todayPhoto = context.GetContext().SpecialBackgroundPhotos.FirstOrDefault(p =>
            p.targetDate.HasValue
            && dpBack.SelectedDate.HasValue
            && p.targetDate.Value.Date == dpBack.SelectedDate.Value.Date
            )
                ?? new SpecialBackgroundPhoto();
            meBackPlayer.Source = null;
            meBackPlayer.Source = todayPhoto.fileName == ""
                ? null
                : new Uri(baseAddress + todayPhoto.fileName);
            meBackPlayer.Play();
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            meBackPlayer.Position = new TimeSpan(0, 0, 1);
            meBackPlayer.Play();
        }
    }
}
