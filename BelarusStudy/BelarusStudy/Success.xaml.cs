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

namespace BelarusStudy
{
    /// <summary>
    /// Логика взаимодействия для Success.xaml
    /// </summary>
    public partial class Success : Window
    {
        public Success()
        {
            InitializeComponent();
            
            Random ran = new Random();
            int i = 0;
            i = ran.Next(0, 7);
            string path = "img/img"+i.ToString()+".jpg";
            img.Source = new BitmapImage(new Uri(path, UriKind.Relative));
           // new QuotesLogic(spBtn, spText, img);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
