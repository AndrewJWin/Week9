using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**********************************\
*                                  *
* Andrew Terwilliger 4/20/2020     *
* Minneapolis College              *
* ITEC 2505-60 C# Programming      *
*                                  *
\**********************************/

namespace Week9
{
    public partial class QuizForm : Form
    {
        // Form lists, Radio buttons and Questions - Makes it easier to run through with loops.
        private List<RadioButton> QuizRadioButtons;
        private List<Question> QuizQuestions;
        
        // Form integers, keeping track of the current Question number and the final Score.
        private int CurrentQuestionNumber = 0;
        private int Score = 0;
        
        // QuizForm initialization method, adds the radio buttons and questions to their respective lists.
        public QuizForm()
        {
            InitializeComponent();

            QuizRadioButtons = new List<RadioButton> { radioButton1, radioButton2, radioButton3, radioButton4 };

            Question q1 = new Question("What is the closest planet to the sun?", "Mercury", new List<string> { "Venus", "Mars", "Earth" });
            Question q2 = new Question("What is the Capital of Norway?", "Oslo", new List<string> { "Bergen", "Hamar", "Arendal" });
            Question q3 = new Question("What is the airspeed velocity of an Unladen Swallow", "10 m/s", new List<string> { "7.44 m/s", "8.5 m/s", "I don't know that!" });

            QuizQuestions = new List<Question> { q1, q2, q3 };
        }

        // QuizForm loading method, displays the first question and disables the next button and focuses the Check button.
        private void QuizForm_Load(object sender, EventArgs e)
        {
            DisplayQuestion(0);
            btnNext.Enabled = false;
            btnCheck.Focus();
        }

        // DisplayQuesiton method, takes in an integer and displays the question in the List under that index integer.
        private void DisplayQuestion(int questionIndex)
        {
            Question question = QuizQuestions[questionIndex];

            // List of answers using the Classes Method.
            List<string> answers = question.AllAnswers;

            // Setting all RadioButtons as unchecked.
            foreach (RadioButton rb in QuizRadioButtons)
            {
                rb.Checked = false;
            }

            // Setting the result as unknown.
            lblResult.Text = "??";


            // Setting each RadioButton text as a possible answer.
            for (int a = 0; a < answers.Count; a++)
            {
                QuizRadioButtons[a].Text = answers[a];
            }

            // Finally setting the question text.
            lblQuestion.Text = question.QuestionText;
        }

        // Check button method, makes sure that the user has selected an answer and check if it's correct or not.
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Pull the current question, so we can pull the correct answer.
            Question currentQuestion = QuizQuestions[CurrentQuestionNumber];

            // Null string for the users Answer.
            string userAnswer = null;

            // For each of the RadioButtons, check if the answer is selected.
            foreach (RadioButton rb in QuizRadioButtons)
            {
                // If a button is checked, set the user's answer to it's text.
                if (rb.Checked == true)
                {
                    userAnswer = rb.Text;
                }
            }

            // If the user hasn't selected an answer - Respond accordingly.
            if (userAnswer == null)
            {
                MessageBox.Show("Please select an answer", "Select an Answer");
                return;
            }

            // Checking if the selected answer is correct - If so, add to the current Score and Question number.
            if (userAnswer == currentQuestion.CorrectAnswer)
            {
                lblResult.Text = $"Correct! The answer was; {currentQuestion.CorrectAnswer}.";
                Score++;
                CurrentQuestionNumber++;
                btnNext.Enabled = true;
                return;
            } else
            // Elsewise, respond accordingly and add to the current Question number.
            {
                lblResult.Text = $"Incorrect! The correct answer was; {currentQuestion.CorrectAnswer}";
                CurrentQuestionNumber++;
                btnNext.Enabled = true;
                return;
            }
        }

        // Next button method, changes the current question and if the quiz is over - Posts the users score.
        private void btnNext_Click(object sender, EventArgs e)
        {
            // If it's not last question. Go to the next question.
            if (CurrentQuestionNumber < QuizQuestions.Count)
            {
                DisplayQuestion(CurrentQuestionNumber);
                btnNext.Enabled = false;
                return;
            } else
            // Elsewise, build a string telling the user that the Quiz is over and their final score.
            {
                StringBuilder Result = new StringBuilder();
                btnCheck.Enabled = false;
                btnNext.Enabled = false;

                lblResult.Text = "Quiz over!";
                lblQuestion.Text = "Quiz over!";

                Result.Append("Quiz Over!").Append($"\nScore: {Score}");

                MessageBox.Show(Result.ToString(), "Quiz Over");

                // Close the quiz.
                this.Close();
            }
        }
    }
}
