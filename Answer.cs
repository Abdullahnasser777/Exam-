
namespace Exam_System_01
{
    public class Answer
    {
        #region Properties
        public int AnswerId { get; set; }

        public string AnswerName { get; set; }

        public Answer(int answerId, string answerName)
        #endregion

        #region Constructor
        {
            AnswerId = answerId;
            AnswerName = answerName;
        }
        #endregion

        #region ToString Override
        public override string ToString()
        {
            return $"{AnswerId}- {AnswerName}";
        } 
        #endregion
    }

}

