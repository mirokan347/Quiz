using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Model
{
    public class Quiz
    {
        private List<Question> questions = new List<Question>();



        public string Title { get; set;}

        public Quiz(string title) => Title = title;

        public int NumberOfQuestion => questions.Count;

        public void AddQuestion(Question q)
        {
            questions.Add(q);

        }

        public Question this[int n]
        {
            get => questions[n];
        }

    }
}
