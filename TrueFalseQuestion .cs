
namespace Exam_System_01
{
    #region Constructor
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, decimal mark)
            : base(header, body, mark)
        {
            Answers = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };
        }
    #endregion

        #region Override
        public override string QuestionTypeLabel => "True | False ";

        #endregion
    }
}


