using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataBase;

namespace GitKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Git Kata!");
            var questions = new List<Question>
            {
                new Question
                {
                    Text =  "First we need to make a directory name 'test'",
                    DesiredAnswer = "mkdir test"
                },
                new Question
                {
                    Text= "Now we need to change into that directory",
                    DesiredAnswer = "cd test"
                }
            };
            var kata = new SequencedKata(questions.ToArray());
            var ques = kata.GetFirstQuestion();
            while (kata.ShouldContinue)
            {
                Console.WriteLine("[{0}] {1}", kata.Grade , ques.Text);
                var ans = Console.ReadLine();
                ques =  kata.AnswerQuestionAndGetNext(ans);

            }

            Console.WriteLine("Congratulations, you've defeated me.  Press enter to quit");
            Console.ReadLine();
        }
    }
}
