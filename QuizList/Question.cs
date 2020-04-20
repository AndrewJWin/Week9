using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**********************************\
*                                  *
* Andrew Terwilliger 4/20/2020     *
* Minneapolis College              *
* ITEC 2505-60 C# Programming      *
*                                  *
\**********************************/

namespace Week9
{
    /*
     * Question Class. Model for a Quiz question that has multiple values and a CorrectQuestion value.
     * 
     * Constructor takes in string questionText - Being the question being asked.
     * A string correctAnswer - Being the correct answer for the question.
     * A list wrongAnswers - Being a list of incorrect answers.
     * 
     */
    internal class Question
    {
        // Constructor, taking in questionText, correctAnswer and wrongAnswers.
        public Question(string questionText, string correctAnswer, List<string> wrongAnswers)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
        }

        // Class Members, viewing the following values: QuestionText, CorrectAnswer and WrongAnswers
        public string QuestionText { get; }
        public string CorrectAnswer { get; }
        public List<string> WrongAnswers { get; }

        // This member makes a new List, adds the correct answer and incorrect answers to it - Then shuffles before returning the List.
        public List<string> AllAnswers {  get
            {
                List<string> allAnswers = new List<string>();
                allAnswers.Add(CorrectAnswer);
                allAnswers.AddRange(WrongAnswers);

                Random random = new Random();

                List<string> shuffledAnswers = new List<string>();

                while (allAnswers.Count > 0)
                {
                    int index = random.Next(allAnswers.Count);

                    string answer = allAnswers[index];

                    allAnswers.RemoveAt(index);

                    int insertIndex = random.Next(shuffledAnswers.Count);

                    shuffledAnswers.Insert(insertIndex, answer);
                }

                return shuffledAnswers;
            } 
        }
    }
}
