using JoseTFG.Models;
using System.Collections.Generic;

namespace JoseTFG.Data
{
    class EpocQuestion
    {
        public static List<QuestionOneSolution> getEpocSurvey()
        {
            List<QuestionOneSolution> survey = new List<QuestionOneSolution>();
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            return survey;
        }
    }
}