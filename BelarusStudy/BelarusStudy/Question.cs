using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BelarusStudy
{
   public class Question
    {
        //Изображения для View
        public BitmapImage Picture { get; set; }

        //Правильный ответ
        public string Answer { get; set; }

        /// Создание вопроса
        /// <param name="PathBitmapImageSource">Путь к изображению</param> 
        /// <param name="AnswerSource">Ответ</param> 

        public Question( string PathBitmapImageSource, string AnswerSource)
        {
            this.Picture = new BitmapImage();
            this.Picture.BeginInit();
            this.Picture.UriSource = new Uri(PathBitmapImageSource, UriKind.Relative);
            this.Picture.EndInit();
            this.Answer = AnswerSource;

        }
    }
}
