using System;
using System.Collections.Generic;

namespace JoseTFG.Models
{
    class QuestionOneSolution : Question
    {
        public int AnswerPosition { get; set; }

        public QuestionOneSolution(String title, List<String> options, bool noAnswer) : base(title, options, noAnswer)
        {
            this.AnswerPosition = -1;
        }

    }
}