using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoseTFG.Models
{
    class QuestionOneSolution : Question
    {
        int AnswerPosition { get; set; }

        public QuestionOneSolution(String title, List<String> options, bool noAnswer) : base(title, options, noAnswer) { }

    }
}