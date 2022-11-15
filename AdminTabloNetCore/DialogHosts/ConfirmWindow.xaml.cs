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
    /// Логика взаимодействия для ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : UserControl
    {
        public string text { get; set; }

        public ConfirmWindow(string text)
        {
            InitializeComponent();
            this.text = text;
            DataContext = this;
        }
    }
}
