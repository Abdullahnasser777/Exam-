
namespace Exam_System_01
{
    internal class Subject
    {
        #region Properties
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public BaseExam SubjectExam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        #endregion

        #region Constructor
        public BaseExam CreateExam(ExamType examType, int examTime, int numberOfQuestions)
        {
            SubjectExam =  examType == ExamType.Practical ? new PracticalExam(examTime, numberOfQuestions) : new FinalExam(examTime, numberOfQuestions);

            return SubjectExam;
        }
        #endregion

        #region ToString Override
        public override string ToString()
        {
            return $"Subject: {SubjectName} (Id: {SubjectId})";
        }
        #endregion
    }

}

