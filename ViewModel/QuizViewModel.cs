using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;


namespace Quiz.ViewModel
{
    using Quiz.Model;
    using BaseClass;
    class QuizViewModel: BaseViewModel
    {
        public int checkedAnswer;

        public Quiz quiz;

        public int CheckedAnswer
        {
            get => checkedAnswer;
            set { 
                checkedAnswer = value;
                onPropertyChanged(nameof(CheckedAnswer));
            }
        }

        private ICommand windowsLoaded;

        //public ICommand WindowsLoaded =>
        
        public QuizViewModel()
        {

                quiz = Load.load_from_file("quiz1.txt");   

        }

       
    }

    
}
