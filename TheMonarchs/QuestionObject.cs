using System.Collections.Generic;

namespace TheMonarchs
{
    public static class Question
    {
        public static List<QuestionObject> GetQuestions()
        {
            return new List<QuestionObject>()
            {
                new QuestionObject
                {
                    Identifier = "a",
                    Question = "How many monarchs are there in the list?",
                    Endpoint = "monarch/count"
                },
                new QuestionObject
                {
                    Identifier = "b",
                    Question = "Which monarch ruled the longest and for how long?",
                    Endpoint = "monarch/longestMonarchRuled"
                },
                new QuestionObject
                {
                    Identifier = "c",
                    Question = "Which house ruled the longest and for how long?",
                    Endpoint = "monarch/longestHouseRuled"
                },
                new QuestionObject
                {
                    Identifier = "d",
                    Question = "What was the most common first name?",
                    Endpoint = "monarch/mostcommonname"
                }
            };
        }

    }

    public class QuestionObject
    {
        public string Identifier { get; set; }

        public string Question { get; set; }

        public string Endpoint { get; set; }
    }
}
