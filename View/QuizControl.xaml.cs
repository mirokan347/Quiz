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
            if(quizControl != null)
            {
                //mechanizm przestawiania zaznaczenia w yniku zmian w viewMOdel
                quizControl.rb_1.IsChecked = true;
            }

            throw new NotImplementedException();
        }

        public int CheckedAnswer
        {

            get { return (int)GetValue(checkedAnswerDP); }
            set { SetValue(checkedAnswerDP, value); }

        }

        public void rb_Checked (object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton checkedRB && int.TryParse(checkedRB.Tag.ToString(), out int number))
            {
                CheckedAnswer = number;

            }


        }

    }
}
