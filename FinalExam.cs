
using System.Diagnostics;

namespace Exam_System_01
{
        #region Construtor
    internal class FinalExam : BaseExam
    {
        public FinalExam(int examTime, int numberOfQuestions)
            : base(examTime, numberOfQuestions)
        {
        } 
        #endregion

        #region Show Exam Override
        public override void ShowExam()
        {
            Console.WriteLine("Final Exam");

            var stopwatch = Stopwatch.StartNew();

            var studentAnswers = ConductExam();

            stopwatch.Stop();

            Console.WriteLine();
            try
            {
                Console.Clear();
            }
            catch
            { 
            }
            Console.WriteLine("Final Exam Results:");

            decimal Grade = 0;
            decimal Total = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                var T = Questions[i];

                var Chosen = studentAnswers[i];

                Console.WriteLine($"Question {i + 1}: {T.Body}");

                Console.WriteLine($"Your Answer => {Chosen.AnswerName}");

                Console.WriteLine($"Correct Answer => {T.RightAnswer.AnswerName}");

                Console.WriteLine();

                Total += T.Mark;

                if (Chosen.AnswerId == T.RightAnswer.AnswerId)
                {
                    Grade += T.Mark;
                }
            }

            Console.WriteLine($"Your Grade is {Grade} from {Total}");

            Console.WriteLine($"Time = {stopwatch.Elapsed}");

            Console.WriteLine("Thank you");
        } 
        #endregion
    }

}

