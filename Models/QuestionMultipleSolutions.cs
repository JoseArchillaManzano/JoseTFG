using System;
using System.Collections.Generic;

namespace JoseTFG.Models
{
    class QuestionMultipleSolutions : Question
    {
        public List<Boolean> Answers { get; set; } = new List<bool>();

        private void AddAnswer(int position, bool answer)
        {
            this.Answers[position] = answer;
        }

        public QuestionMultipleSolutions(String title, List<String> options, bool noAnswer) : base(title, options, noAnswer) { }
    }
}