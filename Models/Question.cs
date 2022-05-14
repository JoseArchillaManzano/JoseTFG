namespace JoseTFG.Models
{
    class Question
    {
        //public String Title { get; set; }

        //public List<String> Options { get; set; }

        public bool NoAnswer { get; set; }

        /* public void addOption(String option)
         {
             this.Options.Add(option);
         }*/

        /* public Question(String title, List<String> options, bool noAnswer)
         {
             this.Title = title;
             this.Options = new List<string>(options);
             this.NoAnswer = noAnswer;
         }*/

        public Question(bool noAnswer)
        {
            this.NoAnswer = noAnswer;
        }
    }
}