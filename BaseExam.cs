namespace Exam_System_01
{
    internal abstract class BaseExam : ICloneable, IComparable<BaseExam>
    {
        #region Properties
        public int ExamTime { get; set; }

        public int NumberOfQuestions { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        #endregion

        #region Constructor
        protected BaseExam(int examTime, int numberOfQuestions)
        {
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
        }
        #endregion

        #region Abstreact 
        public abstract void ShowExam();
        #endregion

        #region Conduct Exam Logic
        protected List<Answer> ConductExam()
        {
            var StudentAnswers = new List<Answer>();

            for (int i = 0; i < Questions.Count; i++)
            {
                var T = Questions[i];

                Console.WriteLine($"Question {i + 1}: {T.Body}");
                Console.WriteLine($"{T.QuestionTypeLabel} Question :   Mark {T.Mark}");

                foreach (var ans in T.Answers)
                {
                    Console.WriteLine(ans);
                }

                int ChoseID;
                Answer SelectedAnswer;

                Console.Write("Enter your answer ID: ");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out ChoseID))
                    {
                        Console.Write("Invalid input, please enter a number: ");
                        continue;
                    }
                    SelectedAnswer = T.Answers.FirstOrDefault(a => a.AnswerId == ChoseID)!;
                    if (SelectedAnswer == null)
                    {
                        Console.WriteLine($"Invalid Chose Please enter a Vaild ID :");
                        continue;
                    }
                    break;
                }
                StudentAnswers.Add(SelectedAnswer);
            }

            return StudentAnswers;
        }
        #endregion

        #region ICloneable Implementation 
        public object Clone()
        {
            var Clone = (BaseExam)this.MemberwiseClone();

            Clone.Questions = this.Questions
                .Select(a => (Question)a.Clone())
                .ToList();

            return Clone;
        }
        #endregion

        #region IComparable Implementation
        public int CompareTo(BaseExam? other)
        {
            if (other == null)
                return 1;

            return this.ExamTime.CompareTo(other.ExamTime);
        }
        #endregion

        #region ToString Override
        public override string ToString()
        {
            return $"Exam Time: {ExamTime} mins, Number of Questions: {NumberOfQuestions}";
        } 
        #endregion
    }


}
