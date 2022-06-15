namespace JoseTFG.Models
{
    class QuestionOneSolution : Question
    {
        public int AnswerPosition { get; set; }

        public int PositiveScore { get; }

        public QuestionOneSolution(bool noAnswer, int positiveScore) : base(noAnswer)
        {
            this.AnswerPosition = -1;
            this.PositiveScore = positiveScore;
        }

        public int getPunctuation()
        {
            return this.AnswerPosition >= this.PositiveScore ? 1 : 0;
        }
    }
}