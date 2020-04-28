using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Objects
{
    class Question
    {
        // Constructor. Notice can use default parameters, similar to methods 
        public Question(string questionText, string correctAnswer, List<String> wrongAnswers, int points = 1)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
            Points = points;
        }

        // Internal variables for validating points
        int _points = 0;

        // Auto-Implemented Properties 
        public string UserAnswer { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> WrongAnswers { get; set; }
        public int Points { get { return _points;  }
            set
            {
                _points = PointParser(value);
            }
        }
        public bool Scored { get; set; } = false;  // An initial value 

        // Private parser, valiates the value provided, if it's negative it throws the exception error.
        private int PointParser(int _point)
        {
            if (_point < 0)
            {
                throw new System.ArgumentException("Points cannot be negative");
            }
            else return _point;
        }

        // Readonly Properties that compute return value from other data in the Question object 

        public bool IsCorrect
        {
            get
            {
                return UserAnswer == CorrectAnswer;
            }
        }

        public List<string> AllAnswers
        {
            get
            {
                // Returns all the possible answers (correct and wrong) in a random order 

                // Combine correct answer and wrong answer strings in a new List
                List<string> allAnswers = new List<string>();
                allAnswers.AddRange(WrongAnswers);
                allAnswers.Add(CorrectAnswer);

                // Create a random number generator 
                Random random = new Random();

                // Create a new empty list 
                List<String> shuffledAnswers = new List<String>();

                // Loop while there are answers to shuffle
                while (allAnswers.Count > 0)
                {
                    // Pick a random index in allAnswers
                    int index = random.Next(allAnswers.Count);

                    // Remove item at the random index
                    string answer = allAnswers[index];
                    allAnswers.RemoveAt(index);

                    // Pick a random index to insert the removed answer, into the shuffled list
                    int insertIndex = random.Next(shuffledAnswers.Count);
                    
                    // And Insert answer in the index
                    shuffledAnswers.Insert(insertIndex, answer);
                }
                return shuffledAnswers;
            }
        }
    }
}
