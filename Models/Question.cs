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
    class Question
    {
        public String Title { get; set; }

        public List<String> Options { get; set; }

        public bool NoAnswer { get; set; }

        public void addOption(String option)
        {
            this.Options.Add(option);
        }

        public Question(String title, List<String> options, bool noAnswer)
        {
            this.Title = title;
            this.Options = new List<string>(options);
            this.NoAnswer = noAnswer;
        }
    }
}