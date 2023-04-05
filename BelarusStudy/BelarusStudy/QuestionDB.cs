using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BelarusStudy
{
    class QuestionDB
    {
        //Коллекция вопросов
        private List<Question> db;

        //Индекс текущего вопроса
        private int index;

        //текущий вопрос
        public Question CurrectQuestion
        {
            get
            {
                index++;
                return db[index % db.Count];
            }
        }

        //Создание QuestionDB
        public QuestionDB()
        {
            this.db = new List<Question>();
            this.index = 0;

            var dataFile = File.ReadAllLines(@"..\..\images\answers.txt");

            foreach (var e in dataFile)
            {
                var args = e.Split('|');
                db.Add(new Question(args[0], args[1]));
            }
        }
    }
}
