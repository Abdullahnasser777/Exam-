using System.Threading.Channels;

namespace Exam_System_01
{
        #region Constructor
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, decimal Mark)
            : base(header, body, Mark)
        {
            Answers = new Answer[4];
        } 
        #endregion

        #region Show Exam Override
        
        public override string QuestionTypeLabel => "MCQ"; 
        #endregion

    }
}
