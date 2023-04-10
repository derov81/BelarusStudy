using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace BelarusStudy
{
    class MainLogic
    {
        private StackPanel spAnswers;
        Image image;
        string currenctAnswer;
        QuestionDB data;

        /// Создание TextBlock для отображения алфавита
        /// <param name="Txt">текст для отображения</param> 
        /// <param name="ToSp">StackPanel для отображения TextBlock</param> 
        private TextBlock CreateTb(string Txt, StackPanel ToSp)
        {
            var tb = new TextBlock()
            {
                Text = Txt,
                FontSize = 25,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(3),
                Background = Brushes.Coral,
                Width = 30,
                Height = 40,

            };

            tb.MouseDown += (s, e) =>
            {
                ToSp.Children.Add(CreateTbAlp((s as TextBlock).Text, ToSp));
               
                CheckAnswer();
            };

            return tb;

        }

        /// Создание TextBlock для отображения ответов
        /// <param name="Txt">текст для отображения</param> 
        /// <param name="ToSp">StackPanel для отображения TextBlock</param> 
        private TextBlock CreateTbAlp(string Txt, StackPanel stackPanel)
        {
            var tb = new TextBlock()
            {
                Text = Txt,
                FontSize = 30,
                Background = Brushes.LightBlue,
                Margin = new Thickness(3),
                Padding = new Thickness(10),

            };

            tb.MouseDown += (s, e) =>
            {
                stackPanel.Children.Remove(s as TextBlock);

            };

            return tb;

        }

        //Проверка ответа
        public void CheckAnswer()
        {
            string word = String.Empty;
            foreach (var e in spAnswers.Children)
                
                word += (e as TextBlock).Text;
           
            if (word == currenctAnswer)
                 {
                Success();
                LoadNewQuestion();
                } 


        }

        public void Success()
        {
            Success success = new Success();
            success.ShowDialog();
        }


        //Загрузка вопроса (картинка и сохранения ответа)
        private void LoadNewQuestion()
        {
            var q = data.CurrectQuestion;
            image.Source = q.Picture;
            currenctAnswer = q.Answer;
            spAnswers.Children.Clear();
        }

      

        /// Создание класса с основной логикой приложения
        /// <param name="SPAlphabet">ссылка StackPanel для отбражения алфавита</param> 
        /// <param name="SPAnswer">ссылка StackPanel для отбражения ответа</param>
        /// <param name="ImageView">ссылка Шьфпу для отбражения изображения</param>
        public MainLogic(StackPanel SPAlphabet, StackPanel SPAnswers, Image ImageView)
        {
            data = new QuestionDB();
            image = ImageView;
            spAnswers = SPAnswers;
            

            for (int i = (int)'а'; i <= (int)'я'; i++)
            {
                SPAlphabet.Children.Add(CreateTb($"{(char)i}",SPAnswers));
                if(i == (int)'е')
                {
                    SPAlphabet.Children.Add(CreateTb($"{'ё'}", SPAnswers));
                }

                if (i == (int)'з')
                {
                    SPAlphabet.Children.Add(CreateTb($"{'і'}", SPAnswers));
                   
                }

                if (i == (int)'и')
                {
                    SPAlphabet.Children.RemoveAt(10);
                }

                if (i == (int)'у')
                {
                    SPAlphabet.Children.Add(CreateTb($"{'ў'}", SPAnswers));

                }

                if (i == (int)'щ')
                {               
                    SPAlphabet.Children.RemoveAt(27);              
                }

                if (i == (int)'ъ')
                {
                    SPAlphabet.Children.RemoveAt(27);
                }

                if (i == (int)'я')
                {
                    SPAlphabet.Children.Add(CreateTb($"{'\''}", SPAnswers));

                }

            
            }

            
            LoadNewQuestion();
        }
    }
}
