namespace JoseTFG.Models
{
    class Question
    {
        public bool NoAnswer { get; set; }

        public Question(bool noAnswer)
        {
            this.NoAnswer = noAnswer;
        }
    }
}