using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Model
{
    public class Answer
    {
        public bool Value { get; set; }

        public string Content { get; set; }

        public Answer(string content, bool value)
        {
            Content = content;
            Value = value;
        }

    }
}
