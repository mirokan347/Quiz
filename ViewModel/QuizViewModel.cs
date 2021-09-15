using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.IO;

namespace Quiz.ViewModel
{
    using Quiz.Model;
    using BaseClass;
    class QuizViewModel : BaseViewModel
    {
 
        private int current_question = 0;
        //public Quiz quiz;

        private ICommand windowsLoaded;

        public ICommand WindowsLoaded => windowsLoaded ??= new RelayCommand(
            (p) =>
                {
                    //quiz.AddQuestion(Question);
                    onPropertyChanged("Quizlist", "quiz");

                },
            p => true
            );

        private ICommand quizSelectionChanged;
        public ICommand QuizSelecionChanged => quizSelectionChanged ??= new RelayCommand(
            (p) =>
            {
                onPropertyChanged("quizlist", "quiz");
            },
            p => true


            ); 

        private List<Quiz> quizlist = new List<Quiz>();
        private RelayCommand prev_question;
        private RelayCommand next_question;
        private int current_quiz;

        public List<Quiz> QuizList
        {
            get => quizlist;
        }
        public QuizViewModel()
        {

        string[] files = Directory.GetFiles(".", "*.txt");

            foreach (string file in files)
            {
                Quiz quiz = Load.Load_from_file(file);
                quizlist.Add(quiz);
            }


        }

        public ICommand Prev_Question => prev_question ??= new RelayCommand(
            (p) =>
            {
                    Current_question -= 1;
                    onPropertyChanged(nameof(Number_question),nameof(title_question), nameof(Answer));
            },
            (p) => Current_question > 0 
 
            );
        public ICommand Next_Question => next_question ??= new RelayCommand(
            (p) =>
            {
                    Current_question += 1;
                    onPropertyChanged(nameof(Number_question), nameof(title_question),nameof(Answer));
            },
            (p) => Current_question < quizlist[current_quiz].NumberOfQuestion-1

            );


        public string current_quest
        {
            get
            {
                if (quizlist.Count > 0)
                {
                    return quizlist[current_quiz][Current_question][0].Content;
                    //return quizlist.Count.ToString();
                }
                else
                {
                    return "Brak quizów";
                }
            }

        }

        public string title_question
        {
            get
            {
                return quizlist[current_quiz][Current_question].Content;

            }
        }

        public int Current_question { get => current_question; set => current_question = value; }

        public string Number_question { get => (current_question +1).ToString()+".";  }

        public List<string> Answer { 
            get
            {
                List<string> answer = new List<string>() { quizlist[current_quiz][Current_question][0].Content,
                quizlist[current_quiz][Current_question][1].Content,
                quizlist[current_quiz][Current_question][2].Content,
                quizlist[current_quiz][Current_question][3].Content,
                };
                return answer;
            }

            }
        public int checkedAnswer
        {
            get {return quizlist[current_quiz][Current_question].CheckAnswer; }

            set { quizlist[current_quiz][Current_question].CheckAnswer = value;
                    onPropertyChanged(nameof(checkedAnswer));
            }
        }
        
    }


}
