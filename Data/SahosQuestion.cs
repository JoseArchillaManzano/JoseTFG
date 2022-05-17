using JoseTFG.Models;
using System.Collections.Generic;

namespace JoseTFG.Data
{
    class SahosQuestion
    {
        public static List<QuestionOneSolution> getSahosSurvey()
        {
            List<QuestionOneSolution> survey = new List<QuestionOneSolution>();
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(true, 2));
            survey.Add(new QuestionOneSolution(true, 3));
            survey.Add(new QuestionOneSolution(true, 1));
            survey.Add(new QuestionOneSolution(true, 3));
            survey.Add(new QuestionOneSolution(false, 3));
            survey.Add(new QuestionOneSolution(false, 3));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(true, 3));
            survey.Add(new QuestionOneSolution(false, 1));
            survey.Add(new QuestionOneSolution(false, 1));
            return survey;

        }
    }
}