using System;
using System.IO;

namespace Quiz.Model
{ 

public class Load
{
		public static Quiz Load_from_file(string file)
		{
			if (File.Exists(file))
			{
				string[] lines = File.ReadAllLines(file);
				string title = file.Substring(2,file.Length-6);

				Quiz quiz = new Quiz(title);

                foreach (var line in lines)
			
				{
					var quizline = line.Split(';');
					Question question = new Question(quizline[0]);
					
					for (int i = 1; i < 5; i++)
                    {
						bool correct = quizline[5] == $"{i}";
						Answer answer = new Answer(quizline[i], correct);
						question.AddAnswer(answer);						
					}
					quiz.AddQuestion(question);
				}
				return quiz;
			}
			return null;
			
		}
	}
}
