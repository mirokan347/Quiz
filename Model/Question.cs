using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Model
{
    public class Question
    {
        private List<Answer> answers = new List<Answer>();

        public string Content { get; set; }

        public Question(string content) => Content = content;

        public void AddAnswer(Answer a) 
            { 
                answers.Add(a);
            }

    }
}
