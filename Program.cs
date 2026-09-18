using Exam_System_01;
internal class Program
{
    static void Main(string[] args)
    {

        Subject subject = new Subject(1, "OOP");

        #region Comment
        // The Header Wes Not Used Based On The Video Sent To Us To Match Whst Was Implementted In The Video
        // A Separate Helper Class Name (Check) Was Implemneted Beyond The Exam Requirements To Manage Exception Hendling And Validate User Input
        #endregion

        #region Exam Setup 
        int examTypeInput = Check.ReadPositveInt("Enter the type of exam (1 for Practical, 2 for Final): ");
        while (examTypeInput < 1 || examTypeInput > 2)
        {
            Console.WriteLine("Invalid input! Please enter 1 or 2.");
            examTypeInput = Check.ReadPositveInt("Enter the type of exam (1 for Practical, 2 for Final): ");
        }
        ExamType examType = (ExamType)examTypeInput;

        int examTime = Check.ReadPositveInt("Please enter the time for the exam (30 to 180 minutes): ");
        while (examTime < 30 || examTime > 180)
        {
            Console.WriteLine("Invalid input! Please enter a value between 30 and 180.");
            examTime = Check.ReadPositveInt("Please enter the time for the exam (30 to 180 minutes): ");
        }

        int numberOfQuestions = Check.ReadPositveInt("Please enter the number of questions: ");

        BaseExam exam = subject.CreateExam(examType, examTime, numberOfQuestions);
        #endregion
        Console.Clear();

        #region Question Creation
        for (int i = 1; i <= numberOfQuestions; i++)
        {
            int questionType = 1;

            if (examType == ExamType.Final)
            {
                try
                {
                    Console.Clear();
                }
                catch
                {
                }
                Console.WriteLine($"Enter details for question {i}:");

                questionType = Check.ReadPositveInt("Choose question type: 1 for MCQ, 2 for True/False: ");
                while (questionType < 1 || questionType > 2)
                {
                    Console.WriteLine("Invalid input! Please enter 1 or 2.");
                    questionType = Check.ReadPositveInt("Choose question type: 1 for MCQ, 2 for True/False: ");
                }
            }
            try
            {
                Console.Clear();
            }
            catch
            {
            }
            string body = Check.ReadNonEmptyString("Please enter the question body: ");

            decimal mark = Check.ReadPositiveDecimal("Please enter the question mark: ");
            while (mark < 0 || mark > 100)
            {
                Console.WriteLine("Invalid mark! Please enter a value between 0 and 100.");
                mark = Check.ReadPositiveDecimal("Please enter the question mark: ");
            }

            Question question;

            if (questionType == 1)
            {
                question = new MCQQuestion("", body, mark);

                Console.WriteLine("Choices of Question:");

                for (int c = 1; c <= 4; c++)
                {
                    string choiceText = Check.ReadNonEmptyString($"Please enter choice number {c}: ");
                    question.Answers[c - 1] = new Answer(c, choiceText);
                }

                int rightId = Check.ReadPositveInt("Please enter the ID of the correct answer (1 to 4): ");
                while (rightId < 1 || rightId > 4)
                {
                    Console.WriteLine("Invalid input! Please enter a value between 1 and 4.");
                    rightId = Check.ReadPositveInt("Please enter the ID of the correct answer (1 to 4): ");
                }

                question.RightAnswer = question.Answers.FirstOrDefault(a => a.AnswerId == rightId)!;
            }
            else
            {
                question = new TrueFalseQuestion("", body, mark);

                int rightId = Check.ReadPositveInt("Please enter the ID of the correct answer (1 OR Y True, 2 OR N False): ");
                while (rightId < 1 || rightId > 2)
                {
                    Console.WriteLine("Invalid input! Please enter 1 OR Y or 2 OR N .");
                    rightId = Check.ReadPositveInt("Please enter the ID of the correct answer (1 OR Y True, 2 OR N False): ");
                }

                question.RightAnswer = question.Answers.FirstOrDefault(a => a.AnswerId == rightId)!;
            }

            exam.Questions.Add(question);
        }
        #endregion

        Console.Clear();
        #region Start Exam 
        string startChoice = Check.ReadNonEmptyString("Do You Want To Start Exam ({1 (OR) Y}, {2 (OR) N}): ")!.Trim().ToUpper();
        while (startChoice != "Y" && startChoice != "1" && startChoice != "N" && startChoice != "2")
        {
            Console.WriteLine("Invalid input! Please enter 1 OR Y OR 2 OR N.");
            startChoice = Check.ReadNonEmptyString("Do You Want To Start Exam ({1 (OR) Y}, {2 (OR) N}): ")!.Trim().ToUpper();
        }
        Console.Clear();

        if (startChoice == "Y" || startChoice == "1")
        {
            exam.ShowExam();
        }
        else
        {
            Console.WriteLine("Thank you");
        }
        #endregion
    }
}








