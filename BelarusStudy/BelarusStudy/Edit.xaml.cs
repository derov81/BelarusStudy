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
using System.IO;

namespace BelarusStudy
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private List<Question> list;


        public Edit()
        {
            InitializeComponent();
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            list = new List<Question>();
            using (StreamReader sr = new StreamReader(@"..\..\images\answers.txt"/*, Encoding.GetEncoding(1251)*/))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parsed = line.Split('|'); //Делим строку по символу &, например
                    list.Add(new Question(parsed[0], parsed[1]));
                }
            }
            editGrid.ItemsSource = list;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            /* editGrid.SelectAllCells();
             editGrid.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
             ApplicationCommands.Copy.Execute(null, editGrid);
             editGrid.UnselectAllCells();
             string path1 = @"..\..\images\answers.txt";
             string result1 = (string)Clipboard.GetText(TextDataFormat.Text);
             Clipboard.Clear();
             StreamWriter stream = new StreamWriter(path1);
             stream.WriteLine(result1);
             stream.Close();*/

           // File.WriteAllText(@"..\..\images\answers.txt",txb.Text);


        }
    }
}
