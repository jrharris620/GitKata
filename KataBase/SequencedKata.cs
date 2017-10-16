﻿using System;
using System.Diagnostics;

namespace KataBase
{
    public class SequencedKata : Kata
    {
        private int _index = 0;
        public SequencedKata(params Question[] questions) : base(questions)
        {
        }

        public decimal Grade => AnswerQueue.Grade;

        public override bool ShouldContinue
        {
            get { return AnswerQueue.Count < Questions.Count || AnswerQueue.Grade < MinimumGrade; }
        }

        public override Question AnswerQuestionAndGetNext(string answer)
        {
            var isCorrect = Questions[_index].DesiredAnswer == answer;
            if (isCorrect)
            {
                var correctResponses = new[] {"Nice!", "Good work", "Keep it up"};
                Console.WriteLine(correctResponses.GetRandom());
                //execute and pipe output to the user
//                ProcessStartInfo start = new ProcessStartInfo();
//                start.FileName = "cmd";
//                start.WorkingDirectory = Environment.CurrentDirectory;
//                start.Arguments = answer;
//                start.UseShellExecute = false;
//                start.RedirectStandardOutput = true;
//              
//                start.RedirectStandardInput = true;
//                start.CreateNoWindow = true;
//                Process.Start(start);
            }
            else
            {
                Console.WriteLine("Errr..  Try again please");
            }
            AnswerQueue.Enqueue(new TrueFalseAnswer(isCorrect));
            
            if (isCorrect)
            {
                _index++;
                if (_index >= Questions.Count) { _index = 0; }
                
            }
            return Questions[_index];
        }

        public override Question GetFirstQuestion()
        {
            if (Questions.Count == 0) return null;
            return Questions[0];
        }
    }
}