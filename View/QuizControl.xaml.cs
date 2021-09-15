using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz.View
{
    /// <summary>
    /// Logika interakcji dla klasy QuizControl.xaml
    /// </summary>
    public partial class QuizControl : UserControl
    {
        public QuizControl()
        {
            InitializeComponent();
        }
        // 0 - brak zaznaczenia
        // 1,2,3,4 - zaznaczone odpowiedzi

        public static readonly DependencyProperty questionDP = DependencyProperty.Register(
            nameof(QuestionContent),
            typeof(string),
            typeof(QuizControl)
            );

        public string QuestionContent
        {
            get { return (string)GetValue(questionDP); }
            set { SetValue(questionDP, value); }
        }


        public static readonly DependencyProperty NumberQuestionDP = DependencyProperty.Register(
            nameof(NumberQuestion),
            typeof(string),
            typeof(QuizControl)
            );

        public List<string> AnswerButton
        {
            get { return (List<string>)GetValue(AnswerButtonDP); }
            set { SetValue(AnswerButtonDP, value); }
        }

        public static readonly DependencyProperty AnswerButtonDP = DependencyProperty.Register(
            nameof(AnswerButton),
            typeof(List<string>),
            typeof(QuizControl)
            );

        public string NumberQuestion
        {
            get { return (string)GetValue(NumberQuestionDP); }
            set { SetValue(NumberQuestionDP, value); }
        }


        public static readonly DependencyProperty checkedAnswerDP = DependencyProperty.Register(

            nameof(CheckedAnswer),
            typeof(int),
            typeof(QuizControl),
            new PropertyMetadata(new PropertyChangedCallback(CheckSelecion))
            );

        private static void CheckSelecion(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            QuizControl quizControl = d as QuizControl;

            // nowa ustawiona wartosc zaznaczenia e.NewValue
            // starą wartosc sprzed zmiany w e.Oldvalue
            if (quizControl != null)
            {
                switch (e.NewValue)
                {
                    case 0:
                        quizControl.rb_1.IsChecked = false;
                        quizControl.rb_2.IsChecked = false;
                        quizControl.rb_3.IsChecked = false;
                        quizControl.rb_4.IsChecked = false;
                        break;
                    case 1:
                        quizControl.rb_1.IsChecked = true;
                        break;
                    case 2:
                        quizControl.rb_2.IsChecked = true;
                        break;
                    case 3:
                        quizControl.rb_3.IsChecked = true;
                        break;
                    case 4:
                        quizControl.rb_4.IsChecked = true;
                        break;
                }
            }

        }

        public int CheckedAnswer
        {

            get { return (int)GetValue(checkedAnswerDP); }
            set { SetValue(checkedAnswerDP, value); }

        }

        //private void Rb_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (sender is RadioButton checkedRB && int.TryParse(checkedRB.Tag.ToString(), out int number))
        //    {
        //        CheckedAnswer = number;

        //    }


        //}

        private void rb_1_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton checkedRB && int.TryParse(checkedRB.Tag.ToString(), out int number))
            {
                CheckedAnswer = number;

            }
        }
    }
}
